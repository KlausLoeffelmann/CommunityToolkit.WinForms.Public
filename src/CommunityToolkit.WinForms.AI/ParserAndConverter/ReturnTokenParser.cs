using CommunityToolkit.Roslyn.Tooling;
using Microsoft.SemanticKernel;

using System.Diagnostics;
using System.Text;

namespace CommunityToolkit.WinForms.AI.ConverterLogic;

/// <summary>
///  Parses and processes tokens from a streaming chat message content.
/// </summary>
/// <remarks>
///  <para>
///   This class is responsible for parsing tokens from a streaming chat message content and 
///   processing them to identify metadata, paragraphs, and code blocks.
///  </para>
///  <para>
///   It handles the detection of inline code using backticks and processes metadata tokens 
///   enclosed in double curly braces.
///  </para>
///  <para>
///   This implementation deliberately avoids using spans for performance optimization, as the 
///   stream comes in token-wise, making it necessary to wait for the data rather than the other 
///   way around.
///  </para>
/// </remarks>
internal static class ReturnTokenParser
{
#if COLLECT_TEST_DATA
    private static readonly List<string> s_testDataCollector = [];
#endif

    public const string CodeBlockFilename = nameof(CodeBlockFilename);
    public const string CodeBlockDescription = nameof(CodeBlockDescription);
    public const string CodeBlockType = nameof(CodeBlockType);

