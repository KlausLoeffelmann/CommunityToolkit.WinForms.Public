namespace CommunityToolkit.WinForms.Extensions.FormAndControlExtensions;

#nullable enable
using System.Drawing;
using System.Windows.Forms;

public static class DataGridViewExtensions
{
    /// <summary>
    ///  Applies a dark mode color scheme to the DataGridView, including column and row headers.
    /// </summary>
    /// <param name="grid">The DataGridView to style.</param>
    public static void ApplyDarkMode(this DataGridView grid)
    {
        if (grid is null) return;

        // General grid settings
        grid.BackgroundColor = Color.FromArgb(30, 30, 30);
        grid.GridColor = Color.FromArgb(0, 120, 215); // Mid blue for cell separator lines
        grid.DefaultCellStyle.BackColor = Color.FromArgb(36, 36, 36); // 20% darker background
        grid.DefaultCellStyle.ForeColor = Color.White;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Blue when selected
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
        grid.DefaultCellStyle.Padding = new Padding(2); // Add padding to all cells

        // Column Header settings
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Blue when selected
        grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(2); // Add padding to column headers

        // Row Header settings
        grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
        grid.RowHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Blue when selected
        grid.RowHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        grid.RowHeadersDefaultCellStyle.Padding = new Padding(2); // Add padding to row headers

        // Set headers to be visually distinct
        grid.EnableHeadersVisualStyles = false;

        // Handle focus events to change selection color
        grid.GotFocus += (sender, e) =>
        {
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Blue when selected
        };

        grid.LostFocus += (sender, e) =>
        {
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Light blue when not focused
        };
    }
}
