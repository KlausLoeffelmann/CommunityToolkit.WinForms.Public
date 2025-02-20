using Microsoft.CodeAnalysis;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;

/// <summary>
///  Represents a block of comments in the code.
/// </summary>
/// <remarks>
///  <para>
///   This class is used to maintain a comment section in trivias in code, and be later able to 
///   back-assign it to the (most likely new) respective syntax node. This is a work in process.
///  </para>
/// </remarks>
public class CommentBlock
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="CommentBlock"/> class.
    /// </summary>
    public CommentBlock()
    {
        Guid = System.Guid.NewGuid().ToString();
    }

    /// <summary>
    ///  Gets or sets the unique identifier for the comment block.
    /// </summary>
    public string Guid { get; set; }

    /// <summary>
    ///  Gets or sets the list of syntax trivia representing the comments.
    /// </summary>
    public List<SyntaxTrivia> Comment { get; set; } = [];

    /// <summary>
    ///  Gets or sets the indentation level of the comment block.
    /// </summary>
    public int IndentationLevel { get; set; }
}
