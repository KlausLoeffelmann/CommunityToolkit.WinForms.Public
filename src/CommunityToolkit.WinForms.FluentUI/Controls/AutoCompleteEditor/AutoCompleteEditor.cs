using CommunityToolkit.WinForms.AsyncSupport;
using CommunityToolkit.WinForms.Extensions;

using System.ComponentModel;

using Timer = System.Windows.Forms.Timer;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
///  A RichTextBox control with auto-complete and suggestion capabilities.
/// </summary>
/// <remarks>
///  <para>
///   This control extends the RichTextBox to provide auto-complete suggestions and command
///   sending functionality. It includes various properties to customize the behavior and
///   appearance of the suggestions.
///  </para>
///  <para>
///   The control uses a timer to manage the timing of suggestion requests and can display
///   an overlay panel to indicate waiting states.
///  </para>
///  <para>
///   <b>Note:</b> The <see cref="AcceptsTab"/> property is set to true by default, so the user can
///   use Tab and Enter to edit, but needs to use Ctrl+Tab to navigate out of the Editor, and
///   a Form's Default-Button cannot be triggered with Enter if a <see cref="AutoCompleteEditor"/>
///   has the focus.
///  </para>
/// </remarks>
public partial class AutoCompleteEditor : RichTextBox
{
    /// <summary>
    ///  Event triggered to request auto-complete suggestions asynchronously.
    /// </summary>
    public event AsyncEventHandler<AsyncRequestAutoCompleteSuggestionEventArgs>? AsyncRequestAutoCompleteSuggestion;

    /// <summary>
    ///  Event triggered to send commands asynchronously.
    /// </summary>
    public event AsyncEventHandler<AsyncSendCommandEventArgs>? AsyncSendCommand;

    private int _minCharsSuggestionRequestSensitivity = 5;
    private int _maxRemainingCharsSuggestionRequestSensitivity = 0;
    private float _minTimeSuggestionRequestSensitivity = 0;
    private int _minCharChangedBeforeNextTextReviewRequest = 60;
    private float _minTimeThresholdForNextTextReviewRequest = 4;

    private bool _allowExistingRemainingTextReplacement;
    private Color _standardEditColor;
    private Color _suggestionColor;
    private Color _autoCorrectionColor;
    private Color _correctionCandidateColor;

    private readonly Timer _suggestionTimer;
    private readonly Timer _clipboardCheckTimer;
    private TextSpan _currentSuggestion;
    private string _oldParagraph = string.Empty;

    private static readonly Color DefaultLightModeStandardEditColor = Color.Black;
    private static readonly Color DefaultDarkModeStandardEditColor = Color.White;
    private static readonly Color DefaultLightModeSuggestionColor = Color.Blue;
    private static readonly Color DefaultDarkModeSuggestionColor = Color.Gray;
    private static readonly Color DefaultLightModeAutoCorrectionColor = Color.Green;
    private static readonly Color DefaultDarkModeAutoCorrectionColor = Color.LightGreen;
    private static readonly Color DefaultLightModeCorrectionCandidateColor = Color.Red;
    private static readonly Color DefaultDarkModeCorrectionCandidateColor = Color.OrangeRed;
    private ContentFreezePanel _overlayPanel = null!;

    private bool _requestPromptSendButton;
    private bool _requestCopyToClipBoardButton;
    private bool _requestPasteFromClipboardButton;
    private bool _requestAddToLibraryButton;
    private bool _requestOpenLibraryButton;
    private ToolStrip? _commandStrip;

    private ToolStripButton? _sendButton;
    private ToolStripButton? _copyButton;
    private ToolStripButton? _pasteButton;
    private ToolStripButton? _addButton;
    private ToolStripButton? _openButton;

