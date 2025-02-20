using static CommunityToolkit.WinForms.AI.ModelInfo;

namespace CommunityToolkit.WinForms.AI;

/// <summary>
///  Represents information about a model.
/// </summary>
/// <remarks>
///  <para>
///   This class holds details about a model including its ID, object type, creation date,
///   owner, and usage information.
///  </para>
/// </remarks>
public class ModelInfo(string Id, string Object, int Created, string OwnedBy, Usage? Usage)
{
    /// <summary>
    ///  Represents usage information for a model.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This class holds details about the usage of a model, specifically the maximum number
    ///   of tokens that can be used.
    ///  </para>
    /// </remarks>
    public class Usage(int? MaxTokens)
    {
        /// <summary>
        ///  Gets the maximum number of tokens that can be used.
        /// </summary>
        public int? MaxTokens { get; } = MaxTokens;
    }

    /// <summary>
    ///  Gets the ID of the model.
    /// </summary>
    public string Id { get; } = Id;

    /// <summary>
    ///  Gets the object type of the model.
    /// </summary>
    public string Object { get; } = Object;

    /// <summary>
    ///  Gets the creation date of the model.
    /// </summary>
    public int Created { get; } = Created;

    /// <summary>
    ///  Gets the owner of the model.
    /// </summary>
    public string OwnedBy { get; } = OwnedBy;

    /// <summary>
    ///  Gets the usage information of the model.
    /// </summary>
    public Usage? TokenUsage { get; } = Usage;
}
