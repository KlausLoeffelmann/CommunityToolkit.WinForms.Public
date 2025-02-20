namespace CommunityToolkit.WinForms.Extensions.FormAndControlExtensions;

public static class WinFormsCommandExtensions
{
    public static void BindCommand(this ToolStripMenuItem toolStripItem, WinFormsCommand command)
    {
        toolStripItem.DataBindings.Add(nameof(ToolStripMenuItem.Command), command, null);
        toolStripItem.DataBindings.Add(nameof(ToolStripMenuItem.Image), command, nameof(command.Image));
        toolStripItem.DataBindings.Add(nameof(ToolStripMenuItem.Checked), command, nameof(command.Checked));
    }

    public static void UnbindCommand(this ToolStripMenuItem toolStripItem, WinFormsCommand command)
    {
        toolStripItem.RemoveBinding(nameof(ToolStripMenuItem.Command));
    }
}
