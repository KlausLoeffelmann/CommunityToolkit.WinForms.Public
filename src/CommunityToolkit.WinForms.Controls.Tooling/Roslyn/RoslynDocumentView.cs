using CommunityToolkit.Roslyn.Tooling;
using System.ComponentModel;

namespace CommunityToolkit.WinForms.Controls.Tooling.Roslyn;

public partial class RoslynDocumentView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoslynDocumentView"/> class.
    /// </summary>
    public RoslynDocumentView()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gets the listing file.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CodeBlockInfo? CodeBlockInfo { get; private set; }

    /// <summary>
    /// Gets the source code viewer.
    /// </summary>
    public RoslynSourceView RoslynSourceView => _sourceCodeViewer;

    /// <summary>
    /// Saves the listing file asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no listing file is set.</exception>
    public async Task SaveFileAsync(string basePath)
    {
        if (string.IsNullOrEmpty(CodeBlockInfo?.Filename))
        {
            throw new InvalidOperationException("No listing file set.");
        }

        string filename = Path.Combine(basePath, CodeBlockInfo.Value.Filename)
            ?? throw new InvalidOperationException("No filename set.");

        // Let's save the file:
        await File.WriteAllTextAsync(filename, CodeBlockInfo.Value.Code);
    }

    /// <summary>
    /// Sets the listing file asynchronously.
    /// </summary>
    /// <param name="codeBlockInfo">The listing file to set.</param>
    /// <returns>A task that represents the asynchronous set operation.</returns>
    public async Task SetCodeBlockInfoAsync(CodeBlockInfo codeBlockInfo)
    {
        // Let's save the file:
        CodeBlockInfo = codeBlockInfo;

        _lblListingTitel.Text = codeBlockInfo.Type;

        await RoslynSourceView.SetSourceCodeAsync(
            sourceCode: codeBlockInfo.Code,
            filename: codeBlockInfo.Filename);
    }
}
