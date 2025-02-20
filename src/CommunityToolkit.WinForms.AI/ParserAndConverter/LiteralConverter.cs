using System.Text;

namespace CommunityToolkit.WinForms.AI.ConverterLogic;

/// <summary>
/// Provides extension methods for converting C# string literals.
/// </summary>
public static class StringLiteralConverterExtension
{
    /// <summary>
    ///  Converts a C# string literal to its corresponding unescaped string value.
    /// </summary>
    /// <param name="literal">
    ///  The C# string literal to convert. The literal "null" is treated as a null value.
    /// </param>
    /// <param name="ensureWindowsLineEndings">
    ///  If true, ensures that line endings are converted to Windows style.
    /// </param>
    /// <returns>
    ///  The unescaped string value, or null if the literal represents a null.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///  Thrown when the input is not a valid C# string literal or contains an invalid escape sequence.
    /// </exception>
    public static string? FromCSharpLiteral(this string? literal, bool ensureWindowsLineEndings = false)
    {
        if (literal == "null")
        {
            return null;
        }

        ArgumentNullException.ThrowIfNull(literal);

        if (literal.Length < 2 || literal[0] != '"' || literal[^1] != '"')
        {
            throw new ArgumentException(
                message: "Input is not a valid C# string literal.",
                paramName: nameof(literal));
        }

        ReadOnlySpan<char> inner = literal.AsSpan(1, literal.Length - 2);
        StringBuilder sb = new();

        for (int i = 0; i < inner.Length; i++)
        {
            char ch = inner[i];
            if (ch is not '\\')
            {
                sb.Append(ch);
            }
            else
            {
                i++;
                if (i >= inner.Length)
                {
                    throw new ArgumentException(
                        message: "Invalid escape sequence at end of literal.",
                        paramName: nameof(literal));
                }

                char next = inner[i];
                sb.Append(next switch
                {
                    '\\' => '\\',
                    '\"' => '\"',
                    '`' => '`',
                    '0' => '\0',
                    'a' => '\a',
                    'b' => '\b',
                    'f' => '\f',
                    'n' => '\n',
                    'r' => '\r',
                    't' => '\t',
                    'v' => '\v',
                    'u' => ParseUnicodeEscape(inner, ref i),
                    _ => throw new ArgumentException(
                        message: $"Unknown escape sequence: \\{next}",
                        paramName: nameof(literal))
                });
            }
        }

        string result = sb.ToString();
        return result;

        // Local function to parse a Unicode escape sequence using ReadOnlySpan<char>.
        static char ParseUnicodeEscape(ReadOnlySpan<char> span, ref int index)
        {
            const int hexDigits = 4;
            if (index + 1 + hexDigits > span.Length)
            {
                throw new ArgumentException(
                    message: "Incomplete Unicode escape sequence.",
                    paramName: nameof(literal));
            }

            ReadOnlySpan<char> hexSpan = span.Slice(index + 1, hexDigits);
            if (!int.TryParse(
                hexSpan,
                style: System.Globalization.NumberStyles.HexNumber,
                provider: null,
                out int code))
            {
                throw new ArgumentException(
                    message: "Invalid Unicode escape sequence.",
                    paramName: nameof(literal));
            }

            index += hexDigits;
            return (char)code;
        }
    }

    /// <summary>
    ///  Converts a string value to its corresponding C# string literal representation.
    /// </summary>
    /// <param name="input">
    ///  The string value to convert. A null value is represented as the literal "null".
    /// </param>
    /// <returns>A C# string literal representing the input string.</returns>
    public static string ToCSharpLiteral(this string? input)
    {
        // We're not using Span<T> here, since the performance difference is negligible.
        if (input is null)
        {
            return "null";
        }

        StringBuilder sb = new();
        sb.Append('\"');

        foreach (char ch in input)
        {
            sb.Append(ch switch
            {
                '\"' => "\\u0022",
                '\\' => "\\\\",
                '`' => "\\u0060",
                _ when (ch < ' ' || ch > (char)255) => ch switch
                {
                    '\0' => "\\0",
                    '\a' => "\\a",
                    '\b' => "\\b",
                    '\f' => "\\f",
                    '\n' => "\\n",
                    '\r' => "\\r",
                    '\t' => "\\t",
                    '\v' => "\\v",
                    _ => $"\\u{(int)ch:X4}"
                },
                _ => ch.ToString()
            });
        }

        sb.Append('\"');
        return sb.ToString();
    }
}
