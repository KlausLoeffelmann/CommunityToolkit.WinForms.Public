using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Diagnostics.CodeAnalysis;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;

/// <summary>
///  Provides extension methods for <see cref="MemberDeclarationSyntax"/>.
/// </summary>
/// <remarks>
///  <para>
///   This class contains various extension methods to work with member declarations in C# syntax trees.
///  </para>
/// </remarks>
public static class MemberDeclarationExtensions
{
    /// <summary>
    ///  Gets the name of the member or a default name if the member does not have a name.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <param name="defaultName">The default name to return if the member does not have a name.</param>
    /// <returns>The name of the member or the default name.</returns>
    /// <remarks>
    ///  <para>
    ///   This method uses pattern matching to determine the type of the member and retrieve its name.
    ///  </para>
    /// </remarks>
    [return: NotNullIfNotNull(nameof(defaultName))]
    public static string? GetNameOrDefault(
        this MemberDeclarationSyntax member,
        string? defaultName = null) => member switch
        {
            FieldDeclarationSyntax field => field.Declaration.Variables.FirstOrDefault()?.Identifier.Text,
            PropertyDeclarationSyntax property => property.Identifier.Text,
            MethodDeclarationSyntax method => method.Identifier.Text,
            ConstructorDeclarationSyntax constructor => constructor.Identifier.Text,
            DestructorDeclarationSyntax destructor => destructor.Identifier.Text,
            IndexerDeclarationSyntax indexer => indexer.ThisKeyword.Text,
            OperatorDeclarationSyntax @operator => @operator.OperatorToken.Text,
            ConversionOperatorDeclarationSyntax conversionOperator => conversionOperator.ImplicitOrExplicitKeyword.Text,
            EventDeclarationSyntax @event => @event.Identifier.Text,
            DelegateDeclarationSyntax @delegate => @delegate.Identifier.Text,
            ClassDeclarationSyntax @class => @class.Identifier.Text,
            InterfaceDeclarationSyntax @interface => @interface.Identifier.Text,
            StructDeclarationSyntax @struct => @struct.Identifier.Text,
            EnumDeclarationSyntax @enum => @enum.Identifier.Text,
            NamespaceDeclarationSyntax @namespace => @namespace.Name.ToString(),
            _ => defaultName,
        };

    /// <summary>
    ///  Gets the next segment of source code members starting from the specified index.
    /// </summary>
    /// <param name="members">The array of member declarations.</param>
    /// <param name="startIndex">The starting index.</param>
    /// <param name="maxCodeLines">The maximum number of code lines for the segment.</param>
    /// <returns>An array of member declarations in the next segment.</returns>
    /// <remarks>
    ///  <para>
    ///   This method gathers members until the total number of code lines reaches the specified maximum.
    ///  </para>
    /// </remarks>
    public static MemberDeclarationSyntax[] GetNextSourceCodeSegment(
        this MemberDeclarationSyntax[] members,
        int startIndex,
        int maxCodeLines)
    {
        List<MemberDeclarationSyntax> segment = [];
        int currentCodeLines = 0;

        for (int i = startIndex; i < members.Length; i++)
        {
            MemberDeclarationSyntax member = members[i];
            segment.Add(member);

            // Count the number of code lines in the member
            int memberCodeLines = member.GetCodeLines().Length;

            // If adding this member exceeds the max code lines, break
            if (currentCodeLines + memberCodeLines > maxCodeLines)
            {
                break;
            }

            currentCodeLines += memberCodeLines;
        }

        return [.. segment];
    }

    /// <summary>
    ///  Gets the code lines of the member.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns>An array of code lines.</returns>
    /// <remarks>
    ///  <para>
    ///   This method converts the member to a full string and splits it into lines.
    ///  </para>
    /// </remarks>
    public static string[] GetCodeLines(this MemberDeclarationSyntax member) => member
            .ToFullString()
            .Split(
                separator: [Environment.NewLine],
                options: StringSplitOptions.None);

    /// <summary>
    ///  Determines whether the member is static.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is static; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the static modifier.
    ///  </para>
    /// </remarks>
    public static bool IsStatic(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.StaticKeyword);

    /// <summary>
    ///  Determines whether the member is public.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is public; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the public modifier.
    ///  </para>
    /// </remarks>
    public static bool IsPublic(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.PublicKeyword);

    /// <summary>
    ///  Determines whether the member is private.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is private; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the private modifier.
    ///  </para>
    /// </remarks>
    public static bool IsPrivate(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.PrivateKeyword);

    /// <summary>
    ///  Determines whether the member is protected.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is protected; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the protected modifier.
    ///  </para>
    /// </remarks>
    public static bool IsProtected(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.ProtectedKeyword);

