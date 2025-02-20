namespace CommunityToolkit.WinForms.AI.Extensions;

public static partial class StringAndStringBuilderExtensions
{
    /// <summary>
    ///  Specifies the type of join operation to perform.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This enum defines the different types of join operations that can be performed
    ///   when joining an array of strings into a single string.
    ///  </para>
    /// </remarks>
    public enum JoinType
    {
        /// <summary>
        ///  Join with new lines.
        /// </summary>
        NewLine,

        /// <summary>
        ///  Join with commas.
        /// </summary>
        Comma,

        /// <summary>
        ///  Join with semicolons.
        /// </summary>
        Semicolon,
    }
}
