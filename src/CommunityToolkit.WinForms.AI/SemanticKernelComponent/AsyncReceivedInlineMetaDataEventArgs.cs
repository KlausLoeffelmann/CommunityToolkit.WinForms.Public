using CommunityToolkit.WinForms.AI.ConverterLogic;

namespace CommunityToolkit.WinForms.AI;

/// <summary>
///  Provides data for the asynchronous received inline metadata event.
/// </summary>
public class AsyncReceivedInlineMetaDataEventArgs(ReturnStreamMetaData metaData) : EventArgs
{
    /// <summary>
    ///  Gets the metadata associated with the event.
    /// </summary>
    public ReturnStreamMetaData MetaData { get; } = metaData;
}
