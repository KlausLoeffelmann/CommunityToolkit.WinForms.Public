using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CommunityToolkit.WinForms.Controls.Tooling.Roslyn;

public class RoslynSourceView : RichTextBox
{
    private Document? _codeDocument;
    private Workspace? _workspace;

    private const string CodeFontName= "Cascadia Code";

    private static readonly Color DefaultDarkModeBackColor = Color.FromArgb(30, 30, 30);
    private static readonly Color DefaultDarkModeForeColor = Color.White;

    private static readonly Color EditorGeneric = GetColorFromHexString("dcdcdc");
    private static readonly Color EditorKeyWord = GetColorFromHexString("569cd6");
    private static readonly Color EditorFieldIdentifier = GetColorFromHexString("9cdcfe");
    private static readonly Color EditorClassIdentifier = GetColorFromHexString("266c3f");
    private static readonly Color EditorComment = GetColorFromHexString("4ec9b0");
    private static readonly Color EditorStruct = GetColorFromHexString("86c691");

    private static Color GetColorFromHexString(string v)
    {
        if (v.Length == 3)
        {
            v = string.Concat(v[0], v[0], v[1], v[1], v[2], v[2]);
        }
        else if (v.Length != 6)
        {
            throw new ArgumentException("Hex string should be 3 or 6 characters long.");
        }

        int r = Convert.ToInt32(v[..2], 16);
        int g = Convert.ToInt32(v.Substring(2, 2), 16);
        int b = Convert.ToInt32(v.Substring(4, 2), 16);

        return Color.FromArgb(r, g, b);
    }

    public RoslynSourceView()
    {
        // Let's disable editing:
        ReadOnly = true;

        if (Application.IsDarkModeEnabled)
        {
            BackColor = DefaultDarkModeBackColor;
            ForeColor = DefaultDarkModeForeColor;
        }
    }

    public Document? Document => _codeDocument;

