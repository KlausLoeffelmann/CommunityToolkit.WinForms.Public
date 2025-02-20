using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics.CodeAnalysis;

namespace CommunityToolkit.Roslyn.CSharp.Extensions;

public static class WorkspaceExtensions
{
    /// <summary>
    ///  Creates an AdhocWorkspace from a collection of source files.
    /// </summary>
    /// <param name="workspace">The workspace to add the project to.</param>
    /// <param name="sourceCodeFiles">The source code files to add to the project.</param>
    /// <param name="defaultName">The default name for the solution.</param>
    /// <param name="defaultProjectName">The default name for the project.</param>
    /// <returns>The created AdhocWorkspace.</returns>
    /// <remarks>
    ///  <para>
    ///   This method initializes an AdhocWorkspace if one is not provided, and creates a new project
    ///   within that workspace. It then adds documents to the project from the provided source code files.
    ///  </para>
    ///  <para>
    ///   The method also attempts to apply changes to the workspace and returns the modified workspace.
    ///  </para>
    /// </remarks>
    [return: NotNull]
    public static AdhocWorkspace CreateWorkspaceFromSourceFiles(
        this AdhocWorkspace? workspace,
        IEnumerable<string> sourceCodeFiles,
        string? defaultName = null,
        string? defaultProjectName = null)
    {
        workspace ??= new AdhocWorkspace();

        defaultName ??= Path.GetFileNameWithoutExtension(
            workspace.CurrentSolution.FilePath ?? $"Solution-{DateTime.Now:yy-MM-dd HH-mm-ss}.sln");

        defaultProjectName ??= defaultName;

        Project project = workspace.AddProject(defaultProjectName, LanguageNames.CSharp);

        foreach (var sourceCodeFile in sourceCodeFiles)
        {
            project = project.AddDocument(
                name: Path.GetFileName(sourceCodeFile),
                text: SourceText.From(File.ReadAllText(sourceCodeFile))).Project;
        }

        workspace.TryApplyChanges(project.Solution);

        return workspace;
    }

    [return: NotNull]
    public static AdhocWorkspace CreateWorkspaceFromString(
        this AdhocWorkspace? workspace,
        string sourceContent,
        string? defaultName = null,
        string? defaultProjectName = null)
    {
        workspace ??= new AdhocWorkspace();

        defaultName ??= Path.GetFileNameWithoutExtension(
            workspace.CurrentSolution.FilePath ?? $"Solution-{DateTime.Now:yy-MM-dd HH-mm-ss}.sln");

        defaultProjectName ??= defaultName;
        Project project = workspace.AddProject(defaultProjectName, LanguageNames.CSharp);

        project = project.AddDocument(
            name: "Source.cs",
            text: SourceText.From(sourceContent)).Project;
        workspace.TryApplyChanges(project.Solution);

        return workspace;
    }

    /// <summary>
    ///  Gets the first project in the workspace or returns null if no projects exist.
    /// </summary>
    /// <param name="workspace">The workspace to search for projects.</param>
    /// <returns>The first project in the workspace or null if no projects exist.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first project from the current solution in the provided workspace.
    ///   If no projects are found, it returns null.
    ///  </para>
    /// </remarks>
    public static Project? GetFirstProjectOrDefault(
        this AdhocWorkspace workspace)
    {
        return workspace
            .CurrentSolution
            .Projects
            .FirstOrDefault();
    }

    /// <summary>
    ///  Gets the first project in the workspace.
    /// </summary>
    /// <param name="workspace">The workspace to search for projects.</param>
    /// <returns>The first project in the workspace.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first project from the current solution in the provided workspace.
    ///   If no projects are found, it throws an InvalidOperationException.
    ///  </para>
    /// </remarks>
    public static Project? GetFirstProject(
        this AdhocWorkspace workspace)
    {
        return workspace
            .CurrentSolution
            .Projects
            .First();
    }

    /// <summary>
    ///  Gets the first document in the first project of the workspace or returns null if no documents exist.
    /// </summary>
    /// <param name="workspace">The workspace to search for documents.</param>
    /// <returns>The first document in the first project of the workspace or null if no documents exist.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first document from the first project in the current solution of the
    ///   provided workspace. If no documents are found, it returns null.
    ///  </para>
    /// </remarks>
    public static Document? GetFirstDocumentOrDefault(
        this AdhocWorkspace workspace)
    {
        return workspace
            .CurrentSolution
            .Projects
            .First()
            .Documents
            .FirstOrDefault();
    }

    /// <summary>
    ///  Gets the first document in the first project of the workspace.
    /// </summary>
    /// <param name="workspace">The workspace to search for documents.</param>
    /// <returns>The first document in the first project of the workspace.</returns>
    /// <remarks>
    ///  <para>
    ///   This method retrieves the first document from the first project in the current solution of the
    ///   provided workspace. If no documents are found, it throws an InvalidOperationException.
    ///  </para>
    /// </remarks>
    public static Document GetFirstDocument(
        this AdhocWorkspace workspace)
    {
        return workspace
            .CurrentSolution
            .Projects
            .First()
            .Documents
            .First();
    }
}
