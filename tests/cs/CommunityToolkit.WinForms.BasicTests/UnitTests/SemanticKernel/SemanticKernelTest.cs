using CommunityToolkit.Roslyn.Tooling;
using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.AI.ConverterLogic;
using CommunityToolkit.WinForms.BasicTests.TestSupport;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

using System.Diagnostics;
using System.Text;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.SemanticKernel;

public class SemanticKernelTest
{
    public static TheoryData<string> GetTestFiles()
        => TestDataDiscovery.GetCsLiteralsTestDataFiles();

    [Theory]
    [MemberData(nameof(GetTestFiles))]
    public async Task ReturnTokenParser_FromTestDataFile(string filename)
    {
        // We building up a mock LLM-return token list from the
        // test data files, and then we process it with the
        // ReturnTokenParser.ProcessTokens method.

        TestDataItemProvider testDataItemInfo = new(filename);

        IAsyncEnumerable<StreamingChatMessageContent> mockData
            = testDataItemInfo.GetStreamingChatMessageContents(AuthorRole.Developer);

        List<ReturnStreamMetaData> receivedMetaData = [];
        List<string> receivedParagraphs = [];
        List<CodeBlockInfo> codeBlocks = [];

        List<string> result = [];
        StringBuilder docFromWordTokenStreamBuilder = new();
        StringBuilder docFromParagraphEventBuilder = new();

        if (filename.EndsWith("MarkDown_ComplexDoc_TestTokenReturnStream.csLiterals"))
        {
            Debug.Print(filename);
        }

        await foreach (string token in ReturnTokenParser.ProcessTokens(
            asyncEnumerable: mockData,
            onReceivedMetaDataAction: OnReceivedMetaData,
            onReceivedNextParagraphAction: OnReceivedNextParagraph,
            onCodeBlockInfoProvidedAction: OnCodeBlockInfoProvided))
        {
            result.Add(token);
            docFromWordTokenStreamBuilder.Append(token);
        }

        string fileContent = docFromWordTokenStreamBuilder.ToString();

        // We need to compare this with the expected content file:
        // So, let read that first - it's the file with the same name
        // but with the .parsed extension:

        // So let's create the filename first and see, if the file is there:
        string parsedFilename = Path.Combine(
            testDataItemInfo.TestDataDirectoryPath,
            $"{testDataItemInfo.NakedFilename}.parsed");

        // Now, let's see, if it's there:
        string expectedContent = File.Exists(parsedFilename)
            ? File.ReadAllText(parsedFilename)
            : string.Empty;

        // If we don't have a file, let's save it:
        if (string.IsNullOrEmpty(expectedContent))
        {
            File.WriteAllText(parsedFilename, fileContent);
        }

        // If the results are different, let's save it under ".parsed.actual":
        if (fileContent != expectedContent)
        {
            string actualFilename = Path.Combine(
                testDataItemInfo.TestDataDirectoryPath,
                $"{testDataItemInfo.NakedFilename}.parsed.actual");

            File.WriteAllText(actualFilename, fileContent);
        }

        string docFromParas = docFromParagraphEventBuilder.ToString();

        // And we finally assert:
        Assert.Equal(expectedContent, fileContent);
        Assert.Equal(expectedContent, docFromParas);

        void OnReceivedMetaData(AsyncReceivedInlineMetaDataEventArgs args)
        {
            receivedMetaData.Add(args.MetaData);
            Debug.Print(args.MetaData.ToString());
        }

        void OnReceivedNextParagraph(AsyncReceivedNextParagraphEventArgs args)
        {
            receivedParagraphs.Add(args.Paragraph);
            docFromParagraphEventBuilder.Append(args.Paragraph);
        }

        void OnCodeBlockInfoProvided(AsyncCodeBlockInfoProvidedEventArgs args)
        {
            codeBlocks.Add(args.CodeBlock);
            Debug.Print("==========================");
            Debug.Print(args.CodeBlock.Code.ToString());
            Debug.Print("==========================");
            Debug.Print("");
            Debug.Print("");
        }
    }
}
