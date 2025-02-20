using System.Collections.Concurrent;

namespace CommunityToolkit.WinForms.AsyncSupport;

/// <summary>
///  Represents a queue for managing asynchronous tasks.
/// </summary>
public sealed class AsyncTaskQueue : IDisposable
{
    private readonly ConcurrentQueue<Func<Task>> _taskQueue = new();
    private readonly SemaphoreSlim _enqueueSignal = new(0);
    private readonly SemaphoreSlim _availableSlots;
    private readonly ManualResetEventSlim _taskStartedEvent;
    private readonly CancellationTokenSource _cts = new();
    private readonly Task _processingTask;
    private readonly TaskCompletionSource _completionSource = new();
    private readonly TaskScheduler? _uiScheduler;
    private readonly int _maxQueuedItems;

    /// <summary>
    ///  Initializes a new instance of the <see cref="AsyncTaskQueue"/> class.
    /// </summary>
    public AsyncTaskQueue(int maxQueuedItems = 10000)
    {
        try
        {
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
        catch (Exception ex) when (ex is not StackOverflowException
            and not OutOfMemoryException
            and not ThreadAbortException
            and not AccessViolationException)
        {
            // Ignore exceptions that can be thrown when there is no synchronization context.
        }

        _maxQueuedItems = maxQueuedItems;
        _availableSlots = new SemaphoreSlim(maxQueuedItems);

        _taskStartedEvent = new ManualResetEventSlim(false);
        _processingTask = Task.Run(ProcessQueueAsync);
        _taskStartedEvent.Wait();
    }

    /// <summary>
    ///  Processes the queue of tasks asynchronously.
    /// </summary>
    private async Task ProcessQueueAsync()
    {
        _taskStartedEvent.Set();

        try
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                await _enqueueSignal.WaitAsync(_cts.Token);

                if (_cts.Token.IsCancellationRequested)
                    break;

                while (_taskQueue.TryDequeue(out var workItem))
                {
                    await workItem();
                    _availableSlots.Release(); // Release a slot after processing
                }

                if (_taskQueue.IsEmpty)
                {
                    _completionSource.TrySetResult(); // Signal all tasks are processed
                }
            }
        }
        catch (Exception ex)
        {
            AggregateException aggregateException = new(
                "Running an async queue caused an exception. See the inner exception for details.",
                ex);

            if (_uiScheduler is null)
            {
                throw aggregateException;
            }

            await Task.Factory.StartNew(
                action: () =>
                {
                    // This runs on the UI thread
                    throw aggregateException;
                },
                cancellationToken: CancellationToken.None,
                creationOptions: TaskCreationOptions.None,
                scheduler: _uiScheduler);
        }
    }

    /// <summary>
    ///  Enqueues an asynchronous method to be executed and waits if the queue is full.
    /// </summary>
    /// <param name="asyncMethod">The asynchronous method to enqueue.</param>
    /// <returns>A task that completes when the method is enqueued.</returns>
    public async Task EnqueueAsync(Func<Task> asyncMethod)
    {
        await _availableSlots.WaitAsync();

        try
        {
            _taskQueue.Enqueue(asyncMethod);
            _enqueueSignal.Release();
        }
        catch (Exception)
        {
            _availableSlots.Release();
            throw;
        }
    }

    public void Enqueue(Func<Task> asyncMethod)
    {
        _availableSlots.Wait();
        _taskQueue.Enqueue(asyncMethod);
        _enqueueSignal.Release();
    }

    /// <summary>
    ///  Returns a task that completes when all tasks in the queue have been processed.
    /// </summary>
    public async Task WaitProcessedAsync()
    {
        // Wait for the task processing completion or cancellation
        await Task.WhenAny(
            _completionSource.Task, 
            Task.Run(() => _cts.Token.WaitHandle.WaitOne()));
    }

    public int Count => _taskQueue.Count;

    /// <summary>
    ///  Releases all resources used by the <see cref="AsyncTaskQueue"/>.
    /// </summary>
    public void Dispose()
    {
        _cts.Cancel();
        _enqueueSignal.Release();
        _processingTask.Wait();
        _availableSlots.Dispose();
        _enqueueSignal.Dispose();
        _cts.Dispose();
    }
}
