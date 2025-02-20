namespace CommunityToolkit.WinForms.FluentUI.AsyncGridView;

public class AsyncGridViewItem(DataGridViewRow parentRow, object? value)
{
    public DataGridViewRow ParentRow { get; set; } = parentRow;

    public object? Value { get; } = value;

    public void Invalidate()
    {
        // We need to invalidate the row to force a repaint
        ParentRow?.DataGridView?.InvalidateRow(ParentRow.Index);
    }

    // A GridViewItem can render itself based on what the DataGridView provides:
    public virtual void Render(Graphics graphics, Rectangle bounds, bool selected)
    {
        // We don't render anything by default
    }

    // A GridViewItem can also provide a preferred size for the cell:
    public virtual Size GetPreferredSize(Graphics graphics, Rectangle bounds)
    {
        // We don't have a preferred size by default
        return Size.Empty;
    }
}
