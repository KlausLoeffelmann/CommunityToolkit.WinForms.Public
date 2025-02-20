using System.Reflection;

namespace CommunityToolkit.WinForms.FluentUI.Imaging;

/// <summary>
///  Represents an image file with support for Exif metadata properties.
/// </summary>
public class ImageFileInfo : FileSystemInfo
{
    /// <summary>
    ///  A lookup dictionary for Exif property names to associated properties in <see cref="ImageFileInfo"/>.
    /// </summary>
    internal static Dictionary<string, PropertyInfo> s_propertyLookUp;

    private readonly FileInfo _fileInfo;

    static ImageFileInfo()
    {
        ExifPropertyNameAttribute? currentAttribute = null;

        s_propertyLookUp = typeof(ImageFileInfo)
            .GetTypeInfo()
            .GetProperties()
            .Where(property =>
            {
                currentAttribute = property.GetCustomAttribute<ExifPropertyNameAttribute>();
                return currentAttribute is not null;
            })
            .ToDictionary(property => currentAttribute!.PropertyName);
    }

    /// <summary>
    ///  Initializes a new instance of the <see cref="ImageFileInfo"/> class for the specified file path.
    /// </summary>
    /// <param name="fileName">The full path to the image file.</param>
    public ImageFileInfo(string fileName) : this(new FileInfo(fileName))
    {
    }

    /// <summary>
    ///  Initializes a new instance of the <see cref="ImageFileInfo"/> class with a <see cref="FileInfo"/> object.
    /// </summary>
    /// <param name="fileInfo">A <see cref="FileInfo"/> object representing the file.</param>
    public ImageFileInfo(FileInfo fileInfo)
    {
        OriginalPath = fileInfo.FullName;
        FullPath = Path.GetFullPath(OriginalPath);

        _fileInfo = fileInfo;
    }

    /// <summary>
    ///  Copies the image file to the specified location.
    /// </summary>
    /// <param name="destinationFilename">The target file path.</param>
    /// <param name="overwrite">If true, overwrite the file if it exists.</param>
    public void CopyTo(string destinationFilename, bool overwrite = false)
        => _fileInfo.CopyTo(destinationFilename, overwrite);

    /// <summary>
    /// Gets the directory name of the image file.
    /// </summary>
    public string? DirectoryName => _fileInfo.DirectoryName;

    /// <summary>
    ///  Gets the file size, in bytes.
    /// </summary>
    public long Length => _fileInfo.Length;

    /// <inheritdoc/>
    public override bool Exists => _fileInfo.Exists;

    /// <inheritdoc/>
    public override string Name => _fileInfo.Name;

    /// <summary>
    ///  Gets the creation time of the image file.
    /// </summary>
    public DateTime CreatedTime => _fileInfo.CreationTime;

    /// <summary>
    ///  Asynchronously loads Exif metadata properties into this instance.
    /// </summary>
    /// <param name="object">An object associated with the update, for callback purposes.</param>
    /// <param name="UpdateUI">An optional action to update the UI after loading Exif information.</param>
    public async Task GetExifInfoAsync(object @object, Action<ImageFileInfo, object>? UpdateUI = null)
    {
        try
        {
            IDictionary<string, object>? imageProps = await this.GetImagePropertiesAsync();

            if (imageProps is not null)
            {
                foreach (var keyValuePair in imageProps)
                {
                    if (keyValuePair.Value is { } value)
                    {
                        var property = s_propertyLookUp[keyValuePair.Key];
                        var type = property.PropertyType;

                        property.SetValue(this, type switch
                        {
                            _ when type == typeof(uint?) => (uint)value,
                            _ when type.IsAssignableFrom(typeof(ushort?)) => (ushort)value,
                            _ when type.IsAssignableFrom(typeof(double?)) => (double)value,
                            _ when type.IsAssignableFrom(typeof(string)) => (string)value,
                            _ when type.IsAssignableFrom(typeof(byte?)) => (byte)value,
                            _ when type.IsAssignableFrom(typeof(DateTimeOffset?)) => (DateTimeOffset)value,
                            _ => value
                        });
                    }
                }
            }

            ExifInfoLoaded = true;

            UpdateUI?.Invoke(this, @object);
        }
        catch (Exception)
        {
            // Consider logging or handling exception based on requirements
        }
    }