    /// <summary>
    ///  Determines whether the member is internal.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is internal; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the internal modifier.
    ///  </para>
    /// </remarks>
    public static bool IsInternal(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.InternalKeyword);

    /// <summary>
    ///  Determines whether the member is abstract.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is abstract; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the abstract modifier.
    ///  </para>
    /// </remarks>
    public static bool IsAbstract(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.AbstractKeyword);

    /// <summary>
    ///  Determines whether the member is virtual.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is virtual; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the virtual modifier.
    ///  </para>
    /// </remarks>
    public static bool IsVirtual(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.VirtualKeyword);

    /// <summary>
    ///  Determines whether the member is an override.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an override; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the override modifier.
    ///  </para>
    /// </remarks>
    public static bool IsOverride(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.OverrideKeyword);

    /// <summary>
    ///  Determines whether the member is sealed.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is sealed; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the sealed modifier.
    ///  </para>
    /// </remarks>
    public static bool IsSealed(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.SealedKeyword);

    /// <summary>
    ///  Determines whether the member is read-only.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is read-only; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the read-only modifier.
    ///  </para>
    /// </remarks>
    public static bool IsReadOnly(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.ReadOnlyKeyword);

    /// <summary>
    ///  Determines whether the member is a constant.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a constant; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member has the const modifier.
    ///  </para>
    /// </remarks>
    public static bool IsConst(this MemberDeclarationSyntax member) => member.Modifiers.Any(SyntaxKind.ConstKeyword);

    /// <summary>
    ///  Determines whether the member is an event.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an event; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is an event declaration.
    ///  </para>
    /// </remarks>
    public static bool IsEvent(this MemberDeclarationSyntax member) => member is EventDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a field.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a field; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a field declaration.
    ///  </para>
    /// </remarks>
    public static bool IsField(this MemberDeclarationSyntax member) => member is FieldDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a property.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a property; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a property declaration.
    ///  </para>
    /// </remarks>
    public static bool IsProperty(this MemberDeclarationSyntax member) => member is PropertyDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a method.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a method; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a method declaration.
    ///  </para>
    /// </remarks>
    public static bool IsMethod(this MemberDeclarationSyntax member) => member is MethodDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a constructor.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a constructor; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a constructor declaration.
    ///  </para>
    /// </remarks>
    public static bool IsConstructor(this MemberDeclarationSyntax member) => member is ConstructorDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a destructor.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a destructor; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a destructor declaration.
    ///  </para>
    /// </remarks>
    public static bool IsDestructor(this MemberDeclarationSyntax member) => member is DestructorDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is an indexer.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an indexer; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is an indexer declaration.
    ///  </para>
    /// </remarks>
    public static bool IsIndexer(this MemberDeclarationSyntax member) => member is IndexerDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is an operator.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an operator; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is an operator declaration.
    ///  </para>
    /// </remarks>
    public static bool IsOperator(this MemberDeclarationSyntax member) => member is OperatorDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a conversion operator.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a conversion operator; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a conversion operator declaration.
    ///  </para>
    /// </remarks>
    public static bool IsConversionOperator(this MemberDeclarationSyntax member) => member is ConversionOperatorDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a class.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a class; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a class declaration.
    ///  </para>
    /// </remarks>
    public static bool IsClass(this MemberDeclarationSyntax member) => member is ClassDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is an interface.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an interface; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is an interface declaration.
    ///  </para>
    /// </remarks>
    public static bool IsInterface(this MemberDeclarationSyntax member) => member is InterfaceDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a struct.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a struct; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a struct declaration.
    ///  </para>
    /// </remarks>
    public static bool IsStruct(this MemberDeclarationSyntax member) => member is StructDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is an enum.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is an enum; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is an enum declaration.
    ///  </para>
    /// </remarks>
    public static bool IsEnum(this MemberDeclarationSyntax member) => member is EnumDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a delegate.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a delegate; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a delegate declaration.
    ///  </para>
    /// </remarks>
    public static bool IsDelegate(this MemberDeclarationSyntax member) => member is DelegateDeclarationSyntax;

    /// <summary>
    ///  Determines whether the member is a namespace.
    /// </summary>
    /// <param name="member">The member declaration syntax.</param>
    /// <returns><c>true</c> if the member is a namespace; otherwise, <c>false</c>.</returns>
    /// <remarks>
    ///  <para>
    ///   Checks if the member is a namespace declaration.
    ///  </para>
    /// </remarks>
    public static bool IsNamespace(this MemberDeclarationSyntax member) => member is NamespaceDeclarationSyntax;
}
