using System.ComponentModel;
using System.Windows.Input;

namespace CommunityToolkit.WinForms.AsyncSupport;

/// <summary>
/// Represents the method that will handle the asynchronous click event of the <see cref="AsyncButton"/> control.
/// </summary>
/// <param name="sender">The source of the event.</param>
/// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
public delegate Task AsyncEventHandler(object? sender, EventArgs e);

public partial class AsyncCommandComponent : Component, ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) 
        => true;

    public void Execute(object? parameter)
    {
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public ICommand? Command { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Component? EventSender { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [TypeConverter(typeof(ComponentEventTypeConverter))]
    public string? Event { get; set; }
}
