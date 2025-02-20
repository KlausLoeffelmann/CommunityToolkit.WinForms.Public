using System.Text;
using System.Text.RegularExpressions;

namespace CommunityToolkit.WinForms.AI.Extensions;

/// <summary>
///  String- and StringBuilder extensions, particularly tailored for formatting
///  prompts in a visible structured way.
/// </summary>
/// <remarks>
///  <para>
///   This class provides extension methods for the StringBuilder class to format text in a structured way.
///   It includes methods to append paragraphs, bullet points, and sub-paragraphs with specific formatting.
///  </para>
/// </remarks>
public static partial class StringAndStringBuilderExtensions
{
    /// <summary>
    ///  Appends a paragraph to the StringBuilder with specified formatting.
    /// </summary>
    /// <param name="sb">The StringBuilder instance to append to.</param>
    /// <param name="value">The text value to append as a paragraph.</param>
    /// <param name="maxLineLength">The maximum length of a line in the paragraph.</param>
    /// <param name="indentLevel">The level of indentation for the paragraph.</param>
    /// <param name="indentation">The number of spaces for each indentation level.</param>
    /// <returns>The updated StringBuilder instance.</returns>
    /// <remarks>
    ///  <para>
    ///   This method formats the input text into a paragraph with specified maximum line length and indentation.
    ///   It removes extra whitespace and newlines, and splits the text into words to fit within the line length.
    ///  </para>
    /// </remarks>
    public static StringBuilder AppendParagraph(
        this StringBuilder sb,
        string value,
        int maxLineLength = 100,
        int indentLevel = 0,
        int indentation = 4)
    {
        // Remove extra whitespace and newlines
        string cleanedValue = RemoveWhiteSpace().Replace(value, " ").Trim();

        // Calculate the effective max line length considering indentation
        int effectiveMaxLineLength = maxLineLength - (indentLevel * indentation);

        // Split the cleaned value into words
        string[] words = cleanedValue.Split(' ');

        // Initialize a new StringBuilder for the paragraph
        StringBuilder paragraphBuilder = new();

        // Initialize the current line length
        int currentLineLength = 0;

        // Add indentation
        string indent = new(' ', indentLevel * indentation);
        paragraphBuilder.Append(indent);

        // Iterate through each word and build the paragraph
        foreach (string word in words)
        {
            if (currentLineLength + word.Length + 1 > effectiveMaxLineLength)
            {
                // Start a new line if the current line length exceeds the max line length
                paragraphBuilder.AppendLine();
                paragraphBuilder.Append(indent);
                currentLineLength = indent.Length;
            }

            // Add a space before the word if it's not the first word in the line
            if (currentLineLength > indent.Length)
            {
                paragraphBuilder.Append(' ');
                currentLineLength++;
            }

            // Append the word to the paragraph
            paragraphBuilder.Append(word);
            currentLineLength += word.Length;
        }

        // Append the built paragraph to the original StringBuilder
        sb.Append(paragraphBuilder);
        sb.AppendLine();

        return sb;
    }