    /// <summary>
    /// Processes tokens from the given async enumerable and triggers actions based on the
    /// identified content.
    /// </summary>
    /// <param name="asyncEnumerable">The async enumerable of streaming chat message content.</param>
    /// <param name="onReceivedMetaDataAction">Action to trigger when metadata is received.</param>
    /// <param name="onReceivedNextParagraphAction">Action to trigger when a new paragraph is received.</param>
    /// <param name="onCodeBlockInfoProvidedAction">Action to trigger when code block information is provided.</param>
    /// <returns>An async enumerable of processed token strings.</returns>
    /// <remarks>
    ///  <para>
    ///   <b>Algorithm Description:</b> This method reads tokens from the provided async enumerable,
    ///   interpreting metadata, paragraphs, and code blocks. When these elements are identified, the
    ///   corresponding actions are triggered.
    ///  </para>
    ///  <para>
    ///   The parser uses several groups of variables to manage its state and build content:
    ///   <list type="bullet">
    ///    <item>
    ///     <term>Accumulators</term>
    ///     <description>
    ///      <c>wordBuilder</c> gathers characters to form words; <c>paragraphBuilder</c> accumulates
    ///      paragraph text; <c>metaDataBuilder</c> collects metadata content; and <c>codeBlockBuilder</c>
    ///      (when initialized) accumulates code block content.
    ///     </description>
    ///    </item>
    ///    <item>
    ///     <term>Position &amp; Parsing State</term>
    ///     <description>
    ///      <c>positionCounter</c> tracks the current position in the stream. Parsing flags such as
    ///      <c>inMeta</c>, <c>pendingOpen</c>, <c>pendingClose</c>, <c>metaCandidateDedicated</c>,
    ///      and <c>isInlineCode</c> control the logic for entering/exiting metadata or code block modes.
    ///     </description>
    ///    </item>
    ///    <item>
    ///     <term>Code Block Management</term>
    ///     <description>
    ///      <c>currentCodeBlock</c> holds details about the active code block, while
    ///      <c>nestedCodeBlockCounter</c> tracks the nesting level for code blocks.
    ///     </description>
    ///    </item>
    ///    <item>
    ///     <term>Character Lookahead</term>
    ///     <description>
    ///      <c>pendingChar</c> temporarily stores a character to support lookahead during parsing.
    ///     </description>
    ///    </item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   <b>Word Processing Context:</b> A local function 
    ///   <c>GetWholeWordWhileProcessingParagraphAndCodeBlock</c> processes completed words to provide
    ///   context that a single token cannot supply. For example, tokens such as ["``", "`csharp"] may
    ///   split logical code boundaries. To address this, the function converts the synchronous token stream
    ///   into an asynchronous character stream and iterates through individual characters to build complete
    ///   words with the necessary context.
    ///  </para>
    /// </remarks>
    public static async IAsyncEnumerable<string> ProcessTokens(
    IAsyncEnumerable<StreamingChatMessageContent> asyncEnumerable,
        Action<AsyncReceivedInlineMetaDataEventArgs> onReceivedMetaDataAction,
        Action<AsyncReceivedNextParagraphEventArgs> onReceivedNextParagraphAction,
        Action<AsyncCodeBlockInfoProvidedEventArgs> onCodeBlockInfoProvidedAction)
    {
        bool useUnixLineEndings = false;

        StringBuilder wordBuilder = new();
        StringBuilder paragraphBuilder = new();
        StringBuilder metaDataBuilder = new();
        StringBuilder? codeBlockBuilder = null;

        int positionCounter = 0;

        // State flags.
        bool inMeta = false;
        bool pendingOpen = false;   // waiting for second '{'
        bool pendingClose = false;  // waiting for second '}'
        bool metaCandidateDedicated = false;
        bool isInlineCode = false;        // new flag to track code blocks/spans

        string? lastFoundCodeBlockFilename = null;
        string? lastFoundCodeBlockType = null;
        string? lastFoundCodeBlockDescription = null;

        CodeBlockInfo? currentCodeBlock = null;
        int nestedCodeBlockCounter = 0;

        // Used to “peek” ahead.
        char? pendingChar = null;

#if COLLECT_TEST_DATA
        s_testDataCollector.Clear();

        await foreach (StreamingChatMessageContent token in asyncEnumerable)
        {
            s_testDataCollector.Add(token.Content.ToCSharpLiteral());
        }

        // Find the temp-directory, see if a RawToken-folder exist,
        // create it, if not, and then save the file under "RowTokens-<timestamp>.txt".
        string tempPath = Path.GetTempPath();
        string rawTokenPath = Path.Combine(tempPath, "RawTokens");

        if (!Directory.Exists(rawTokenPath))
        {
            Directory.CreateDirectory(rawTokenPath);
        }

        string fileName = Path.Combine(rawTokenPath, $"RawTokens-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt");
        File.WriteAllLines(fileName, s_testDataCollector);
#endif

        // Get the char stream.
        await using IAsyncEnumerator<char> enumerator =
            ConvertToCharStreamAsync(asyncEnumerable).GetAsyncEnumerator();

        while (true)
        {
            char c;

            if (pendingChar is not null)
            {
                c = pendingChar.Value;
                pendingChar = null;
            }
            else if (await enumerator.MoveNextAsync())
            {
                c = enumerator.Current;
            }
            else
            {
                // End of stream.
                c = '\0';
            }

            // --- Code detection (simple inline code using backticks) ---
            if (c == '`' && nestedCodeBlockCounter == 0)
            {
                isInlineCode = !isInlineCode;
                // Always output the backtick.
                positionCounter++;
                wordBuilder.Append(c);
                paragraphBuilder.Append(c);

                continue;
            }

            // --- Only process potential meta markers if not in code ---
            if (!inMeta && !isInlineCode)
            {
                if (pendingOpen)
                {
                    if (c == '{')
                    {
                        // Start metadata block.
                        inMeta = true;
                        pendingOpen = false;
                        metaDataBuilder.Clear();

                        // If no text has been appended to the paragraph, mark as dedicated.
                        metaCandidateDedicated = paragraphBuilder.Length == 0;

                        continue;
                    }
                    else
                    {
                        // False alarm: output the pending '{' and process current char.
                        wordBuilder.Append('{');
                        positionCounter++;
                        pendingOpen = false;
                        // Fall through to normal processing.
                    }
                }

                if (c == '{')
                {
                    pendingOpen = true;
                    continue;
                }
            }
            else if (inMeta)
            {
                // We're inside a metadata token stream: {{key:value}}.
                if (pendingClose)
                {
                    if (c == '}')
                    {
                        // End metadata block.
                        inMeta = false;
                        pendingClose = false;

                        string metaContent = metaDataBuilder.ToString();
                        // Parse key and value.
                        int colonIndex = metaContent.IndexOf(':');

                        string key = colonIndex >= 0
                            ? metaContent[..colonIndex].Trim()
                            : metaContent.Trim();

                        string value = colonIndex >= 0
                            ? metaContent[(colonIndex + 1)..].Trim()
                            : string.Empty;

                        bool wasDedicated = false;

                        (pendingChar, wasDedicated) = await ProcessMetadataTokenStream(
                            metaCandidateDedicated,
                            pendingChar,
                            enumerator,
                            wasDedicated);

                        switch (key)
                        {
                            case CodeBlockFilename:
                                lastFoundCodeBlockFilename = value;
                                break;

                            case CodeBlockType:
                                lastFoundCodeBlockType = value;
                                break;

                            case CodeBlockDescription:
                                lastFoundCodeBlockDescription = value;
                                break;
                        }

                        ReturnStreamMetaData metaDataItem =
                            new(key, value, positionCounter, wasDedicated);

                        onReceivedMetaDataAction(
                            new AsyncReceivedInlineMetaDataEventArgs(metaDataItem));

                        metaDataBuilder.Clear();
                        metaCandidateDedicated = false;

                        continue;
                    }
                    else
                    {
                        // False alarm: include the pending '}'.
                        metaDataBuilder.Append('}');
                        pendingClose = false;
                        // Process current char as metadata content.
                    }
                }

                if (c == '}')
                {
                    pendingClose = true;
                    continue;
                }

                metaDataBuilder.Append(c);

                continue;
            }

            // --- Normal text processing (including when inCode) ---
            if (c != '\0')
            {
                positionCounter++;
                wordBuilder.Append(c);
                paragraphBuilder.Append(c);
            }

            if (IsWordSeparator(c) && wordBuilder.Length > 0)
            {
                yield return GetWholeWordWhileProcessingParagraphAndCodeBlock(
                    word: wordBuilder.ToString(),
                    lastChar: c,
                    useUnixLineEndings: useUnixLineEndings,
                    isEndOfDocument: c == '\0');

                wordBuilder.Clear();
            }

            if (c == '\0')
            {
                break;
            }
        }

        static async Task<(char? pendingChar, bool wasDedicated)> ProcessMetadataTokenStream(
            bool metaCandidateDedicated,
            char? pendingChar,
            IAsyncEnumerator<char> enumerator,
            bool wasDedicated)
        {
            // Peek ahead to see if the metadata token is alone on the line.
            if (metaCandidateDedicated && await enumerator.MoveNextAsync())
            {
                char next = enumerator.Current;

                if (next is '\n')
                {
                    wasDedicated = true;
                    pendingChar = null;
                }
                else
                {
                    pendingChar = next;
                    wasDedicated = false;
                }
            }

            return (pendingChar, wasDedicated);
        }

        string GetWholeWordWhileProcessingParagraphAndCodeBlock(
            string word,
            char? lastChar,
            bool useUnixLineEndings,
            bool isEndOfDocument = false)
        {
            if (isEndOfDocument)
            {
                // We need to flush the last [word]-Paragraph.
                word = useUnixLineEndings
                    ? word
                    : word.Replace("\n", "\r\n");

                onReceivedNextParagraphAction(new AsyncReceivedNextParagraphEventArgs(
                    paragraph: paragraphBuilder.ToString(),
                    textPosition: positionCounter,
                    isLastParagraph: isEndOfDocument));

                return word;
            }

            // Pipeline-internally, we use Unix-style line endings, so we won't use look-aheads.
            if (lastChar is null or '\n')
            {
                string paragraph = paragraphBuilder.ToString();

                if (IsCodeBlockInitiator(paragraph, out CodeBlockInfo? codeBlockInfo))
                {
                    if (nestedCodeBlockCounter == 0)
                    {
                        currentCodeBlock = codeBlockInfo;
                    }

                    nestedCodeBlockCounter++;
                    isInlineCode = true;
                }
                else
                {
                    string trimmedParagraph = paragraph.Trim();

                    if (trimmedParagraph == "```")
                    {
                        if (nestedCodeBlockCounter == 1)
                        {
                            isInlineCode = false;

                            CodeBlockInfo codeBlock = currentCodeBlock
                                ?? throw new InvalidOperationException("Code block not initialized.");

                            codeBlock.Code = codeBlockBuilder?.ToString()
                                ?? throw new InvalidOperationException("Code block content not initialized.");

                            codeBlock.Type = lastFoundCodeBlockType ?? string.Empty;
                            codeBlock.Filename = lastFoundCodeBlockFilename ?? string.Empty;
                            codeBlock.Description = lastFoundCodeBlockDescription ?? string.Empty;

                            onCodeBlockInfoProvidedAction(
                                new AsyncCodeBlockInfoProvidedEventArgs(codeBlock));

                            currentCodeBlock = null;
                            lastFoundCodeBlockFilename = null;
                            lastFoundCodeBlockType = null;
                            lastFoundCodeBlockDescription = null;
                            codeBlockBuilder = null;
                        }

                        nestedCodeBlockCounter--;
                        Debug.Assert(nestedCodeBlockCounter >= 0);
                    }
                }

                if (nestedCodeBlockCounter > 0)
                {
                    // We need to skip the first line, because we do not want
                    // the tick-line to be part of the code-block.
                    if (codeBlockBuilder is null)
                    {
                        codeBlockBuilder = new();
                    }
                    else
                    {
                        codeBlockBuilder?.Append(paragraph);
                    }
                }

                if (!useUnixLineEndings)
                {
                    if (paragraphBuilder.Length == 0)
                    {
                        // If we have no paragraph, we need to add a new line.
                        paragraphBuilder.Append("\r\n");
                    }
                    else if (paragraphBuilder.Length == 1 && paragraphBuilder[0] == '\n')
                    {
                        // If we have only a single \n, we need to convert to Windows.
                        paragraphBuilder[0] = '\r';
                        paragraphBuilder.Append('\n');
                    }
                    else if (paragraphBuilder[^2] != '\r'
                        && paragraphBuilder[^1] == '\n')
                    {
                        paragraphBuilder[^1] = '\r';
                        paragraphBuilder.Append('\n');
                    }
                }

                onReceivedNextParagraphAction(new AsyncReceivedNextParagraphEventArgs(
                        paragraph: paragraphBuilder.ToString(),
                        textPosition: positionCounter,
                        isLastParagraph: isEndOfDocument));

                paragraphBuilder.Clear();
            }

            return useUnixLineEndings
                ? word
                : word.Replace("\n", "\r\n");
        }
    }

