namespace CommunityToolkit.WinForms.AI
{
    /// <summary>
    ///  Attribute to map a specific prompt segment to a property in an AI template.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   The <c>AITemplateSegmentAttribute</c> is used to annotate properties within an AI template
    ///   class. It assigns a specific segment of the overall prompt (as defined in the system/developer
    ///   prompt) to the property, thereby facilitating a structured Prompt-&gt;Property assignment.
    ///  </para>
    ///  <para>
    ///   This attribute is essential for StructuredMode scenarios where both input and output are
    ///   organized into discrete segments. The optional prompt string provides detailed instructions for
    ///   that segment, while the <see cref="SegmentPurpose"/> property (defaulting to Output) indicates the
    ///   intended role of the segment.
    ///  </para>
    ///  <para>
    ///   The <see cref="AITemplateAttribute"/> class can be used to define the overall prompt for the AI template,
    ///   while the <c>AITemplateSegmentAttribute</c> maps specific segments of that prompt to individual properties.
    ///  </para>
    /// </remarks>
    /// <example>
    ///  <code language="csharp">
    ///   public class MyAITemplate
    ///   {
    ///       // This property is used for both input and output.
    ///       [AITemplateSegment("Provide initial input or capture the resulting output.")]
    ///       public string? Interaction { get; set; }
    /// 
    ///       // This property is used to capture only the generated output.
    ///       [AITemplateSegment("The generated response will be populated here.")]
    ///       public string? GeneratedResponse { get; set; }
    ///   }
    ///  </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class AITemplateSegmentAttribute() : Attribute
    {
        /// <summary>
        ///  Gets the purpose of the segment.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   The <see cref="SegmentPurpose"/> indicates whether the segment is intended for input, output,
        ///   or both. By default, this is set to <see cref="SegmentPurpose.Response"/>.
        ///  </para>
        /// </remarks>
        public SegmentPurpose Purpose { get; set; } = SegmentPurpose.Response;

        /// <summary>
        ///  Gets the prompt associated with this segment.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   The prompt provides specific instructions for this segment and maps the respective portion
        ///   of the overall AI prompt to the property.
        ///  </para>
        /// </remarks>
        public string? Prompt { get; set; }
    }

    /// <summary>
    ///  Specifies the intended role of an AI template segment.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   The <c>SegmentPurpose</c> enum defines whether a segment in an AI template is meant for input,
    ///   output, or both. This designation helps in clearly distinguishing the purpose of each segment
    ///   when constructing the prompt and processing the language model's response.
    ///  </para>
    /// </remarks>
    /// <example>
    ///  <code language="csharp">
    ///   // Example usage of SegmentPurpose in a conditional check.
    ///   AITemplateSegmentAttribute attribute = new AITemplateSegmentAttribute("Example prompt");
    ///   if (attribute.Purpose == SegmentPurpose.Output)
    ///   {
    ///       // Execute logic specific to output segments.
    ///   }
    ///  </code>
    /// </example>
    public enum SegmentPurpose
    {
        /// <summary>
        ///  Indicates that the segment is intended for output.
        /// </summary>
        Response,
        /// <summary>
        ///  Indicates that the segment is intended for input.
        /// </summary>
        Request,
        /// <summary>
        ///  Indicates that the segment is used for both input and output.
        /// </summary>
        RequestAndResponse
    }
}
