using CommunityToolkit.WinForms.AI.ConverterLogic;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace CommunityToolkit.WinForms.BasicTests.TestSupport;

/// <summary>
///  Provides data items for testing purposes.
/// </summary>
/// <remarks>
///  <para>
///   This class is responsible for loading test data from a specified file. It extracts the directory path,
///   the filename without extension, and the expected content from a corresponding .txt file.
///  </para>
///  <para>
///   It also reads the literal content of the provided file and splits it into an array of strings based on
///   newline characters.
///  </para>
/// </remarks>
public class TestDataItemProvider
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="TestDataItemProvider"/> class.
    /// </summary>
    /// <param name="filename">The path to the file containing the test data.</param>
    /// <exception cref="ArgumentException">Thrown when the provided file path is invalid.</exception>
    /// <remarks>
    ///  <para>
    ///   The constructor initializes the properties by extracting the directory path, the filename without
    ///   extension, and the expected content from a corresponding .txt file. It also reads the literal content
    ///   of the provided file and splits it into an array of strings based on newline characters.
    ///  </para>
    /// </remarks>
    public TestDataItemProvider(string filename)
    {
        TestDataDirectoryPath = Path.GetDirectoryName(filename)
            ?? throw new ArgumentException("Invalid file path", nameof(filename));

        NakedFilename = Path.GetFileNameWithoutExtension(filename);

        // Now, get the file which holds the file we need to test against, which is the .txt file:
        ExpectedFilePath = Path.Combine(TestDataDirectoryPath, $"{NakedFilename}.txt");
        ExpectedContent = File.Exists(ExpectedFilePath)
            ? File.ReadAllText(ExpectedFilePath)
            : string.Empty;

        LiteralContent = File.ReadAllText(filename);
        Literals = LiteralContent.Split(['\n'], StringSplitOptions.TrimEntries);
    }

    public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContents(AuthorRole role)
    {
        List<StreamingChatMessageContent> streamingChatMessageContents = [];

        foreach (string literal in Literals)
        {
            // This is a CSharp Literal, which we need to convert:
            string? token = literal.FromCSharpLiteral();
            streamingChatMessageContents.Add(new(role, token));
        }
        return streamingChatMessageContents.ToIAsyncEnumerable();
    }

    /// <summary>
    ///  Gets the directory path of the test data file.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds the directory path where the test data file is located.
    ///  </para>
    /// </remarks>
    public string TestDataDirectoryPath { get; }

    /// <summary>
    ///  Gets the filename without extension.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds the filename without its extension, extracted from the provided file path.
    ///  </para>
    /// </remarks>
    public string NakedFilename { get; }

    /// <summary>
    ///  Gets the path to the expected content file.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds the path to the .txt file that contains the expected content for testing.
    ///  </para>
    /// </remarks>
    public string ExpectedFilePath { get; }

    /// <summary>
    ///  Gets the expected content from the .txt file.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds the content read from the .txt file that is used for comparison in tests.
    ///  </para>
    /// </remarks>
    public string ExpectedContent { get; }

    /// <summary>
    ///  Gets the literal content of the provided file.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds the entire content of the provided test data file.
    ///  </para>
    /// </remarks>
    public string LiteralContent { get; }

    /// <summary>
    ///  Gets the literals split by newline characters.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds an array of strings, each representing a line from the provided test data file.
    ///  </para>
    /// </remarks>
    public string[] Literals { get; }
}
