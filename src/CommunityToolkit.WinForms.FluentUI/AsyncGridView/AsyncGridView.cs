using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.AsyncGridView;

public partial class AsyncGridView : Panel
{
    private readonly AsyncDataGridView _dataGridView;

    public AsyncGridView()
    {
        _dataGridView = new AsyncDataGridView
        {
            Dock = DockStyle.Fill
        };

        Controls.Add(_dataGridView);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int ColumnCount
    {
        get => _dataGridView.ColumnCount;
        set => _dataGridView.ColumnCount = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Type? GridViewItemTemplate { get; set; }
}
