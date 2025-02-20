using Chatty.ViewModels;

namespace Chatty.Views;

internal partial class FrmOptions : Form
{
    private OptionsViewModel _options;

    public FrmOptions()
    {
        InitializeComponent();
        _options = new OptionsViewModel();
    }

    internal FrmOptions(OptionsViewModel options)
    {
        InitializeComponent();
        _options = options;
    }

    public OptionsViewModel Options => _options;

    private void FrmOptions_Load(object sender, EventArgs e)
    {
        _chkArchiveChats.Checked = _options?.ArchiveChats ?? false;
        _txtAppDataPath.Text = _options?.BasePath ?? string.Empty;
    }

    private void ChkArchiveChats_CheckedChanged(object sender, EventArgs e)
    {
        _options.ArchiveChats = _chkArchiveChats.Checked;
    }

    private void BtnPickPath_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Select the folder where Chatty will store its data.",
            ShowNewFolderButton = true,
            SelectedPath = _txtAppDataPath.Text
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _txtAppDataPath.Text = dialog.SelectedPath;
            _options.BasePath = dialog.SelectedPath;
        }
    }
}