    /// <summary>
    ///  Appends a bullet point to the StringBuilder with specified formatting.
    /// </summary>
    /// <param name="sb">The StringBuilder instance to append to.</param>
    /// <param name="value">The text value to append as a bullet point.</param>
    /// <param name="maxLineLength">The maximum length of a line in the bullet point.</param>
    /// <param name="bulletLevel">The level of the bullet point.</param>
    /// <param name="bulletLevelChars">The characters to use for different bullet levels.</param>
    /// <param name="indentLevel">The level of indentation for the bullet point.</param>
    /// <param name="indentation">The number of spaces for each indentation level.</param>
    /// <returns>The updated StringBuilder instance.</returns>
    /// <remarks>
    ///  <para>
    ///   This method formats the input text into a bullet point with specified maximum line length and indentation.
    ///   It removes extra whitespace and newlines, and splits the text into words to fit within the line length.
    ///   The bullet character is determined by the bullet level.
    ///  </para>
    /// </remarks>
    public static StringBuilder AppendBulletPoint(
        this StringBuilder sb,
        string value,
        int maxLineLength = 100,
        int bulletLevel = 0,
        string bulletLevelChars = "*-•+",
        int indentLevel = 0,
        int indentation = 4)
    {
        // Instead of cleaning with RemoveWhiteSpace().Replace(...).Trim(),
        // we'll process 'value' inline using Span<char> to collapse whitespace.
        ReadOnlySpan<char> span = value.AsSpan();
        int pos = 0;

        // Skip leading whitespace
        while (pos < span.Length && char.IsWhiteSpace(span[pos]))
        {
            pos++;
        }
        
        // Calculate the effective max line length considering indentation
        int effectiveMaxLineLength = maxLineLength - (indentLevel * indentation); // Adjust for bullet point visibility

        // Initialize a new StringBuilder for the bullet point
        StringBuilder bulletPointBuilder = new();

        // Initialize the current line length
        int currentLineLength = indentLevel * indentation;

        // Add indentation
        string indent = new(' ', indentLevel * indentation);
        bulletPointBuilder.Append(indent);

        // Add bullet character based on bullet level
        if (bulletLevel < bulletLevelChars.Length)
        {
            bulletPointBuilder.Append(bulletLevelChars[bulletLevel]);
            bulletPointBuilder.Append(' ');
            currentLineLength += 2;
        }

        bool firstWord = true;
        int start = pos;
        
        while (pos <= span.Length)
        {
            // At end or found whitespace -> word boundary.
            if (pos == span.Length || char.IsWhiteSpace(span[pos]))
            {
                if (pos > start)
                {
                    ReadOnlySpan<char> word = span[start..pos];
                    
                    // If adding the word would exceed line length, break line.
                    if (currentLineLength + word.Length > effectiveMaxLineLength)
                    {
                        bulletPointBuilder.AppendLine();
                        bulletPointBuilder.Append(indent);
                        bulletPointBuilder.Append("  "); // Indent wrapped lines by 2 characters
                        currentLineLength = indent.Length + 2;
                        firstWord = true;
                    }
                    
                    // Append a space if not first word in the line.
                    if (!firstWord)
                    {
                        bulletPointBuilder.Append(' ');
                        currentLineLength++;
                    }
                    
                    bulletPointBuilder.Append(word);
                    currentLineLength += word.Length;
                    firstWord = false;
                }
                
                // Skip all consecutive whitespace characters.
                while (pos < span.Length && char.IsWhiteSpace(span[pos]))
                {
                    pos++;
                }

                if (pos == span.Length)
                {
                    break;
                }

                start = pos;
            }
            else
            {
                pos++;
            }
        }

        // Append the built bullet point to the original StringBuilder
        sb.Append(bulletPointBuilder);
        sb.AppendLine();

        return sb;
    }

    /// <summary>
    ///  Appends a sub-paragraph to a bullet point in the StringBuilder with specified formatting.
    /// </summary>
    /// <param name="sb">The StringBuilder instance to append to.</param>
    /// <param name="value">The text value to append as a sub-paragraph.</param>
    /// <param name="maxLineLength">The maximum length of a line in the sub-paragraph.</param>
    /// <param name="bulletLevel">The level of the bullet point.</param>
    /// <param name="indentLevel">The level of indentation for the sub-paragraph.</param>
    /// <param name="indentation">The number of spaces for each indentation level.</param>
    /// <returns>The updated StringBuilder instance.</returns>
    /// <remarks>
    ///  <para>
    ///   This method formats the input text into a sub-paragraph with specified maximum line length and indentation.
    ///   It removes extra whitespace and newlines, and splits the text into words to fit within the line length.
    ///   The indentation is combined from both bullet level and indent level.
    ///  </para>
    /// </remarks>
    public static StringBuilder AppendBulletPointSubParagraph(
        this StringBuilder sb,
        string value,
        int maxLineLength = 100,
        int bulletLevel = 0,
        int indentLevel = 0,
        int indentation = 4)
    {
        // Remove extra whitespace and newlines
        string cleanedValue = RemoveWhiteSpace().Replace(value, " ").Trim();

        // Calculate the effective max line length considering indentation
        int effectiveMaxLineLength = maxLineLength
            - (bulletLevel * 2 + (indentLevel * indentation));

        // Split the cleaned value into words
        string[] words = cleanedValue.Split(' ');

        // Initialize a new StringBuilder for the sub-paragraph
        StringBuilder subParagraphBuilder = new();

        // Initialize the current line length
        int currentLineLength = 0;

        // Add combined indentation
        string indent = new(' ', (bulletLevel + indentLevel) * indentation);
        subParagraphBuilder.Append(indent);
        currentLineLength += indent.Length;

        // Iterate through each word and build the sub-paragraph
        foreach (string word in words)
        {
            if (currentLineLength + word.Length + 1 > effectiveMaxLineLength)
            {
                // Start a new line if the current line length exceeds the max line length
                subParagraphBuilder.AppendLine();
                subParagraphBuilder.Append(indent);
                subParagraphBuilder.Append("  "); // Indent wrapped lines by 2 characters
                currentLineLength = indent.Length + 2;
            }

            // Add a space before the word if it's not the first word in the line
            if (currentLineLength > indent.Length + 2)
            {
                subParagraphBuilder.Append(' ');
                currentLineLength++;
            }

            // Append the word to the sub-paragraph
            subParagraphBuilder.Append(word);
            currentLineLength += word.Length;
        }

        // Append the built sub-paragraph to the original StringBuilder
        sb.Append(subParagraphBuilder);
        sb.AppendLine();

        return sb;
    }

