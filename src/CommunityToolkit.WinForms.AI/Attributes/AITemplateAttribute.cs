using System.Globalization;

namespace CommunityToolkit.WinForms.AI;

/// <summary>
///  Attribute to define an AI template for structured interactions with a language model.
/// </summary>
/// <remarks>
///  <para>
///   The <c>AITemplateAttribute</c> is applied to classes to specify a system/developer prompt that guides
///   the language model during a structured roundtrip. The prompt provides detailed instructions and context,
///   forming the basis for constructing the complete conversation with the AI.
///  </para>
///  <para>
///   In a typical implementation, the prompt defined by this attribute is paired with properties decorated with
///   the <see cref="AITemplateSegmentAttribute"/>. These segment attributes map specific portions of the overall prompt
///   to individual properties, thereby facilitating a clear Prompt-&gt;Property assignment.
///  </para>
///  <para>
///   This attribute is primarily used in StructuredMode scenarios, where the AI's input and output are organized
///   into discrete segments. In such cases, additional metadata such as the current date, time, time zone,
///   and cultural formatting information can be provided to enrich the prompt and ensure consistent localization.
///  </para>
/// </remarks>
/// <example>
///  <code language="csharp">
///   [AITemplate(Prompt = "Provide a detailed description of the task.")]
///   public class TaskTemplate
///   {
///       [AITemplateSegment("Describe the task in detail.")]
///       public string? TaskDescription { get; set; }
///
///       [AITemplateSegment("Specify the deadline for the task.")]
///       public DateTime Deadline { get; set; }
///   }
///  </code>
/// </example>
[AttributeUsage(AttributeTargets.Class)]
public class AITemplateAttribute() : Attribute
{
    /// <summary>
    ///  Gets or sets the system/developer prompt used to instruct the language model.
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether to include the current time in the prompt.
    /// </summary>
    public bool ProvideTime { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether to include the current date in the prompt.
    /// </summary>
    public bool ProvideDate { get; set; }

    /// <summary>
    ///  Gets or sets a value indicating whether to include the current time zone information in the prompt.
    /// </summary>
    public bool ProvideTimeZone { get; set; }

    /// <summary>
    ///  Gets or sets the culture information used for formatting data in the prompt.
    /// </summary>
    public CultureInfo? FormatCulture { get; set; }

    /// <summary>
    ///  Gets or sets the culture information used for determining the language of the prompt.
    /// </summary>
    public CultureInfo? LanguageCulture { get; set; }
}
