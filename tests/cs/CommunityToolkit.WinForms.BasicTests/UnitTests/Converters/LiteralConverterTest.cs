using CommunityToolkit.WinForms.AI.ConverterLogic;
using CommunityToolkit.WinForms.BasicTests.TestSupport;
using System.Text;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.Converters;

public class LiteralConverterTest
{
    [Fact]
    public void FromCSharpLiteral_ValidLiteral_ReturnsString()
    {
        // Arrange
        string literal = "\"Hello\\nWorld\"";

        // Act
        string? result = literal.FromCSharpLiteral();

        // Assert
        Assert.Equal("Hello\nWorld", result);
    }

    [Fact]
    public void FromCSharpLiteral_NullLiteral_ReturnsNull()
    {
        // Arrange
        string literal = "null";

        // Act
        string? result = literal.FromCSharpLiteral();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FromCSharpLiteral_InvalidLiteral_ThrowsArgumentException()
    {
        // Arrange
        string literal = "Hello";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => literal.FromCSharpLiteral());
    }

    [Fact]
    public void ToCSharpLiteral_ValidString_ReturnsLiteral()
    {
        // Arrange
        string input = "Hello\nWorld";

        // Act
        string result = input.ToCSharpLiteral();

        // Assert
        Assert.Equal("\"Hello\\nWorld\"", result);
    }

    [Fact]
    public void ToCSharpLiteral_NullString_ReturnsNullLiteral()
    {
        // Arrange
        string? input = null;

        // Act
        string result = input.ToCSharpLiteral();

        // Assert
        Assert.Equal("null", result);
    }

    [Fact]
    public void FromCSharpLiteral_MultipleParagraphs_ReturnsString()
    {
        // Arrange
        string literal = "\"First paragraph\\n\\nSecond paragraph\\n\\nThird paragraph\"";

        // Act
        string? result = literal.FromCSharpLiteral();

        // Assert
        Assert.Equal("First paragraph\n\nSecond paragraph\n\nThird paragraph", result);
    }

    [Fact]
    public void FromCSharpLiteral_EscapeSequences_ReturnsString()
    {
        // Arrange
        string literal = "\"Quote: \\\" Tick: \\` Unicode: \\u0041\"";

        // Act
        string? result = literal.FromCSharpLiteral();

        // Assert
        Assert.Equal("Quote: \" Tick: ` Unicode: A", result);
    }

    [Fact]
    public void ToCSharpLiteral_MultipleParagraphs_ReturnsLiteral()
    {
        // Arrange
        string input = "First paragraph\n\nSecond paragraph\n\nThird paragraph";

        // Act
        string result = input.ToCSharpLiteral();

        // Assert
        Assert.Equal("\"First paragraph\\n\\nSecond paragraph\\n\\nThird paragraph\"", result);
    }

    [Fact]
    public void ToCSharpLiteral_EscapeSequences_ReturnsLiteral()
    {
        // Arrange
        string input = "Quote: \" Tick: ` Unicode: A";

        // Act
        string result = input.ToCSharpLiteral();

        // Assert
        Assert.Equal("\"Quote: \\u0022 Tick: \\u0060 Unicode: A\"", result);
    }

    public static TheoryData<string> GetTestFiles()
        => TestDataDiscovery.GetCsLiteralsTestDataFiles();

    [Theory]
    [MemberData(nameof(GetTestFiles))]
    public void FromCSharpLiteral_FromTestDataFile_ReturnsLiteralFileContent(string filename)
    {
        TestDataItemProvider testDataProvider = new(filename);
        
        string expectedContent = string.Empty;

        bool doesNotExist = false;

        // Let's test, if the file exists, and then read the content.
        if (File.Exists(testDataProvider.ExpectedFilePath))
        {
            expectedContent = File.ReadAllText(testDataProvider.ExpectedFilePath);
        }
        else
        {
            doesNotExist = true;
        }

        StringBuilder actualFileContentBuilder = new();

        // We want this list, because we will do the same in the other direction,
        // and then we should exactly have what we had at the beginning.
        List<string?> parsedTokens = [];

        // Now we parse them throw the FromCSharpLiteral method.
        for (int i = 0; i < testDataProvider.Literals.Length; i++)
        {
            string? parsedToken = testDataProvider.Literals[i].FromCSharpLiteral(ensureWindowsLineEndings: true);

            parsedTokens.Add(parsedToken);
            actualFileContentBuilder.Append(parsedToken);
        }

        string actualContent = actualFileContentBuilder.ToString();

        // Now let's check, if the actual content is equal to the expected content.
        if (!string.Equals(expectedContent, actualContent))
        {
            // If not, let's write the actual content to the file.
            // Let's call that extension ".actual.txt".
            if (doesNotExist)
            {
                File.WriteAllText(testDataProvider.ExpectedFilePath, actualContent);
            }
            else
            {
                File.WriteAllText(testDataProvider.ExpectedFilePath + ".actual", actualContent);
            }
        }

        // And assert.
        Assert.Equal(expectedContent, actualContent);

        // Now we do the same in the other direction.
        StringBuilder actualLiteralContentBuilder = new();

        // Now we parse them throw the ToCSharpLiteral method.
        for (int i = 0; i < parsedTokens.Count; i++)
        {
            string literal = parsedTokens[i].ToCSharpLiteral();

            // Every literal has its own line, except the last one.
            if (i < parsedTokens.Count - 1)
            {
                actualLiteralContentBuilder.AppendLine(literal);
            }
            else
            {
                actualLiteralContentBuilder.Append(literal);
            }
        }

        string actualLiteralContent = actualLiteralContentBuilder.ToString();

        // Now let's check, if the actual content is equal to the expected content.
        if (!string.Equals(testDataProvider.LiteralContent, actualLiteralContent))
        {
            // If not, let's write the actual content to the file.
            // Let's call that extension ".actual.txt".
            if (doesNotExist)
            {
                File.WriteAllText(filename, actualLiteralContent);
            }
            else
            {
                File.WriteAllText(filename + ".actual", actualLiteralContent);
            }
        }

        // And assert.
        Assert.Equal(testDataProvider.LiteralContent, actualLiteralContent);
    }
}
