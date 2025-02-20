using System.Runtime.CompilerServices;

namespace CommunityToolkit.WinForms.AsyncSupport;

/// <summary>
/// Represents an awaitable component that can be used with the await keyword.
/// </summary>
public interface IAwaitableComponent
{
    /// <summary>
    /// Gets the awaiter for the component.
    /// </summary>
    /// <returns>An object that implements the <see cref="INotifyCompletion"/> interface.</returns>
    INotifyCompletion GetAwaiter();
}
