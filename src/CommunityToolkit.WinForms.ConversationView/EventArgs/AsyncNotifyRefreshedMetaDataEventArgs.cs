using CommunityToolkit.WinForms.ChatUI.AIStructures;

namespace CommunityToolkit.WinForms.ChatUI;

/// <summary>
///  Provides data for the asynchronous notification of refreshed chat metadata.
/// </summary>
/// <remarks>
///  <para>
///   This class encapsulates the metadata of a chat, such as the title, summary, keywords, token count,
///   and memory facts. It also handles exceptions that may occur during the metadata refresh process.
///  </para>
///  <para>
///   The class provides two constructors: one for successful metadata refreshes and one for handling exceptions.
///  </para>
/// </remarks>
public class AsyncNotifyRefreshedMetaDataEventArgs : EventArgs
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="AsyncNotifyRefreshedMetaDataEventArgs"/> class with the specified chat metadata.
    /// </summary>
    /// <param name="chatMetaData">The metadata of the chat.</param>
    /// <remarks>
    ///  <para>
    ///   This constructor initializes the properties of the class with the values from the provided <see cref="ChatInfoAITemplate"/> object.
    ///  </para>
    /// </remarks>
    internal AsyncNotifyRefreshedMetaDataEventArgs(ChatInfoAITemplate? chatMetaData)
    {
        ChatTitle = chatMetaData?.ChatTitle;
        ChatSummary = chatMetaData?.ChatSummary;
        ChatKeywords = chatMetaData?.ChatKeywords;
        MemoryFactList = chatMetaData?.MemoryFactList;
    }

    /// <summary>
    ///  Initializes a new instance of the <see cref="AsyncNotifyRefreshedMetaDataEventArgs"/> class with the specified exception.
    /// </summary>
    /// <param name="exception">The exception that occurred during the metadata refresh process.</param>
    /// <remarks>
    ///  <para>
    ///   This constructor sets the <see cref="CausedException"/> property to true and stores the provided exception.
    ///  </para>
    /// </remarks>
    internal AsyncNotifyRefreshedMetaDataEventArgs(Exception exception)
    {
        CausedException = true;
        Exception = exception;
    }

    /// <summary>
    ///  Gets the title of the chat.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains the title of the chat, which is a brief, descriptive name for the chat.
    ///  </para>
    /// </remarks>
    public string? ChatTitle { get; }

    /// <summary>
    ///  Gets the summary of the chat.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains a brief summary of the chat, providing an overview of the chat's content.
    ///  </para>
    /// </remarks>
    public string? ChatSummary { get; }

    /// <summary>
    ///  Gets the keywords associated with the chat.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains keywords that are relevant to the chat, helping to categorize and search for the chat.
    ///  </para>
    /// </remarks>
    public string? ChatKeywords { get; }

    /// <summary>
    ///  Gets the number of tokens used in the chat.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains the count of tokens used in the chat, which can be useful for tracking the length and complexity of the chat.
    ///  </para>
    /// </remarks>
    public int TokenCount { get; }

    /// <summary>
    ///  Gets the list of memory facts from the chat.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains a list of important facts mentioned in the chat, which are worth remembering long-term.
    ///  </para>
    /// </remarks>
    public string? MemoryFactList { get; }

    /// <summary>
    ///  Gets a value indicating whether an exception occurred during the metadata refresh process.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property is set to true if an exception occurred during the metadata refresh process, otherwise false.
    ///  </para>
    /// </remarks>
    public bool CausedException { get; }

    /// <summary>
    ///  Gets the exception that occurred during the metadata refresh process.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property contains the exception that was thrown during the metadata refresh process, if any.
    ///  </para>
    /// </remarks>
    public Exception? Exception { get; }
}
