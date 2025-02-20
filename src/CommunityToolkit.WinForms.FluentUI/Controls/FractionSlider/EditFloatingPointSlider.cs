using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
///  A control that combines a floating point track bar and a text box for editing floating point values.
/// </summary>
[ToolboxBitmap(typeof(TrackBar))]
internal class EditFloatingPointSlider : ContainerControl
{
    private TextBox _innerTextBox;
    private FloatingPointTrackBar _innerSlider;

    /// <summary>
    ///  Occurs when the value of the slider changes.
    /// </summary>
    public event EventHandler? ValueChanged;

    /// <summary>
    ///  Initializes a new instance of the <see cref="EditFloatingPointSlider"/> class.
    /// </summary>
    public EditFloatingPointSlider()
    {
        // Setup a FloatingPointSlider and a TextBox as the inner controls:
        _innerTextBox = new TextBox()
        {
            Size = new Size(80, 20),
            Text = "0.0",
            Dock = DockStyle.Right,
        };

        _innerSlider = new FloatingPointTrackBar()
        {
            Size = new Size(120, 20),
            Dock = DockStyle.Fill,
        };

        Controls.Add(_innerSlider);
        Controls.Add(_innerTextBox);

        _innerSlider.ValueChanged += InnerSlider_ValueChanged;
    }

    /// <summary>
    ///  Raises the <see cref="ValueChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

    private void InnerSlider_ValueChanged(object? sender, EventArgs e)
    {
        try
        {
            _innerTextBox.Text = _innerSlider.Value.ToString("#.###");
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    ///  Gets or sets the minimum value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.0f)]
    [Description("The minimum value of the track bar.")]
    [Category("Behavior")]
    public float Minimum
    {
        get => _innerSlider.Minimum;
        set
        {
            _innerSlider.Minimum = value;
        }
    }

    /// <summary>
    ///  Gets or sets the maximum value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(1.0f)]
    [Description("The maximum value of the track bar.")]
    [Category("Behavior")]
    public float Maximum
    {
        get => _innerSlider.Maximum;
        set
        {
            _innerSlider.Maximum = value;
        }
    }

    /// <summary>
    ///  Gets or sets the current value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.0f)]
    [Description("The current value of the track bar.")]
    [Category("Behavior")]
    public float Value
    {
        get => _innerSlider.Value;
        set
        {
            _innerSlider.Value = value;
            _innerTextBox.Text = value.ToString("#.###");
            OnValueChanged(EventArgs.Empty);
        }
    }

    /// <summary>
    ///  Gets or sets the small change value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The small change value of the track bar.")]
    [Category("Appearance")]
    public float SmallChange
    {
        get => _innerSlider.SmallChange;
        set => _innerSlider.SmallChange = value;
    }

    /// <summary>
    ///  Gets or sets the large change value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.25f)]
    [Description("The large change value of the track bar.")]
    [Category("Appearance")]
    public float LargeChange
    {
        get => _innerSlider.LargeChange;
        set => _innerSlider.LargeChange = value;
    }

    /// <summary>
    ///  Gets or sets the tick frequency value of the track bar.
    /// </summary>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The tick frequency value of the track bar.")]
    [Category("Appearance")]
    public float TickFrequency
    {
        get => _innerSlider.TickFrequency;
        set => _innerSlider.TickFrequency = value;
    }
}
