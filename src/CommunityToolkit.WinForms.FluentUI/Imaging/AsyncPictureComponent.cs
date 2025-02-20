using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Imaging;

public class AsyncPictureComponent : BindableComponent
{
    public event EventHandler? ImageFileInfoChanged;
    public event EventHandler? BitmapChanged;
    public event EventHandler? AutoLoadChanged;
    public event EventHandler? ExifDataLoaded;

    private ImageFileInfo? _imageFileInfo;
    private Bitmap? _bitmap;
    private bool _autoLoad = false;

    public AsyncPictureComponent() { }

    public AsyncPictureComponent(ImageFileInfo imageFileInfo)
    {
        ImageFileInfo = imageFileInfo;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(false)]
    [Description("Determines whether the image should be loaded automatically.")]
    [Category("Behavior")]
    public bool AutoLoad
    {
        get => _autoLoad;
        set
        {
            if (_autoLoad == value)
            {
                return;
            }

            _autoLoad = value;
            OnAutoLoadChanged();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Bitmap? Bitmap => _bitmap;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ImageFileInfo? ImageFileInfo
    {
        get => _imageFileInfo;
        set
        {
            if (_imageFileInfo == value)
            {
                return;
            }

            _imageFileInfo = value;
            OnImageFileInfoChanged();
        }
    }

    public async Task LoadImageAsync(CancellationToken cancellation = default)
    {
        if (ImageFileInfo is null)
        {
            return;
        }

        _bitmap = await ImageFileInfo.LoadImageAsync(cancellation: cancellation);
        OnBitmapChanged();
    }

    protected virtual async void OnImageFileInfoChanged()
    {
        ImageFileInfoChanged?.Invoke(this, EventArgs.Empty);

        Task bitmapLoaderTask = Task.CompletedTask;
        Task exifLoaderTask = Task.CompletedTask;

        if (AutoLoad && ImageFileInfo != null)
        {
            bitmapLoaderTask = ImageFileInfo
                .LoadImageAsync()
                .ContinueWith((bitmap) => 
                {
                    _bitmap = bitmap.Result;
                    OnBitmapChanged();
                });
        }

        if (ImageFileInfo != null)
        {
            exifLoaderTask = ImageFileInfo
                .GetExifInfoAsync(this)
                .ContinueWith((obj) =>
                {
                    OnExifDataLoaded();
                });
        }

        await Task.WhenAll(bitmapLoaderTask, exifLoaderTask);
    }

    protected virtual void OnAutoLoadChanged()
        => AutoLoadChanged?.Invoke(this, EventArgs.Empty);

    protected virtual void OnBitmapChanged()
        => BitmapChanged?.Invoke(this, EventArgs.Empty);

    protected virtual void OnExifDataLoaded()
        => ExifDataLoaded?.Invoke(this, EventArgs.Empty);
}