    /// <summary>
    ///  Indents each line of the given text by a specified number of spaces.
    /// </summary>
    /// <param name="text">The text to indent.</param>
    /// <param name="indentLevel">The level of indentation.</param>
    /// <param name="indent">The number of spaces for each indentation level.</param>
    /// <returns>The indented text.</returns>
    /// <remarks>
    ///  <para>
    ///   This method indents each line of the given text by a specified number of spaces.
    ///   It splits the text into lines, adds the indentation, and then joins the lines back together.
    ///  </para>
    /// </remarks>
    public static string IndentLines(this string? text, int indentLevel, int indent = 4)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        string indentString = new(' ', indentLevel * indent);

        return string.Join(
            separator: Environment.NewLine,
            values: text.Split(Environment.NewLine)
                .Select(line => $"{indentString}{line}"));
    }

    /// <summary>
    ///  Joins an array of strings into a single string, or returns an empty string if the array is null or empty.
    /// </summary>
    /// <param name="strings">The array of strings to join.</param>
    /// <param name="joinType">The type of join operation to perform.</param>
    /// <returns>The joined string, or an empty string if the array is null or empty.</returns>
    /// <remarks>
    ///  <para>
    ///   This method joins an array of strings into a single string using the specified join type.
    ///   If the array is null or empty, it returns an empty string.
    ///  </para>
    /// </remarks>
    public static string JoinOrEmpty(this string[]? strings, JoinType joinType = JoinType.NewLine)
    {
        if (strings is null || strings.Length == 0)
        {
            return string.Empty;
        }

        return strings.Join(joinType);
    }

    /// <summary>
    ///  Joins an array of strings into a single string, or returns null if the array is null or empty.
    /// </summary>
    /// <param name="strings">The array of strings to join.</param>
    /// <param name="joinType">The type of join operation to perform.</param>
    /// <returns>The joined string, or null if the array is null or empty.</returns>
    /// <remarks>
    ///  <para>
    ///   This method joins an array of strings into a single string using the specified join type.
    ///   If the array is null or empty, it returns null.
    ///  </para>
    /// </remarks>
    public static string? JoinOrDefault(this string[]? strings, JoinType joinType = JoinType.NewLine)
    {
        if (strings is null || strings.Length == 0)
        {
            return null;
        }

        return strings.Join(joinType);
    }

    /// <summary>
    ///  Joins an array of strings into a single string using the specified join type.
    /// </summary>
    /// <param name="strings">The array of strings to join.</param>
    /// <param name="joinType">The type of join operation to perform.</param>
    /// <returns>The joined string.</returns>
    /// <remarks>
    ///  <para>
    ///   This method joins an array of strings into a single string using the specified join type.
    ///   It supports joining with new lines, commas, or semicolons.
    ///  </para>
    /// </remarks>
    public static string Join(this string[]? strings, JoinType joinType = JoinType.NewLine)
    {
        if (strings is null)
        {
            return string.Empty;
        }
        return joinType switch
        {
            JoinType.NewLine => string.Join(Environment.NewLine, strings),
            JoinType.Comma => string.Join(", ", strings),
            JoinType.Semicolon => string.Join("; ", strings),
            _ => throw new ArgumentOutOfRangeException(nameof(joinType), joinType, null)
        };
    }

    /// <summary>
    ///  Removes extra whitespace from a string.
    /// </summary>
    /// <returns>A Regex object to match extra whitespace.</returns>
    /// <remarks>
    ///  <para>
    ///   This method returns a Regex object that matches one or more whitespace characters.
    ///   It is used to clean up the input text by removing extra whitespace and newlines.
    ///  </para>
    /// </remarks>
    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveWhiteSpace();
}
