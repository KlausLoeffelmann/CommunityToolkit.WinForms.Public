using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.Storage;

namespace CommunityToolkit.WinForms.FluentUI.Imaging;

public static class ImageFileInfoExtensions
{
    private static readonly string[] s_photoProperties;

    static ImageFileInfoExtensions()
    {
        s_photoProperties = [.. ImageFileInfo.s_propertyLookUp.Keys];
    }

    public static async Task<IDictionary<string, object>> GetImagePropertiesAsync(this ImageFileInfo imageFile)
    {
        StorageFile file = await StorageFile.GetFileFromPathAsync(imageFile.FullName);

        // BMARK 60:
        var photoProps = await file.Properties.RetrievePropertiesAsync(s_photoProperties);

        return photoProps;
    }

    public static async Task<Bitmap> LoadImageAsync(
        this ImageFileInfo imageFileInfo, 
        SizeF? scaleTargetSize = default, 
        CancellationToken cancellation = default)
    {
        // Get the file and open it as a stream
        StorageFile file = await StorageFile.GetFileFromPathAsync(imageFileInfo.FullName);

        using IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
        cancellation.ThrowIfCancellationRequested();

        // BMARK 50:
        // We are using the Windows.Graphics.Imaging.BitmapDecoder to load the image file and return a Bitmap object.
        // This way, we are able to decode all the different formats supported by Windows - including RAW formats and HEIC!
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
        cancellation.ThrowIfCancellationRequested();

        // Set up transformation with scaling if scaleTargetSize is provided
        BitmapTransform transform = new();

        if (scaleTargetSize.HasValue)
        {
            // Calculate scale ratios based on target size
            float scaleX = scaleTargetSize.Value.Width / decoder.PixelWidth;
            float scaleY = scaleTargetSize.Value.Height / decoder.PixelHeight;

            // Use the smaller scale to maintain aspect ratio
            float scale = Math.Min(scaleX, scaleY);

            transform.ScaledWidth = (uint)(decoder.PixelWidth * scale);
            transform.ScaledHeight = (uint)(decoder.PixelHeight * scale);
        }
        else
        {
            // No scaling if no target size is specified
            transform.ScaledWidth = decoder.PixelWidth;
            transform.ScaledHeight = decoder.PixelHeight;
        }

        // 4. Get the pixel data with the transformation applied
        PixelDataProvider pixelProvider = await decoder.GetPixelDataAsync(
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied,
            transform,
            ExifOrientationMode.IgnoreExifOrientation,
            ColorManagementMode.DoNotColorManage);
        cancellation.ThrowIfCancellationRequested();

        // 5. Get the pixel data as a byte array
        byte[] pixels = pixelProvider.DetachPixelData();

        // 6. Create a Bitmap with the new scaled dimensions
        Bitmap bitmap = new(
            (int)transform.ScaledWidth,
            (int)transform.ScaledHeight,
            PixelFormat.Format32bppArgb);

        BitmapData bmpData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

        Marshal.Copy(
            pixels,
            0,
            bmpData.Scan0,
            pixels.Length);

        bitmap.UnlockBits(bmpData);

        return bitmap;
    }
}
