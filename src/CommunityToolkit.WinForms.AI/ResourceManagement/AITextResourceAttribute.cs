namespace CommunityToolkit.WinForms.AI.ResourceManagement
{
    /// <summary>
    ///  An attribute to mark text resources as the source of truth 
    ///  for automatically maintaining the correlated resource files.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   The <see cref="AITextResourceAttribute"/> is used to designate certain text 
    ///   resources as the authoritative source. This helps in ensuring that any changes 
    ///   made to these resources are automatically reflected in the related resource files.
    ///  </para>
    ///  <para>
    ///   <b>Workflow:</b>
    ///   <list type="number">
    ///    <item>
    ///     <description>Apply the <see cref="AITextResourceAttribute"/> to the text 
    ///     resource that should be the source of truth.</description>
    ///    </item>
    ///    <item>
    ///     <description>When the text resource is modified, the attribute ensures that 
    ///     all correlated resource files are updated accordingly.</description>
    ///    </item>
    ///    <item>
    ///     <description>The AI component analyzes the changes and suggests updates to 
    ///     maintain consistency across different resource files.</description>
    ///    </item>
    ///    <item>
    ///     <description>This helps in maintaining consistency across different resource 
    ///     files without manual intervention.</description>
    ///    </item>
    ///    <item>
    ///     <description>Automatic translation of text resources to multiple languages 
    ///     to support internationalization.</description>
    ///    </item>
    ///    <item>
    ///     <description>Detection and correction of grammatical errors in text resources.</description>
    ///    </item>
    ///    <item>
    ///     <description>Contextual suggestions for improving the clarity and readability 
    ///     of text resources.</description>
    ///    </item>
    ///    <item>
    ///     <description>Automatic generation of documentation based on text resources.</description>
    ///    </item>
    ///   </list>
    ///  </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Parameter)]
    public class AITextResourceAttribute : Attribute
    {
    }
}