    /// <summary>
    ///  Initializes a new instance of the <see cref="AutoCompleteEditor"/> class.
    /// </summary>
    public AutoCompleteEditor()
    {
        _semanticKernel = new()
        {
            ModelId = "gpt-4o-mini-2024-07-18",
            MaxTokens = 4096
        };

        _suggestionTimer = new Timer();
        _suggestionTimer.Tick += SuggestionTimer_Tick;

        _clipboardCheckTimer = new Timer
        {
            Interval = 1000 // Check every second
        };
        _clipboardCheckTimer.Tick += ClipboardCheckTimer_Tick;
        _clipboardCheckTimer.Start();

        if (Application.IsDarkModeEnabled)
        {
            _standardEditColor = DefaultDarkModeStandardEditColor;
            _suggestionColor = DefaultDarkModeSuggestionColor;
            _autoCorrectionColor = DefaultDarkModeAutoCorrectionColor;
            _correctionCandidateColor = DefaultDarkModeCorrectionCandidateColor;
        }
        else
        {
            _standardEditColor = DefaultLightModeStandardEditColor;
            _suggestionColor = DefaultLightModeSuggestionColor;
            _autoCorrectionColor = DefaultLightModeAutoCorrectionColor;
            _correctionCandidateColor = DefaultLightModeCorrectionCandidateColor;
        }

        InitializeOverlay();
        AcceptsTab = true;
    }

    /// <summary>
    ///  Gets or sets the minimum character count to trigger suggestion request.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the minimum number of characters that must be typed before
    ///   a suggestion request is triggered.
    ///  </para>
    /// </remarks>
    [Description("Minimum character count to trigger suggestion request.")]
    [DefaultValue(5)]
    [Category("AI: prediction behavior")]
    public int MinPrecedingCharsSuggestionRequestSensitivity
    {
        get => _minCharsSuggestionRequestSensitivity;
        set
        {
            if (value < 5 || value > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Valid values are between 5 and 20.");
            }

            _minCharsSuggestionRequestSensitivity = value;
        }
    }

    /// <summary>
    ///  Gets or sets the maximum character count to trigger suggestion request.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the maximum number of characters that can remain before
    ///   a suggestion request is triggered.
    ///  </para>
    /// </remarks>
    [Description("Maximum character count to trigger suggestion request.")]
    [DefaultValue(10)]
    [Category("AI: prediction behavior")]
    public int MaxRemainingCharsSuggestionRequestSensitivity
    {
        get => _maxRemainingCharsSuggestionRequestSensitivity;
        set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Valid values are between 3 and 200.");
            }

