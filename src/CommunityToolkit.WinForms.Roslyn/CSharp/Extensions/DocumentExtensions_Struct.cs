using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;

public static partial class DocumentExtensions
{
    /// <summary>
    ///  Gets all struct declarations and nested struct declarations in the document.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves all struct declarations, including nested ones, from the syntax tree of the
    ///   provided document. It returns an enumerable collection of <see cref="StructDeclarationSyntax"/>.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to search for struct declarations.</param>
    /// <returns>An enumerable collection of struct declarations.</returns>
    public static async Task<IEnumerable<StructDeclarationSyntax>> GetStructsAndNestedStructsAsync(
        this Document document)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync().ConfigureAwait(false);

        return root?.DescendantNodes().OfType<StructDeclarationSyntax>()
            ?? [];
    }

    /// <summary>
    ///  Gets the count of struct declarations in the document.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method counts all struct declarations, including nested ones, in the provided document.
    ///   It uses the <see cref="GetStructsAndNestedStructsAsync"/> method to retrieve the struct declarations
    ///   and then returns the count.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to count struct declarations in.</param>
    /// <returns>The count of struct declarations.</returns>
    public static async Task<int> GetStructCountAsync(this Document document)
        => (await document.GetStructsAndNestedStructsAsync().ConfigureAwait(false)).Count();

    /// <summary>
    ///  Gets the first struct declaration in the document.
    ///  Throws if none exist.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first struct declaration from the provided document. If no struct declarations
    ///   are found, it throws an <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to search for the first struct declaration.</param>
    /// <returns>The first struct declaration.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no struct declarations are found.</exception>
    public static async Task<StructDeclarationSyntax> GetFirstStructAsync(
        this Document document)
    {
        IEnumerable<StructDeclarationSyntax> structs = await document.GetStructsAndNestedStructsAsync().ConfigureAwait(false);

        return structs.FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any struct declarations.");
    }

    /// <summary>
    ///  Gets the first struct declaration in the document or null if none exist.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first struct declaration from the provided document. If no struct declarations
    ///   are found, it returns null.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to search for the first struct declaration.</param>
    /// <returns>The first struct declaration or null if none exist.</returns>
    public static async Task<StructDeclarationSyntax?> GetFirstStructOrDefaultAsync(
        this Document document)
        => (await document.GetStructsAndNestedStructsAsync().ConfigureAwait(false)).FirstOrDefault();

    /// <summary>
    ///  Gets the single top-level struct declaration in the document.
    ///  Throws if none exist or if there is more than one.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level struct declaration from the provided document. If no struct
    ///   declarations are found or if there is more than one, it throws an <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to search for the single struct declaration.</param>
    /// <returns>The single top-level struct declaration.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no struct declarations are found or if there is more than one.</exception>
    public static async Task<StructDeclarationSyntax> GetSingleStructAsync(
        this Document document)
    {
        StructDeclarationSyntax structDeclaration = (await document.GetStructsAndNestedStructsAsync().ConfigureAwait(false))
            .FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any struct declarations.");

        return (StructDeclarationSyntax)ValidateSingleTypeDeclaration(structDeclaration);
    }

    /// <summary>
    ///  Gets the single top-level struct declaration in the document or null if none exist.
    ///  Throws if more than one struct declaration is found.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level struct declaration from the provided document. If no struct
    ///   declarations are found, it returns null. If more than one struct declaration is found, it throws an
    ///   <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    /// <param name="document">The document to search for the single struct declaration.</param>
    /// <returns>The single top-level struct declaration or null if none exist.</returns>
    /// <exception cref="InvalidOperationException">Thrown if more than one struct declaration is found.</exception>
    public static async Task<StructDeclarationSyntax?> GetSingleStructOrDefaultAsync(
        this Document document)
    {
        StructDeclarationSyntax? structDeclaration = (await document.GetStructsAndNestedStructsAsync().ConfigureAwait(false))
            .FirstOrDefault();

        return structDeclaration is null
            ? null
            : (StructDeclarationSyntax)ValidateSingleTypeDeclaration(structDeclaration);
    }
}
