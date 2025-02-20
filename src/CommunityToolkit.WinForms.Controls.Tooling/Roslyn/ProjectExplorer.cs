using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.ComponentModel;

namespace CommunityToolkit.WinForms.Controls.Tooling.Roslyn;

public class ProjectExplorer : TreeView
{
    public ProjectExplorer()
    {
        // Set the TreeView to show lines and root lines
        ShowLines = true;
        ShowRootLines = true;
    }

    // Make sure, we do not expose those properties for serialization
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool ShowLines { get; }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool ShowRootLines { get; }

    public async Task<Workspace> LoadProjectAsync(string filename)
    {
        MSBuildWorkspace workspace = MSBuildWorkspace.Create();
        Project? project;

        if (Directory.Exists(filename))
        {
            var solution = await workspace.OpenSolutionAsync(filename);
            project = solution.Projects.FirstOrDefault();
        }
        else if (File.Exists(filename) && Path.GetExtension(filename) == ".csproj")
        {
            project = await workspace.OpenProjectAsync(filename);
        }
        else
        {
            throw new ArgumentException("The filename must be a valid directory or a .csproj file.", nameof(filename));
        }

        if (project == null)
        {
            throw new InvalidOperationException("No project found in the specified path.");
        }

        BuildDocumentAndFolderTree(project);

        return workspace;
    }

    public void BuildDocumentAndFolderTree(Project project)
    {
        Nodes.Clear();

        var root = new TreeNode(project.Name);
        Nodes.Add(root);
        root.Tag = project;

        foreach (var document in project.Documents)
        {
            var documentNode = new TreeNode(document.Name);
            root.Nodes.Add(documentNode);
            documentNode.Tag = document;
        }

        var folders = project
            .Documents
            .Select(d => Path.GetDirectoryName(d.FilePath)).Distinct();

        foreach (var folder in folders)
        {
            var folderNode = new TreeNode(folder);
            root.Nodes.Add(folderNode);
            folderNode.Tag = folder;
        }
    }

    public Document? FindDocumentByName(string documentName)
    {
            foreach (TreeNode childNode in Nodes[0].Nodes)
            {
                if (childNode.Text == documentName)
                {
                    return (Document?)childNode.Tag;
                }
            }

        return null;
    }
}
