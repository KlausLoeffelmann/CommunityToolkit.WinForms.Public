using CommunityToolkit.WinForms.AI;

namespace CommunityToolkit.WinForms.ChatUI.AIStructures;

[AITemplate(
    Prompt = ClassPrompt,
    ProvideDate = true,
    ProvideTime = true)]
public class ChatInfoAITemplate
{
    private const string ClassPrompt = """
        You are an assistant in a chatbot client application.
        Your role is to generate meta information such as chat summaries and concise headlines.
        """;

    private const string ChatTitlePrompt = """
        Generate a chat title based on the conversation context.
        Ensure the title reflects the discussion topics—not the user's request—and limit it to 40 characters.
        """;

    private const string ChatSummaryPrompt = """
        Create a brief summary of the conversation for quick reference.
        Limit the summary to 2000 characters.
        """;

    private const string ChatKeywordsPrompt = """
        List 5 relevant keywords from the chat, separated by semicolons.
        Arrange them from general to increasingly specific.
        """;

    public const string MemoryFactListPrompt = """
        Provide a bullet list of key personal facts mentioned by the user.
        Include only explicit statements about the user or their circumstances.
        Exclude details phrased as questions or uncertainties.
        Format each fact on a new line starting with '* ' - but note that this is not an array, but a string.

        For example, if the chat includes:
        "I have a dog named Fido and he is a golden retriever. Is it true that
        golden retrievers eat anything they find?"
        then return as one string:

        * User has a dog named Fido
        * Fido is a golden retriever

        Only capture personal facts.
        """;

    [AITemplateSegment(Prompt = ChatTitlePrompt)]
    public string? ChatTitle { get; set; }

    [AITemplateSegment(Prompt = ChatSummaryPrompt)]
    public string? ChatSummary { get; set; }

    [AITemplateSegment(Prompt = ChatKeywordsPrompt)]
    public string? ChatKeywords { get; set; }

    [AITemplateSegment(Prompt = MemoryFactListPrompt)]
    public string? MemoryFactList { get; set; }

    public void Merge(Conversation conversation)
    {
        conversation.Title = ChatTitle!;
        conversation.Summary = ChatSummary!;
        conversation.Keywords = ChatKeywords!;
        conversation.DateLastEdited = DateTimeOffset.Now;
    }
}
