namespace CommunityToolkit.WinForms.BasicTests.TestSupport;

internal static class AsyncHelperExtensions
{
#pragma warning disable IDE1006 // Naming rule violation: Missing suffix: 'Async'
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public static async IAsyncEnumerable<T> ToIAsyncEnumerable<T>(this IEnumerable<T> source)
    {
        foreach (var item in source)
        {
            yield return item;
        }
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore IDE1006 // Naming rule violation: Missing suffix: 'Async'
}
