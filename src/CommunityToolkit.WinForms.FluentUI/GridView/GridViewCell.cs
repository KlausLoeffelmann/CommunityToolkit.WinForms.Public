using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI;

internal class GridViewCell : DataGridViewCell
{
    private static readonly Padding s_defaultPadding = new(5, 5, 5, 0);

    private GridViewItemTemplate? _itemTemplate;
    private bool _isMouseOver;

    protected override void OnMouseEnter(int rowIndex)
    {
        base.OnMouseEnter(rowIndex);

        _isMouseOver = true;
        DataGridView?.InvalidateCell(this);
    }

    override protected void OnMouseLeave(int rowIndex)
    {
        base.OnMouseLeave(rowIndex);

        _isMouseOver = false;
        DataGridView?.InvalidateCell(this);
    }

    internal GridViewItemTemplate? ItemTemplate
    {
        get => _itemTemplate;

        set
        {
            if (_itemTemplate == value)
            {
                return;
            }

            _itemTemplate = value;
        }
    }

    public override object Clone()
    {
        var clone = (GridViewCell)base.Clone();
        clone.ItemTemplate = ItemTemplate;
        return clone;
    }

    protected override object? GetFormattedValue(
        object? value,
        int rowIndex,
        ref DataGridViewCellStyle cellStyle,
        TypeConverter? valueTypeConverter,
        TypeConverter? formattedValueTypeConverter,
        DataGridViewDataErrorContexts context)
    {
        return $"{(value is null ? "- - -" : value)}";
    }

    protected override Size GetPreferredSize(
        Graphics graphics,
        DataGridViewCellStyle cellStyle,
        int rowIndex,
        Size constraintSize)
    {
        if (ItemTemplate is null)
        {
            return base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        }

        if (rowIndex < 0)
        {
            return ItemTemplate.GetPreferredSize(constraintSize, null, rowIndex);
        }
        else
        {
            return ItemTemplate.GetPreferredSize(constraintSize, GetValue(rowIndex), rowIndex);
        }
    }

    protected override void Paint(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates cellState,
        object? value,
        object? formattedValue,
        string? errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        if (_itemTemplate is null || value is null)
        {
            return;
        }

        var padding = ItemTemplate is null
            ? s_defaultPadding
            : ItemTemplate.Padding;

        var paddedBounds = cellBounds.Pad(padding);

        ItemTemplate?.OnPaintContent(
            value,
            this,
            new PaintEventArgs(graphics, clipBounds),
            paddedBounds,
            _isMouseOver);
    }

    protected override void PaintErrorIcon(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        string? errorText)
    {

        if (_itemTemplate is null)
        {
            base.PaintErrorIcon(graphics, clipBounds, cellBounds, errorText);
            return;
        }

        var padding = ItemTemplate is null
            ? s_defaultPadding
            : ItemTemplate.Padding;

        // Set the padding for the cell:
        cellBounds.Inflate(-padding.Right, -padding.Bottom);
        cellBounds.Offset(padding.Left, padding.Top);

        _itemTemplate.PaintErrorIcon(graphics, clipBounds, cellBounds, errorText);
    }
}
