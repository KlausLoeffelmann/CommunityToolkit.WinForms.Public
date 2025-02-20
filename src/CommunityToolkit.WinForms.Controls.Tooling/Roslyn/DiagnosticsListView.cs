namespace CommunityToolkit.WinForms.Controls.Tooling.Roslyn;

public class DiagnosticsListView : ListView
{
    public DiagnosticsListView()
    {
        // Set the view to show details
        this.View = View.Details;

        // Allow the user to edit item text
        this.LabelEdit = true;

        // Allow the user to rearrange columns
        this.AllowColumnReorder = true;

        // Display check boxes
        this.CheckBoxes = true;

        // Select the item and subitems when selection is made
        this.FullRowSelect = true;

        // Display grid lines
        this.GridLines = true;

        // Sort the items in the list in ascending order
        this.Sorting = SortOrder.Ascending;

        // Create columns for the items and subitems
        this.Columns.Add("Error Number", -2, HorizontalAlignment.Left);
        this.Columns.Add("Description", -2, HorizontalAlignment.Left);
        this.Columns.Add("Project", -2, HorizontalAlignment.Left);
        this.Columns.Add("File", -2, HorizontalAlignment.Left);
        this.Columns.Add("Line", -2, HorizontalAlignment.Left);
        this.Columns.Add("Column", -2, HorizontalAlignment.Left);
    }
}
