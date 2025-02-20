using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Chatty;

partial class FrmAbout : Form
{
    public FrmAbout()
    {
        InitializeComponent();

        Text = String.Format("About {0}", AssemblyTitle);
        
        (int lines, _lblProductname.Text) = StairFormat(AssemblyProduct);
        _lblProductname.Height = (int)(_lblProductname.Font.Height * 1.2 * lines);

        _lblVersion.Text = String.Format("Version {0}", AssemblyVersion);
        _lblCopyRight.Text = AssemblyCopyright;
        _lblCompany.Text = $"Company: {AssemblyCompany}";
        _lblAuthors.Text = $"Authors: {AssemblyAuthors}";
    }

    protected async override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await InvokeAsync(() =>
        {
            string rtf= LoadRtfContent();
            if (rtf != null)
            {
                _rtbChattyStory.Rtf = rtf;
            }
        });
    }

    private string LoadRtfContent()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string resourceName = "Chatty.Properties.ChattyBackground.rtf";

        using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                throw new InvalidOperationException($"Resource '{resourceName}' not found.");
            }

            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    private static (int lines, string result) StairFormat(string assemblyProduct)
    {
        string[] words = assemblyProduct.Split(
            separator: [' ', '-'],
            options: StringSplitOptions.RemoveEmptyEntries);

        StringBuilder result = new();
        int indent = 0;

        foreach (string word in words)
        {
            result.AppendLine(
                new string(' ', indent) + word);

            indent += 4;
        }

        return (words.Length, result.ToString());
    }

    public static string AssemblyTitle =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyTitleAttribute>()?
            .Title ?? Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);

    public static string AssemblyVersion =>
        Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;

    public static string AssemblyAuthors
    {
        get
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string? author = assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(a => a.Key == "Authors")?.Value;

            return author ?? string.Empty;
        }
    }

    public static string AssemblyDescription =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyDescriptionAttribute>()?
            .Description ?? string.Empty;

    public static string AssemblyProduct =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyProductAttribute>()?
            .Product ?? string.Empty;

    public static string AssemblyCopyright =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyCopyrightAttribute>()?
            .Copyright ?? string.Empty;

    public static string AssemblyCompany =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyCompanyAttribute>()?
            .Company ?? string.Empty;
}
