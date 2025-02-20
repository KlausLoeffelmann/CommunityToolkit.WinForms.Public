using System.ComponentModel;
using System.Diagnostics;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

[ToolboxBitmap(typeof(TrackBar))]
public class FloatingPointTrackBar : TrackBar
{
    private float _minimumValue;
    private float _maximumValue;
    private float _value;
    private bool _isMouseCaptured;

    public FloatingPointTrackBar()
    {
        LargeChange = 0.25f;
        SmallChange = 0.1f;
        TickFrequency = 0.1f;
        Minimum = 0.0f;
        Maximum = 1.0f;
        Value = 0.0f;

        // Enable double buffering
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.0f)]
    [Description("The minimum value of the track bar.")]
    [Category("Behavior")]
    public new float Minimum
    {
        get => _minimumValue;
        set
        {
            _minimumValue = value;
            base.Minimum = (int)(value * 100);
        }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(1.0f)]
    [Description("The maximum value of the track bar.")]
    [Category("Behavior")]
    public new float Maximum
    {
        get => _maximumValue;
        set
        {
            _maximumValue = value;
            base.Maximum = (int)(value * 100);
        }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.0f)]
    [Description("The current value of the track bar.")]
    [Category("Behavior")]
    public new float Value
    {
        get => _value;
        set
        {
            _value = value;
            base.Value = (int)(value * 100);
        }
    }

    protected override void OnScroll(EventArgs e)
    {
        _value = base.Value / 100f;

        if (!IsAncestorSiteInDesignMode)
        {
            Debug.Print($"Value: {base.Value}");
        }

        base.OnScroll(e);

        if (_isMouseCaptured)
        {
            Invalidate();
        }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The small change value of the track bar.")]
    [Category("Appearance")]
    public new float SmallChange
    {
        get => base.SmallChange / 100f;
        set => base.SmallChange = (int)(value * 100);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.25f)]
    [Description("The large change value of the track bar.")]
    [Category("Appearance")]
    public new float LargeChange
    {
        get => base.LargeChange / 100f;
        set => base.LargeChange = (int)(value * 100);
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(0.1f)]
    [Description("The tick frequency value of the track bar.")]
    [Category("Appearance")]
    public new float TickFrequency
    {
        get => base.TickFrequency / 100f;
        set => base.TickFrequency = (int)(value * 100);
    }

    protected override void OnMouseCaptureChanged(EventArgs e)
    {
        base.OnMouseCaptureChanged(e);
        if (_isMouseCaptured)
            _isMouseCaptured = false;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        _isMouseCaptured = true;
        Invalidate();
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_PAINT = 0x000F;

        base.WndProc(ref m);

        if (m.Msg == WM_PAINT)
        {
            // OnPaintInternal();
        }
    }

    private void OnPaintInternal()
    {
        if (!_isMouseCaptured)
        {
            return;
        }

        var valueText = _value.ToString();
        var textSize = TextRenderer.MeasureText(valueText, Font);

        // Get the coordinates of the mouse relative to the control:
        int x = PointToClient(Cursor.Position).X;

        var leftSpace = x - textSize.Width;
        var rightSpace = Width - x;

        int y = Height / 2 - textSize.Height / 2;

        var renderPoint = leftSpace > rightSpace
            ? new Point(x - textSize.Width, y)
            : new Point(x, y);

        using var graphics = Graphics.FromHwnd(Handle);

        graphics.DrawString(valueText, Font, Brushes.White, renderPoint);

        if (!IsAncestorSiteInDesignMode)
        {
            Debug.Print($"OP Value: {base.Value}{renderPoint}");
        }
    }
}
