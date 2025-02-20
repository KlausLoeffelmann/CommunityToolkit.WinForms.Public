using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.WinForms.AsyncSupport;

public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e);

/// <summary>
///  Represents an awaitable event that can be used with the await keyword.
/// </summary>
/// <typeparam name="T">The type of the event arguments.</typeparam>
public class AwaitableEvent<T> : IAwaitableComponent
    where T : EventArgs
{
    // TaskCompletionSource, providing a task that completes when the ToolStripMenuItem is clicked.
    private TaskCompletionSource<AwaitableEvent<T>>? _eventCompletion;
    private IComponent? _sender;
    private readonly Action<object?, T> _eventAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="AwaitableEvent{T}"/> class.
    /// </summary>
    public AwaitableEvent()
    {
        _eventAction = (object? sender, T eArgs) =>
        {
            Sender = (IComponent)sender!;
            EArgs = eArgs;
            EventCompletion.TrySetResult(this);
        };
    }

    /// <summary>
    /// Gets the task completion source for the event.
    /// </summary>
    private TaskCompletionSource<AwaitableEvent<T>> EventCompletion
        => _eventCompletion ??= new TaskCompletionSource<AwaitableEvent<T>>();

    /// <summary>
    /// Gets the action to be executed when the event is raised.
    /// </summary>
    public Action<object?, T> EventAction => _eventAction;

    /// <summary>
    /// Gets the sender of the event.
    /// </summary>
    public IComponent Sender 
    {   get => _sender ?? throw new ArgumentNullException("Sender not yet set.");
        private set => _sender = value;
    }

    public T EArgs { get; private set; } = null!;

    /// <summary>
    ///  Gets the awaiter for the component.
    /// </summary>
    /// <returns>
    ///  An object that implements the <see cref="INotifyCompletion"/> interface.
    /// </returns>
    INotifyCompletion IAwaitableComponent.GetAwaiter()
    {
        _eventCompletion = new TaskCompletionSource<AwaitableEvent<T>>();

        return EventCompletion.Task.GetAwaiter();
    }
}
