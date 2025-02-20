using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace CommunityToolkit.WinForms.AsyncSupport;

public static class AsyncExtensions
{
    public static void RunAsync<T>(this Control control, Func<T, Task> asyncAction, T arg)
    {
        ArgumentNullException.ThrowIfNull(control);
        ArgumentNullException.ThrowIfNull(asyncAction);

        var context = SynchronizationContext.Current
            ?? throw new InvalidOperationException("No synchronization context available.");

        context.Post(async _ =>
            {
                try
                {
                    await asyncAction(arg).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    ExceptionDispatchInfo.Capture(ex).Throw();
                }
            },
            state: null);
    }

    public static void RunSync(this Control control, Func<Task> asyncAction)
    {
        ArgumentNullException.ThrowIfNull(control);
        ArgumentNullException.ThrowIfNull(asyncAction);

        var context = SynchronizationContext.Current
            ?? throw new InvalidOperationException("No synchronization context available.");

        var tcs = new TaskCompletionSource();

        Task.Run(() => 
        {
            context.Post(async _ =>
            {
                try
                {
                    await asyncAction().ConfigureAwait(false);
                    tcs.SetResult();
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            },
            state: null);
        });

        while (!tcs.Task.Wait(25))
        {
            Application.DoEvents();
        }

        if (tcs.Task.Exception is not null)
        {
            ExceptionDispatchInfo.Capture(tcs.Task.Exception.InnerException!).Throw();
        }
    }
}
