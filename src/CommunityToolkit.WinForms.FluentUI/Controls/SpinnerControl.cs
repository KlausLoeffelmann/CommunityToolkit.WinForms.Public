using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Text;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
///  A control that displays a spinning animation using a special font.
/// </summary>
public class SpinnerControl : Label
{
    /// <summary>
    ///  Occurs when the <see cref="IsSpinning"/> property has changed.
    /// </summary>
    public event EventHandler? IsSpinningChanged;

    private const string BootFontPath = "Boot\\Fonts_EX";
    private const string FontFileName = "segoe_slboot_EX.ttf";

    // That's the whole magic, folks. It's amazingly simple!
    private static readonly char[] s_charParts = CharSequence(0xE052..0xE0CB);
    private static readonly string s_pausingCharPart = $"{s_charParts[24]}";

    private static PrivateFontCollection s_fontCollection = new();

    private bool _isSpinning;
    private CancellationTokenSource? _cancellationTokenSource;
    private TaskCompletionSource _initializedCompletion = new();

    /// <summary>
    ///  Initializes a new instance of the <see cref="SpinnerControl"/> class.
    /// </summary>
    public SpinnerControl()
    {
        DoubleBuffered = true;
        _isSpinning = false;

        LoadBootFontFromBootFolder();
    }

    // Starts the spinning animation asynchronously.
    public async Task SpinAsync(CancellationToken cancellationToken)
    {
        if (IsSpinning)
            return;

        int partCount;

        try
        {
            await _initializedCompletion.Task;
            partCount = 0;

            for (; ; )
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                // BMARK 01:
                // InvokeAsync in Action:
                // Now, this call could have come from whatever thread, so we need to
                // make sure that we're on the UI thread. But we're also won't to be
                // neither blocking for the invoking, nor do we want to block
                // "inside" the invoking. So we're using the "InvokeAsync" method
                // with the overload that takes a "Func<CancellationToken, ValueTask>".
                await InvokeAsync(DrawSpinnerPartAsync, cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            Text = s_pausingCharPart;
        }

        // This gets marshalled back to the UI thread...
        async ValueTask DrawSpinnerPartAsync(CancellationToken cancellationToken)
        {
            Text = $"{s_charParts[partCount++]}";
            partCount %= s_charParts.Length;

            try
            {
                // ...but is awaited "inside" of the invoking process.
                await Task.Delay(15, cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }

    private static char[] CharSequence(Range range)
        => Enumerable
        .Range(
            start: range.Start.Value,
            count: range.End.Value - range.Start.Value + 1)
        .Select(i => (char)i)
        .ToArray();

    /// <summary>
    ///  Loads the special boot font from the boot folder.
    /// </summary>
    private void LoadBootFontFromBootFolder()
    {
        string windowsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        string bootFolderPath = Path.Combine(windowsFolderPath, BootFontPath);
        s_fontCollection.AddFontFile(Path.Combine(bootFolderPath, FontFileName));
    }

    /// <summary>
    ///  Gets or sets a value indicating whether the spinner is spinning.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    public bool IsSpinning
    {
        get => _isSpinning;
        set
        {
            if (_isSpinning == value)
            {
                return;
            }

            _isSpinning = value;
            OnIsSpinningChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    ///  Raises the <see cref="IsSpinningChanged"/> event.
    /// </summary>
    /// <param name="e">The event data.</param>
    protected async virtual void OnIsSpinningChanged(EventArgs e)
    {
        IsSpinningChanged?.Invoke(this, e);

        if (_cancellationTokenSource is not null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
            Text = s_pausingCharPart;

            return;
        }

        _cancellationTokenSource = new CancellationTokenSource();
        await SpinAsync(_cancellationTokenSource.Token);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [AllowNull]
    public override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [AllowNull]
    public override Font Font
    {
        get => base.Font;
        set => base.Font = value;
    }

    public int FontSize
    {
        get => (int)Font.Size;
        set => Font = new Font(Font.FontFamily, value);
    }

    private bool ShouldSerializeFontSize() => FontSize != 12;

    protected override void OnCreateControl()
    {
        base.OnCreateControl();

        Font = new Font(s_fontCollection.Families[0], Font.Size + 2);
        ForeColor = SystemColors.ControlText;
        Text = s_pausingCharPart;
        AutoSize = true;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        _initializedCompletion.SetResult();
    }

    protected override void Dispose(bool disposing)
    {
        IsSpinning = false;
        base.Dispose(disposing);
    }

    internal object EnsureNull()
    {
        throw new NotImplementedException();
    }
}
