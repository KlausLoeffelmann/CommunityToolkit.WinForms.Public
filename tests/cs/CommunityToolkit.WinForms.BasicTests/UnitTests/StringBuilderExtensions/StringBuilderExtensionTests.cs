using CommunityToolkit.WinForms.AI.Extensions;

using System.Text;

using static CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.StringBuilderExtensions;

public class StringBuilderExtensionTests
{
    [Fact]
    public void AppendParagraph_ShouldFormatTextCorrectly()
    {
        // Arrange
        StringBuilder sb = new();
        string text = "This is a test paragraph that should be formatted correctly.";
        
        // Act
        sb.AppendParagraph(text, maxLineLength: 20, indentLevel: 1, indentation: 2);
        
        // Assert
        string expected = "  This is a test\r\n  paragraph that\r\n  should be\r\n  formatted\r\n  correctly.\r\n";
        Assert.Equal(expected, sb.ToString());
    }

    [Fact]
    public void AppendBulletPoint_ShouldFormatTextCorrectly()
    {
        // Arrange
        StringBuilder sb = new();
        string text = "This is a test bullet point that should be formatted correctly.";
        
        // Act
        sb.AppendBulletPoint(text, maxLineLength: 20, bulletLevel: 1, bulletLevelChars: "*-•+", indentLevel: 1, indentation: 2);
        
        // Assert
        string expected = "  - This is a test\r\n    bullet point\r\n    that should be\r\n    formatted\r\n    correctly.\r\n";
        Assert.Equal(expected, sb.ToString());
    }

    [Fact]
    public void AppendBulletPointSubParagraph_ShouldFormatTextCorrectly()
    {
        // Arrange
        StringBuilder sb = new();
        string text = "This is a test sub-paragraph that should be formatted correctly.";
        
        // Act
        sb.AppendBulletPointSubParagraph(text, maxLineLength: 20, bulletLevel: 1, indentLevel: 1, indentation: 2);
        
        // Assert
        string expected = "    This is a\r\n      test\r\n      sub-paragraph\r\n      that\r\n      should be\r\n      formatted\r\n      correctly.\r\n";
        string actual = sb.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IndentLines_ShouldIndentTextCorrectly()
    {
        // Arrange
        string text = "This is a test\r\nparagraph.";
        
        // Act
        string result = text.IndentLines(indentLevel: 1, indent: 2);
        
        // Assert
        string expected = "  This is a test\r\n  paragraph.";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void JoinOrEmpty_ShouldReturnJoinedString()
    {
        // Arrange
        string[] strings = { "This", "is", "a", "test" };
        
        // Act
        string result = strings.JoinOrEmpty(JoinType.Comma);
        
        // Assert
        string expected = "This, is, a, test";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void JoinOrDefault_ShouldReturnJoinedString()
    {
        // Arrange
        string[] strings = { "This", "is", "a", "test" };
        
        // Act
        string? result = strings.JoinOrDefault(JoinType.Semicolon);
        
        // Assert
        string expected = "This; is; a; test";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Join_ShouldReturnJoinedString()
    {
        // Arrange
        string[] strings = { "This", "is", "a", "test" };
        
        // Act
        string result = strings.Join(JoinType.NewLine);
        
        // Assert
        string expected = "This\r\nis\r\na\r\ntest";
        Assert.Equal(expected, result);
    }
}
