using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CommunityToolkit.WinForms.FluentUI.Controls;

/// <summary>
///  Control for an convenient follow-up conversation with the AI. 
///  Builds lists of Buttons based on Options returned by the AI for 
///  the user to click on.
/// </summary>
public class FluentFollowUpControl : Panel
{
    private const string DefaultInitialEngagementSuggestion =
        "What can I ask?";

    private ObservableCollection<string> _replyChoices = new();

    [Category("Behavior")]
    [Description("The initial suggestion to engage the user.")]
    [DefaultValue(DefaultInitialEngagementSuggestion)]
    public string InitialEngagementSuggestions { get; set; } = DefaultInitialEngagementSuggestion;

    [Category("Behavior")]
    [Description("The reply from the Model to the user. This is for rendering the Model's replay into the control.")]
    [DefaultValue("")]
    public string InitialEngagementReply { get; set; } = string.Empty;

    [Category("Layout")]
    [Description("The orientation of the buttons.")]
    [DefaultValue(Orientation.Horizontal)]
    public Orientation ButtonOrientation { get; set; } = Orientation.Horizontal;

    [Category("Behavior")]
    [Description("The maximum length of the choice text before it is truncated.")]
    [DefaultValue(40)]
    public int MaxChoiceLength { get; set; } = 40;

    public ObservableCollection<string> ReplyChoices => _replyChoices;

    public FluentFollowUpControl()
    {
        _replyChoices.CollectionChanged += ReplyChoices_CollectionChanged;
    }

    private void ReplyChoices_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Controls.Clear();

        foreach (string choice in _replyChoices)
        {
            Button button = new();
            string displayText = choice.Length > MaxChoiceLength 
                ? choice[..MaxChoiceLength] + "..." 
                : choice;

            button.Text = displayText;

            if (choice.Length > MaxChoiceLength)
            {
                ToolTip toolTip = new();
                toolTip.SetToolTip(button, choice);
            }

            button.AutoSize = true;
            button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button.MaximumSize = new Size(ButtonOrientation == Orientation.Horizontal ? 0 : Width, 0);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(button);
        }

        if (ButtonOrientation == Orientation.Vertical)
        {
            foreach (Control control in Controls)
            {
                control.Dock = DockStyle.Top;
            }
        }
        else
        {
            foreach (Control control in Controls)
            {
                control.Dock = DockStyle.Left;
            }
        }
    }
}
