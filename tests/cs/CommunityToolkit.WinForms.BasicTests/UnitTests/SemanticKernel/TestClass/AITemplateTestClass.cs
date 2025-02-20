using CommunityToolkit.WinForms.AI;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.SemanticKernel.TestClass;

[AITemplate(
    Prompt = ClassPrompt,
    ProvideDate = true,
    ProvideTime = true)]
public class AITemplateTestClass
{
    private const string ClassPrompt = """
    You are an expert .NET Developer: fluent in legacy .NET Framework and modern .NET 5+ with C# 11–13.
    You use the latest language features where they add value—improving readability, maintainability, efficiency,
    security, reliability, and robustness. Expect legacy C# with outdated constructs and formatting issues.
    Modernize each code member as requested. Ensure that you:
    The request can include more than one code block, when they are smaller, for better efficiency.
    So, the output will be then a list of responses, one for each code block, according to the
    structure described below.
    """;

    private const string TemplateItemPrompt = """
    A list of items, one for each code block.
    """;

    [AITemplateSegment(Purpose = SegmentPurpose.Request)]
    public string? Guid { get; set; }

    [AITemplateSegment(Prompt = TemplateItemPrompt, Purpose = SegmentPurpose.RequestAndResponse)]
    public AITemplateItemTestClass[]? Items { get; set; }
}


[AITemplate(Prompt = ClassPrompt)]
public class AITemplateItemTestClass
{
    private const string ClassPrompt = """
    This is the Code-Block item definition, which belongs to the original modernization request.
    """;

    private const string ActualCodePrompt = """
    Should return the source code of the modernized code, without any additional meta- or formatting information.
    """;

    private const string GuidPrompt = """
    Include the unique GUID that has been passed in the request. Please return in the Format {{GUID:guid}}.
    """;

    private const string DetectedIssuesPrompt = """
    If you detect issues worth mentioning from the original code, please list them in Markdown.
    Start each line with "* {{Severity:info|suggestion|warning|error|critical}}:" followed by the issue description.
    """;

    private const string ConfidenceLevelPrompt = """
    Provide a confidence level (0–100) indicating how sure you are that the modernized code is correct and non-breaking.
    """;

    [AITemplateSegment(Prompt = ClassPrompt, Purpose = SegmentPurpose.Request)]
    public string? Guid { get; set; }

    [AITemplateSegment(Prompt = ClassPrompt, Purpose = SegmentPurpose.RequestAndResponse)]
    public string? SourceCode { get; set; }

    [AITemplateSegment(Prompt = ActualCodePrompt, Purpose = SegmentPurpose.Response)]
    public string[]? DetectedIssues { get; set; }

    [AITemplateSegment(Prompt = GuidPrompt, Purpose = SegmentPurpose.Response)]
    public int ConfidenceLevel { get; set; }
}
