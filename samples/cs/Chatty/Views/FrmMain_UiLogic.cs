using Chatty.ViewModels;
using Chatty.Views;
using CommunityToolkit.WinForms.ChatUI;

namespace Chatty;

public partial class FrmMain
{
    private TreeNode UpdateTreeView(Guid id = default)
    {
        TreeNode nodeToReturn = null!;

        try
        {
            // We want to be visually as quick as possible.
            _trvConversationHistory.BeginUpdate();

            // Clear the TreeView:
            _trvConversationHistory.Nodes.Clear();

            // Let's get all the directories in the base path, and from there let's
            // get the .cjson file in the folder:
            var conversations = new List<Conversation>();
            foreach (string folder in Directory.EnumerateDirectories(_options.BasePath))
            {
                string[] files = Directory.GetFiles(folder, "*.cjson");

                if (files.Length == 0)
                {
                    continue;
                }

                Conversation conversation = Conversation.GetHeaderFromFile(files[0])!;
                conversations.Add(conversation);
            }

            // Sort conversations by DateLastEdited descending
            var sortedConversations = conversations
                .OrderByDescending(c => c.DateLastEdited);

            foreach (var conversation in sortedConversations)
            {
                DateTimeOffset date = conversation.DateLastEdited;
                TreeNode parentNode;

                parentNode = date.Date switch
                {
                    var d when d == DateTime.Today => _knownNodes[KnownNode.Today],
                    var d when d == DateTime.Today.AddDays(-1) => _knownNodes[KnownNode.Yesterday],
                    var d when d >= DateTime.Today.AddDays(-7) => _knownNodes[KnownNode.LastWeek],
                    var d when d >= DateTime.Today.AddDays(-14) => _knownNodes[KnownNode.LastTwoWeeks],
                    var d when d >= DateTime.Today.AddMonths(-1) => _knownNodes[KnownNode.LastMonth],
                    _ => _trvConversationHistory.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Text == date.ToString("MMMM yyyy"))
                        ?? _trvConversationHistory.Nodes.Add(date.ToString("MMMM yyyy"))
                };

                // Let's find out, if that node is already in the TreeView:
                if (!_trvConversationHistory.Nodes.Contains(parentNode))
                {
                    // We need to get rid of the nodes we might already have.
                    // TODO: We should later build the delta and targeted update/remove.
                    parentNode.Nodes.Clear();

                    _trvConversationHistory.Nodes.Add(parentNode);
                }

                TreeNode node = parentNode.Nodes.Add(conversation.Title);
                node.Tag = conversation;

                // If no node was selected/current before, we pick the first one.
                nodeToReturn ??= node;

                if (id != Guid.Empty && conversation.Id == id)
                {
                    nodeToReturn = node;
                }

                if (!parentNode.IsExpanded)
                {
                    parentNode.Expand();
                }
            }

            _trvConversationHistory.SelectedNode = nodeToReturn;
            return nodeToReturn;
        }
        finally
        {
            _trvConversationHistory.EndUpdate();
        }
    }

    private void UpdateStatusBar(Conversation conversation)
    {
        var idPersonality = conversation.IdPersonality;

        _tslItemDateInfo.Text = $"{conversation.DateCreated:g}";
        _tslPersonality.Text = $"{GetPersonality(idPersonality)} with {conversation.Model}";
        _txtSummary.Text = conversation.Summary;

        // Todo: We would need to load the conversation items.
        // We will get the times we need best from the second item.
        // (Test first one won't have latencies, since in these cases it came from the user.)
        if (conversation.ConversationItems.Skip(1).FirstOrDefault() is ConversationItem conversationItem)
        {
            _tslProcessTimes.Text = 
                $"{conversationItem.FirstResponseDuration.TotalSeconds:#,##0.000} s /" +
                $"{conversationItem.CompleteProcessDuration.TotalSeconds:#,##0.000} s /";
        }
        else
        {
            _tslProcessTimes.Text = "- N/A -";
        }

        _tslProcessTimes.Text = "";

        _tsddKeywords.Text = null;
        _tsddKeywords.DropDownItems.Clear();

        ReportToStatusBarInfo(
            "OK.",
            $"ID:{conversation.Id}\nPath:{conversation.Filename}\n\nDouble-Click copies path to clipboard ring.");

        if (string.IsNullOrWhiteSpace(conversation.Keywords))
        {
            return;
        }

        foreach (string keyword in conversation.Keywords.Split(';'))
        {
            ToolStripMenuItem item = new(keyword);

            // We only show the first keyword in the status drop-down button.
            _tsddKeywords.Text ??= keyword;

            // TODO: We want to filter for keywords later.
            item.Click += (s, e) => _tsddKeywords.Text = keyword;
            _tsddKeywords.DropDownItems.Add(item);
        }
    }

    private Personality GetPersonality(Guid idPersonality)
    {
        if (idPersonality == Guid.Empty)
        {
            // We pick the first one from the list, since it's the default.
            return _personalities.Personalities.First();
        }

        return _personalities
            .Personalities
            .First(_personalities => _personalities.Id == idPersonality);
    }

    private async void ConversationHistory_NodeMouseDoubleClick(
        object sender, 
        TreeNodeMouseClickEventArgs e)
    {
        // Let's get the ConservationView from the node's tag:
        if (e.Node!.Tag is not Conversation conversation)
        {
            // TODO: Error Message.
            return;
        }

        _currentNode = e.Node;

        await _chatView.LoadConversationAsync(conversation.Filename);

        // This is a new instance which has now the conversation items.
        e.Node.Tag = conversation;

        _lblConversationTitle.Text = conversation.Title;
        _lblDate.Text = conversation.DateLastEdited.ToString("F");
    }

    private void ReportToStatusBarInfo(string message,
        string? toolTipText = null,
        string? additionalInfo = null,
        bool critical = false)
    {
        _tslInfo.Text = message;
        _tslInfo.ToolTipText = toolTipText is null ? message : toolTipText;
        _tslInfo.ForeColor = critical ? Color.Red : SystemColors.ControlText;
        _tsbInfo.Visible = !string.IsNullOrWhiteSpace(additionalInfo);
        _tsbInfo.DropDownItems.Clear();

        if (_tsbInfo.Visible)
        {
            _tsbInfo.DropDownItems.Add(additionalInfo);
        }
    }

    private void TsmOptions_Click(object sender, EventArgs e)
    {
        using FrmOptions frmOptions = new(_options!);

        if (frmOptions.ShowDialog() == DialogResult.OK)
        {
            _options = frmOptions.Options;
        }
    }

    private void About_Click(object sender, EventArgs e)
    {
        using FrmAbout about = new();
        about.ShowDialog();
    }
}
