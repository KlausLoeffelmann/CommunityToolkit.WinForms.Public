using Chatty.ViewModels;

using CommunityToolkit.Roslyn.Tooling;
using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.ChatUI;
using CommunityToolkit.WinForms.ComponentModel;
using CommunityToolkit.WinForms.Controls.Tooling.Roslyn;
using CommunityToolkit.WinForms.Extensions;

namespace Chatty;

public partial class FrmMain : Form
{
    private static readonly string Key_OpenAI_Standard = "AI:OpenAI:ApiKey";

    private const string Key_MainView_Bounds = nameof(Key_MainView_Bounds);
    private const string Key_Options = nameof(Key_Options);

    private readonly Dictionary<KnownNode, TreeNode> _knownNodes = [];
    private readonly IUserSettingsService _settingsService;

    private OptionsViewModel _options = null!;
    private PersonalityManager _personalities = null!;
    private IEnumerable<string>? _openAIModels;
    private TreeNode? _currentNode;
    private Personality _currentPersonality = null!;
    private readonly CancellationTokenSource _shutDownCancellation = new();

    private readonly ChatView _chatView;

    /// <summary>
    /// Initializes a new instance of the <see cref="FrmMain"/> class.
    /// </summary>
    /// <exception cref="NullReferenceException"></exception>
    public FrmMain()
    {
        InitializeComponent();
        CreateKnownTreeViewNodes();

        if (Application.IsDarkModeEnabled)
        {
            _statusStrip.BackColor = Color.Black;
        }

        Application.ThreadException += (s, e) =>
        {
            ReportToStatusBarInfo(
                message: e.Exception.Message,
                toolTipText: e.Exception.Message,
                additionalInfo: e.Exception.StackTrace,
                critical: true);
        };

        _chatView = new()
        {
            ApiKeyGetter = () => Environment.GetEnvironmentVariable(Key_OpenAI_Standard)
                ?? throw new NullReferenceException($"The environment variable '{Key_OpenAI_Standard}' is not set.")
        };

        _chatView.AsyncNotifyRefreshedMetaData += ChatView_AsyncNotifyRefreshedMetaData;
        _chatView.AsyncCodeBlockInfoProvided += ChatView_AsyncCodeBlockInfoProvided;
        _chatView.AsyncRequestFileExtractingSettings += ChatView_AsyncRequestFileExtractingSettings;
        _chatView.AsyncNotifySaveChat += ChatView_AsyncNotifySaveChatAsync;
        _chatView.RequestChatViewOptions += ChatView_RequestChatViewOptions;

        _settingsService = WinFormsUserSettingsService.CreateAndLoad();

        _options = _settingsService.GetInstance(
            key: Key_Options,
            defaultValue: new OptionsViewModel());

        // Handle changing the personalities:
        _tscPersonalities.SelectedIndexChanged += (s, e) =>
        {
            // Lookup the selected personality:
            _currentPersonality = _tscPersonalities.SelectedItem as Personality
                ?? throw new NullReferenceException("Personality disorder exception!");

            _chatView.DeveloperPrompt = _currentPersonality.GetDeveloperPrompt();
            _chatView.ClearChatHistory();
        };

        _tscModels.SelectedIndexChanged += (s, e) =>
        {
            _options.LastUsedModel = _tscModels.SelectedItem as string
                ?? throw new NullReferenceException("Models disorder exception!");

            _chatView.ModelName = _options.LastUsedModel;
        };
    }

    private void ChatView_RequestChatViewOptions(object? sender, RequestChatViewOptionsEventArgs e)
    {
        e.BasePath = _options.BasePath;
        e.LastUsedConfigurationId = _options.LastUsedIdPersonality;
        e.LastUsedModel = _options.LastUsedModel;
    }

    private async Task ChatView_AsyncRequestFileExtractingSettings(object sender, AsyncRequestFileContextEventArgs e)
    {
        // TODO: Handle the extraction settings.
        await Task.CompletedTask;
    }

    private async Task ChatView_AsyncNotifySaveChatAsync(object sender, AsyncRequestFileContextEventArgs e)
    {
        // Iterate through any additional open tabs and save the respective listing files:
        foreach (Panel tabPage in _mainTabControl.Tabs)
        {
            if (tabPage.Controls[0] is not RoslynDocumentView sourceViewer)
            {
                continue;
            }

            PersonalityFileExtractionSetting settings = _currentPersonality.FileExtractionSettings;

            // Let's save the file according to the Personality-Setting.
            if (settings.HasFlag(PersonalityFileExtractionSetting.ExtractAutomatically))
            {
                if (settings.HasFlag(PersonalityFileExtractionSetting.SaveToConversationFolder))
                {
                    await sourceViewer.SaveFileAsync(e.ConversationPath
                        ?? throw new NullReferenceException(nameof(e.ConversationPath)));
                }
                else if (settings.HasFlag(PersonalityFileExtractionSetting.SaveToDedicatedPersonalityFolder))
                {
                    await sourceViewer.SaveFileAsync(_currentPersonality.DedicatedPersonalityFolder);                }
                else
                {
                    throw new NotImplementedException("The Personality setting for automatic code-block saving is faulty.");
                }
            }
        }
    }

