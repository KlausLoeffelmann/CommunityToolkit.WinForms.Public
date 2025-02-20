namespace CommunityToolkit.WinForms.AsyncSupport;

public static class AwaitableComponentExtensions
{
    /// <summary>
    ///  Waits for any of the specified awaitable components to complete.
    /// </summary>
    /// <param name="controlAwaitables">The collection of awaitable components to wait for.</param>
    /// <param name="additionalAwaitables">Additional collections of awaitable components to wait for.</param>
    /// <returns>A task that represents the first completed awaitable component.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="controlAwaitables"/> is null.</exception>
    public static async Task<IAwaitableComponent> WhenAny(
        this IEnumerable<IAwaitableComponent> controlAwaitables,
        params IEnumerable<IAwaitableComponent> additionalAwaitables)
    {
        // combine the controlAwaitables with the additionalAwaitables
        var tempAwaitables = new List<IAwaitableComponent>(controlAwaitables);
        tempAwaitables.AddRange(additionalAwaitables);

        var tcs = new TaskCompletionSource<IAwaitableComponent>();

        foreach (var awaitable in tempAwaitables)
        {
            var awaiter = awaitable.GetAwaiter();
            awaiter.OnCompleted(() => OnCompletedHandler(awaiter));
        }

        return await tcs.Task;

        void OnCompletedHandler(dynamic awaiter)
        {
            if (!awaiter.IsCompleted)
                return; // Just in case

            try
            {
                var result = awaiter.GetResult();
                tcs.TrySetResult(result);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        }
    }
}
