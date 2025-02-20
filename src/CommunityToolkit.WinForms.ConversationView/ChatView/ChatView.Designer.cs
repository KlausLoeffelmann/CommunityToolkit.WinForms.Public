using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.ChatUI;
using CommunityToolkit.WinForms.FluentUI.Containers;
using CommunityToolkit.WinForms.FluentUI.Controls;

namespace CommunityToolkit.WinForms.ChatUI;

partial class ChatView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatView));
        _splitChatArea = new SplitContainer();
        _conversationView = new ConversationView();
        _decoratorPanel = new FluentDecoratorPanel();
        _promptControl = new AutoCompleteEditor();
        _skCommunicator = new SemanticKernelComponent();
        _skMetaDataProcessor = new SemanticKernelComponent();
        ((System.ComponentModel.ISupportInitialize)_splitChatArea).BeginInit();
        _splitChatArea.Panel1.SuspendLayout();
        _splitChatArea.Panel2.SuspendLayout();
        _splitChatArea.SuspendLayout();
        _decoratorPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _splitChatArea
        // 
        _splitChatArea.Dock = DockStyle.Fill;
        _splitChatArea.Location = new Point(0, 0);
        _splitChatArea.Name = "_splitChatArea";
        _splitChatArea.Orientation = Orientation.Horizontal;
        // 
        // _splitChatArea.Panel1
        // 
        _splitChatArea.Panel1.Controls.Add(_conversationView);
        _splitChatArea.Panel1.Padding = new Padding(5, 5, 5, 5);
        // 
        // _splitChatArea.Panel2
        // 
        _splitChatArea.Panel2.Controls.Add(_decoratorPanel);
        _splitChatArea.Panel2.Padding = new Padding(5, 5, 5, 5);
        _splitChatArea.Size = new Size(1019, 726);
        _splitChatArea.SplitterDistance = 535;
        _splitChatArea.TabIndex = 1;
        // 
        // _conversationView
        // 
        _conversationView.Dock = DockStyle.Fill;
        _conversationView.HostPage = "wwwroot/index.html";
        _conversationView.Location = new Point(5, 5);
        _conversationView.Name = "_conversationView";
        _conversationView.Size = new Size(1009, 525);
        _conversationView.TabIndex = 0;
        _conversationView.Text = "conversationView1";
        // 
        // _decoratorPanel
        // 
        _decoratorPanel.BorderThickness = 1;
        _decoratorPanel.Controls.Add(_promptControl);
        _decoratorPanel.Dock = DockStyle.Fill;
        _decoratorPanel.Location = new Point(5, 46);
        _decoratorPanel.Name = "_decoratorPanel";
        _decoratorPanel.Padding = new Padding(10, 10, 10, 10);
        _decoratorPanel.Size = new Size(1009, 136);
        _decoratorPanel.TabIndex = 0;
        _decoratorPanel.VerticalContentAlignment = FluentDecoratorPanel.VerticalContentAlignments.Fill;
        // 
        // _promptControl
        // 
        _promptControl.BorderStyle = BorderStyle.None;
        _promptControl.Location = new Point(11, 11);
        _promptControl.Margin = new Padding(2, 2, 2, 2);
        _promptControl.MaxRemainingCharsSuggestionRequestSensitivity = 0;
        _promptControl.MinCharChangedBeforeNextTextReviewRequest = 60;
        _promptControl.MinTimeSuggestionRequestSensitivity = 1F;
        _promptControl.MinTimeThresholdForNextTextReviewRequest = 4F;
        _promptControl.Name = "_promptControl";
        _promptControl.Size = new Size(987, 114);
        _promptControl.TabIndex = 0;
        _promptControl.Text = "";
        // 
        // _skCommunicator
        // 
        _skCommunicator.TopP = null;
        // 
        // _skMetaDataProcessor
        // 
        _skMetaDataProcessor.TopP = null;
        // 
        // ChatView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(_splitChatArea);
        Name = "ChatView";
        Size = new Size(1019, 726);
        _splitChatArea.Panel1.ResumeLayout(false);
        _splitChatArea.Panel2.ResumeLayout(false);
        _splitChatArea.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_splitChatArea).EndInit();
        _splitChatArea.ResumeLayout(false);
        _decoratorPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer _splitChatArea;
    private ConversationView _conversationView;
    private FluentDecoratorPanel _decoratorPanel;
    private AutoCompleteEditor _promptControl;
    private SemanticKernelComponent _skCommunicator;
    private SemanticKernelComponent _skMetaDataProcessor;
}
