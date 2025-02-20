using CommunityToolkit.WinForms.Extensions;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
/// A panel that captures the underlying content, applies a milk-glass effect,
/// and renders waiting text on top.
/// </summary>
public class ContentFreezePanel : Panel
{
    private Bitmap? _frozenContent;
    private readonly SpinnerControl? _spinner;
    private CancellationTokenSource? _cancellationTokenSource;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentFreezePanel"/> class.
    /// </summary>
    public ContentFreezePanel()
    {
        DoubleBuffered = true;
        Visible = false;

        _spinner = new SpinnerControl
        {
            Visible = false,
        };

        Controls.Add(_spinner);
    }

    /// <summary>
    ///  Captures the content of the specified control and applies a milk-glass effect.
    /// </summary>
    /// <param name="source">
    ///  The control whose content should be captured. Typically your RichTextBox.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null.</exception>
    public async Task FreezeContent(Control source)
    {
        ArgumentNullException.ThrowIfNull(source);

        // Capture the source content.
        using Bitmap tempBmp = new(source.Width, source.Height);
        source.DrawToBitmap(tempBmp, new Rectangle(Point.Empty, source.Size));

        // Create a new bitmap and apply the milk-glass effect.
        Bitmap bmp = new(source.Width, source.Height);

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawImage(tempBmp, 0, 0);

            using SolidBrush overlay = new(Color.FromArgb(100, Color.Gray));
            g.FillRectangle(overlay, new Rectangle(Point.Empty, bmp.Size));
        }

        // Dispose any previous frozen content.
        _frozenContent?.Dispose();
        _frozenContent = bmp;

        // Show the spinner. We need to add the Spinner to the panel.
        // And also center it in the middle, but we cannot Dock it.
        _ = _spinner.EnsureNotNull();
        _spinner.BackColor = Color.Transparent;
        _spinner.EnsureNotNull().FontSize = (int)(Font.Size * 2);
        _spinner.EnsureNotNull().Visible = true;
        _spinner.EnsureNotNull().Location = new Point((Width - _spinner.Width) / 2, (Height - _spinner.Height) / 2);

        _cancellationTokenSource = new CancellationTokenSource();
        Visible = true;

        await _spinner.SpinAsync(_cancellationTokenSource.Token);
    }

    public void UnfreezeContent()
    {
        if (_cancellationTokenSource is null)
        {
            throw new InvalidOperationException("The content is not frozen.");
        }

        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
        _cancellationTokenSource = null;
        _spinner.EnsureNotNull();
        _spinner.Visible = false;
        Visible = false;
    }

    /// <summary>
    /// Paints the frozen content and the waiting text.
    /// </summary>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the frozen (milk-glassed) content if available.
        if (_frozenContent is not null)
        {
            e.Graphics.DrawImage(_frozenContent, 0, 0, Width, Height);
        }
    }

    /// <summary>
    /// Disposes of the resources used by the panel.
    /// </summary>
    /// <param name="disposing">
    /// <see langword="true"/> to release both managed and unmanaged resources;
    /// <see langword="false"/> to release only unmanaged resources.
    /// </param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _frozenContent?.Dispose();
        }

        base.Dispose(disposing);
    }
}