    protected override void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        // When we get a new Parent, we set the Font 2 points bigger than the parent's font,
        // and we are also going for a monospaced font:
        if (Parent is not null)
        {
            Font = new Font(CodeFontName, Parent.Font.Size + 3);
        }
    }

    private bool ShouldSerializeBackColor() 
        => Application.IsDarkModeEnabled 
            ? BackColor != DefaultDarkModeBackColor 
            : BackColor != DefaultBackColor;

    private bool ShouldSerializeForeColor()
        => Application.IsDarkModeEnabled
            ? ForeColor != DefaultDarkModeForeColor
            : ForeColor != DefaultForeColor;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string Text
    {
        get => base.Text;
        private set => base.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string? Rtf
    {
        get => base.Rtf;
        private set => base.Rtf = value;
    }

    // We shadow the Font property, because we don't want to serialize it.
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Font Font
    {
        get => base.Font;
        set => base.Font = value;
    }

    public async Task SetSourceCodeAsync(string sourceCode, string? filename)
    {
        if (string.IsNullOrEmpty(sourceCode))
        {
            throw new ArgumentException("Source code cannot be null or empty.", nameof(sourceCode));
        }

        if (string.IsNullOrEmpty(filename))
        {
            filename = "* untitled";
        }

        AdhocWorkspace workspace = new();
        _workspace = workspace;

        Project project = workspace.AddProject("TempProject", LanguageNames.CSharp);
        Document document = workspace.AddDocument(project.Id, filename, SourceText.From(sourceCode));

        // We need to format the document now:
        document = await Formatter.FormatAsync(document);

        _codeDocument = document;

        string rtf = await ColorCodeRtf();
        Rtf = rtf;
    }

    private async Task<string> ColorCodeRtf()
    {
        if (_codeDocument is null)
        {
            throw new InvalidOperationException("Code document is not set.");
        }

        SourceText docText = await _codeDocument.GetTextAsync();

        string debugText = docText.ToString();

        var classifiedSpans = MergingClassifier.EnumerateClassifiedSpansAsync(_codeDocument);

        StringBuilder rtfBuilder = new();
        rtfBuilder.Append(@"{\rtf1\ansi");

        // Define the color table
        rtfBuilder.Append(@"{\colortbl ;");
        rtfBuilder.Append(GetRtfColor(EditorGeneric));
        rtfBuilder.Append(GetRtfColor(EditorKeyWord));
        rtfBuilder.Append(GetRtfColor(EditorFieldIdentifier));
        rtfBuilder.Append(GetRtfColor(EditorComment));
        rtfBuilder.Append(GetRtfColor(EditorComment));
        rtfBuilder.Append(GetRtfColor(EditorClassIdentifier));
        rtfBuilder.Append(GetRtfColor(EditorStruct));
        rtfBuilder.Append('}');

        // Start writing the content
        await foreach (var classifiedSpan in classifiedSpans)
        {
            var spanText = docText.ToString(classifiedSpan.TextSpan);

            // Escape the text for RTF. 
            // This is a simple approach that handles braces and backslashes.
            spanText = EscapeForRtf(spanText);

            var colorIndex = GetColorForClassification(classifiedSpan.ClassificationType);
            rtfBuilder.Append($@"\cf{colorIndex} {spanText}");
        }

        rtfBuilder.Append('}');
        return rtfBuilder.ToString();

        static int GetColorForClassification(string classificationType)
            => classificationType switch
            {
                ClassificationTypeNames.Keyword => 2,
                ClassificationTypeNames.Identifier => 3,
                ClassificationTypeNames.Comment => 4,
                ClassificationTypeNames.StringLiteral => 5,
                ClassificationTypeNames.ClassName => 6,
                ClassificationTypeNames.StructName => 7,
                ClassificationTypeNames.FieldName => 3,
                ClassificationTypeNames.InterfaceName => 6,
                ClassificationTypeNames.EnumName => 7,
                _ => 1, // 0 => default color (white/black)
            };

        static string EscapeForRtf(string text)
        {
            // RTF requires braces, backslash, and other special chars to be escaped.
            // This is the minimal approach for braces and backslashes:
            StringBuilder sb = new(text.Length);
            foreach (char c in text)
            {
                switch (c)
                {
                    case '\\': sb.Append(@"\\"); break;
                    case '{': sb.Append(@"\{"); break;
                    case '}': sb.Append(@"\}"); break;
                    case '\n': sb.Append(@"\par "); break; // Newline
                    case '\r': break; // Ignore carriage return
                    case '\t': sb.Append(@"\tab "); break; // Tab
                    case ' ': sb.Append(@"\~"); break; // Space
                    default: sb.Append(c); break;
                }
            }

            return sb.ToString();
        }

        static string GetRtfColor(Color color)
        {
            return $@"\red{color.R}\green{color.G}\blue{color.B};";
        }
    }
}

/// <summary>
///  Provide a way to iterate through classified and unclassified text spans
///  to include white spaces and complete other trivia in the return stream.
/// </summary>
public static class MergingClassifier
{
    public static async IAsyncEnumerable<ClassifiedSpan> EnumerateClassifiedSpansAsync(
        Document document,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var docText = await document.GetTextAsync(cancellationToken);
        var classifiedSpans = await Classifier.GetClassifiedSpansAsync(
            document,
            new TextSpan(0, docText.Length),
            cancellationToken);

        int lastEnd = 0;

        foreach (var span in classifiedSpans.OrderBy(s => s.TextSpan.Start))
        {
            if (span.TextSpan.Start > lastEnd)
            {
                yield return new ClassifiedSpan(
                    ClassificationTypeNames.Text,
                    TextSpan.FromBounds(lastEnd, span.TextSpan.Start));
            }

            yield return span;
            lastEnd = span.TextSpan.End;
        }

        if (lastEnd < docText.Length)
        {
            yield return new ClassifiedSpan(
                ClassificationTypeNames.Text,
                TextSpan.FromBounds(lastEnd, docText.Length));
        }
    }

}