using CommunityToolkit.WinForms.AsyncSupport;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
///  Represents a button control that supports asynchronous event handling.
/// </summary>
[DefaultEvent(nameof(AsyncClick))]
public class AsyncButton : Button
{
    /// <summary>
    ///  Occurs when the <see cref="AsyncButton"/> control is clicked asynchronously.
    /// </summary>
    public event AsyncEventHandler? AsyncClick;

    /// <summary>
    ///  Raises the <see cref="Control.Click"/> 
    ///  and the <see cref="AsyncClick"/> event.
    /// </summary>
    /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
    protected async override void OnClick(EventArgs e)
    {
        bool previousEnabled = Enabled;
        base.OnClick(e);

        if (AsyncClick is null)
            return;

        if (AutoDisableWhenBusy)
        {
            previousEnabled = Enabled;
            Enabled = false;
        }

        if (ParallelInvoke)
        {
            // Invoke each handler in parallel
            await Task
                .WhenAll(AsyncClick
                    .GetInvocationList()
                    .Cast<AsyncEventHandler>()
                    .Select(handler => handler.Invoke(this, e)))
                .ConfigureAwait(false);
        }
        else
        {
            IEnumerable<AsyncEventHandler> handlers = AsyncClick
                .GetInvocationList()
                .Cast<AsyncEventHandler>();

            // Invoke each handler safely in sequence.
            foreach (AsyncEventHandler handler in handlers)
            {
                try
                {
                    await handler.Invoke(this, e).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // Rethrow the exception on the UI thread.
                    await InvokeAsync(() => ExceptionDispatchInfo.Capture(ex).Throw());
                }
            }
        }

        if (AutoDisableWhenBusy && !previousEnabled)
        {
            Enabled = previousEnabled;
        }
    }

    /// <summary>
    ///  Gets or sets a value indicating whether the <see cref="AsyncButton"/> control should invoke async handler in parallel.
    /// </summary>
    [DefaultValue(false)]
    public bool ParallelInvoke { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether the <see cref="AsyncButton"/> control should be automatically disabled when busy.
    /// </summary>
    [DefaultValue(false)]
    public bool AutoDisableWhenBusy { get; set; }
}
