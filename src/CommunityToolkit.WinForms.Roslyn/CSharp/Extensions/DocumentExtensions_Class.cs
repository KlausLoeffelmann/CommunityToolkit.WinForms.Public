using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;


/// <summary>
///  Provides extension methods for working with Roslyn documents.
/// </summary>
/// <remarks>
///  <para>
///   This class contains methods to retrieve class declarations from a Roslyn document.
///   It includes methods to get all classes, nested classes, and specific class declarations.
///  </para>
/// </remarks>
public static partial class DocumentExtensions
{
    /// <summary>
    ///  Gets all top-level class declarations in the document.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>An enumerable of top-level class declarations.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves all top-level class declarations in the provided document.
    ///   It first finds the first class declaration and then retrieves all class declarations
    ///   at the same level as the first one.
    ///  </para>
    /// </remarks>
    public static async Task<IEnumerable<ClassDeclarationSyntax>> GetClassesAsync(
        this Document document)
    {
        var root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
        var first = root?.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

        if (first is not null)
        {
            var parent = first.Parent ?? throw new NullReferenceException(nameof(first));
            return parent.ChildNodes().OfType<ClassDeclarationSyntax>();
        }

        return [];
    }

    /// <summary>
    ///  Gets all class declarations, including nested classes, in the document.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>An enumerable of all class declarations.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves all class declarations in the provided document, including
    ///   nested classes. It searches through all descendant nodes to find class declarations.
    ///  </para>
    /// </remarks>
    public static async Task<IEnumerable<ClassDeclarationSyntax>> GetClassesAndNestedClassesAsync(
        this Document document)
    {
        var root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
        return root?.DescendantNodes().OfType<ClassDeclarationSyntax>() ?? [];
    }

    /// <summary>
    ///  Gets the count of class declarations in the document.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>The count of class declarations.</returns>
    /// <remarks>
    ///  <para>
    ///   This method returns the total number of class declarations in the provided document,
    ///   including nested classes.
    ///  </para>
    /// </remarks>
    public static async Task<int> GetClassCountAsync(this Document document)
        => (await document.GetClassesAndNestedClassesAsync().ConfigureAwait(false)).Count();

    /// <summary>
    ///  Gets the first class declaration in the document.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>The first class declaration.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first class declaration in the provided document. If no
    ///   class declarations are found, it throws an <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    public static async Task<ClassDeclarationSyntax> GetFirstClassAsync(
        this Document document)
    {
        var classes = await document.GetClassesAndNestedClassesAsync().ConfigureAwait(false);
        return classes.FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any class declarations.");
    }

    /// <summary>
    ///  Gets the first class declaration in the document or null if none exist.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>The first class declaration or null.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first class declaration in the provided document. If no
    ///   class declarations are found, it returns null.
    ///  </para>
    /// </remarks>
    public static async Task<ClassDeclarationSyntax?> GetFirstClassOrDefaultAsync(
        this Document document)
        => (await document.GetClassesAndNestedClassesAsync().ConfigureAwait(false)).FirstOrDefault();

    /// <summary>
    ///  Gets the single top-level class declaration in the document.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>The single top-level class declaration.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level class declaration in the provided document.
    ///   If no class declarations are found or if there is more than one, it throws an
    ///   <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    public static async Task<ClassDeclarationSyntax> GetSingleClassAsync(
        this Document document)
    {
        var classDeclaration = (await document.GetClassesAndNestedClassesAsync().ConfigureAwait(false))
            .FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any class declarations.");

        return (ClassDeclarationSyntax)ValidateSingleTypeDeclaration(classDeclaration);
    }

    /// <summary>
    ///  Gets the single top-level class declaration in the document or null if none exist.
    /// </summary>
    /// <param name="document">The Roslyn document to search.</param>
    /// <returns>The single top-level class declaration or null.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level class declaration in the provided document.
    ///   If no class declarations are found, it returns null. If more than one class declaration
    ///   is found, it throws an <see cref="InvalidOperationException"/>.
    ///  </para>
    /// </remarks>
    public static async Task<ClassDeclarationSyntax?> GetSingleClassOrDefaultAsync(
        this Document document)
    {
        var classDeclaration = (await document.GetClassesAndNestedClassesAsync().ConfigureAwait(false))
            .FirstOrDefault();

        return classDeclaration is null
            ? null
            : (ClassDeclarationSyntax)ValidateSingleTypeDeclaration(classDeclaration);
    }
}