    /// <summary>
    ///  A placeholder for asynchronously updating Exif metadata information.
    /// </summary>
    public async Task UpdateExIfInfoAsync()
    {
        await Task.Delay(0); // Placeholder for future implementation
    }

    /// <inheritdoc/>
    public override void Delete() => _fileInfo.Delete();

    /// <summary>
    ///  Indicates whether Exif metadata has been loaded.
    /// </summary>
    public bool ExifInfoLoaded { get; set; }

    [ExifPropertyName("System.Image.BitDepth")]
    public uint? BitDepth { get; set; }

    [ExifPropertyName("System.Photo.CameraManufacturer")]
    public string? CameraManufacturer { get; set; }

    [ExifPropertyName("System.Photo.CameraModel")]
    public string? CameraModel { get; set; }

    [ExifPropertyName("System.Image.Compression")]
    public ushort? Compression { get; set; }

    [ExifPropertyName("System.Photo.DateTaken")]
    public DateTimeOffset? DateTaken { get; set; }

    [ExifPropertyName("System.Photo.ExposureIndex")]
    public string? ExposureIndex { get; set; }

    [ExifPropertyName("System.Photo.FNumber")]
    public double? FNumber { get; set; }

    [ExifPropertyName("System.Photo.Flash")]
    public byte? Flash { get; set; }

    [ExifPropertyName("System.Photo.FocalLength")]
    public double? FocalLength { get; set; }

    [ExifPropertyName("System.Image.HorizontalResolution")]
    public double? HorizontalResolution { get; set; }

    [ExifPropertyName("System.Image.HorizontalSize")]
    public uint? HorizontalSize { get; set; }

    [ExifPropertyName("System.Photo.ISOSpeed")]
    public ushort? ISOSpeed { get; set; }

    [ExifPropertyName("System.Photo.LensModel")]
    public string? LensModel { get; set; }

    [ExifPropertyName("System.Photo.Orientation")]
    public ushort? Orientation { get; set; }

    [ExifPropertyName("System.Photo.Saturation")]
    public uint? Saturation { get; set; }

    [ExifPropertyName("System.Photo.ShutterSpeed")]
    public double? ShutterSpeed { get; set; }

    [ExifPropertyName("System.Image.VerticalResolution")]
    public double? VerticalResolution { get; set; }

    [ExifPropertyName("System.Image.VerticalSize")]
    public uint? VerticalSize { get; set; }

    private static readonly string[] s_imageExtensions =
    [
        ".bmp", ".gif", ".jpeg", ".jpg", ".png", ".tiff", ".tif",
        ".heic", ".raw", ".arw", ".nef", ".cr2", ".webp", ".avif"
    ];

    /// <summary>
    ///  Retrieves <see cref="ImageFileInfo"/> objects for all image files in a specified directory.
    /// </summary>
    /// <param name="directoryPath">The path to the directory to search.</param>
    /// <returns>An IEnumerable of <see cref="ImageFileInfo"/> objects representing the images found.</returns>
    public static IEnumerable<ImageFileInfo> GetImageFiles(string directoryPath) 
        => Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
            .Where(file => s_imageExtensions.Contains(Path.GetExtension(file).ToLower()))
            .Select(file => new ImageFileInfo(file));

    /// <summary>
    ///  Asynchronously retrieves <see cref="ImageFileInfo"/> objects for all image files in a specified directory as an async stream.
    /// </summary>
    /// <param name="directoryPath">The path to the directory to search.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An IAsyncEnumerable of <see cref="ImageFileInfo"/> objects representing the images found.</returns>
    public static async IAsyncEnumerable<ImageFileInfo> GetImageFilesAsync(
        string directoryPath,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var file in Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            if (s_imageExtensions.Contains(Path.GetExtension(file).ToLower()))
            {
                yield return new ImageFileInfo(file);
            }

            await Task.Yield();
        }
    }
}
