namespace CommunityToolkit.WinForms.FluentUI.AsyncGridView;

internal class AsyncDataGridView : DataGridView
{
    public AsyncDataGridView()
    {
        // We need to set the DoubleBuffered property to true to avoid flickering
        DoubleBuffered = true;

        // We can't have any ColumnHeaders or RowHeaders. We need this just as a render base for scrollbar control and such.
        ColumnHeadersVisible = false;
        RowHeadersVisible = false;

        // We don't want the user to be able to add or remove rows
        AllowUserToAddRows = false;
        AllowUserToDeleteRows = false;

        // We don't want the user to be able to resize columns
        AllowUserToResizeColumns = false;
        AllowUserToResizeRows = false;

        // We don't want the user to be able to reorder columns
        AllowUserToOrderColumns = false;

        // We want the user only to select cells, but no rows or columns
        SelectionMode = DataGridViewSelectionMode.CellSelect;

        // We don't want the user to be able to edit the cells
        ReadOnly = true;

        // We are always in virtual mode
        VirtualMode = true;
    }

    protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
    {
        base.OnCellValueNeeded(e);
    }

    // We need to override the OnCellPainting method to render the cell content
    protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
    {
        base.OnCellPainting(e);

        if (e.Graphics is null)
        {
            return;
        }

        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        AsyncGridViewItem? gridViewItem = Rows[e.RowIndex].DataBoundItem as AsyncGridViewItem;

        if (gridViewItem == null)
        {
            return;
        }

        var bounds = e.CellBounds;
        bounds.Inflate(-1, -1);

        gridViewItem.Render(
            graphics: e.Graphics,
            bounds: bounds,
            selected: e.State.HasFlag(DataGridViewElementStates.Selected));
    }
}
