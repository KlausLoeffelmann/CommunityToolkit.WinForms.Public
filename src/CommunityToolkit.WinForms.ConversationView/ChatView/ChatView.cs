using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.AsyncSupport;
using CommunityToolkit.WinForms.ChatUI.AIStructures;
using CommunityToolkit.WinForms.FluentUI.Controls;

using Microsoft.SemanticKernel.ChatCompletion;

using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace CommunityToolkit.WinForms.ChatUI
{
    /// <summary>
    ///  Represents the ChatView control which integrates asynchronous AI chat functionality within a
    ///  WinForms application.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This control handles the processing of user input and AI responses, manages conversation history,
    ///   and provides a flexible UI to interact with an AI model.
    ///  </para>
    ///  <para>
    ///   It integrates with various components such as the communicator and metadata processor from the 
    ///   CommunityToolkit to offer a rich chat experience.
    ///  </para>
    /// </remarks>
    public partial class ChatView : UserControl
    {
        /// <summary>
        ///  Represents the default model identifier for the communicator.
        /// </summary>
        public const string DefaultCommunicatorModel = "gpt-4o";

        /// <summary>
        ///  Represents the default model identifier for the meta data processor.
        /// </summary>
        public const string DefaultMetaDataProcessorModel = "gpt-4o-mini-2024-07-18";

        /// <summary>
        ///  Occurs when the metadata has been refreshed asynchronously.
        /// </summary>
        public event AsyncEventHandler<AsyncNotifyRefreshedMetaDataEventArgs>? AsyncNotifyRefreshedMetaData;

        /// <summary>
        ///  Occurs when a code block info is provided asynchronously.
        /// </summary>
        public event AsyncEventHandler<AsyncCodeBlockInfoProvidedEventArgs>? AsyncCodeBlockInfoProvided;

        /// <summary>
        ///  Occurs when file context needs to be requested for extracting settings.
        /// </summary>
        public event AsyncEventHandler<AsyncRequestFileContextEventArgs>? AsyncRequestFileExtractingSettings;

        /// <summary>
        ///  Occurs when a request to save the chat is notified asynchronously.
        /// </summary>
        public event AsyncEventHandler<AsyncRequestFileContextEventArgs>? AsyncNotifySaveChat;

        /// <summary>
        ///  Occurs when the prompt visibility is changed.
        /// </summary>
        public event EventHandler? ShowPromptControlChanged;

        /// <summary>
        ///  Occurs when the developer prompt is modified.
        /// </summary>
        public event EventHandler? DeveloperPromptChanged;

        /// <summary>
        ///  Occurs when the model name is modified.
        /// </summary>
        public event EventHandler? ModelNameChanged;

        /// <summary>
        ///  Occurs when the chat view options are requested.
        /// </summary>
        public event EventHandler<RequestChatViewOptionsEventArgs>? RequestChatViewOptions;

        private ConversationProcessor _conversationProcessor = null!;
        private ChatViewOptions _options = null!;
        private bool _requestClearChatHistory;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ChatView"/> class.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   Configures initial event wiring for the conversation view and prompt control, and sets the default
        ///   model identifiers for the meta data processor and communicator.
        ///  </para>
        /// </remarks>
        public ChatView()
        {
            InitializeComponent();
            ConversationView.ConversationItemAdded += ConversationView_ConversationItemAdded;
            PromptControl.AsyncSendCommand += PromptControl_AsyncSendCommand;

            _skMetaDataProcessor.ModelId = DefaultMetaDataProcessorModel;
            _skCommunicator.ModelId = DefaultCommunicatorModel;

            // We want a toolstrip with 32 Pixels.
            // TODO: We need more configuration options here.
            _decoratorPanel.ProvideToolStripInSize = 32;
            _promptControl.CommandStrip = _decoratorPanel.ToolStrip;
            _promptControl.RequestPromptSendButton = true;
            _promptControl.RequestOpenLibraryButton = true;
        }

        /// <summary>
        ///  Handles additional initialization when the control is loaded.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <remarks>
        ///  <para>
        ///   Registers the API key getter for both the communicator and the meta data processor; requests chat view 
        ///   options and sets up event handlers for asynchronous responses.
        ///  </para>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (ApiKeyGetter is null)
            {
                throw new InvalidOperationException("ApiKeyGetter is null. Please provide a valid ApiKeyGetter.");
            }

            // Wiring the delegate which provides the Open AI ApiKey when we need it:
            _skCommunicator.ApiKeyGetter = ApiKeyGetter;
            _skMetaDataProcessor.ApiKeyGetter = _skCommunicator.ApiKeyGetter;

            RequestChatViewOptionsEventArgs eArgs = new(null, string.Empty, Guid.Empty);
            OnRequestChatViewOptions(eArgs);
            _options = new ChatViewOptions(eArgs.BasePath, eArgs.LastUsedModel, eArgs.LastUsedConfigurationId);

            _skCommunicator.AsyncReceivedNextParagraph += SKCommunicator_ReceivedNextParagraph;
            _skCommunicator.AsyncCodeBlockInfoProvided += SKCommunicator_AsyncCodeBlockInfoProvided;
        }

        /// <summary>
        ///  Gets or sets the developer prompt for the communicator.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   Modifying this property changes the context for the conversation mid-stream and updates the UI via an event.
        ///  </para>
        /// </remarks>
        [DefaultValue(null)]
        public string? DeveloperPrompt
        {
            get => _skCommunicator.DeveloperPrompt;
            set
            {
                if (_skCommunicator.DeveloperPrompt == value)
                {
                    return;
                }

                _skCommunicator.DeveloperPrompt = value;
                OnDeveloperPromptChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        ///  Raises the <see cref="DeveloperPromptChanged"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <remarks>
        ///  <para>
        ///   Invokes the event to notify subscribers that the developer prompt has changed.
        ///  </para>
        /// </remarks>
        protected virtual void OnDeveloperPromptChanged(EventArgs e)
            => DeveloperPromptChanged?.Invoke(this, e);

        /// <summary>
        ///  Gets or sets the model name used by the communicator.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   Changing this property updates the underlying model identifier in the communicator and raises the 
        ///   corresponding event.
        ///  </para>
        /// </remarks>
        [DefaultValue(DefaultCommunicatorModel)]
        public string ModelName
        {
            get => _skCommunicator.ModelId;
            set
            {
                if (_skCommunicator.ModelId == value)
                {
                    return;
                }
                _skCommunicator.ModelId = value;
                OnModelNameChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        ///  Gets or sets the format in which human readable text is returned from the model.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   This property allows setting the style of the response output, for example as plain text.
        ///  </para>
        /// </remarks>
        [Bindable(true)]
        [Browsable(true)]
        [Category("Model Parameter")]
        [Description("Gets or sets the Format in which human readable, non-structured Text is requested to be returned from the Model.")]
        [DefaultValue(ResponseTextFormat.PlainText)]
        public ResponseTextFormat ReturnStringsFormat
        {
            get => _skCommunicator.ResponseTextFormat;
            set => _skCommunicator.ResponseTextFormat = value;
        }

        /// <summary>
        ///  Raises the <see cref="ModelNameChanged"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <remarks>
        ///  <para>
        ///   Invokes the event to notify subscribers that the model name has been updated.
        ///  </para>
        /// </remarks>
        protected virtual void OnModelNameChanged(EventArgs e)
            => ModelNameChanged?.Invoke(this, e);

        /// <summary>
        ///  Gets the conversation view which displays the current chat conversation.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   This property provides access to the conversation view where new items are added upon conversations.
        ///  </para>
        /// </remarks>
        public ConversationView ConversationView
            => _conversationView;

        /// <summary>
        ///  Gets the prompt control that handles user input.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   The prompt control allows users to input text, which is then sent as chat commands asynchronously.
        ///  </para>
        /// </remarks>
        public AutoCompleteEditor PromptControl
            => _promptControl;

        /// <summary>
        ///  Gets or sets a value indicating whether the prompt control is visible.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   Changing this property toggles the visibility of the prompt control and refreshes the layout.
        ///  </para>
        /// </remarks>
        [DefaultValue(true)]
        public bool ShowPromptControl
        {
            get => _promptControl.Visible;
            set
            {
                if (_promptControl.Visible == value)
                {
                    return;
                }

                _promptControl.Visible = value;
                OnShowPromptControlChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        ///  Gets or sets the function that retrieves the API key used for authentication.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   This function is used to supply the necessary API key to the communicator and meta data processor.
        ///  </para>
        /// </remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string>? ApiKeyGetter { get; set; }

        /// <summary>
        ///  Raises the <see cref="ShowPromptControlChanged"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <remarks>
        ///  <para>
        ///   Invokes the event to notify subscribers that the prompt control's visual state has changed.
        ///  </para>
        /// </remarks>
        protected virtual void OnShowPromptControlChanged(EventArgs e)
        {
            // We need to re-layout:
            PerformLayout();
            ShowPromptControlChanged?.Invoke(this, e);
        }

        /// <summary>
        ///  Clears the internal chat history without affecting the visual conversation history.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   This method resets the internal state to allow a developer prompt to be changed mid-conversation.
        ///  </para>
        /// </remarks>
        public void ClearChatHistory()
        {
            _requestClearChatHistory = true;
        }

        /// <summary>
        ///  Starts a new chat session by clearing history and resetting the conversation title.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///   Resets both the internal state and the conversation view, effectively preparing for a new conversation.
        ///  </para>
        /// </remarks>
        public void StartNewChat()
        {
            _requestClearChatHistory = true;
            ConversationView.ClearHistory();
            ConversationView.Conversation.Title = Conversation.GetDefaultTitle();
        }

        /// <summary>
        ///  Adds a new chat item to the communicator.
        /// </summary>
        /// <param name="isResponse">Specifies whether the item is a response from the AI.</param>
        /// <param name="message">The message text to add.</param>
        /// <remarks>
        ///  <para>
        ///   This method passes the chat item to the communicator, ensuring that it is reflected in the conversation.
        ///  </para>
        /// </remarks>
        public void AddChatItem(bool isResponse, string message)
            => _skCommunicator.AddChatItem(isResponse, message);

        /// <summary>
        ///  Loads a conversation from a file asynchronously.
        /// </summary>
        /// <param name="filename">The name of the file to load the conversation from.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        ///  <para>
        ///   Loads the conversation and populates the conversation view along with clearing the prompt control.
        ///  </para>
        /// </remarks>
        public async Task LoadConversationAsync(string filename)
        {
            RequestChatViewOptionsEventArgs eArgs = new(_options);
            OnRequestChatViewOptions(eArgs);

            ClearChatHistory();

            _options.LastUsedModel = eArgs.LastUsedModel;
            _options.LastUsedConfigurationId = eArgs.LastUsedConfigurationId;
            _options.BasePath = eArgs.BasePath
                ?? throw new InvalidOperationException("BasePath is null. Please handle the RequestChatViewOptions to set a valid base path.");

            _conversationProcessor = await ConversationProcessor.FromFileAsync(
            _options.BasePath, filename);

            ConversationView.Conversation = _conversationProcessor.Conversation;
            foreach (ConversationItem item in ConversationView.Conversation.ConversationItems)
            {
                AddChatItem(
                item.IsResponse,
                item.MarkdownContent!);
            }

            PromptControl.Clear();
        }

        /// <summary>
        ///  Sends a chat request asynchronously using the content of the verbal request.
        /// </summary>
        /// <param name="verbalRequest">The text to send as part of the chat command.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        ///  <para>
        ///   This method assigns the verbal request to the prompt control and triggers the async send command.
        ///  </para>
        /// </remarks>
        public Task SendRequestAsync(string verbalRequest)
        {
            PromptControl.Text = verbalRequest;
            return PromptControl.SendCommandAsync();
        }

        /// <summary>
        ///  Queries all available OpenAI model names asynchronously.
        /// </summary>
        /// <returns>
        ///  A task that returns an enumerable collection of model names or null if no results are available.
        /// </returns>
        /// <remarks>
        ///  <para>
        ///   This method utilizes the communicator to retrieve a list of available OpenAI model names.
        ///  </para>
        /// </remarks>
        public Task<IEnumerable<string>?> QueryOpenAiModelNamesAsync()
            => _skCommunicator.QueryOpenAiModelNamesAsync();

        /// <summary>
        ///  Queries detailed information for a specific OpenAI model asynchronously.
        /// </summary>
        /// <param name="modelName">The name of the model to query information for.</param>
        /// <returns>
        ///  A task that returns the model information or null if the model is not found.
        /// </returns>
        /// <remarks>
        ///  <para>
        ///   Fetches model details through the communicator, enabling clients to adjust settings based on model info.
        ///  </para>
        /// </remarks>
        public Task<ModelInfo?> QueryOpenAiModelInfoAsync(string modelName)
            => _skCommunicator.QueryOpenAiModelInfoAsync(modelName);

        private void ConversationView_ConversationItemAdded(object? sender, ConversationItemAddedEventArgs e)
        {
            // We can save only with 2 items or more, since otherwise the Meta data
            // we retrieve from the meta data skComponent can't provide enough reliable
            // information.
            if (ConversationView.Conversation is not Conversation conversation
                || conversation.ConversationItems.Count < 2)
            {
                return;
            }

            // TODO: Calculate last turn-around time and save it in the Conversation itself.
            e.ConversationItem.FirstResponseDuration = ConversationView.Conversation.LastKickOffTime;
            e.ConversationItem.CompleteProcessDuration = DateTime.Now - conversation.DateCreated;
        }

        private async Task PromptControl_AsyncSendCommand(object sender, AsyncSendCommandEventArgs e)
        {
            string textToSend = e.CommandText ?? string.Empty;
            Conversation conversation = ConversationView.Conversation;

            conversation.LastKickOffTime = TimeSpan.Zero;
            conversation.DateLastEdited = DateTime.Now;

            if (conversation.ConversationItems.Count == 0)
            {
                conversation.Model = _options.LastUsedModel;
                conversation.IdPersonality = _options.LastUsedConfigurationId;
            }

            try
            {
                // First, we add our original question to the conversation view.
                // This, by the way, will then raise the ConversationItemAdded event,
                // where we then write the conversation to disc and update the tree view.
                ConversationView.AddConversationItem(textToSend, isResponse: false);

                // And then, we let the _skCommunicator "pump" it's partial results from the
                // async stream to the conversation view. When the answer is complete, we will be
                // getting a respective event a la WinForms. And that's where we can write the
                // conversation items on disc.
                IAsyncEnumerable<string> responses = ConversationView.UpdateCurrentResponseAsync(
                    asyncEnumerable: _skCommunicator.RequestPromptResponseStreamAsync(
                        valueToProcess: textToSend,
                        keepChatHistory: !_requestClearChatHistory));

                _requestClearChatHistory = false;

                await ResponsePumpingAsync(responses);

                ChatInfoAITemplate? chatInfo = await GetChatMetaDataAsync(_skMetaDataProcessor.ChatHistory, textToSend);
                await OnAsyncNotifyRefreshMetaDataAsync(new AsyncNotifyRefreshedMetaDataEventArgs(chatInfo));

                // This updates the meta-data we just got with the current conversation.
                chatInfo?.Merge(conversation);

                _conversationProcessor ??= new(
                    conversation: conversation,
                    basePath: _options.BasePath!);

                await _conversationProcessor.SaveConversationAsync();


                PromptControl.Clear();
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo dispatchInfo = ExceptionDispatchInfo.Capture(ex);
                dispatchInfo.Throw();
            }


            // And this is actual pumping, which here does nothing.
            // This could be modified, for example to write logs or construct something.
            static async Task ResponsePumpingAsync(IAsyncEnumerable<string> responses)
            {
                await foreach (string? response in responses)
                {
                    if (response is null)
                    {
                        continue;
                    }
                }
            }
        }

        // That's the task which gets the title from the conversation.
        private async Task<ChatInfoAITemplate?> GetChatMetaDataAsync(ChatHistory? chatHistory, string? text = default)
        {
            string chatContent = string.Empty;

            if (chatHistory is not null)
            {
                chatContent = GetJoinedChatHistory(chatHistory);
            }

            chatContent += "\n" + text;

            ChatInfoAITemplate? returnValue = await _skMetaDataProcessor.RequestStructuredResponseAsync<ChatInfoAITemplate?>(
                chatContent);

            return returnValue;
        }

        private static string GetJoinedChatHistory(ChatHistory? chatHistory) =>
            // Let's build one string from all the text items in the chat history:
            chatHistory is null
                ? string.Empty
                : string.Join("\n", chatHistory.Select(item => item.Content));

        private async Task RefreshMetaData(object? sender, EventArgs e)
        {
            try
            {
                // Update the title and summary of the conversation:
                ChatInfoAITemplate? metaData = await GetChatMetaDataAsync(_skCommunicator.ChatHistory);

                if (metaData is null)
                {
                    return;
                }

                metaData.Merge(ConversationView.Conversation);

                AsyncNotifyRefreshedMetaDataEventArgs eventArgs = new(metaData);
                await OnAsyncNotifyRefreshMetaDataAsync(eventArgs);
            }
            catch (Exception ex)
            {
                AsyncNotifyRefreshedMetaDataEventArgs eventArgs = new(ex);
                await OnAsyncNotifyRefreshMetaDataAsync(eventArgs);
            }
        }

        private Task SKCommunicator_AsyncCodeBlockInfoProvided(object sender, AsyncCodeBlockInfoProvidedEventArgs e)
        {
            return OnAsyncCodeBlockInfoProvidedAsync(e);
        }

        /// <summary>
                ///  Raises the <see cref="AsyncCodeBlockInfoProvided"/> event asynchronously.
                /// </summary>
                /// <param name="e">The event data.</param>
                /// <returns>A task representing the asynchronous operation.</returns>
                /// <remarks>
                ///  <para>
                ///   Invokes the event to notify that code block information has been provided.
                ///  </para>
                /// </remarks>

        protected virtual Task OnAsyncCodeBlockInfoProvidedAsync(AsyncCodeBlockInfoProvidedEventArgs e)
            => AsyncCodeBlockInfoProvided?.Invoke(this, e) ?? Task.CompletedTask;

        /// <summary>
        ///  Raises the <see cref="AsyncNotifyRefreshedMetaData"/> event asynchronously.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        ///  <para>
        ///   Notifies subscribers that new metadata is available after processing the chat history.
        ///  </para>
        /// </remarks>
        protected virtual Task OnAsyncNotifyRefreshMetaDataAsync(AsyncNotifyRefreshedMetaDataEventArgs e)
            => AsyncNotifyRefreshedMetaData?.Invoke(this, e) ?? Task.CompletedTask;

        /// <summary>
        ///  Raises the <see cref="AsyncRequestFileExtractingSettings"/> event asynchronously.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        ///  <para>
        ///   Invokes the event to signal the need for file context settings used during conversation saving.
        ///  </para>
        /// </remarks>
        protected virtual Task OnAsyncRequestFileExtractingSettingsAsync(AsyncRequestFileContextEventArgs e)
            => AsyncRequestFileExtractingSettings?.Invoke(this, e) ?? Task.CompletedTask;

        /// <summary>
        ///  Raises the <see cref="AsyncNotifySaveChat"/> event asynchronously.
        /// </summary>
        /// <param name="e">The event data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        ///  <para>
        ///   Notifies subscribers that a save chat request has been triggered.
        ///  </para>
        /// </remarks>
        protected virtual Task OnAsyncNotifySaveChatAsync(AsyncRequestFileContextEventArgs e)
            => AsyncNotifySaveChat?.Invoke(this, e) ?? Task.CompletedTask;

        /// <summary>
        ///  Invokes the <see cref="RequestChatViewOptions"/> event.
        /// </summary>
        /// <param name="e">The event data containing chat view options.</param>
        /// <remarks>
        ///  <para>
        ///   This event provides an opportunity for external customization of the chat view options.
        ///  </para>
        /// </remarks>
        protected virtual void OnRequestChatViewOptions(RequestChatViewOptionsEventArgs e)
            => RequestChatViewOptions?.Invoke(this, e);
    }
}
