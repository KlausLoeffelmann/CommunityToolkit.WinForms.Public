using CommunityToolkit.WinForms.AI.ConverterLogic;
using CommunityToolkit.WinForms.AsyncSupport;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommunityToolkit.WinForms.AI;

#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
public partial class SemanticKernelComponent : BindableComponent
{
    public static string CodeBlockFilenameMetaTag => ReturnTokenParser.CodeBlockFilename;
    public static string CodeBlockTypeMetaTag => ReturnTokenParser.CodeBlockType;
    public static string CodeBlockDescriptionMetaTag => ReturnTokenParser.CodeBlockDescription;

    private const string DefaultModelName = "gpt-4o-2024-11-20";
    private const string ApiEndpoint = "https://api.openai.com/v1/models";

    private static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    private static readonly JsonSerializerOptions TrailingCommasJsonSerializerOptions = new()
    {
        AllowTrailingCommas = true
    };

    /// <summary>
    ///  Event triggered to request assistant instructions asynchronously.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This event is triggered to request assistant instructions asynchronously.
    ///   It allows subscribers to provide custom instructions for the assistant.
    ///  </para>
    /// </remarks>
    public event AsyncEventHandler<AsyncRequestAssistantInstructionsEventArgs>? AsyncRequestAssistanceInstructions;

    /// <summary>
    ///  Event triggered to request execution settings asynchronously.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This event is triggered to request execution settings asynchronously.
    ///   It allows subscribers to provide custom execution settings for the assistant.
    ///  </para>
    /// </remarks>
    public event AsyncEventHandler<AsyncRequestExecutionSettingsEventArgs>? AsyncRequestExecutionSettings;

    /// <summary>
    ///  Event triggered when the next paragraph is received asynchronously.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This event is triggered when the next paragraph is received asynchronously.
    ///   It allows subscribers to handle the received paragraph data.
    ///  </para>
    /// </remarks>
    public event AsyncEventHandler<AsyncReceivedNextParagraphEventArgs>? AsyncReceivedNextParagraph;

    public event AsyncEventHandler<AsyncCodeBlockInfoProvidedEventArgs>? AsyncCodeBlockInfoProvided;

    /// <summary>
    ///  Event triggered when inline metadata is received asynchronously.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This event is triggered when inline metadata is received asynchronously.
    ///   It allows subscribers to handle the received metadata.
    ///  </para>
    /// </remarks>
    public event AsyncEventHandler<AsyncReceivedInlineMetaDataEventArgs>? AsyncReceivedInlineMetaData;

    public event EventHandler? JsonSchemaStringChanged;
    public event EventHandler? JsonSchemaChanged;

    // The chat history. If you are using ChatGPT for example directly in the WebBrowser,
    // this equals the chat history, so, the things you've said and the responses you've received.
    private ChatHistory? _chatHistory;

    // The kernel for the Semantic Kernel scenario. It bundles the connectors and services.
    private Kernel? _kernel;

    // The parentForm, which we might need to invoke the UI thread.
    private double? _topP;
    private double? _temperature;
    private double? _presencePenalty;
    private double? _frequencyPenalty;

    // Both lazy singletons.
    private JsonSerializerOptions? _jsonDefaultSerializerOptions;
    private JsonSerializerOptions? _jsonTrailingCommasSerializerOptions;

    private readonly SynchronizationContext? _syncContext = WindowsFormsSynchronizationContext.Current;
    private string? _developerPrompt;
    private bool _queueDeveloperPrompt;
    private JsonElement? _jsonSchema;

