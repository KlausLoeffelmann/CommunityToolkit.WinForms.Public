using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;

public static partial class DocumentExtensions
{
    /// <summary>
    ///  Retrieves all comment blocks from the specified document.
    /// </summary>
    /// <param name="document">The document to extract comment blocks from.</param>
    /// <returns>An asynchronous enumerable of lists of comment blocks.</returns>
    /// <remarks>
    ///  <para>
    ///   This method traverses the syntax tree of the provided document and collects all
    ///   single-line and multi-line comments into blocks. Each block is a contiguous sequence
    ///   of comments.
    ///  </para>
    ///  <para>
    ///   The method yields a list of comment blocks, where each block contains the comments
    ///   and their associated trivia.
    ///  </para>
    /// </remarks>
    public static async IAsyncEnumerable<List<CommentBlock>> GetAllCommentBlocks(
        this Document document)
    {
        SyntaxNode? root = (await document.GetSyntaxRootAsync())
            ?? throw new InvalidOperationException("Document has no syntax root");

        List<CommentBlock> commentBlocks = [];
        CommentBlock currentBlock = new();

        foreach (SyntaxTrivia trivia in root.DescendantTrivia())
        {
            if (trivia.IsKind(SyntaxKind.SingleLineCommentTrivia)
                || trivia.IsKind(SyntaxKind.MultiLineCommentTrivia))
            {
                currentBlock.Comment.Add(trivia);
            }
            else if (currentBlock.Comment.Count != 0)
            {
                commentBlocks.Add(currentBlock);
                currentBlock = new CommentBlock();
            }
        }

        if (currentBlock.Comment.Count != 0)
        {
            commentBlocks.Add(currentBlock);
        }

        yield return commentBlocks;
    }

    /// <summary>
    ///  Replaces all comments in the document with GUIDs.
    /// </summary>
    /// <param name="document">The document to process.</param>
    /// <returns>A tuple containing the updated document and a list of comment blocks.</returns>
    /// <remarks>
    ///  <para>
    ///   This method traverses the syntax tree of the provided document and replaces each
    ///   comment with a unique GUID. The original comments are stored in a list of comment
    ///   blocks, each associated with the corresponding GUID.
    ///  </para>
    ///  <para>
    ///   The method returns the updated document and the list of comment blocks, which can
    ///   be used to restore the original comments if needed.
    ///  </para>
    /// </remarks>
    public static async Task<(Document, List<CommentBlock>)> ReplaceCommentsByGuids(
        this Document document)
    {
        SyntaxNode? root = (await document.GetSyntaxRootAsync())
            ?? throw new InvalidOperationException("Document has no syntax root");

        List<CommentBlock> commentBlocks = [];

        SyntaxNode? newRoot = root.ReplaceTrivia(root.DescendantTrivia(), (original, rewritten) =>
        {
            if (original.IsKind(SyntaxKind.SingleLineCommentTrivia) || original.IsKind(SyntaxKind.MultiLineCommentTrivia))
            {
                string guid = System.Guid.NewGuid().ToString();
                CommentBlock commentBlock = new()
                {
                    Guid = guid,
                    Comment = [original]
                };
                commentBlocks.Add(commentBlock);
                return SyntaxFactory.Comment($"/* {guid} */");
            }
            return original;
        });

        return (document.WithSyntaxRoot(newRoot), commentBlocks);
    }

