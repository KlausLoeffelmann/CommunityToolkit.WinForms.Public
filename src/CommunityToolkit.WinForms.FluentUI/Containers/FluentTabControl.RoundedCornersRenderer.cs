using System.Drawing.Drawing2D;

namespace CommunityToolkit.WinForms.FluentUI.Containers;

public partial class FluentTabControl
{
    private class RoundedCornersRenderer : ToolStripProfessionalRenderer
    {
        private LinearGradientBrush? _tabBackgroundBrush;

        // Add a bigger margin to the left and right of the menu items
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // Measure the text size:
            var textSize = e.Graphics.MeasureString(e.Text, e.TextFont!);

            // Add a 5px margin left and right and top:
            e.TextRectangle = new Rectangle(
                e.TextRectangle.X - 5,
                e.TextRectangle.Y,
                (int)textSize.Width + 10,
                e.TextRectangle.Height);

            base.OnRenderItemText(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Do nothing to hide the border
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var bounds = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item is not ToolStripMenuItem menuItem)
            {
                return;
            }

            if (_tabBackgroundBrush is null)
            {
                // We create a gradient Brush for the background from the top to the bottom of the item
                // with starting with SystemColors.ControlDarkDark to SystemColor.Control

                if (Application.IsDarkModeEnabled)
                {
                    _tabBackgroundBrush = new LinearGradientBrush(
                        bounds,
                        SystemColors.ControlDarkDark,
                        SystemColors.Control,
                        LinearGradientMode.Vertical);
                }
                else
                {
                    _tabBackgroundBrush = new LinearGradientBrush(
                        bounds,
                        SystemColors.ControlLightLight,
                        SystemColors.ControlLight,
                        LinearGradientMode.Vertical);
                }
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = new GraphicsPath();

            // Start from bottom-left, draw counter-clockwise
            path.AddLine(bounds.X, bounds.Bottom, bounds.X, bounds.Y + 10);  // Left line
            path.AddArc(bounds.X, bounds.Y, 10, 10, 180, 90);  // Top-left arc
            path.AddArc(bounds.Right - 10, bounds.Y, 9, 9, 270, 90);  // Top-right arc
            path.AddLine(bounds.Right - 1, bounds.Y + 4, bounds.Right - 1, bounds.Bottom);  // Right line

            e.Graphics.FillPath(_tabBackgroundBrush, path);

            if (menuItem.Checked)
            {
                var hotTrackBarBounds = new Rectangle(bounds.X, bounds.Y, 10, bounds.Height);
                using var hotTrackBrush = new SolidBrush(SystemColors.HotTrack);
                e.Graphics.FillRectangle(hotTrackBrush, hotTrackBarBounds);
            }

            if (menuItem.Selected)
            {
                // Draw a white border around the bar:
                using var borderPen = new Pen(SystemColors.ControlText);
                e.Graphics.DrawRoundedRectangle(
                    borderPen,
                    new Rectangle(
                        bounds.X,
                        bounds.Y,
                        bounds.Width - 1,
                        bounds.Height - 1),
                    new Size(15, 15));
            }

            // Paint a TextColor line at the bottom of the item:
            using var textBrush = new SolidBrush(SystemColors.ControlText);
            e.Graphics.FillRectangle(
                textBrush,
                new Rectangle(
                    bounds.X,
                    bounds.Bottom - 1,
                    bounds.Width,
                    1));
        }
    }
}
