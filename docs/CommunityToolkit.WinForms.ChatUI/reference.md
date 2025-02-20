<a name='assembly'></a>
# CommunityToolkit.WinForms.ChatUI

## Contents

- [AsyncNotifyRefreshedMetaDataEventArgs](#T-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs')
  - [#ctor(chatMetaData)](#M-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-#ctor-CommunityToolkit-WinForms-ChatUI-AIStructures-ChatInfoAITemplate- 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.#ctor(CommunityToolkit.WinForms.ChatUI.AIStructures.ChatInfoAITemplate)')
  - [#ctor(exception)](#M-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-#ctor-System-Exception- 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.#ctor(System.Exception)')
  - [CausedException](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-CausedException 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.CausedException')
  - [ChatKeywords](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatKeywords 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.ChatKeywords')
  - [ChatSummary](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatSummary 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.ChatSummary')
  - [ChatTitle](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatTitle 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.ChatTitle')
  - [Exception](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-Exception 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.Exception')
  - [MemoryFactList](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-MemoryFactList 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.MemoryFactList')
  - [TokenCount](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-TokenCount 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.TokenCount')
- [AsyncRequestFileContextEventArgs](#T-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs 'CommunityToolkit.WinForms.ChatUI.AsyncRequestFileContextEventArgs')
  - [#ctor()](#M-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-#ctor-System-String,System-String,System-String- 'CommunityToolkit.WinForms.ChatUI.AsyncRequestFileContextEventArgs.#ctor(System.String,System.String,System.String)')
  - [BasePath](#P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-BasePath 'CommunityToolkit.WinForms.ChatUI.AsyncRequestFileContextEventArgs.BasePath')
  - [ConversationPath](#P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-ConversationPath 'CommunityToolkit.WinForms.ChatUI.AsyncRequestFileContextEventArgs.ConversationPath')
  - [Filename](#P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-Filename 'CommunityToolkit.WinForms.ChatUI.AsyncRequestFileContextEventArgs.Filename')
- [ChatView](#T-CommunityToolkit-WinForms-ChatUI-ChatView 'CommunityToolkit.WinForms.ChatUI.ChatView')
  - [DefaultCommunicatorModel](#F-CommunityToolkit-WinForms-ChatUI-ChatView-DefaultCommunicatorModel 'CommunityToolkit.WinForms.ChatUI.ChatView.DefaultCommunicatorModel')
  - [DefaultMetaDataProcessorModel](#F-CommunityToolkit-WinForms-ChatUI-ChatView-DefaultMetaDataProcessorModel 'CommunityToolkit.WinForms.ChatUI.ChatView.DefaultMetaDataProcessorModel')
  - [components](#F-CommunityToolkit-WinForms-ChatUI-ChatView-components 'CommunityToolkit.WinForms.ChatUI.ChatView.components')
  - [ApiKeyGetter](#P-CommunityToolkit-WinForms-ChatUI-ChatView-ApiKeyGetter 'CommunityToolkit.WinForms.ChatUI.ChatView.ApiKeyGetter')
  - [ConversationView](#P-CommunityToolkit-WinForms-ChatUI-ChatView-ConversationView 'CommunityToolkit.WinForms.ChatUI.ChatView.ConversationView')
  - [DeveloperPrompt](#P-CommunityToolkit-WinForms-ChatUI-ChatView-DeveloperPrompt 'CommunityToolkit.WinForms.ChatUI.ChatView.DeveloperPrompt')
  - [ModelName](#P-CommunityToolkit-WinForms-ChatUI-ChatView-ModelName 'CommunityToolkit.WinForms.ChatUI.ChatView.ModelName')
  - [PromptControl](#P-CommunityToolkit-WinForms-ChatUI-ChatView-PromptControl 'CommunityToolkit.WinForms.ChatUI.ChatView.PromptControl')
  - [ReturnStringsFormat](#P-CommunityToolkit-WinForms-ChatUI-ChatView-ReturnStringsFormat 'CommunityToolkit.WinForms.ChatUI.ChatView.ReturnStringsFormat')
  - [ShowPromptControl](#P-CommunityToolkit-WinForms-ChatUI-ChatView-ShowPromptControl 'CommunityToolkit.WinForms.ChatUI.ChatView.ShowPromptControl')
  - [ClearChatHistory()](#M-CommunityToolkit-WinForms-ChatUI-ChatView-ClearChatHistory 'CommunityToolkit.WinForms.ChatUI.ChatView.ClearChatHistory')
  - [Dispose(disposing)](#M-CommunityToolkit-WinForms-ChatUI-ChatView-Dispose-System-Boolean- 'CommunityToolkit.WinForms.ChatUI.ChatView.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-CommunityToolkit-WinForms-ChatUI-ChatView-InitializeComponent 'CommunityToolkit.WinForms.ChatUI.ChatView.InitializeComponent')
  - [QueryOpenAiModelNamesAsync()](#M-CommunityToolkit-WinForms-ChatUI-ChatView-QueryOpenAiModelNamesAsync 'CommunityToolkit.WinForms.ChatUI.ChatView.QueryOpenAiModelNamesAsync')
  - [StartNewChat()](#M-CommunityToolkit-WinForms-ChatUI-ChatView-StartNewChat 'CommunityToolkit.WinForms.ChatUI.ChatView.StartNewChat')
- [ChatViewOptions](#T-CommunityToolkit-WinForms-ChatUI-ChatViewOptions 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions')
  - [#ctor(basePath,lastUsedModel,lastUsedConfigurationId)](#M-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-#ctor-System-String,System-String,System-Guid- 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions.#ctor(System.String,System.String,System.Guid)')
  - [_basePath](#F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_basePath 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions._basePath')
  - [_lastUsedConfigurationId](#F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_lastUsedConfigurationId 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions._lastUsedConfigurationId')
  - [_lastUsedModel](#F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_lastUsedModel 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions._lastUsedModel')
  - [BasePath](#P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-BasePath 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions.BasePath')
  - [DefaultModel](#P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-DefaultModel 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions.DefaultModel')
  - [LastUsedConfigurationId](#P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-LastUsedConfigurationId 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions.LastUsedConfigurationId')
  - [LastUsedModel](#P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-LastUsedModel 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions.LastUsedModel')
- [Conversation](#T-CommunityToolkit-WinForms-ChatUI-Conversation 'CommunityToolkit.WinForms.ChatUI.Conversation')
  - [BackColor](#P-CommunityToolkit-WinForms-ChatUI-Conversation-BackColor 'CommunityToolkit.WinForms.ChatUI.Conversation.BackColor')
  - [CompleteProcessDuration](#P-CommunityToolkit-WinForms-ChatUI-Conversation-CompleteProcessDuration 'CommunityToolkit.WinForms.ChatUI.Conversation.CompleteProcessDuration')
  - [ConversationItems](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ConversationItems 'CommunityToolkit.WinForms.ChatUI.Conversation.ConversationItems')
  - [CurrentListingInfo](#P-CommunityToolkit-WinForms-ChatUI-Conversation-CurrentListingInfo 'CommunityToolkit.WinForms.ChatUI.Conversation.CurrentListingInfo')
  - [DateCreated](#P-CommunityToolkit-WinForms-ChatUI-Conversation-DateCreated 'CommunityToolkit.WinForms.ChatUI.Conversation.DateCreated')
  - [DateLastEdited](#P-CommunityToolkit-WinForms-ChatUI-Conversation-DateLastEdited 'CommunityToolkit.WinForms.ChatUI.Conversation.DateLastEdited')
  - [Filename](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Filename 'CommunityToolkit.WinForms.ChatUI.Conversation.Filename')
  - [FirstResponseDuration](#P-CommunityToolkit-WinForms-ChatUI-Conversation-FirstResponseDuration 'CommunityToolkit.WinForms.ChatUI.Conversation.FirstResponseDuration')
  - [ForeColor](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ForeColor 'CommunityToolkit.WinForms.ChatUI.Conversation.ForeColor')
  - [Headline](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Headline 'CommunityToolkit.WinForms.ChatUI.Conversation.Headline')
  - [Id](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Id 'CommunityToolkit.WinForms.ChatUI.Conversation.Id')
  - [IdPersonality](#P-CommunityToolkit-WinForms-ChatUI-Conversation-IdPersonality 'CommunityToolkit.WinForms.ChatUI.Conversation.IdPersonality')
  - [Keywords](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Keywords 'CommunityToolkit.WinForms.ChatUI.Conversation.Keywords')
  - [LastKickOffTime](#P-CommunityToolkit-WinForms-ChatUI-Conversation-LastKickOffTime 'CommunityToolkit.WinForms.ChatUI.Conversation.LastKickOffTime')
  - [Model](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Model 'CommunityToolkit.WinForms.ChatUI.Conversation.Model')
  - [ResponseInProgress](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgress 'CommunityToolkit.WinForms.ChatUI.Conversation.ResponseInProgress')
  - [ResponseInProgressBackColor](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgressBackColor 'CommunityToolkit.WinForms.ChatUI.Conversation.ResponseInProgressBackColor')
  - [Summary](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Summary 'CommunityToolkit.WinForms.ChatUI.Conversation.Summary')
  - [Title](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Title 'CommunityToolkit.WinForms.ChatUI.Conversation.Title')
  - [TokenCount](#P-CommunityToolkit-WinForms-ChatUI-Conversation-TokenCount 'CommunityToolkit.WinForms.ChatUI.Conversation.TokenCount')
  - [ViewUpdatesSuspended](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ViewUpdatesSuspended 'CommunityToolkit.WinForms.ChatUI.Conversation.ViewUpdatesSuspended')
  - [FromJson(json)](#M-CommunityToolkit-WinForms-ChatUI-Conversation-FromJson-System-String- 'CommunityToolkit.WinForms.ChatUI.Conversation.FromJson(System.String)')
  - [GetDefaultTitle()](#M-CommunityToolkit-WinForms-ChatUI-Conversation-GetDefaultTitle 'CommunityToolkit.WinForms.ChatUI.Conversation.GetDefaultTitle')
  - [GetNextParagraph(text,offset)](#M-CommunityToolkit-WinForms-ChatUI-Conversation-GetNextParagraph-System-ReadOnlySpan{System-Char},System-Int32@- 'CommunityToolkit.WinForms.ChatUI.Conversation.GetNextParagraph(System.ReadOnlySpan{System.Char},System.Int32@)')
  - [OnResponseInProgressChanging(value)](#M-CommunityToolkit-WinForms-ChatUI-Conversation-OnResponseInProgressChanging-System-String- 'CommunityToolkit.WinForms.ChatUI.Conversation.OnResponseInProgressChanging(System.String)')
  - [OnTitleChanging(value)](#M-CommunityToolkit-WinForms-ChatUI-Conversation-OnTitleChanging-System-String- 'CommunityToolkit.WinForms.ChatUI.Conversation.OnTitleChanging(System.String)')
  - [ProcessMarkdownToHTML(conversation)](#M-CommunityToolkit-WinForms-ChatUI-Conversation-ProcessMarkdownToHTML-CommunityToolkit-WinForms-ChatUI-Conversation- 'CommunityToolkit.WinForms.ChatUI.Conversation.ProcessMarkdownToHTML(CommunityToolkit.WinForms.ChatUI.Conversation)')
- [ConversationItem](#T-CommunityToolkit-WinForms-ChatUI-ConversationItem 'CommunityToolkit.WinForms.ChatUI.ConversationItem')
  - [BackColor](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-BackColor 'CommunityToolkit.WinForms.ChatUI.ConversationItem.BackColor')
  - [CompleteProcessDuration](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-CompleteProcessDuration 'CommunityToolkit.WinForms.ChatUI.ConversationItem.CompleteProcessDuration')
  - [DateCreated](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-DateCreated 'CommunityToolkit.WinForms.ChatUI.ConversationItem.DateCreated')
  - [FirstResponseDuration](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-FirstResponseDuration 'CommunityToolkit.WinForms.ChatUI.ConversationItem.FirstResponseDuration')
  - [ForeColor](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-ForeColor 'CommunityToolkit.WinForms.ChatUI.ConversationItem.ForeColor')
  - [HtmlContent](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-HtmlContent 'CommunityToolkit.WinForms.ChatUI.ConversationItem.HtmlContent')
  - [IsResponse](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-IsResponse 'CommunityToolkit.WinForms.ChatUI.ConversationItem.IsResponse')
  - [MarkdownContent](#P-CommunityToolkit-WinForms-ChatUI-ConversationItem-MarkdownContent 'CommunityToolkit.WinForms.ChatUI.ConversationItem.MarkdownContent')
- [ConversationProcessor](#T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor')
  - [#ctor(conversation,basePath)](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-#ctor-CommunityToolkit-WinForms-ChatUI-Conversation,System-String- 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.#ctor(CommunityToolkit.WinForms.ChatUI.Conversation,System.String)')
  - [BasePath](#P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-BasePath 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.BasePath')
  - [Conversation](#P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-Conversation 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.Conversation')
  - [ConversationBaseFolder](#P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-ConversationBaseFolder 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.ConversationBaseFolder')
  - [FromFileAsync(basePath,filename)](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-FromFileAsync-System-String,System-String- 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.FromFileAsync(System.String,System.String)')
  - [GetFolderFullPathFromFilename(basePath,fileName)](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-GetFolderFullPathFromFilename-System-String,System-String- 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.GetFolderFullPathFromFilename(System.String,System.String)')
  - [HandleNewParagraphAsync(paragraph,textPosition,isLastParagraph)](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-HandleNewParagraphAsync-System-String,System-Int32,System-Boolean- 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.HandleNewParagraphAsync(System.String,System.Int32,System.Boolean)')
  - [SaveConversationAsync()](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-SaveConversationAsync 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.SaveConversationAsync')
  - [TryGetConversationBaseFolder()](#M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-TryGetConversationBaseFolder-System-Boolean- 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor.TryGetConversationBaseFolder(System.Boolean)')
- [ConversationRenderer](#T-CommunityToolkit-WinForms-ChatUI-Components-ConversationRenderer 'CommunityToolkit.WinForms.ChatUI.Components.ConversationRenderer')
- [ConversationView](#T-CommunityToolkit-WinForms-ChatUI-ConversationView 'CommunityToolkit.WinForms.ChatUI.ConversationView')
  - [#ctor()](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-#ctor 'CommunityToolkit.WinForms.ChatUI.ConversationView.#ctor')
  - [Conversation](#P-CommunityToolkit-WinForms-ChatUI-ConversationView-Conversation 'CommunityToolkit.WinForms.ChatUI.ConversationView.Conversation')
  - [AddConversationItem(text,isResponse)](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-AddConversationItem-System-String,System-Boolean- 'CommunityToolkit.WinForms.ChatUI.ConversationView.AddConversationItem(System.String,System.Boolean)')
  - [ClearHistory()](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-ClearHistory 'CommunityToolkit.WinForms.ChatUI.ConversationView.ClearHistory')
  - [OnConversationItemAdded(conversationItemAddedEventArgs)](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnConversationItemAdded-CommunityToolkit-WinForms-ChatUI-ConversationItemAddedEventArgs- 'CommunityToolkit.WinForms.ChatUI.ConversationView.OnConversationItemAdded(CommunityToolkit.WinForms.ChatUI.ConversationItemAddedEventArgs)')
  - [OnConversationTitleChanged(conversationTitleChangedEventArgs)](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnConversationTitleChanged-CommunityToolkit-WinForms-ChatUI-ConversationTitleChangedEventArgs- 'CommunityToolkit.WinForms.ChatUI.ConversationView.OnConversationTitleChanged(CommunityToolkit.WinForms.ChatUI.ConversationTitleChangedEventArgs)')
  - [OnPaintBackground(e)](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnPaintBackground-System-Windows-Forms-PaintEventArgs- 'CommunityToolkit.WinForms.ChatUI.ConversationView.OnPaintBackground(System.Windows.Forms.PaintEventArgs)')
  - [ToJson()](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-ToJson 'CommunityToolkit.WinForms.ChatUI.ConversationView.ToJson')
  - [UpdateCurrentResponseAsync(asyncEnumerable)](#M-CommunityToolkit-WinForms-ChatUI-ConversationView-UpdateCurrentResponseAsync-System-Collections-Generic-IAsyncEnumerable{System-String}- 'CommunityToolkit.WinForms.ChatUI.ConversationView.UpdateCurrentResponseAsync(System.Collections.Generic.IAsyncEnumerable{System.String})')
- [JsonElementExtensions](#T-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-String- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.String)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Int32- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.Int32)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-DateTimeOffset- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.DateTimeOffset)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Guid- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.Guid)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-DateTime- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.DateTime)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Boolean- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.Boolean)')
  - [GetPropertyOrDefault(element,propertyName,defaultValue)](#M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-TimeSpan- 'CommunityToolkit.WinForms.ChatUI.Extension.JsonElementExtensions.GetPropertyOrDefault(System.Text.Json.JsonElement,System.String,System.TimeSpan)')
- [RequestChatViewOptionsEventArgs](#T-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs')
  - [#ctor(basePath,lastUsedModel,lastUsedConfigurationId)](#M-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-#ctor-System-String,System-String,System-Guid- 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs.#ctor(System.String,System.String,System.Guid)')
  - [#ctor(options)](#M-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-#ctor-CommunityToolkit-WinForms-ChatUI-ChatViewOptions- 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs.#ctor(CommunityToolkit.WinForms.ChatUI.ChatViewOptions)')
  - [BasePath](#P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-BasePath 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs.BasePath')
  - [LastUsedConfigurationId](#P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-LastUsedConfigurationId 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs.LastUsedConfigurationId')
  - [LastUsedModel](#P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-LastUsedModel 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs.LastUsedModel')
- [__KnownINotifyPropertyChangedArgs](#T-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs')
  - [BackColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-BackColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BackColor')
  - [BasePath](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-BasePath 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BasePath')
  - [CompleteProcessDuration](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-CompleteProcessDuration 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CompleteProcessDuration')
  - [ConversationItems](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ConversationItems 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ConversationItems')
  - [CurrentListingInfo](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-CurrentListingInfo 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentListingInfo')
  - [DateCreated](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-DateCreated 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DateCreated')
  - [DateLastEdited](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-DateLastEdited 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DateLastEdited')
  - [Filename](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Filename 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Filename')
  - [FirstResponseDuration](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-FirstResponseDuration 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FirstResponseDuration')
  - [ForeColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ForeColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ForeColor')
  - [Headline](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Headline 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Headline')
  - [HtmlContent](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-HtmlContent 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HtmlContent')
  - [Id](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Id 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Id')
  - [IdPersonality](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-IdPersonality 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IdPersonality')
  - [IsResponse](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-IsResponse 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsResponse')
  - [Keywords](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Keywords 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Keywords')
  - [LastKickOffTime](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastKickOffTime 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LastKickOffTime')
  - [LastUsedConfigurationId](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastUsedConfigurationId 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LastUsedConfigurationId')
  - [LastUsedModel](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastUsedModel 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LastUsedModel')
  - [MarkdownContent](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-MarkdownContent 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.MarkdownContent')
  - [Model](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Model 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Model')
  - [ResponseInProgress](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ResponseInProgress 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ResponseInProgress')
  - [ResponseInProgressBackColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ResponseInProgressBackColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ResponseInProgressBackColor')
  - [Summary](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Summary 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Summary')
  - [Title](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Title 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Title')
  - [TokenCount](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-TokenCount 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.TokenCount')
  - [ViewUpdatesSuspended](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ViewUpdatesSuspended 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ViewUpdatesSuspended')
- [__KnownINotifyPropertyChangingArgs](#T-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs')
  - [BackColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-BackColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BackColor')
  - [BasePath](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-BasePath 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BasePath')
  - [CompleteProcessDuration](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-CompleteProcessDuration 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CompleteProcessDuration')
  - [ConversationItems](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ConversationItems 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ConversationItems')
  - [CurrentListingInfo](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-CurrentListingInfo 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentListingInfo')
  - [DateCreated](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-DateCreated 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DateCreated')
  - [DateLastEdited](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-DateLastEdited 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DateLastEdited')
  - [Filename](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Filename 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Filename')
  - [FirstResponseDuration](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-FirstResponseDuration 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FirstResponseDuration')
  - [ForeColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ForeColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ForeColor')
  - [Headline](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Headline 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Headline')
  - [HtmlContent](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-HtmlContent 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HtmlContent')
  - [Id](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Id 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Id')
  - [IdPersonality](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-IdPersonality 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IdPersonality')
  - [IsResponse](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-IsResponse 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsResponse')
  - [Keywords](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Keywords 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Keywords')
  - [LastKickOffTime](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastKickOffTime 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LastKickOffTime')
  - [LastUsedConfigurationId](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastUsedConfigurationId 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LastUsedConfigurationId')
  - [LastUsedModel](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastUsedModel 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LastUsedModel')
  - [MarkdownContent](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-MarkdownContent 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.MarkdownContent')
  - [Model](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Model 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Model')
  - [ResponseInProgress](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ResponseInProgress 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ResponseInProgress')
  - [ResponseInProgressBackColor](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ResponseInProgressBackColor 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ResponseInProgressBackColor')
  - [Summary](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Summary 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Summary')
  - [Title](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Title 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Title')
  - [TokenCount](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-TokenCount 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.TokenCount')
  - [ViewUpdatesSuspended](#F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ViewUpdatesSuspended 'CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ViewUpdatesSuspended')

<a name='T-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs'></a>
## AsyncNotifyRefreshedMetaDataEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Provides data for the asynchronous notification of refreshed chat metadata.

##### Remarks

This class encapsulates the metadata of a chat, such as the title, summary, keywords, token count,
  and memory facts. It also handles exceptions that may occur during the metadata refresh process.

The class provides two constructors: one for successful metadata refreshes and one for handling exceptions.

<a name='M-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-#ctor-CommunityToolkit-WinForms-ChatUI-AIStructures-ChatInfoAITemplate-'></a>
### #ctor(chatMetaData) `constructor`

##### Summary

Initializes a new instance of the [AsyncNotifyRefreshedMetaDataEventArgs](#T-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs') class with the specified chat metadata.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| chatMetaData | [CommunityToolkit.WinForms.ChatUI.AIStructures.ChatInfoAITemplate](#T-CommunityToolkit-WinForms-ChatUI-AIStructures-ChatInfoAITemplate 'CommunityToolkit.WinForms.ChatUI.AIStructures.ChatInfoAITemplate') | The metadata of the chat. |

##### Remarks

This constructor initializes the properties of the class with the values from the provided [ChatInfoAITemplate](#T-CommunityToolkit-WinForms-ChatUI-AIStructures-ChatInfoAITemplate 'CommunityToolkit.WinForms.ChatUI.AIStructures.ChatInfoAITemplate') object.

<a name='M-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-#ctor-System-Exception-'></a>
### #ctor(exception) `constructor`

##### Summary

Initializes a new instance of the [AsyncNotifyRefreshedMetaDataEventArgs](#T-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs') class with the specified exception.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | The exception that occurred during the metadata refresh process. |

##### Remarks

This constructor sets the [CausedException](#P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-CausedException 'CommunityToolkit.WinForms.ChatUI.AsyncNotifyRefreshedMetaDataEventArgs.CausedException') property to true and stores the provided exception.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-CausedException'></a>
### CausedException `property`

##### Summary

Gets a value indicating whether an exception occurred during the metadata refresh process.

##### Remarks

This property is set to true if an exception occurred during the metadata refresh process, otherwise false.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatKeywords'></a>
### ChatKeywords `property`

##### Summary

Gets the keywords associated with the chat.

##### Remarks

This property contains keywords that are relevant to the chat, helping to categorize and search for the chat.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatSummary'></a>
### ChatSummary `property`

##### Summary

Gets the summary of the chat.

##### Remarks

This property contains a brief summary of the chat, providing an overview of the chat's content.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-ChatTitle'></a>
### ChatTitle `property`

##### Summary

Gets the title of the chat.

##### Remarks

This property contains the title of the chat, which is a brief, descriptive name for the chat.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-Exception'></a>
### Exception `property`

##### Summary

Gets the exception that occurred during the metadata refresh process.

##### Remarks

This property contains the exception that was thrown during the metadata refresh process, if any.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-MemoryFactList'></a>
### MemoryFactList `property`

##### Summary

Gets the list of memory facts from the chat.

##### Remarks

This property contains a list of important facts mentioned in the chat, which are worth remembering long-term.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncNotifyRefreshedMetaDataEventArgs-TokenCount'></a>
### TokenCount `property`

##### Summary

Gets the number of tokens used in the chat.

##### Remarks

This property contains the count of tokens used in the chat, which can be useful for tracking the length and complexity of the chat.

<a name='T-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs'></a>
## AsyncRequestFileContextEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Provides data for the various events that are raised when a file needs to be extracted.

<a name='M-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-#ctor-System-String,System-String,System-String-'></a>
### #ctor() `constructor`

##### Summary

Provides data for the various events that are raised when a file needs to be extracted.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-BasePath'></a>
### BasePath `property`

##### Summary

Gets or sets the base path for the file extraction.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-ConversationPath'></a>
### ConversationPath `property`

##### Summary

Gets or sets the conversation path for the file extraction.

<a name='P-CommunityToolkit-WinForms-ChatUI-AsyncRequestFileContextEventArgs-Filename'></a>
### Filename `property`

##### Summary

Gets or sets the filename for the file extraction.

<a name='T-CommunityToolkit-WinForms-ChatUI-ChatView'></a>
## ChatView `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Represents the ChatView control which integrates asynchronous AI chat functionality within a
 WinForms application.

##### Remarks

This control handles the processing of user input and AI responses, manages conversation history,
  and provides a flexible UI to interact with an AI model.

It integrates with various components such as the communicator and metadata processor from the 
  CommunityToolkit to offer a rich chat experience.

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatView-DefaultCommunicatorModel'></a>
### DefaultCommunicatorModel `constants`

##### Summary

Represents the default model identifier for the communicator.

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatView-DefaultMetaDataProcessorModel'></a>
### DefaultMetaDataProcessorModel `constants`

##### Summary

Represents the default model identifier for the meta data processor.

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatView-components'></a>
### components `constants`

##### Summary

Required designer variable.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-ApiKeyGetter'></a>
### ApiKeyGetter `property`

##### Summary

Gets or sets the function that retrieves the API key used for authentication.

##### Remarks

This function is used to supply the necessary API key to the communicator and meta data processor.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-ConversationView'></a>
### ConversationView `property`

##### Summary

Gets the conversation view which displays the current chat conversation.

##### Remarks

This property provides access to the conversation view where new items are added upon conversations.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-DeveloperPrompt'></a>
### DeveloperPrompt `property`

##### Summary

Gets or sets the developer prompt for the communicator.

##### Remarks

Modifying this property changes the context for the conversation mid-stream and updates the UI via an event.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-ModelName'></a>
### ModelName `property`

##### Summary

Gets or sets the model name used by the communicator.

##### Remarks

Changing this property updates the underlying model identifier in the communicator and raises the 
  corresponding event.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-PromptControl'></a>
### PromptControl `property`

##### Summary

Gets the prompt control that handles user input.

##### Remarks

The prompt control allows users to input text, which is then sent as chat commands asynchronously.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-ReturnStringsFormat'></a>
### ReturnStringsFormat `property`

##### Summary

Gets or sets the format in which human readable text is returned from the model.

##### Remarks

This property allows setting the style of the response output, for example as plain text.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatView-ShowPromptControl'></a>
### ShowPromptControl `property`

##### Summary

Gets or sets a value indicating whether the prompt control is visible.

##### Remarks

Changing this property toggles the visibility of the prompt control and refreshes the layout.

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatView-ClearChatHistory'></a>
### ClearChatHistory() `method`

##### Summary

Clears the internal chat history without affecting the visual conversation history.

##### Parameters

This method has no parameters.

##### Remarks

This method resets the internal state to allow a developer prompt to be changed mid-conversation.

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatView-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Clean up any resources being used.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | true if managed resources should be disposed; otherwise, false. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatView-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

Required method for Designer support - do not modify 
the contents of this method with the code editor.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatView-QueryOpenAiModelNamesAsync'></a>
### QueryOpenAiModelNamesAsync() `method`

##### Summary

Queries all available OpenAI model names asynchronously.

##### Returns

A task that returns an enumerable collection of model names or null if no results are available.

##### Parameters

This method has no parameters.

##### Remarks

This method utilizes the communicator to retrieve a list of available OpenAI model names.

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatView-StartNewChat'></a>
### StartNewChat() `method`

##### Summary

Starts a new chat session by clearing history and resetting the conversation title.

##### Parameters

This method has no parameters.

##### Remarks

Resets both the internal state and the conversation view, effectively preparing for a new conversation.

<a name='T-CommunityToolkit-WinForms-ChatUI-ChatViewOptions'></a>
## ChatViewOptions `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

*Inherit from parent.*

##### Summary

Represents the options for the ChatView.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| basePath | [T:CommunityToolkit.WinForms.ChatUI.ChatViewOptions](#T-T-CommunityToolkit-WinForms-ChatUI-ChatViewOptions 'T:CommunityToolkit.WinForms.ChatUI.ChatViewOptions') | The base path for the chat view. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-#ctor-System-String,System-String,System-Guid-'></a>
### #ctor(basePath,lastUsedModel,lastUsedConfigurationId) `constructor`

##### Summary

Represents the options for the ChatView.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base path for the chat view. |
| lastUsedModel | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The last used model for the chat view. |
| lastUsedConfigurationId | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The last used configuration ID for the chat view. |

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_basePath'></a>
### _basePath `constants`

##### Summary

The base path for the chat view.

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_lastUsedConfigurationId'></a>
### _lastUsedConfigurationId `constants`

##### Summary

The last used configuration ID for the chat view.

<a name='F-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-_lastUsedModel'></a>
### _lastUsedModel `constants`

##### Summary

The last used model for the chat view.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-BasePath'></a>
### BasePath `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-DefaultModel'></a>
### DefaultModel `property`

##### Summary

Gets the default model.

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-LastUsedConfigurationId'></a>
### LastUsedConfigurationId `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-LastUsedModel'></a>
### LastUsedModel `property`

##### Summary

*Inherit from parent.*

<a name='T-CommunityToolkit-WinForms-ChatUI-Conversation'></a>
## Conversation `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-BackColor'></a>
### BackColor `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-CompleteProcessDuration'></a>
### CompleteProcessDuration `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-ConversationItems'></a>
### ConversationItems `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-CurrentListingInfo'></a>
### CurrentListingInfo `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-DateCreated'></a>
### DateCreated `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-DateLastEdited'></a>
### DateLastEdited `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Filename'></a>
### Filename `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-FirstResponseDuration'></a>
### FirstResponseDuration `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-ForeColor'></a>
### ForeColor `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Headline'></a>
### Headline `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Id'></a>
### Id `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-IdPersonality'></a>
### IdPersonality `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Keywords'></a>
### Keywords `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-LastKickOffTime'></a>
### LastKickOffTime `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Model'></a>
### Model `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgress'></a>
### ResponseInProgress `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgressBackColor'></a>
### ResponseInProgressBackColor `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Summary'></a>
### Summary `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-Title'></a>
### Title `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-TokenCount'></a>
### TokenCount `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-Conversation-ViewUpdatesSuspended'></a>
### ViewUpdatesSuspended `property`

##### Summary

*Inherit from parent.*

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-FromJson-System-String-'></a>
### FromJson(json) `method`

##### Summary

Loads conversation items from a JSON string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The JSON string representing the conversation items. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-GetDefaultTitle'></a>
### GetDefaultTitle() `method`

##### Summary

Gets the default title for a conversation. IMPORTANT: $0200 is a zero-width space, 
 which is our marker for a new conversation and that the LLM has yet to come up with a new name.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-GetNextParagraph-System-ReadOnlySpan{System-Char},System-Int32@-'></a>
### GetNextParagraph(text,offset) `method`

##### Summary

Returns the next "paragraph" (line) from the given text starting at `offset`.
Handles different newline conventions: LF, CR, and CRLF.
Advances `offset` to the start of the following line.

##### Returns

A [ReadOnlySpan\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ReadOnlySpan`1 'System.ReadOnlySpan`1') containing the next paragraph, or an empty span if the offset is at the end.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.ReadOnlySpan{System.Char}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ReadOnlySpan 'System.ReadOnlySpan{System.Char}') | The text to read from. |
| offset | [System.Int32@](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32@ 'System.Int32@') | The starting index in `text`. On return, it points to the beginning of the next line. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-OnResponseInProgressChanging-System-String-'></a>
### OnResponseInProgressChanging(value) `method`

##### Summary

Executes the logic for when [ResponseInProgress](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgress 'CommunityToolkit.WinForms.ChatUI.Conversation.ResponseInProgress') is changing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The new property value being set. |

##### Remarks

This method is invoked right before the value of [ResponseInProgress](#P-CommunityToolkit-WinForms-ChatUI-Conversation-ResponseInProgress 'CommunityToolkit.WinForms.ChatUI.Conversation.ResponseInProgress') is changed.

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-OnTitleChanging-System-String-'></a>
### OnTitleChanging(value) `method`

##### Summary

Executes the logic for when [Title](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Title 'CommunityToolkit.WinForms.ChatUI.Conversation.Title') is changing.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The new property value being set. |

##### Remarks

This method is invoked right before the value of [Title](#P-CommunityToolkit-WinForms-ChatUI-Conversation-Title 'CommunityToolkit.WinForms.ChatUI.Conversation.Title') is changed.

<a name='M-CommunityToolkit-WinForms-ChatUI-Conversation-ProcessMarkdownToHTML-CommunityToolkit-WinForms-ChatUI-Conversation-'></a>
### ProcessMarkdownToHTML(conversation) `method`

##### Summary

Processes markdown content into HTML, handling nested code blocks using a counter.
Assumes that code blocks always start with a line like "\`\`\`something" and end
with a line that is exactly "\`\`\`".

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversation | [CommunityToolkit.WinForms.ChatUI.Conversation](#T-CommunityToolkit-WinForms-ChatUI-Conversation 'CommunityToolkit.WinForms.ChatUI.Conversation') | The conversation containing markdown items. |

<a name='T-CommunityToolkit-WinForms-ChatUI-ConversationItem'></a>
## ConversationItem `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-BackColor'></a>
### BackColor `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-CompleteProcessDuration'></a>
### CompleteProcessDuration `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-DateCreated'></a>
### DateCreated `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-FirstResponseDuration'></a>
### FirstResponseDuration `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-ForeColor'></a>
### ForeColor `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-HtmlContent'></a>
### HtmlContent `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-IsResponse'></a>
### IsResponse `property`

##### Summary

*Inherit from parent.*

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationItem-MarkdownContent'></a>
### MarkdownContent `property`

##### Summary

*Inherit from parent.*

<a name='T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor'></a>
## ConversationProcessor `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Processes conversations and handles various operations related to conversation files and listings.

##### Remarks

This class is responsible for managing conversation data, including saving and loading conversations from files.

It also handles the processing of paragraphs within a conversation, identifying and managing code listings.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-#ctor-CommunityToolkit-WinForms-ChatUI-Conversation,System-String-'></a>
### #ctor(conversation,basePath) `constructor`

##### Summary

Initializes a new instance of the [ConversationProcessor](#T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversation | [CommunityToolkit.WinForms.ChatUI.Conversation](#T-CommunityToolkit-WinForms-ChatUI-Conversation 'CommunityToolkit.WinForms.ChatUI.Conversation') | The conversation to be processed. |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base path for storing conversation files. |

##### Remarks

Sets up the conversation processor with the provided conversation and base path.

Subscribes to the [](#!-Conversation-PropertyChanged 'Conversation.PropertyChanged') event if the conversation 
title is not set or starts with a zero-width space.

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-BasePath'></a>
### BasePath `property`

##### Summary

Gets the base path for storing conversation files.

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-Conversation'></a>
### Conversation `property`

##### Summary

Gets the conversation being processed.

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-ConversationBaseFolder'></a>
### ConversationBaseFolder `property`

##### Summary

Gets or sets the base folder for the conversation.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-FromFileAsync-System-String,System-String-'></a>
### FromFileAsync(basePath,filename) `method`

##### Summary

Creates a [ConversationProcessor](#T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor') from a file asynchronously.

##### Returns

A task representing the asynchronous operation, with a [ConversationProcessor](#T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor') as the result.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base path for storing conversation files. |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename of the conversation file. |

##### Remarks

Reads the conversation data from the specified file and creates a new [ConversationProcessor](#T-CommunityToolkit-WinForms-ChatUI-ConversationProcessor 'CommunityToolkit.WinForms.ChatUI.ConversationProcessor') instance.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-GetFolderFullPathFromFilename-System-String,System-String-'></a>
### GetFolderFullPathFromFilename(basePath,fileName) `method`

##### Summary

Gets the full path of the folder from the filename.

##### Returns

The full path of the folder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base path. |
| fileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filename. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-HandleNewParagraphAsync-System-String,System-Int32,System-Boolean-'></a>
### HandleNewParagraphAsync(paragraph,textPosition,isLastParagraph) `method`

##### Summary

Handles a new paragraph in the conversation.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| paragraph | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The paragraph text. |
| textPosition | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The position of the text in the conversation. |
| isLastParagraph | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether this is the last paragraph. |

##### Remarks

Processes the paragraph to identify and manage code listings.

Adds the paragraph to the current listing if it is part of a code block.

Creates a new [ConversationItem](#T-CommunityToolkit-WinForms-ChatUI-ConversationItem 'CommunityToolkit.WinForms.ChatUI.ConversationItem') for the paragraph if it is the last paragraph.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-SaveConversationAsync'></a>
### SaveConversationAsync() `method`

##### Summary

Saves the conversation asynchronously.

##### Returns

A task representing the asynchronous save operation.

##### Parameters

This method has no parameters.

##### Remarks

Opens a file stream to write the conversation data to a file in JSON format.

Flushes the file stream asynchronously to ensure all data is written to the file.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationProcessor-TryGetConversationBaseFolder-System-Boolean-'></a>
### TryGetConversationBaseFolder() `method`

##### Summary

Attempts to get the base folder for the conversation.

##### Parameters

This method has no parameters.

##### Remarks

Generates a unique filename from the conversation title and ensures it does not contain invalid characters.

Creates the necessary folder structure for storing the conversation file.

<a name='T-CommunityToolkit-WinForms-ChatUI-Components-ConversationRenderer'></a>
## ConversationRenderer `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI.Components

##### Summary

MarkDown renderer component - based on Alexander Mutel's MarkDig, 
 Copyright by Alexander Mutel.

<a name='T-CommunityToolkit-WinForms-ChatUI-ConversationView'></a>
## ConversationView `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Represents a custom conversation view control that extends 
 the BlazorWebView class.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the ConversationView class.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-ChatUI-ConversationView-Conversation'></a>
### Conversation `property`

##### Summary

Gets or sets the unique identifier for the conversation.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-AddConversationItem-System-String,System-Boolean-'></a>
### AddConversationItem(text,isResponse) `method`

##### Summary

Adds a conversation item to the conversation view.

##### Returns

The added conversation item.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text content of the conversation item. |
| isResponse | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether the item is a response. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-ClearHistory'></a>
### ClearHistory() `method`

##### Summary

Clears the conversation history.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnConversationItemAdded-CommunityToolkit-WinForms-ChatUI-ConversationItemAddedEventArgs-'></a>
### OnConversationItemAdded(conversationItemAddedEventArgs) `method`

##### Summary

Raises the [](#E-CommunityToolkit-WinForms-ChatUI-ConversationView-ConversationItemAdded 'CommunityToolkit.WinForms.ChatUI.ConversationView.ConversationItemAdded') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversationItemAddedEventArgs | [CommunityToolkit.WinForms.ChatUI.ConversationItemAddedEventArgs](#T-CommunityToolkit-WinForms-ChatUI-ConversationItemAddedEventArgs 'CommunityToolkit.WinForms.ChatUI.ConversationItemAddedEventArgs') | The event data. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnConversationTitleChanged-CommunityToolkit-WinForms-ChatUI-ConversationTitleChangedEventArgs-'></a>
### OnConversationTitleChanged(conversationTitleChangedEventArgs) `method`

##### Summary

Raises the [](#E-CommunityToolkit-WinForms-ChatUI-ConversationView-ConversationTitleChanged 'CommunityToolkit.WinForms.ChatUI.ConversationView.ConversationTitleChanged') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| conversationTitleChangedEventArgs | [CommunityToolkit.WinForms.ChatUI.ConversationTitleChangedEventArgs](#T-CommunityToolkit-WinForms-ChatUI-ConversationTitleChangedEventArgs 'CommunityToolkit.WinForms.ChatUI.ConversationTitleChangedEventArgs') | The event data. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-OnPaintBackground-System-Windows-Forms-PaintEventArgs-'></a>
### OnPaintBackground(e) `method`

##### Summary

Paints the background of the control.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Windows.Forms.PaintEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.PaintEventArgs 'System.Windows.Forms.PaintEventArgs') | A [PaintEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.PaintEventArgs 'System.Windows.Forms.PaintEventArgs') that contains the event data. |

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-ToJson'></a>
### ToJson() `method`

##### Summary

Converts the conversation items to a JSON string.

##### Returns

A JSON string representing the conversation items.

##### Parameters

This method has no parameters.

<a name='M-CommunityToolkit-WinForms-ChatUI-ConversationView-UpdateCurrentResponseAsync-System-Collections-Generic-IAsyncEnumerable{System-String}-'></a>
### UpdateCurrentResponseAsync(asyncEnumerable) `method`

##### Summary

Builds the current response asynchronously, which is MVVM'd to the Blazor component.
 Doesn't process anything, just controls the Token-by-Token rendering in the Blazor component.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| asyncEnumerable | [System.Collections.Generic.IAsyncEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IAsyncEnumerable 'System.Collections.Generic.IAsyncEnumerable{System.String}') |  |

<a name='T-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions'></a>
## JsonElementExtensions `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI.Extension

##### Summary

Provides extension methods for [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement').

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-String-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a string, 
 or a default value if the property does not exist.

##### Returns

The value of the property as a string, or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Int32-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as an integer, 
 or a default value if the property does not exist.

##### Returns

The value of the property as an integer, or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-DateTimeOffset-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a [DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset'), 
 or a default value if the property does not exist.

##### Returns

The value of the property as a [DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset'), or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Guid-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid'), 
 or a default value if the property does not exist.

##### Returns

The value of the property as a [Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid'), or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-DateTime-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a [DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime'), 
 or a default value if the property does not exist.

##### Returns

The value of the property as a [DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime'), or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-Boolean-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a boolean, 
 or a default value if the property does not exist.

##### Returns

The value of the property as a boolean, or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | The default value to return if the property does not exist. |

<a name='M-CommunityToolkit-WinForms-ChatUI-Extension-JsonElementExtensions-GetPropertyOrDefault-System-Text-Json-JsonElement,System-String,System-TimeSpan-'></a>
### GetPropertyOrDefault(element,propertyName,defaultValue) `method`

##### Summary

Gets the value of a specified property as a [TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan'), 
 or a default value if the property does not exist.

##### Returns

The value of the property as a [TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan'), or the default value if the property does not exist.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| element | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The [JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') to search. |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to get. |
| defaultValue | [System.TimeSpan](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.TimeSpan 'System.TimeSpan') | The default value to return if the property does not exist. |

<a name='T-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs'></a>
## RequestChatViewOptionsEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.ChatUI

##### Summary

Provides data for the RequestChatViewOptions event.

<a name='M-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-#ctor-System-String,System-String,System-Guid-'></a>
### #ctor(basePath,lastUsedModel,lastUsedConfigurationId) `constructor`

##### Summary

Initializes a new instance of the [RequestChatViewOptionsEventArgs](#T-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| basePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The base path for the chat view. |
| lastUsedModel | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The last used model for the chat view. |
| lastUsedConfigurationId | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | The last used configuration ID for the chat view. |

<a name='M-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-#ctor-CommunityToolkit-WinForms-ChatUI-ChatViewOptions-'></a>
### #ctor(options) `constructor`

##### Summary

Initializes a new instance of the [RequestChatViewOptionsEventArgs](#T-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs 'CommunityToolkit.WinForms.ChatUI.RequestChatViewOptionsEventArgs') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [CommunityToolkit.WinForms.ChatUI.ChatViewOptions](#T-CommunityToolkit-WinForms-ChatUI-ChatViewOptions 'CommunityToolkit.WinForms.ChatUI.ChatViewOptions') | The chat view options. |

<a name='P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-BasePath'></a>
### BasePath `property`

##### Summary

Gets the base path for the chat view.

<a name='P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-LastUsedConfigurationId'></a>
### LastUsedConfigurationId `property`

##### Summary

Gets the last used configuration ID for the chat view.

<a name='P-CommunityToolkit-WinForms-ChatUI-RequestChatViewOptionsEventArgs-LastUsedModel'></a>
### LastUsedModel `property`

##### Summary

Gets the last used model for the chat view.

<a name='T-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs'></a>
## __KnownINotifyPropertyChangedArgs `type`

##### Namespace

CommunityToolkit.Mvvm.ComponentModel.__Internals

##### Summary

A helper type providing cached, reusable [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instances
for all properties generated with [ObservablePropertyAttribute](#T-CommunityToolkit-Mvvm-ComponentModel-ObservablePropertyAttribute 'CommunityToolkit.Mvvm.ComponentModel.ObservablePropertyAttribute').

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-BackColor'></a>
### BackColor `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "BackColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-BasePath'></a>
### BasePath `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "BasePath" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-CompleteProcessDuration'></a>
### CompleteProcessDuration `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "CompleteProcessDuration" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ConversationItems'></a>
### ConversationItems `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "ConversationItems" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-CurrentListingInfo'></a>
### CurrentListingInfo `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "CurrentListingInfo" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-DateCreated'></a>
### DateCreated `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "DateCreated" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-DateLastEdited'></a>
### DateLastEdited `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "DateLastEdited" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Filename'></a>
### Filename `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Filename" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-FirstResponseDuration'></a>
### FirstResponseDuration `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "FirstResponseDuration" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ForeColor'></a>
### ForeColor `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "ForeColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Headline'></a>
### Headline `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Headline" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-HtmlContent'></a>
### HtmlContent `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "HtmlContent" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Id'></a>
### Id `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Id" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-IdPersonality'></a>
### IdPersonality `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "IdPersonality" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-IsResponse'></a>
### IsResponse `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "IsResponse" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Keywords'></a>
### Keywords `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Keywords" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastKickOffTime'></a>
### LastKickOffTime `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "LastKickOffTime" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastUsedConfigurationId'></a>
### LastUsedConfigurationId `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "LastUsedConfigurationId" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-LastUsedModel'></a>
### LastUsedModel `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "LastUsedModel" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-MarkdownContent'></a>
### MarkdownContent `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "MarkdownContent" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Model'></a>
### Model `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Model" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ResponseInProgress'></a>
### ResponseInProgress `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "ResponseInProgress" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ResponseInProgressBackColor'></a>
### ResponseInProgressBackColor `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "ResponseInProgressBackColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Summary'></a>
### Summary `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Summary" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-Title'></a>
### Title `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "Title" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-TokenCount'></a>
### TokenCount `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "TokenCount" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangedArgs-ViewUpdatesSuspended'></a>
### ViewUpdatesSuspended `constants`

##### Summary

The cached [PropertyChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs') instance for all "ViewUpdatesSuspended" generated properties.

<a name='T-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs'></a>
## __KnownINotifyPropertyChangingArgs `type`

##### Namespace

CommunityToolkit.Mvvm.ComponentModel.__Internals

##### Summary

A helper type providing cached, reusable [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instances
for all properties generated with [ObservablePropertyAttribute](#T-CommunityToolkit-Mvvm-ComponentModel-ObservablePropertyAttribute 'CommunityToolkit.Mvvm.ComponentModel.ObservablePropertyAttribute').

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-BackColor'></a>
### BackColor `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "BackColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-BasePath'></a>
### BasePath `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "BasePath" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-CompleteProcessDuration'></a>
### CompleteProcessDuration `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "CompleteProcessDuration" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ConversationItems'></a>
### ConversationItems `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "ConversationItems" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-CurrentListingInfo'></a>
### CurrentListingInfo `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "CurrentListingInfo" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-DateCreated'></a>
### DateCreated `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "DateCreated" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-DateLastEdited'></a>
### DateLastEdited `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "DateLastEdited" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Filename'></a>
### Filename `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Filename" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-FirstResponseDuration'></a>
### FirstResponseDuration `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "FirstResponseDuration" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ForeColor'></a>
### ForeColor `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "ForeColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Headline'></a>
### Headline `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Headline" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-HtmlContent'></a>
### HtmlContent `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "HtmlContent" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Id'></a>
### Id `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Id" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-IdPersonality'></a>
### IdPersonality `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "IdPersonality" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-IsResponse'></a>
### IsResponse `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "IsResponse" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Keywords'></a>
### Keywords `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Keywords" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastKickOffTime'></a>
### LastKickOffTime `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "LastKickOffTime" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastUsedConfigurationId'></a>
### LastUsedConfigurationId `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "LastUsedConfigurationId" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-LastUsedModel'></a>
### LastUsedModel `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "LastUsedModel" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-MarkdownContent'></a>
### MarkdownContent `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "MarkdownContent" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Model'></a>
### Model `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Model" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ResponseInProgress'></a>
### ResponseInProgress `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "ResponseInProgress" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ResponseInProgressBackColor'></a>
### ResponseInProgressBackColor `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "ResponseInProgressBackColor" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Summary'></a>
### Summary `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Summary" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-Title'></a>
### Title `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "Title" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-TokenCount'></a>
### TokenCount `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "TokenCount" generated properties.

<a name='F-CommunityToolkit-Mvvm-ComponentModel-__Internals-__KnownINotifyPropertyChangingArgs-ViewUpdatesSuspended'></a>
### ViewUpdatesSuspended `constants`

##### Summary

The cached [PropertyChangingEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.PropertyChangingEventArgs 'System.ComponentModel.PropertyChangingEventArgs') instance for all "ViewUpdatesSuspended" generated properties.
