using CommunityToolkit.Roslyn.CSharp.Extensions;
using CommunityToolkit.WinForms.BasicTests.TestSupport;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.Roslyn.CSharp;

public class TypeDeclarationExtensionsTests
{
    private const string SubDirectoryPath = "Roslyn/CSharp/Modernization";

    public static TheoryData<string> GetTestFiles()
    {
        List<string> files =
        [
            "ToolStripDesignerUtils.cs"
        ];

        string targetDirectory = TestDataDiscovery.GetTestDataDirectoryPath(
            subDirectoryPath: SubDirectoryPath);

        return TestDataDiscovery.GetTheoryDataFromFiles(files, targetDirectory);
    }

    [Theory]
    [MemberData(nameof(GetTestFiles))]
    public async Task CS_TypeDeclarationExtensions_ListOfMemberKinds(string filename)
    {
        AdhocWorkspace workspace = null!;
        workspace = workspace.CreateWorkspaceFromSourceFiles([filename]);

        Document document = workspace.GetFirstDocument();
        Assert.NotNull(document);

        TypeDeclarationSyntax typeDeclarationSyntax = await document.GetSingleTypeAsync();
        Assert.NotNull(typeDeclarationSyntax);

        var memberKinds = typeDeclarationSyntax.GetMemberKinds();
        Assert.NotEmpty(memberKinds);

        var memberKindLookup = typeDeclarationSyntax.GetMemberDictionary();
        var memberLookup = memberKindLookup.FlattenKindsToMembers();

        // Iterate through the member-lookup-Table and assign the
        // context to a debug-string:
        Assert.NotEmpty(memberLookup);

        foreach (var member in memberLookup)
        {
            Assert.NotNull(member);
            string debugString = member.ToFullString();
        }

        // Get the semantic model and the diagnostics:
        SemanticModel? semanticModel = await document.GetSemanticModelAsync();
        Assert.NotNull(semanticModel);
    }
}