    private static bool IsCodeBlockInitiator(string paragraph, out CodeBlockInfo? codeBlock)
    {
        codeBlock = null;

        // Let's use a Span<char> to avoid allocations:
        // A code-block can be initiated with 3 or 4 ticks, followed by a code-block descriptor
        // (e.g., "csharp" or "cs" for C# code) and a newline.
        ReadOnlySpan<char> span = paragraph.AsSpan();

        if (span.Length < 4)
        {
            return false;
        }

        // We need to _ensure_ 3 or 4 ticks and then _get_ the descriptor.
        // However, a 5th tick is not allowed - then this would not be a code block start.
        if (span[0] != '`' || span[1] != '`' || span[2] != '`')
        {
            return false;
        }

        int tickCount = 3;
        if (span.Length > 3 && span[3] == '`')
        {
            tickCount++;
        }

        // Ensure no 5th tick
        if (span.Length > tickCount && span[tickCount] == '`')
        {
            return false;
        }

        // Check for a valid descriptor after the ticks
        ReadOnlySpan<char> descriptor = span[tickCount..].Trim();

        if (descriptor.Length == 0)
        {
            return false;
        }

        codeBlock = new CodeBlockInfo
        {
            Code = string.Empty,
            Language = descriptor.ToString(),
            Type = string.Empty,
            Filename = string.Empty
        };

        return true;
    }

    private static bool IsWordSeparator(char c) =>
        // 0 signals end of stream.
        c == '\0' || char.IsWhiteSpace(c);

    static async IAsyncEnumerable<char> ConvertToCharStreamAsync(
        IAsyncEnumerable<StreamingChatMessageContent> asyncEnumerable)
    {
        bool wasCR = false;

        await foreach (StreamingChatMessageContent response in asyncEnumerable)
        {
            if (response?.Content is null)
            {
                continue;
            }

            foreach (char c in response.Content)
            {
                if (c == '\r')
                {
                    wasCR = true;
                    continue;
                }
                else if (c == '\n')
                {
                    // If there was a preceding CR, we yield one newline.
                    if (wasCR)
                    {
                        wasCR = false;
                    }

                    yield return '\n';
                }
                else
                {
                    // If there was a CR but no LF, yield the CR.
                    if (wasCR)
                    {
                        wasCR = false;
                        yield return '\r';
                    }

                    yield return c;
                }
            }
        }
    }
}