    private async Task ChatView_AsyncCodeBlockInfoProvided(object sender, AsyncCodeBlockInfoProvidedEventArgs e)
    {
        // If we don't have a filename, it's likely the user picked a profile, which returned
        // a different format. In that case, the prompt is missing the ask to include
        // meta-information in the response like {{filename:myfilename.cs}} or {{title:My Title}}.
        if (string.IsNullOrEmpty(e.CodeBlock.Filename))
        {
            // We now report that as a warning to the user:
            ReportToStatusBarInfo(
                message: "The profile you selected does not support listing extraction.",
                toolTipText: "The profile you selected does not support the meta-information.",
                "No filename was provided, please make sure your prompt request extraction!",
                critical: true);

            return;
        }

        try
        {
            RoslynDocumentView sourceViewer = null!;

            CodeBlockInfo codeBlockInfo = e.CodeBlock;

            await InvokeAsync(() =>
            {
                // Let's add another Tab to the TabControl:
                sourceViewer = new();

                _mainTabControl.AddTab(
                    tabPageTitle: codeBlockInfo.Filename,
                    tabContent: sourceViewer);
            });

            await sourceViewer.SetCodeBlockInfoAsync(
                codeBlockInfo);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task ChatView_AsyncNotifyRefreshedMetaData(object sender, AsyncNotifyRefreshedMetaDataEventArgs e)
    {
        if (!e.CausedException)
        {
            await InvokeAsync(() =>
            {
                _lblConversationTitle.Text = e.ChatTitle;

                Conversation conversation = _chatView.ConversationView.Conversation;
                _currentNode = UpdateTreeView(conversation.Id);
                UpdateStatusBar(conversation);
            });

            return;
        }

        await InvokeAsync(() =>
        {
            if (e.Exception is null)
            {
                return;
            }

            _tslItemDateInfoCaption.Text = $"Failed to refresh metadata: {e.Exception.Message}";
            _tslItemDateInfoCaption.ToolTipText = e.Exception.StackTrace;
            _tslItemDateInfoCaption.ForeColor = Color.Red;
        });
    }

    protected async override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        _mainTabControl.AddTab("Conversation", _chatView);

        _lblConversationTitle.Text = $"New chat";
        _lblDate.Text = $"{DateTime.Now:dddd, MMM dd yyyy - HH:mm}";

        Rectangle bounds = _settingsService.GetInstance(
            Key_MainView_Bounds,
            this.CenterOnScreen(
                horizontalFillGrade: 80,
                verticalFillGrade: 80));

        Bounds = bounds;

        _personalities = PersonalityManager
            .GetPersonalitiesOrDefault(_options.BasePath);

        RebuildPersonalitiesDropDown(_options.LastUsedIdPersonality);
        UpdateTreeView();

        await SetupOpenAIModelsAsync();
        await ShowTimeAsync(_shutDownCancellation.Token);

        // The loop which is showing the time is running in the background.
        async Task ShowTimeAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(500, token).ConfigureAwait(false);
                await InvokeAsync(() =>
                {
                    _tslClockInfo.Text = $"{DateTime.Now:dddd, MMM dd yyyy - HH:mm:ss}";
                }, token);
            }
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Every async thing which is still active, please stop what you are doing!
        _shutDownCancellation.Cancel();

        base.OnFormClosing(e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);

        _settingsService.SetInstance(Key_MainView_Bounds, this.GetRestorableBounds());
        _settingsService.SetInstance(Key_Options, _options);
        _settingsService.Save();
    }

    private async Task SetupOpenAIModelsAsync()
    {
        _openAIModels = await _chatView.QueryOpenAiModelNamesAsync();

        if (_openAIModels is null)
        {
            return;
        }

        _openAIModels = _openAIModels.Order();

        _tscModels.Items.Clear();
        _tscModels.Items.AddRange([.. _openAIModels]);
        _tscModels.SelectedItem = _options.LastUsedModel;
    }

    private void BtnStartNewChat_Click(object sender, EventArgs e)
        => _chatView.StartNewChat();

    private void RebuildPersonalitiesDropDown(Guid lastUsedIdPersonality)
    {
        // Let's remember the currently selected ID:
        Guid selectedId = _tscPersonalities.SelectedItem is Personality selectedPersonality
            ? selectedPersonality.Id
            : lastUsedIdPersonality;

        _tscPersonalities.Items.Clear();
        _tscPersonalities.Items.AddRange([.. _personalities.Personalities]);

        // If the remembered Guid is Empty, let's select the first one:
        if (selectedId == Guid.Empty && _tscPersonalities.Items.Count > 0)
        {
            _tscPersonalities.SelectedIndex = 0;
            return;
        }

        try
        {
            // And select the one we had before:
            _tscPersonalities.SelectedItem = _tscPersonalities.Items
                .OfType<Personality>()
                .FirstOrDefault(item => item.Id == selectedId);
        }
        catch (Exception)
        {
            _tscPersonalities.SelectedIndex = 0;
        }
    }

    private void CreateKnownTreeViewNodes()
    {
        foreach (KnownNode knownNode in Enum.GetValues<KnownNode>())
        {
            TreeNode node = _trvConversationHistory.Nodes.Add(knownNode.ToString());
            node.NodeFont = new Font(_trvConversationHistory.Font, FontStyle.Bold);
            _knownNodes[knownNode] = node;
        }
    }

    private void TscPersonalities_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_tscPersonalities.SelectedItem is not Personality selectedPersonality)
        {
            return;
        }

        _options.LastUsedIdPersonality = selectedPersonality.Id;
    }

    private void TrvConversationHistory_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is not Conversation conversation)
        {
            return;
        }

        _currentNode = e.Node;

        // We're updating the status bar:
        UpdateStatusBar(conversation);
    }


    private void PersonalitiesChanged(object? sender, EventArgs e)
    {
        // We're saving the changes:
        _personalities.SavePersonalities(_options.BasePath);

        // Rebuild the ComboBox:
        RebuildPersonalitiesDropDown(_options.LastUsedIdPersonality);
    }
}