            _maxRemainingCharsSuggestionRequestSensitivity = value;
        }
    }

    /// <summary>
    ///  Gets or sets the minimum character changes before the next text review request.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the minimum number of character changes that must occur
    ///   before the next text review request is triggered.
    ///  </para>
    /// </remarks>
    [DefaultValue(50)]
    [Category("AI: prediction behavior")]
    public int MinCharChangedBeforeNextTextReviewRequest
    {
        get => _minCharChangedBeforeNextTextReviewRequest;
        set => _minCharChangedBeforeNextTextReviewRequest = value;
    }

    /// <summary>
    ///  Gets or sets the minimum time threshold for the next text review request.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the minimum time in seconds that must pass before the next
    ///   text review request is triggered.
    ///  </para>
    /// </remarks>
    [DefaultValue(2f)]
    [Category("AI: prediction behavior")]
    public float MinTimeThresholdForNextTextReviewRequest
    {
        get => _minTimeThresholdForNextTextReviewRequest;
        set
        {
            if (_minTimeThresholdForNextTextReviewRequest == value)
            {
                return;
            }

            if (value < 2 || value > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Valid values are between 0 and 9 seconds.");
            }

            bool wasOff = _minTimeThresholdForNextTextReviewRequest == 0;
            _minTimeThresholdForNextTextReviewRequest = value;

            if (wasOff)
            {
                StartOrResetSuggestionTimer();
            }

            if (value == 0)
            {
                _suggestionTimer.Stop();
            }
            else
            {
                _suggestionTimer.Interval = (int)(value * 1000);
            }
        }
    }

    /// <summary>
    ///  Gets or sets the minimum time in seconds to trigger suggestion request.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the minimum time in seconds that must pass before a
    ///   suggestion request is triggered.
    ///  </para>
    /// </remarks>
    [Description("Minimum time in seconds to trigger suggestion request.")]
    [DefaultValue(0f)]
    [Category("AI: prediction behavior")]
    public float MinTimeSuggestionRequestSensitivity
    {
        get => _minTimeSuggestionRequestSensitivity;

        set
        {
            if (_minTimeSuggestionRequestSensitivity == value)
            {
                return;
            }

            if (value < 0 || value > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Valid values are between 0 and 9 seconds.");
            }

            bool wasOff = _minTimeSuggestionRequestSensitivity == 0;
            _minTimeSuggestionRequestSensitivity = value;

            if (wasOff)
            {
                StartOrResetSuggestionTimer();
            }

            if (value == 0)
            {
                _suggestionTimer.Stop();
            }
            else
            {
                _suggestionTimer.Interval = (int)(value * 1000);
            }
        }
    }

    /// <summary>
    ///  Gets or sets a value indicating whether to allow replacement of existing remaining text.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property determines whether the existing remaining text can be replaced by
    ///   the auto-complete suggestions.
    ///  </para>
    /// </remarks>
    [Description("Allow replacement of existing remaining text.")]
    [DefaultValue(false)]
    [Category("AI: prediction behavior")]
    public bool AllowExistingRemainingTextReplacement
    {
        get => _allowExistingRemainingTextReplacement;
        set => _allowExistingRemainingTextReplacement = value;
    }

    /// <summary>
    ///  Gets or sets the color for standard text editing.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the color used for standard text editing in the control.
    ///  </para>
    /// </remarks>
    [Description("Color for standard text editing.")]
    [Category("AI: Appearance")]
    public Color StandardEditColor
    {
        get => _standardEditColor;
        set => _standardEditColor = value;
    }

    /// <summary>
    ///  Gets or sets the color for suggestions.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the color used for displaying suggestions in the control.
    ///  </para>
    /// </remarks>
    [Description("Color for suggestions.")]
    [Category("AI: Appearance")]
    public Color SuggestionColor
    {
        get => _suggestionColor;
        set => _suggestionColor = value;
    }

    /// <summary>
    ///  Gets or sets the color for auto-corrections.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the color used for displaying auto-corrections in the control.
    ///  </para>
    /// </remarks>
    [Description("Color for auto-corrections.")]
    [Category("AI: Appearance")]
    public Color AutoCorrectionColor
    {
        get => _autoCorrectionColor;
        set => _autoCorrectionColor = value;
    }

    /// <summary>
    ///  Gets or sets the color for correction candidates.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the color used for displaying correction candidates in the
    ///   control.
    ///  </para>
    /// </remarks>
    [Description("Color for correction candidates.")]
    [Category("AI: Appearance")]
    public Color CorrectionCandidateColor
    {
        get => _correctionCandidateColor;
        set => _correctionCandidateColor = value;
    }

    [Description("Show the Prompt Send button.")]
    [DefaultValue(false)]
    [Category("AI: Command Strip")]
    public bool RequestPromptSendButton
    {
        get => _requestPromptSendButton;
        set
        {
            _requestPromptSendButton = value;
            if (_sendButton != null)
            {
                _sendButton.Visible = value;
            }
        }
    }

    [Description("Show the Copy to Clipboard button.")]
    [DefaultValue(false)]
    [Category("AI: Command Strip")]
    public bool RequestCopyToClipBoardButton
    {
        get => _requestCopyToClipBoardButton;
        set
        {
            _requestCopyToClipBoardButton = value;
            if (_copyButton != null)
            {
                _copyButton.Visible = value;
            }
        }
    }

    [Description("Show the Paste from Clipboard button.")]
    [DefaultValue(false)]
    [Category("AI: Command Strip")]
    public bool RequestPasteFromClipboardButton
    {
        get => _requestPasteFromClipboardButton;
        set
        {
            _requestPasteFromClipboardButton = value;
            if (_pasteButton != null)
            {
                _pasteButton.Visible = value && IsClipboardContentCompatible();
            }
        }
    }

    [Description("Show the Add to Library button.")]
    [DefaultValue(false)]
    [Category("AI: Command Strip")]
    public bool RequestAddToLibraryButton
    {
        get => _requestAddToLibraryButton;
        set
        {
            _requestAddToLibraryButton = value;
            if (_addButton != null)
            {
                _addButton.Visible = value;
            }
        }
    }

    [Description("Show the Open Library button.")]
    [DefaultValue(false)]
    [Category("AI: Command Strip")]
    public bool RequestOpenLibraryButton
    {
        get => _requestOpenLibraryButton;
        set
        {
            _requestOpenLibraryButton = value;
            if (_openButton != null)
            {
                _openButton.Visible = value;
            }
        }
    }

    [Description("Command strip for the editor. When you assign a ToolStrip here, " +
        "the AutoCompleteEditor takes over and controls the context-depending ToolStrip buttons.")]
    [Category("AI: Command Strip")]
    public ToolStrip? CommandStrip
    {
        get => _commandStrip;
        set
        {
            _commandStrip = value;
            SetupCommandStrip();
        }
    }

    private bool ShouldSerializeCommandStrip() => _commandStrip != null;

    private void ResetCommandStrip() => _commandStrip = null;

    /// <summary>
    ///  Determines whether the standard edit color should be serialized.
    /// </summary>
    /// <returns>
    ///  <c>true</c> if the standard edit color should be serialized; otherwise, <c>false</c>.
    /// </returns>
    private bool ShouldSerializeStandardEditColor()
    {
        return Application.IsDarkModeEnabled
            ? _standardEditColor != DefaultDarkModeStandardEditColor
            : _standardEditColor != DefaultLightModeStandardEditColor;
    }

    /// <summary>
    ///  Determines whether the suggestion color should be serialized.
    /// </summary>
    /// <returns>
    ///  <c>true</c> if the suggestion color should be serialized; otherwise, <c>false</c>.
    /// </returns>
    private bool ShouldSerializeSuggestionColor()
    {
        return Application.IsDarkModeEnabled
            ? _suggestionColor != DefaultDarkModeSuggestionColor
            : _suggestionColor != DefaultLightModeSuggestionColor;
    }

    /// <summary>
    ///  Determines whether the auto-correction color should be serialized.
    /// </summary>
    /// <returns>
    ///  <c>true</c> if the auto-correction color should be serialized; otherwise, <c>false</c>.
    /// </returns>
    private bool ShouldSerializeAutoCorrectionColor()
    {
        return Application.IsDarkModeEnabled
            ? _autoCorrectionColor != DefaultDarkModeAutoCorrectionColor
            : _autoCorrectionColor != DefaultLightModeAutoCorrectionColor;
    }

    /// <summary>
    ///  Determines whether the correction candidate color should be serialized.
    /// </summary>
    /// <returns>
    ///  <c>true</c> if the correction candidate color should be serialized; otherwise, <c>false</c>.
    /// </returns>
    private bool ShouldSerializeCorrectionCandidateColor()
    {
        return Application.IsDarkModeEnabled
            ? _correctionCandidateColor != DefaultDarkModeCorrectionCandidateColor
            : _correctionCandidateColor != DefaultLightModeCorrectionCandidateColor;
    }

    /// <summary>
    ///  Raises the <see cref="AsyncRequestAutoCompleteSuggestion"/> event.
    /// </summary>
    /// <param name="e">The event data.</param>
    protected virtual Task OnAsyncRequestAutoCompleteSuggestionAsync(AsyncRequestAutoCompleteSuggestionEventArgs e)
        => AsyncRequestAutoCompleteSuggestion?.Invoke(this, e) ?? Task.CompletedTask;

    /// <summary>
    ///  Raises the <see cref="Control.ReadOnlyChanged"/> event.
    /// </summary>
    /// <param name="e">The event data.</param>
    /// <remarks>
    ///  <para>
    ///   This method updates the background and foreground colors of the control based on
    ///   the read-only state and the application's dark mode setting.
    ///  </para>
    /// </remarks>
    protected override void OnReadOnlyChanged(EventArgs e)
    {
        base.OnReadOnlyChanged(e);

        if (ReadOnly)
        {
            if (Application.IsDarkModeEnabled)
            {
                BackColor = Color.FromArgb(30, 30, 30); // Dark mode background color for read-only
                ForeColor = Color.LightGray; // Dark mode text color for read-only
            }
            else
            {
                BackColor = Color.LightGray; // Light mode background color for read-only
                ForeColor = Color.DarkGray; // Light mode text color for read-only
            }
        }
        else
        {
            if (Application.IsDarkModeEnabled)
            {
                BackColor = Color.Black; // Dark mode background color for editable
                ForeColor = Color.White; // Dark mode text color for editable
            }
            else
            {
                BackColor = Color.White; // Light mode background color for editable
                ForeColor = Color.Black; // Light mode text color for editable
            }
        }
    }

    // We need to shadow AcceptsTab to change the default value to true.
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(true)]
    public new bool AcceptsTab
    {
        get => base.AcceptsTab;
        set => base.AcceptsTab = value;
    }

    /// <summary>
    ///  Initializes the overlay panel.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method sets up the overlay panel that is used to indicate waiting states.
    ///   The overlay panel is resized to match the size of the RichTextBox and is added
    ///   to the control's collection of child controls.
    ///  </para>
    /// </remarks>
    private void InitializeOverlay()
    {
        _overlayPanel = new ContentFreezePanel
        {
            Visible = false,
            Text = "Waiting...", // Text rendered by the control.
            Font = new Font(Font.FontFamily, Font.Size * 2, FontStyle.Bold),
            ForeColor = Color.White,
            // Resize the overlay panel to match the size of the RichTextBox
            Size = Size
        };

        // Add event handler to resize the overlay panel when the RichTextBox is resized
        SizeChanged += (sender, e) => _overlayPanel.Size = Size;

        Controls.Add(_overlayPanel);
    }

    /// <summary>
    ///  Ensures that the overlay panel is initialized.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method checks if the overlay panel is null and initializes it if necessary.
    ///  </para>
    /// </remarks>
    private void EnsureOverlayInitialized()
    {
        if (_overlayPanel is null)
        {
            InitializeOverlay();
        }
    }

    /// <summary>
    ///  Shows the overlay panel.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method makes the overlay panel visible and freezes the content of the
    ///   RichTextBox.
    ///  </para>
    /// </remarks>
    public async Task ShowOverlayAsync()
    {
        EnsureOverlayInitialized();
        await _overlayPanel.FreezeContent(this);
    }

    /// <summary>
    ///  Hides the overlay panel.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method hides the overlay panel.
    ///  </para>
    /// </remarks>
    public void HideOverlay()
    {
        _overlayPanel.UnfreezeContent();
    }

    private void SetupCommandStrip()
    {
        if (_commandStrip == null) return;

        _commandStrip.Items.Clear();

        var buttons = new[]
        {
            new { Button = new ToolStripButton("Send"), Command = AutoCompleteEditorCommand.Send, Symbol = FluentSymbols.CommonToolStripSymbols.Send, ToolTip = "Send" },
            new { Button = new ToolStripButton("Copy"), Command = AutoCompleteEditorCommand.Copy, Symbol = FluentSymbols.CommonToolStripSymbols.Copy, ToolTip = "Copy" },
            new { Button = new ToolStripButton("Paste"), Command = AutoCompleteEditorCommand.Paste, Symbol = FluentSymbols.CommonToolStripSymbols.Paste, ToolTip = "Paste" },
            new { Button = new ToolStripButton("Add to Library"), Command = AutoCompleteEditorCommand.Add, Symbol = FluentSymbols.CommonToolStripSymbols.AddBold, ToolTip = "Add to Library" },
            new { Button = new ToolStripButton("Open Library"), Command = AutoCompleteEditorCommand.Open, Symbol = FluentSymbols.CommonToolStripSymbols.Open, ToolTip = "Open Library" }
        };

        _commandStrip.SuspendLayout();

        foreach (var item in buttons)
        {
            item.Button.DisplayStyle = ToolStripItemDisplayStyle.Image;
            item.Button.ToolTipText = item.ToolTip;
            item.Button.Margin = new Padding(10,3,0,3);
            item.Button.Padding = new Padding(3);
            _commandStrip.Items.Add(item.Button);

            // Important: We need on owner for this not to blow!
            item.Button.SetSymbolImage(item.Symbol);
        }

        _sendButton = buttons[0].Button;
        _copyButton = buttons[1].Button;
        _pasteButton = buttons[2].Button;
        _addButton = buttons[3].Button;
        _openButton = buttons[4].Button;

        _sendButton.Click += async (s, e) => await SendCommandAsync();
        _copyButton.Click += (s, e) => CopyToClipboard();
        _pasteButton.Click += (s, e) => PasteFromClipboard();
        _addButton.Click += (s, e) => OnAsyncSendCommandAsync(new(AutoCompleteEditorCommand.Add));
        _openButton.Click += (s, e) => OnAsyncSendCommandAsync(new(AutoCompleteEditorCommand.Open));

        UpdateCommandStrip();
        _commandStrip.ResumeLayout();
    }

    private void CopyToClipboard()
    {
        if (!string.IsNullOrEmpty(SelectedText))
        {
            Clipboard.SetText(SelectedText);
        }
    }

    private void PasteFromClipboard()
    {
        if (Clipboard.ContainsText(TextDataFormat.Text))
        {
            SelectedText = Clipboard.GetText(TextDataFormat.Text);
        }
        else if (Clipboard.ContainsText(TextDataFormat.Rtf))
        {
            SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
        }
    }

    private static bool IsClipboardContentCompatible()
    {
        if (Clipboard.ContainsText(TextDataFormat.Text) || Clipboard.ContainsText(TextDataFormat.Rtf))
        {
            return true;
        }

        return false;
    }

    private void ClipboardCheckTimer_Tick(object? sender, EventArgs e)
    {
        if (RequestPasteFromClipboardButton != IsClipboardContentCompatible())
        {
            RequestPasteFromClipboardButton = IsClipboardContentCompatible();
            UpdateCommandStrip();
        }
    }

    protected virtual Task OnAsyncSendCommandAsync(AsyncSendCommandEventArgs e)
        => AsyncSendCommand?.Invoke(this, e) ?? Task.CompletedTask;

    private void UpdateCommandStrip()
    {
        if (_commandStrip == null)
            return;

        _commandStrip.SuspendLayout();

        _sendButton.EnsureNotNull().Visible = RequestPromptSendButton;
        _copyButton.EnsureNotNull().Visible = RequestCopyToClipBoardButton;
        _pasteButton.EnsureNotNull().Visible = RequestPasteFromClipboardButton;
        _addButton.EnsureNotNull().Visible = RequestAddToLibraryButton;
        _openButton.EnsureNotNull().Visible = RequestOpenLibraryButton;

        _commandStrip.ResumeLayout();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _clipboardCheckTimer.Stop();
            _clipboardCheckTimer.Dispose();
        }
        base.Dispose(disposing);
    }
}
