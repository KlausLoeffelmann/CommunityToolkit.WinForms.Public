using CommunityToolkit.WinForms.AI;

namespace CommunityToolkit.WinForms.ChatUI.AIStructures;

[AITemplate(
    Prompt = ClassPrompt,
    ProvideDate = true,
    ProvideTime = true)]
public class CodeBlockAITemplate(string basePath, string content)
{
    private const string ClassPrompt = """
        You are an assistant for a classification agents for text-based Listings.
        Your primary goal is for example to find out, if a listing is a C# source file,
        a JSON file, a Markdown file (which again can contain listing codes), a Batch file,
        or a plain text file.

        You should also look-out for implausibilities in the content of the listing, or 
        how the content could best be brief described, summarized and/or categorized.
        """;

    private const string ListingTitlePrompt = """
        The title of the listing file, which would assumingly best conclude the content. 
        Make sure that the title is no longer than 40 characters
        """;

    private const string ListingShortDescriptionPrompt = """
            You should provide a concise summary that reflects the core content 
            or purpose of the listing. Focus on clarity and brevity.
            """;

    private const string TypicalTypeExtensionPrompt = """
            Provide the typical file extension commonly associated with 
            the listing's type (e.g., '.cs', '.json', '.txt').
            """;

    private const string BriefTypeExplanationPrompt = """
            Offer a short explanation of why the listing falls under its 
            type category, mentioning one or two defining aspects.
            """;

    private const string PeculiaritiesPrompt = """
            Point out any unique, unusual, or specific characteristics 
            found in the listing that might be noteworthy. This could be
            for example bugs you spotted in the code, or issues which would
            slow down things considerably. Please provide them as Markdown and
            as formatted as a list.
            """;

    public CodeBlockAITemplate(string fullFilename, string content, ListingType listingType)
        : this(Path.GetDirectoryName(fullFilename)!, content)
    {
        FileName = fullFilename;
        ListingType = listingType;
    }

    public string BasePath { get; } = basePath;

    public string? FileName { get; set; }

    public string Content { get; } = content;

    [AITemplateSegment(Prompt = ListingTitlePrompt)]
    public string? ListingTitle { get; set; }

    [AITemplateSegment(Prompt = ListingShortDescriptionPrompt)]
    public string? ShortDescription { get; set; }

    public ListingType ListingType { get; } = ListingType.Other;

    [AITemplateSegment(Prompt = TypicalTypeExtensionPrompt)]
    public string? TypicalTypeExtension { get; set; }

    [AITemplateSegment(Prompt = BriefTypeExplanationPrompt)]
    public string? BriefTypeExplanation { get; set; }

    [AITemplateSegment(Prompt = PeculiaritiesPrompt)]
    public string? Peculiarities { get; set; }

    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
}
