namespace CommunityToolkit.WinForms.AsyncSupport;

public readonly struct AsyncEventInvoker<TAsyncEventArgs>(
    AsyncEventHandler<TAsyncEventArgs> asyncEventHandler,
    bool parallelInvoke)
    where TAsyncEventArgs : EventArgs
{
    public async Task RaiseEventAsync(
        object sender,
        TAsyncEventArgs e)
    {
        Control control = (Control)sender;

        if (asyncEventHandler is null)
            return;

        IEnumerable<Task> eventHandlerTasks = asyncEventHandler
            .GetInvocationList()
            .OfType<AsyncEventHandler<TAsyncEventArgs>>()
            .Select(handler => handler.DynamicInvoke(sender, e) as Task)
            .OfType<Task>();

        if (parallelInvoke)
        {
            // Invoke each handler in parallel
            await Task.WhenAll(eventHandlerTasks).ConfigureAwait(false);
        }
        else
        {
            // Invoke each handler safely
            foreach (Task task in eventHandlerTasks)
            {
                await task.ConfigureAwait(false);
            }
        }
    }
}
