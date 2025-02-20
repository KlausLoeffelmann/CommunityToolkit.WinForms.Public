using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

[ToolboxBitmap(typeof(TrackBar))]
public class FloatingPointSlider : TrackBar
{
    private const int ScaleFactor = 100;

    public FloatingPointSlider()
    {
        Minimum = 0;
        Maximum = 1;
        Value = 0;
        TickFrequency = 0.1f;
        LargeChange = 0.1f;
        SmallChange = 0.01f;
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0)]
    [Description("The minimum value of the slider.")]
    [Category("Slider")]
    public new float Minimum
    {
        get => base.Minimum / (float)ScaleFactor;
        set => base.Minimum = (int)(value * ScaleFactor);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(1)]
    [Description("The maximum value of the slider.")]
    [Category("Slider")]
    public new float Maximum
    {
        get => base.Maximum / (float)ScaleFactor;
        set => base.Maximum = (int)(value * ScaleFactor);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0)]
    [Description("The current value of the slider.")]
    [Category("Slider")]
    public new float Value
    {
        get => base.Value / (float)ScaleFactor;
        set => base.Value = (int)(value * ScaleFactor);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The frequency of tick marks on the slider.")]
    [Category("Slider")]
    public new float TickFrequency
    {
        get => base.TickFrequency / (float)ScaleFactor;
        set => base.TickFrequency = (int)(value * ScaleFactor);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The amount by which the slider value changes when the user clicks the track bar on either side of the slider thumb.")]
    [Category("Slider")]
    public new float LargeChange
    {
        get => base.LargeChange / (float)ScaleFactor;
        set => base.LargeChange = (int)(value * ScaleFactor);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.01f)]
    [Description("The amount by which the slider value changes when the user presses the arrow keys.")]
    [Category("Slider")]
    public new float SmallChange
    {
        get => base.SmallChange / (float)ScaleFactor;
        set => base.SmallChange = (int)(value * ScaleFactor);
    }
}