    /// <summary>
    ///  Replaces GUIDs in the document with the original comments.
    /// </summary>
    /// <param name="document">The document to process.</param>
    /// <param name="commentBlocks">The list of comment blocks containing the original comments.</param>
    /// <returns>A tuple containing the updated document and the list of comment blocks.</returns>
    /// <remarks>
    ///  <para>
    ///   This method traverses the syntax tree of the provided document and replaces each
    ///   GUID with the corresponding original comment from the list of comment blocks.
    ///  </para>
    ///  <para>
    ///   The method returns the updated document and the list of comment blocks, which can
    ///   be used to verify the restoration of the original comments.
    ///  </para>
    /// </remarks>
    public static async Task<(Document, List<CommentBlock>)> ReplaceGuidsByComments(
        this Document document, List<CommentBlock> commentBlocks)
    {
        SyntaxNode? root = (await document.GetSyntaxRootAsync())
            ?? throw new InvalidOperationException("Document has no syntax root");

        SyntaxNode? newRoot = root.ReplaceTrivia(root.DescendantTrivia(), (original, rewritten) =>
        {
            if (original.IsKind(SyntaxKind.MultiLineCommentTrivia))
            {
                string commentText = original.ToString();
                string guid = commentText[3..^3].Trim();
                CommentBlock? commentBlock = commentBlocks.FirstOrDefault(cb => cb.Guid == guid);
                if (commentBlock != null)
                {
                    return commentBlock.Comment.First();
                }
            }
            return original;
        });

        return (document.WithSyntaxRoot(newRoot), commentBlocks);
    }

    /// <summary>
    ///  Normalizes the start of the document by adding a copyright comment and sorting using directives.
    /// </summary>
    /// <param name="document">The document to normalize.</param>
    /// <param name="CopyrightText">The copyright text to add as a comment at the start of the document.</param>
    /// <returns>The updated document.</returns>
    /// <remarks>
    ///  <para>
    ///   This method adds a copyright comment at the start of the document if the provided
    ///   copyright text is not empty. It also sorts the using directives in alphabetical
    ///   order and converts the namespace declaration to a file-scoped namespace if applicable.
    ///  </para>
    ///  <para>
    ///   The method returns the updated document with the normalized start, ensuring a
    ///   consistent structure and style.
    ///  </para>
    /// </remarks>
    public static async Task<Document> NormalizeDocumentStartAsync(
        this Document document, string CopyrightText)
    {
        SyntaxNode? root = (await document.GetSyntaxRootAsync())
            ?? throw new InvalidOperationException("Document has no syntax root");

        SyntaxNode newRoot = root;

        if (!string.IsNullOrEmpty(CopyrightText))
        {
            SyntaxTrivia copyrightComment = SyntaxFactory.Comment($"/* {CopyrightText} */");
            newRoot = newRoot.WithLeadingTrivia(copyrightComment);
        }

        List<UsingDirectiveSyntax> usings = [.. newRoot
            .DescendantNodes()
            .OfType<UsingDirectiveSyntax>()];

        if (usings.Count != 0)
        {

            List<UsingDirectiveSyntax> sortedUsings =
                [.. usings.OrderBy(u => u.Name!.ToString())];

            newRoot = newRoot.RemoveNodes(
                    usings,
                    SyntaxRemoveOptions.KeepNoTrivia)!;

            if (newRoot is CompilationUnitSyntax compilationUnit)
            {
                newRoot = compilationUnit.AddUsings([.. sortedUsings]);
            }
            else
            {
                newRoot = newRoot.InsertNodesBefore(
                    newRoot.ChildNodes().First(),
                    sortedUsings);
            }
        }

        NamespaceDeclarationSyntax? namespaceDeclaration = newRoot
            .DescendantNodes()
            .OfType<NamespaceDeclarationSyntax>()
            .FirstOrDefault();

        if (namespaceDeclaration is not null)
        {
            FileScopedNamespaceDeclarationSyntax fileScopedNamespace =
                SyntaxFactory.FileScopedNamespaceDeclaration(namespaceDeclaration.Name)
                    .WithMembers(namespaceDeclaration.Members)
                    .WithLeadingTrivia(namespaceDeclaration.GetLeadingTrivia())
                    .WithTrailingTrivia(namespaceDeclaration.GetTrailingTrivia());

            newRoot = newRoot.ReplaceNode(namespaceDeclaration, fileScopedNamespace);
        }

        return document.WithSyntaxRoot(newRoot);
    }
}
