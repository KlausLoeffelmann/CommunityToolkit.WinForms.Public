using CommunityToolkit.WinForms.AsyncSupport;
using System.Text;

namespace CommunityToolkit.WinForms.Controls.Tooling.Console;

/// <summary>
///  Represents a custom control that provides a console-like interface.
/// </summary>
public class ConsoleControl : RichTextBox
{
    private Color _currentTextColor;
    private CustomFontStyle _currentFontStyle;
    private FontSize _currentFontSize;
    private AsyncTaskQueue _taskQueue = new();
    private ConsoleControlTextWriter? _consoleOut;

    /// <summary>
    ///  Initializes a new instance of the <see cref="ConsoleControl"/> class.
    /// </summary>
    public ConsoleControl()
    {
        _currentTextColor = ForeColor;
        _currentFontStyle = CustomFontStyle.Normal;
        _currentFontSize = FontSize.Normal;
    }

    private class ConsoleControlTextWriter(ConsoleControl consoleControl) : TextWriter
    {
        private readonly ConsoleControl _consoleControl = consoleControl;

        public override Encoding Encoding => Encoding.UTF8;

        public override async void Write(char value)
        {
            try
            {
                await _consoleControl.WriteAsync(value.ToString());
            }
            catch (Exception)
            {
            }
        }
        public override async void Write(string? value)
        {
            if (value is null)
            {
                return;
            }

            try
            {
                await _consoleControl.WriteAsync(value);
            }
            catch (Exception)
            {
            }
        }
    }

    public TextWriter ConsoleOut 
        => _consoleOut ??= new ConsoleControlTextWriter(this);

    /// <summary>
    ///  Writes the specified text asynchronously to the console control.
    /// </summary>
    /// <param name="text">The text to write.</param>
    /// <param name="textColor">The color of the text. (Optional)</param>
    /// <param name="style">The font style of the text. (Optional)</param>
    /// <param name="size">The font size of the text. (Optional)</param>
    /// <param name="keepStyles">Indicates whether to keep the current text styles. (Optional)</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task WriteAsync(
        string text,
        Color? textColor = null,
        CustomFontStyle? style = null,
        FontSize? size = null,
        bool keepStyles = false)
    {
        await _taskQueue.EnqueueAsync(
            () => WriteInternalAsync(text, textColor, style, size, keepStyles));
    }

    public async Task WriteInternalAsync(
        string text,
        Color? textColor = null,
        CustomFontStyle? style = null,
        FontSize? size = null,
        bool keepStyles = false)
    {
        await Task.Run(() =>
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => ApplyText(text, textColor, style, size, keepStyles)));
            }
            else
            {
                ApplyText(text, textColor, style, size, keepStyles);
            }
        });
    }

    /// <summary>
    ///  Writes the specified text followed by a new line asynchronously to the console control.
    /// </summary>
    /// <param name="text">The text to write. (Optional)</param>
    /// <param name="textColor">The color of the text. (Optional)</param>
    /// <param name="style">The font style of the text. (Optional)</param>
    /// <param name="size">The font size of the text. (Optional)</param>
    /// <param name="keepStyles">Indicates whether to keep the current text styles. (Optional)</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task WriteLineAsync(
        string? text = null,
        Color? textColor = null,
        CustomFontStyle? style = null,
        FontSize? size = null,
        bool keepStyles = false)
    {
        await WriteAsync(
            (text ?? string.Empty) + Environment.NewLine, 
            textColor, 
            style, 
            size, 
            keepStyles);
    }

    /// <summary>
    ///  Resets the styles.
    /// </summary>
    /// <param name="resetStyles">Indicates whether to reset the text styles. (Optional)</param>
    public Task ResetStylesAsync()
        => _taskQueue.EnqueueAsync(
            () => InvokeAsync(
                () => ResetStyles()));

    /// <summary>
    ///  Cancels all pending Write/WriteLine/Style tasks and clears the console control.
    /// </summary>
    /// <returns></returns>
    public Task ResetAsync()
    {
        // We need to signal to end the task queue before clearing the control
        _taskQueue.Dispose();
        _taskQueue = new AsyncTaskQueue();

        return InvokeAsync(() => ClearControl(true));

    }

    /// <summary>
    ///  Sets the text styles for the console control.
    /// </summary>
    /// <param name="textColor">The color of the text. (Optional)</param>
    /// <param name="style">The font style of the text. (Optional)</param>
    /// <param name="size">The font size of the text. (Optional)</param>
    /// <param name="keepSetting">Indicates whether to keep the current text styles. (Optional)</param>
    public Task SetStyleAsync(
        Color? textColor = null,
        CustomFontStyle? style = null,
        FontSize? size = null,
        bool keepSetting = false) 
            => _taskQueue.EnqueueAsync(
                () => InvokeAsync(
                    () => ApplyStyles(textColor, style, size, keepSetting)));

    private void ApplyText(
        string text,
        Color? textColor,
        CustomFontStyle? style,
        FontSize? size,
        bool keepStyles)
    {
        ApplyStyles(textColor, style, size, keepStyles);
        AppendText(text);

        if (!keepStyles)
        {
            ResetStyles();
        }
    }

    private void ClearControl(bool resetStyles)
    {
        Clear();

        if (resetStyles)
        {
            ResetStyles();
        }
    }

    private void ApplyStyles(
        Color? textColor,
        CustomFontStyle? style,
        FontSize? size,
        bool keepStyles)
    {
        if (textColor.HasValue)
        {
            SelectionColor = textColor.Value;
            if (keepStyles)
            {
                _currentTextColor = textColor.Value;
            }
        }
        else
        {
            SelectionColor = _currentTextColor;
        }

        var fontStyle = ConvertToDrawingFontStyle(style ?? _currentFontStyle);
        var fontSize = ConvertToFontSize(size ?? _currentFontSize);

        SelectionFont = new Font(Font.FontFamily, fontSize, fontStyle);

        if (keepStyles)
        {
            _currentFontStyle = style ?? _currentFontStyle;
            _currentFontSize = size ?? _currentFontSize;
        }
    }

    private void ResetStyles()
    {
        _currentTextColor = ForeColor;
        _currentFontStyle = CustomFontStyle.Normal;
        _currentFontSize = FontSize.Normal;
        SelectionColor = _currentTextColor;
        SelectionFont = Font;
    }

    private static FontStyle ConvertToDrawingFontStyle(CustomFontStyle style) 
        => style switch
        {
            CustomFontStyle.Bold => FontStyle.Bold,
            CustomFontStyle.Italic => FontStyle.Italic,
            CustomFontStyle.Underline => FontStyle.Underline,
            CustomFontStyle.StrikeThrough => FontStyle.Strikeout,
            _ => FontStyle.Regular
        };

    private float ConvertToFontSize(FontSize size)
    {
        var baseSize = Font.Size;

        return size switch
        {
            FontSize.Smaller => baseSize - 2f,
            FontSize.Small => baseSize - 1f,
            FontSize.Larger => baseSize + 1f,
            FontSize.Large => baseSize + 2f,
            _ => baseSize,
        };
    }
}
