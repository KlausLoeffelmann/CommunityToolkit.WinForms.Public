using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;


public static partial class DocumentExtensions
{
    /// <summary>
    ///  Returns the source code as string of the document until the first curly brace of the first type declaration.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the source code of the document up to the first curly brace of the first type
    ///   declaration. It is useful for extracting the initial part of the document, such as the using directives
    ///   and namespace declarations.
    ///  </para>
    /// </remarks>
    public static async Task<string> GetDocumentIntroduction(this Document document)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
        TypeDeclarationSyntax? firstType = root?
            .DescendantNodes()
            .OfType<TypeDeclarationSyntax>()
            .FirstOrDefault();

        if (firstType == null)
        {
            return string.Empty;
        }

        Microsoft.CodeAnalysis.Text.SourceText text = await document.GetTextAsync().ConfigureAwait(false);
        TextSpan span = TextSpan.FromBounds(0, firstType.OpenBraceToken.SpanStart);

        return text.GetSubText(span).ToString();
    }

    /// <summary>
    ///  Replaces the source code of the document until the first curly brace of the first type declaration with the provided code.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method replaces the initial part of the document, up to the first curly brace of the first type
    ///   declaration, with the provided code. It is useful for modifying the initial part of the document, such as
    ///   the using directives and namespace declarations.
    ///  </para>
    /// </remarks>
    public static async Task<Document> ReplaceDocumentIntroductionAsync(this Document document, string newIntroductionCode)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync().ConfigureAwait(false);
        TypeDeclarationSyntax? firstType = root?
            .DescendantNodes()
            .OfType<TypeDeclarationSyntax>()
            .FirstOrDefault();

        if (firstType == null)
        {
            return document;
        }

        Microsoft.CodeAnalysis.Text.SourceText text = await document.GetTextAsync().ConfigureAwait(false);
        TextSpan span = TextSpan.FromBounds(0, firstType.OpenBraceToken.SpanStart);
        SourceText newText = text.WithChanges(new TextChange(span, newIntroductionCode));

        return document.WithText(newText);
    }

    /// <summary>
    ///  Gets all type declarations and nested type declarations in the document.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves all type declarations and nested type declarations in the document. It is useful for
    ///   analyzing the structure of the document and identifying all types defined within it.
    ///  </para>
    /// </remarks>
    public static async Task<IEnumerable<TypeDeclarationSyntax>> GetTypesAndNestedTypesAsync(this Document document)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync().ConfigureAwait(false);

        return root?.DescendantNodes().OfType<TypeDeclarationSyntax>()
            ?? [];
    }

    /// <summary>
    ///  Gets the count of type declarations in the document.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the count of type declarations in the document. It is useful for determining the
    ///   number of types defined within the document.
    ///  </para>
    /// </remarks>
    public static async Task<int> GetTypeCountAsync(this Document document)
        => (await document.GetTypesAndNestedTypesAsync().ConfigureAwait(false)).Count();

    /// <summary>
    ///  Gets the first type declaration in the document.
    ///  Throws if none exist.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first type declaration in the document. If no type declarations exist, it throws
    ///   an InvalidOperationException. It is useful for accessing the first type defined within the document.
    ///  </para>
    /// </remarks>
    public static async Task<TypeDeclarationSyntax> GetFirstTypeAsync(this Document document)
    {
        IEnumerable<TypeDeclarationSyntax> types = await document.GetTypesAndNestedTypesAsync().ConfigureAwait(false);

        return types.FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any type declarations.");
    }

    /// <summary>
    ///  Gets the first type declaration in the document or null if none exist.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first type declaration in the document or null if no type declarations exist. It
    ///   is useful for accessing the first type defined within the document without throwing an exception.
    ///  </para>
    /// </remarks>
    public static async Task<TypeDeclarationSyntax?> GetFirstTypeOrDefaultAsync(this Document document)
        => (await document.GetTypesAndNestedTypesAsync().ConfigureAwait(false)).FirstOrDefault();

    /// <summary>
    ///  Validates that the type is the only top-level type under its parent.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method validates that the provided type declaration is the only top-level type under its parent. If
    ///   there are multiple top-level types, it throws an InvalidOperationException. It is useful for ensuring that
    ///   the document contains a single top-level type declaration.
    ///  </para>
    /// </remarks>
    private static TypeDeclarationSyntax ValidateSingleTypeDeclaration(TypeDeclarationSyntax typeDeclaration)
    {
        if (typeDeclaration.Parent is not { } parent ||
            parent.ChildNodes().OfType<TypeDeclarationSyntax>().Count() != 1)
        {
            throw new InvalidOperationException(
                "The document contains more than one type declaration.");
        }

        return typeDeclaration;
    }

    /// <summary>
    ///  Gets the single top-level type declaration in the document.
    ///  Throws if none exist or if there is more than one.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level type declaration in the document. If no type declarations exist
    ///   or if there is more than one, it throws an InvalidOperationException. It is useful for accessing the single
    ///   top-level type defined within the document.
    ///  </para>
    /// </remarks>
    public static async Task<TypeDeclarationSyntax> GetSingleTypeAsync(this Document document)
    {
        TypeDeclarationSyntax typeDeclaration = (await document.GetTypesAndNestedTypesAsync().ConfigureAwait(false))
            .FirstOrDefault()
            ?? throw new InvalidOperationException(
                "The document does not contain any type declarations.");

        return ValidateSingleTypeDeclaration(typeDeclaration);
    }

    /// <summary>
    ///  Gets the single top-level type declaration in the document or null if none exist.
    ///  Throws if more than one type declaration is found.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the single top-level type declaration in the document or null if no type declarations
    ///   exist. If there is more than one type declaration, it throws an InvalidOperationException. It is useful for
    ///   accessing the single top-level type defined within the document without throwing an exception if none exist.
    ///  </para>
    /// </remarks>
    public static async Task<TypeDeclarationSyntax?> GetSingleTypeOrDefaultAsync(this Document document)
    {
        TypeDeclarationSyntax? typeDeclaration = (await document.GetTypesAndNestedTypesAsync().ConfigureAwait(false))
            .FirstOrDefault();

        return typeDeclaration is null
            ? null
            : ValidateSingleTypeDeclaration(typeDeclaration);
    }
}