    /// <summary>
    ///  Requests a prompt response from the OpenAI API. Make sure, you set at least the <see cref="ApiKeyGetter"/> property,
    ///  and the <see cref="DeveloperPrompt"/> property, which is the general description, what the Assistant is suppose to do.
    /// </summary>
    /// <param name="valueToProcess">The value as string which the model should process.</param>
    /// <returns>The result from the LLM Model as plain text string or JSon string.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<string?> RequestTextPromptResponseAsync(
        string valueToProcess,
        bool keepChatHistory)
    {
        if (string.IsNullOrWhiteSpace(valueToProcess))
            throw new InvalidOperationException("You requested to process a prompt, but did not provide any content to process.");

        (OpenAIChatCompletionService chatService, OpenAIPromptExecutionSettings executionSettings) = await GetOrCreateChatServiceAsync();

        ChatHistory chatHistory = HandleChatHistory(valueToProcess, keepChatHistory);

        IReadOnlyList<ChatMessageContent> responses = await chatService.GetChatMessageContentsAsync(
            chatHistory,
            kernel: _kernel,
            executionSettings: executionSettings);

        StringBuilder responseStringBuilder = new();

        // We can have several responses, so we'll append them all to the text box.
        // But we need to also add them to the chat history!
        foreach (ChatMessageContent response in responses)
        {
            chatHistory.AddMessage(response.Role, response.ToString());
            responseStringBuilder.Append(response);
        }

        return responseStringBuilder.ToString();
    }

    /// <summary>
    ///  Requests a prompt response from the OpenAI API as an async stream. Make sure, you set at least the <see cref="ApiKeyGetter"/> property,
    ///  and the <see cref="DeveloperPrompt"/> property, which is the general description, what the Assistant is suppose to do.
    /// </summary>
    /// <param name="valueToProcess">The value as string which the model should process.</param>
    /// <param name="keepChatHistory">Indicates whether to keep the chat history for the session.</param>
    /// <returns>
    ///  Returns an async stream of strings, which are the responses from the LLM model.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///  Thrown when the value to process is null or empty.
    /// </exception>
    /// <remarks>
    ///  <para>
    ///   This method sends a prompt to the OpenAI API and returns the responses as an asynchronous stream of strings.
    ///   It ensures that the necessary properties, such as the API key and system prompt, are set before making the request.
    ///  </para>
    ///  <para>
    ///   The method handles the chat history based on the keepChatHistory parameter. If keepChatHistory is false, the chat history is cleared,
    ///   and the system prompt is queued for the next request. If keepChatHistory is true, the chat history is maintained across requests.
    ///  </para>
    ///  <para>
    ///   The responses are processed as an asynchronous stream, allowing the caller to handle each response as it is received.
    ///   The method also raises events for received metadata and paragraphs, enabling subscribers to handle these events accordingly.
    ///  </para>
    /// </remarks>
    public async IAsyncEnumerable<string> RequestPromptResponseStreamAsync(string valueToProcess, bool keepChatHistory)
    {
        if (string.IsNullOrWhiteSpace(valueToProcess))
            throw new InvalidOperationException("You requested to process a prompt, but did not provide any content to process.");

        (OpenAIChatCompletionService chatService, OpenAIPromptExecutionSettings executionSettings) 
            = await GetOrCreateChatServiceAsync();

        ChatHistory chatHistory = HandleChatHistory(valueToProcess, keepChatHistory);

        IAsyncEnumerable<StreamingChatMessageContent> responses = chatService.GetStreamingChatMessageContentsAsync(
            chatHistory,
            executionSettings: executionSettings,
            kernel: _kernel);

        responses = chatHistory.AddStreamingMessageAsync(
            (IAsyncEnumerable<OpenAIStreamingChatMessageContent>)responses);

        await foreach (string response in ReturnTokenParser.ProcessTokens(
            asyncEnumerable: responses,
            onReceivedMetaDataAction: OnReceivedMetaData,
            onReceivedNextParagraphAction: OnReceivedNextParagraph,
            onCodeBlockInfoProvidedAction: OnCodeBlockInfoProvided))
        {
            if (string.IsNullOrEmpty(response))
            {
                continue;
            }

            yield return response;
        }
    }

    protected virtual void OnReceivedMetaData(AsyncReceivedInlineMetaDataEventArgs receivedMetaDataEventArgs)
        => AsyncReceivedInlineMetaData?.Invoke(this, receivedMetaDataEventArgs);

    private ChatHistory HandleChatHistory(string valueToProcess, bool keepChatHistory)
    {
        if (ChatHistory is null)
        {
            throw new InvalidOperationException("You requested to process a prompt, but the ChatHistory is not set.");
        }

        // If we do not want to keep the chat history, clear it and queue the system prompt for the next request.
        if (!keepChatHistory)
        {
            ChatHistory.Clear();
            _queueDeveloperPrompt = true;
        }

        // If the system prompt is queued, add it to the chat history.
        // The _queueDeveloperPrompt is for scenarios where we change the DeveloperPrompt on the fly.
        // TODO: Since the introduction of DeveloperPrompts, this doesn't work reliably, anymore, and we should make sure, changing the Developer-Prompt erases the ChatHistory.
        if (_queueDeveloperPrompt)
        {
            ChatHistory.AddMessage(
                AuthorRole.Developer,
                EffectiveDeveloperPrompt ?? throw new InvalidOperationException("The effective developer prompt is not set."));

            _queueDeveloperPrompt = false;
        }

        // Add the user's message to the chat history.
        ChatHistory.AddUserMessage(valueToProcess);

        return ChatHistory;
    }

    private async Task<(OpenAIChatCompletionService chatService, OpenAIPromptExecutionSettings executionSettings)> GetOrCreateChatServiceAsync()
    {
        if (ApiKeyGetter is null)
            throw new InvalidOperationException("You have tried to request a prompt, but did not provide Func delegate to get the api key.");

        AsyncRequestAssistantInstructionsEventArgs eArgs = new(GetAssistantInstructions());
        await OnRequestAssistantInstructionsAsync(eArgs);

        OpenAIPromptExecutionSettings executionSettings = new()
        {
            ModelId = ModelId
        };

        if (!ModelId.StartsWith("o1") && !ModelId.StartsWith("o3"))
        {
            executionSettings = executionSettings
            .WithDefaultModelParameters(
                MaxTokens: MaxTokens,
                temperature: Temperature,
                topP: TopP,
                frequencyPenalty: _frequencyPenalty,
                presencePenalty: _presencePenalty);
        }

        if (!string.IsNullOrEmpty(JsonSchemaString))
        {
            // We have a JsonSchema, but we need to convert this into a JsonElement internally:
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement?>(JsonSchemaString) 
                ?? throw new InvalidOperationException("The Json Schema could not be deserialized.");

            executionSettings = executionSettings.WithJsonReturnSchema(
                jsonElement,
                JsonSchemaName,
                JsonSchemaDescription);

            EffectiveDeveloperPrompt = $"{eArgs.AssistantInstructions}\n\n{DeveloperPromptSchemaAmendment}" +
                  $"\n\nThe Json Schema is as follows:\n{JsonSchemaString}";
        }
        else
        {
            string formatRequestString = $"\n\nIMPORTANT: Please make sure that you format your replies consistently "
                + ResponseTextFormat switch
                {
                    ResponseTextFormat.Markdown => "Markdown formatted.",
                    ResponseTextFormat.Html => "as HTML.",
                    ResponseTextFormat.MicrosoftRichText => "as Microsoft Rich Text Format (RTF).",
                    _ => "as plain text without any additional formatting."
                };

            EffectiveDeveloperPrompt = $"{eArgs.AssistantInstructions}\n" + $"{formatRequestString}";
        }

        AsyncRequestExecutionSettingsEventArgs settingsEventArgs = new(executionSettings);
        await OnRequestExecutionSettingsAsync(settingsEventArgs);

        string apiKey = ApiKeyGetter.Invoke()
            ?? throw new InvalidOperationException("The ApiKeyGetter did not retrieve a working api key.");

        IKernelBuilder kernelBuilder = Kernel
            .CreateBuilder()
            .AddOpenAIChatCompletion(ModelId, apiKey);

        if (Logger is not null)
        {
            ILoggerFactory loggerFactory = CreateTelemetryLogger();
            kernelBuilder.Services.AddSingleton(loggerFactory);

            Logger.LogDebug("Telemetry logger created.");
        }

        _kernel = kernelBuilder.Build();
        _chatHistory ??= [];

        OpenAIChatCompletionService chatService = (OpenAIChatCompletionService)_kernel
            .GetRequiredService<IChatCompletionService>();

        return (chatService, settingsEventArgs.ExecutionSettings);
    }


    /// <summary>
    /// Asynchronously queries the OpenAI API for available model names.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a collection of model names if the request is successful; 
    /// otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the API key for Open-AI access could not be retrieved.
    /// </exception>
    public async Task<IEnumerable<string>?> QueryOpenAiModelNamesAsync()
    {
        string apiKey = (ApiKeyGetter?.Invoke())
            ?? throw new InvalidOperationException("API-Key for Open-AI access could not be retrieved.");

        using HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        try
        {
            _jsonDefaultSerializerOptions ??= new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            HttpResponseMessage response = await client.GetAsync(ApiEndpoint);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            OpenAiModelList? models = JsonSerializer.Deserialize<OpenAiModelList>(
                responseBody,
                options: _jsonDefaultSerializerOptions);

            return models?.Data.Select(item => item.Id);
        }
        catch (Exception ex)
        {
            ExceptionDispatchInfo dispatchInfo = ExceptionDispatchInfo.Capture(ex);

            // Marshal to the UI thread
            _syncContext?.Post(_ => { dispatchInfo.Throw(); }, null);

            return null;
        }
    }

    /// <summary>
    /// Asynchronously queries the OpenAI API for detailed information about a specified model.
    /// </summary>
    /// <param name="modelName">The name of the model to query.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the model information if successful; 
    /// otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the API key for Open-AI access could not be retrieved.
    /// </exception>
    public async Task<ModelInfo?> QueryOpenAiModelInfoAsync(string modelName)
    {
        string apiKey = (ApiKeyGetter?.Invoke())
            ?? throw new InvalidOperationException("API-Key for Open-AI access could not be retrieved.");

        using HttpClient client = new();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        try
        {
            HttpResponseMessage response = await client.GetAsync($"{ApiEndpoint}/{modelName}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            ModelInfo? modelInfo = JsonSerializer.Deserialize<ModelInfo>(content);

            return modelInfo;
        }
        catch (Exception ex)
        {
            ExceptionDispatchInfo dispatchInfo = ExceptionDispatchInfo.Capture(ex);

            // Marshal to the UI thread
            _syncContext?.Post(_ => { dispatchInfo.Throw(); }, null);
        }

        return null;
    }

    /// <summary>
    /// Sends a request with the specified prompt to obtain a structured response and deserializes it to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the JSON response will be deserialized.</typeparam>
    /// <param name="userRequestPrompt">The user prompt to send as a request.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the deserialized object of type <typeparamref name="T"/>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the type prompt is not available or when the text response is empty.
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown if there is an error parsing or constructing the response object from the returned data.
    /// </exception>
    public async Task<T> RequestStructuredResponseAsync<T>(string userRequestPrompt)
    {
        string? jsonSchema = PromptFromTypeGenerator.GetJSonSchema<T>();
        string prompt = PromptFromTypeGenerator.GetTypePrompt<T>();

        string developerPrompt = prompt
            ?? throw new InvalidOperationException("The type did not return a basic (system) prompt.");

        string? previousJSonSchema = JsonSchemaString;

        if (string.IsNullOrWhiteSpace(previousJSonSchema))
        {
            previousJSonSchema = null;
        }

        string? previousDeveloperPrompt = DeveloperPrompt;

        JsonSchemaString = jsonSchema;
        DeveloperPrompt = developerPrompt;

        try
        {
            string? jsonReturnData = await RequestTextPromptResponseAsync(userRequestPrompt, false);

            if (string.IsNullOrEmpty(jsonReturnData))
            {
                throw new InvalidOperationException("Trying to parse the text input failed for unknown reasons.");
            }

            // Eliminate markdown formatting if present.
            if (jsonReturnData.StartsWith("```"))
            {
                int firstLineEnd = jsonReturnData.IndexOf('\n');
                if (firstLineEnd > 0)
                {
                    jsonReturnData = jsonReturnData[firstLineEnd..];
                }
            }

            if (jsonReturnData.EndsWith("```"))
            {
                int lastLineStart = jsonReturnData.LastIndexOf('\n');
                if (lastLineStart > 0)
                {
                    jsonReturnData = jsonReturnData[..lastLineStart];
                }
            }

            try
            {
                _jsonTrailingCommasSerializerOptions ??= new()
                {
                    AllowTrailingCommas = true
                };

                T typedReturnValue = JsonSerializer.Deserialize<T>(jsonReturnData, _jsonTrailingCommasSerializerOptions)!;

                return typedReturnValue;
            }
            catch (Exception innerException)
            {
                if (innerException is FormatException)
                {
                    throw;
                }

                throw new FormatException(
                    "There was a problem constructing the type from the response data.", innerException);
            }
        }
        finally
        {
            JsonSchemaString = previousJSonSchema;
            DeveloperPrompt = previousDeveloperPrompt;
        }
    }

    private static ILoggerFactory CreateTelemetryLogger()
    {
        ResourceBuilder resourceBuilder = ResourceBuilder
            .CreateDefault()
            .AddService("TelemetryConsoleQuickstart");

        // Enable model diagnostics with sensitive data!!
        // AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnosticsSensitive", true);

        // Enable model diagnostics without sensitive data.
        AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnostics", true);

        using TracerProvider traceProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(resourceBuilder)
            .AddSource("Microsoft.SemanticKernel*")
            .AddConsoleExporter()
            .Build();

        using MeterProvider meterProvider = Sdk.CreateMeterProviderBuilder()
            .SetResourceBuilder(resourceBuilder)
            .AddMeter("Microsoft.SemanticKernel*")
            .AddConsoleExporter()
            .Build();

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            // Add OpenTelemetry as a logging provider
            builder.AddOpenTelemetry(options =>
            {
                options.SetResourceBuilder(resourceBuilder);
                options.AddConsoleExporter();
                options.IncludeFormattedMessage = true;
                options.IncludeScopes = true;
            });

            builder.SetMinimumLevel(LogLevel.Trace);
        });

        return loggerFactory;
    }

    protected virtual string? GetAssistantInstructions()
        => DeveloperPrompt;

    protected virtual Task OnRequestAssistantInstructionsAsync(AsyncRequestAssistantInstructionsEventArgs eArgs)
        => AsyncRequestAssistanceInstructions?.Invoke(this, eArgs) ?? Task.CompletedTask;

    protected virtual Task OnRequestExecutionSettingsAsync(AsyncRequestExecutionSettingsEventArgs eArgs)
        => AsyncRequestExecutionSettings?.Invoke(this, eArgs) ?? Task.CompletedTask;

    /// <summary>
    /// Raises the <see cref="AsyncReceivedNextParagraph"/> event.
    /// </summary>
    /// <param name="receivedNextParagraphEventArgs">The event data.</param>
    protected virtual void OnReceivedNextParagraph(AsyncReceivedNextParagraphEventArgs receivedNextParagraphEventArgs)
        => AsyncReceivedNextParagraph?.Invoke(this, receivedNextParagraphEventArgs);

    protected virtual void OnCodeBlockInfoProvided(AsyncCodeBlockInfoProvidedEventArgs codeBlockInfoProvidedEventArgs)
        => AsyncCodeBlockInfoProvided?.Invoke(this, codeBlockInfoProvidedEventArgs);

    /// <summary>
    ///  Adds a chat item to the chat history.
    /// </summary>
    /// <param name="isResponse">Indicates whether the message is a response from the assistant.</param>
    /// <param name="message">The message to add to the chat history.</param>
    /// <remarks>
    ///  <para>
    ///   This method adds a message to the chat history, distinguishing between user messages 
    ///   and assistant responses.
    ///  </para>
    /// </remarks>
    public void AddChatItem(bool isResponse, string message)
    {
        _chatHistory ??= [];

        _chatHistory.AddMessage(
            isResponse ? AuthorRole.Developer : AuthorRole.User,
            message);
    }

    /// <summary>
    ///  Gets or sets the format in which human-readable, non-structured text is requested to be returned from the model.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the format for the text returned by the model, such as plain text, HTML, 
    ///   Markdown, or Microsoft Rich Text.
    ///  </para>
    /// </remarks>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Model Parameter")]
    [Description("Gets or sets the format in which human readable, non-structured Text is requested to be returned from the Model.")]
    [DefaultValue(ResponseTextFormat.Markdown)]
    public ResponseTextFormat ResponseTextFormat { get; set; } = ResponseTextFormat.Markdown;

    /// <summary>
    ///  Gets or sets the function to retrieve the API key for OpenAI.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds a delegate function that returns the API key required for accessing OpenAI services.
    ///  </para>
    ///  <para>
    ///   To set, for example, the API key in the Environment Variables on Windows, follow these steps:
    ///   <list type="number">
    ///     <item>
    ///       <description>Open the Start Menu and search for "Environment Variables".</description>
    ///     </item>
    ///     <item>
    ///       <description>Select "Edit the system environment variables".</description>
    ///     </item>
    ///     <item>
    ///       <description>In the System Properties window, click on the "Environment Variables" button.</description>
    ///     </item>
    ///     <item>
    ///       <description>In the Environment Variables window, click "New" under the "User variables" section.</description>
    ///     </item>
    ///     <item>
    ///       <description>Enter the variable name (e.g., "OPENAI_API_KEY") and the API key as the variable value.</description>
    ///     </item>
    ///     <item>
    ///       <description>Click "OK" to save the new environment variable.</description>
    ///     </item>
    ///     <item>
    ///       <description>Log off and log back on to ensure the environment variable is recognized by the system.</description>
    ///     </item>
    ///   </list>
    ///  </para>
    ///  <para>
    ///   Here is an example of how to create an ApiKeyGetter Func in C#:
    ///   <code language="csharp">
    ///    public Func<string> ApiKeyGetter = () => Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    ///   </code>
    ///  </para>
    ///  <para>
    ///   Here is an example of how to create an ApiKeyGetter Func in VB:
    ///   <code language="vb">
    ///    Public ApiKeyGetter As Func(Of String) = Function() Environment.GetEnvironmentVariable("OPENAI_API_KEY")
    ///   </code>
    ///  </para>
    /// </remarks>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Func<string>? ApiKeyGetter { get; set; }

    /// <summary>
    ///  Gets or sets the console control for logging.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property allows setting a console control to capture and display log output.
    ///  </para>
    /// </remarks>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ILogger? Logger { get; set; }

    /// <summary>
    ///  Gets or sets the JSON schema for the return value.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property defines the JSON schema for the return value. It can be set at design-time 
    ///   if the schema is known and constant, or dynamically using the PromptFromTypeSupport methods 
    ///   for flexible scenarios.
    ///  </para>
    /// </remarks>
    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Category("Model Parameter")]
    [Description($"Gets or sets JSon schema for the return value. If you are sure that the schema in your " +
        $"scenario never changes, you can put it here already at design-time. But " +
        $"consider using the {nameof(PromptFromTypeGenerator)} methods for flexible scenarios.")]
    public string? JsonSchemaString
    {
        get => _jsonSchema is null ? null : $"{_jsonSchema}";
        set
        {
            if (value == $"{_jsonSchema}")
            {
                // Nothing has changed - we're good.
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _jsonSchema = null;
                    return;
                }

                _jsonSchema = JsonSerializer.Deserialize<JsonElement?>(value);
            }
            catch (Exception ex)
            {
                // We need to pack whatever exception we got into a beginner's friendly message:
                string outerExceptionMessage = "The Json Schema could not be deserialized. Please check the schema for errors.\n" +
                    "The inner exception message will give you more details.";

                throw new InvalidOperationException(outerExceptionMessage, ex);
            }
            finally
            {
                OnJsonSchemaStringChanged(EventArgs.Empty);
                OnJsonSchemaChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    ///  Gets the JSON schema as a JsonElement.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property returns the JSON schema as a JsonElement, which can be used for further processing 
    ///   or validation.
    ///  </para>
    /// </remarks>
    public JsonElement? JsonSchema => _jsonSchema;

    /// <summary>
    ///  Raises the JsonSchemaStringChanged event.
    /// </summary>
    /// <param name="e">The event data.</param>
    /// <remarks>
    ///  <para>
    ///   This method is called when the JsonSchemaString property changes, raising the JsonSchemaStringChanged event.
    ///  </para>
    /// </remarks>
    protected virtual void OnJsonSchemaStringChanged(EventArgs e)
        => JsonSchemaStringChanged?.Invoke(this, e);

    /// <summary>
    ///  Raises the JsonSchemaChanged event.
    /// </summary>
    /// <param name="e">The event data.</param>
    /// <remarks>
    ///  <para>
    ///   This method is called when the JsonSchema property changes, raising the JsonSchemaChanged event.
    ///  </para>
    /// </remarks>
    protected virtual void OnJsonSchemaChanged(EventArgs e)
        => JsonSchemaChanged?.Invoke(this, e);
    /// <summary>
    ///  Gets or sets the JSon schema name for the return format.
    /// </summary>

    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Category("Model Parameter")]
    [Description("Gets or sets the name for the JSon schema. This does currently not influence what the model returns.")]
    public string? JsonSchemaName { get; set; } = null;

    /// <summary>
    ///  Gets or sets the JSon schema name for the return format.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Category("Model Parameter")]
    [Description("Gets or sets the Json schema description. This does currently not influence what the model returns.")]
    public string? JsonSchemaDescription { get; set; } = null;

    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(4096)]
    [Category("Model Parameter")]
    [Description("Gets or sets the maximum number of tokens to return.")]
    public int MaxTokens { get; set; } = 4096;

    /// <summary>
    ///  Gets or sets the resource string source for the Assistant Instructions.
    /// </summary>
    [DefaultValue(null)]
    public string? ResourceStreamSource { get; set; }

    /// <summary>
    ///  Gets or sets the chat history for the Semantic Kernel scenario.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ChatHistory? ChatHistory => _chatHistory;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual string? DeveloperPrompt
    {
        get => _developerPrompt;
        set
        {
            if (value == _developerPrompt)
                return;

            _developerPrompt = value;
            _queueDeveloperPrompt = true;
        }
    }

    /// <summary>
    ///  The SystemPrompt, as it became constructed based on schema information, original SystemPrompt and SystemPrompt event.
    /// </summary>
    private string? EffectiveDeveloperPrompt { get; set; }

    /// <summary>
    ///  Gets or sets an amendment to the system prompt in the case, a JSon schema had been provided, so 
    ///  we need to instruct the model to return the result in JSon according to the schema information.
    /// </summary>
    protected virtual string DeveloperPromptSchemaAmendment { get; set; } =
        // Note: The "IMPORTANT" is actually not necessary anymore with more modern models, like GPT-4o.
        // Also read: https://cookbook.openai.com/examples/structured_outputs_intro
        $"""
        In addition to everything previously said, it is absolutely essential that you return 
        the result in Json according to the enclosed json schema information. 
        
        IMPORTANT: DO NOT add any listing tags or other formatting to the result, just the plain json string!
        """;

    /// <summary>
    ///  Gets or sets the model name to use for chat completion.
    /// </summary>
    [Category("Model Parameter")]
    [DefaultValue(DefaultModelName)]
    [Description("The model name to use for chat completion - for example 'chat-gpt4o'.")]
    public string ModelId { get; set; } = DefaultModelName;

    /// <summary>
    ///  Gets or sets the frequency penalty to apply during chat completion.
    /// </summary>
    /// <remarks>
    ///  The frequency penalty is a value between 0 and 1 that penalizes the model for repeating the same response.
    ///  A higher value will make the model less likely to repeat responses.
    /// </remarks>
    [Category("Model Parameter")]
    [DefaultValue(null)]
    [Description("The frequency penalty is a value between 0 and 1 that penalizes the model for repeating the same response.")]
    public double? FrequencyPenalty
    {
        get => _frequencyPenalty;
        set => _frequencyPenalty = value;
    }

    /// <summary>
    ///  Gets or sets the presence penalty to apply during chat completion.
    /// </summary>
    /// <remarks>
    ///  The presence penalty is a value between 0 and 1 that penalizes the model for generating responses that are too long.
    ///  A higher value will make the model more likely to generate shorter responses.
    /// </remarks>
    [Category("Model Parameter")]
    [DefaultValue(null)]
    [Description("The presence penalty is a value between 0 and 1 that penalizes the model for generating responses that are too long.")]
    public double? PresencePenalty
    {
        get => _presencePenalty;
        set => _presencePenalty = value;
    }

    /// <summary>
    ///  Gets or sets the temperature value for chat completion.
    /// </summary>
    /// <remarks>
    ///  The temperature value controls the randomness of the model's responses.
    ///  A higher value will make the responses more random, while a lower value 
    ///  will make them more deterministic.
    /// </remarks>
    [Category("Model Parameter")]
    [DefaultValue(null)]
    [Description("The temperature value controls the randomness of the model's responses.")]
    public double? Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    /// <summary>
    ///  Gets or sets the top-p value for chat completion.
    /// </summary>
    /// <remarks>
    ///  The top-p value is a value between 0 and 1 that controls the diversity 
    ///  of the model's responses.
    ///  A higher value will make the responses more diverse, while a lower value 
    ///  will make them more focused.
    /// </remarks>
    [Category("Model Parameter")]
    [Description("The top-p value is a value between 0 and 1 that controls the diversity of the model's responses.")]
    [DefaultValue(1)]
    public double? TopP
    {
        get => _topP;
        set => _topP = value;
    }
}
