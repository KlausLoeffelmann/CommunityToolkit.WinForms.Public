<a name='assembly'></a>
# CommunityToolkit.WinForms.AI

## Contents

- [AIGeneratedAttribute](#T--AIGeneratedAttribute '.AIGeneratedAttribute')
  - [#ctor(guid,timeStamp,confidence)](#M-AIGeneratedAttribute-#ctor-System-String,System-String,System-Int32- 'AIGeneratedAttribute.#ctor(System.String,System.String,System.Int32)')
  - [AgentName](#P-AIGeneratedAttribute-AgentName 'AIGeneratedAttribute.AgentName')
  - [Confidence](#P-AIGeneratedAttribute-Confidence 'AIGeneratedAttribute.Confidence')
  - [EnableReviewDiagnostics](#P-AIGeneratedAttribute-EnableReviewDiagnostics 'AIGeneratedAttribute.EnableReviewDiagnostics')
  - [Guid](#P-AIGeneratedAttribute-Guid 'AIGeneratedAttribute.Guid')
  - [Metadata](#P-AIGeneratedAttribute-Metadata 'AIGeneratedAttribute.Metadata')
  - [TextSpanRanges](#P-AIGeneratedAttribute-TextSpanRanges 'AIGeneratedAttribute.TextSpanRanges')
  - [TimeStamp](#P-AIGeneratedAttribute-TimeStamp 'AIGeneratedAttribute.TimeStamp')
- [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-AITemplateAttribute-#ctor 'CommunityToolkit.WinForms.AI.AITemplateAttribute.#ctor')
  - [FormatCulture](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-FormatCulture 'CommunityToolkit.WinForms.AI.AITemplateAttribute.FormatCulture')
  - [LanguageCulture](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-LanguageCulture 'CommunityToolkit.WinForms.AI.AITemplateAttribute.LanguageCulture')
  - [Prompt](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-Prompt 'CommunityToolkit.WinForms.AI.AITemplateAttribute.Prompt')
  - [ProvideDate](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideDate 'CommunityToolkit.WinForms.AI.AITemplateAttribute.ProvideDate')
  - [ProvideTime](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideTime 'CommunityToolkit.WinForms.AI.AITemplateAttribute.ProvideTime')
  - [ProvideTimeZone](#P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideTimeZone 'CommunityToolkit.WinForms.AI.AITemplateAttribute.ProvideTimeZone')
- [AITemplateSegmentAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-#ctor 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute.#ctor')
  - [Prompt](#P-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-Prompt 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute.Prompt')
  - [Purpose](#P-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-Purpose 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute.Purpose')
- [AITextResourceAttribute](#T-CommunityToolkit-WinForms-AI-ResourceManagement-AITextResourceAttribute 'CommunityToolkit.WinForms.AI.ResourceManagement.AITextResourceAttribute')
- [AsyncCodeBlockInfoProvidedEventArgs](#T-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs 'CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-#ctor-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo- 'CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs.#ctor(CommunityToolkit.Roslyn.Tooling.CodeBlockInfo)')
  - [CodeBlock](#P-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-CodeBlock 'CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs.CodeBlock')
  - [Handled](#P-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-Handled 'CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs.Handled')
- [AsyncReceivedInlineMetaDataEventArgs](#T-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs 'CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs-#ctor-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData- 'CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs.#ctor(CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData)')
  - [MetaData](#P-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs-MetaData 'CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs.MetaData')
- [AsyncReceivedNextParagraphEventArgs](#T-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs')
  - [#ctor(paragraph,textPosition,isLastParagraph)](#M-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-#ctor-System-String,System-Int32,System-Boolean- 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs.#ctor(System.String,System.Int32,System.Boolean)')
  - [IsLastParagraph](#P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-IsLastParagraph 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs.IsLastParagraph')
  - [Paragraph](#P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-Paragraph 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs.Paragraph')
  - [TextPosition](#P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-TextPosition 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs.TextPosition')
- [IUsesSemanticKernelComponent](#T-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent')
  - [ModelName](#P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-ModelName 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.ModelName')
  - [OpenAiModelId](#P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-OpenAiModelId 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.OpenAiModelId')
  - [SemanticKernel](#P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-SemanticKernel 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.SemanticKernel')
  - [SemanticKernelGetter](#P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-SemanticKernelGetter 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.SemanticKernelGetter')
  - [Initialize()](#M-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-Initialize 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.Initialize')
  - [ProvidePropertyProcessingDelegates(instance,semanticKernelGetter)](#M-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-ProvidePropertyProcessingDelegates-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent,System-Func{CommunityToolkit-WinForms-AI-SemanticKernelComponent}- 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent.ProvidePropertyProcessingDelegates(CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent,System.Func{CommunityToolkit.WinForms.AI.SemanticKernelComponent})')
- [JoinType](#T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType')
  - [Comma](#F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-Comma 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType.Comma')
  - [NewLine](#F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-NewLine 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType.NewLine')
  - [Semicolon](#F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-Semicolon 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType.Semicolon')
- [ModelInfo](#T-CommunityToolkit-WinForms-AI-ModelInfo 'CommunityToolkit.WinForms.AI.ModelInfo')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-ModelInfo-#ctor-System-String,System-String,System-Int32,System-String,CommunityToolkit-WinForms-AI-ModelInfo-Usage- 'CommunityToolkit.WinForms.AI.ModelInfo.#ctor(System.String,System.String,System.Int32,System.String,CommunityToolkit.WinForms.AI.ModelInfo.Usage)')
  - [Created](#P-CommunityToolkit-WinForms-AI-ModelInfo-Created 'CommunityToolkit.WinForms.AI.ModelInfo.Created')
  - [Id](#P-CommunityToolkit-WinForms-AI-ModelInfo-Id 'CommunityToolkit.WinForms.AI.ModelInfo.Id')
  - [Object](#P-CommunityToolkit-WinForms-AI-ModelInfo-Object 'CommunityToolkit.WinForms.AI.ModelInfo.Object')
  - [OwnedBy](#P-CommunityToolkit-WinForms-AI-ModelInfo-OwnedBy 'CommunityToolkit.WinForms.AI.ModelInfo.OwnedBy')
  - [TokenUsage](#P-CommunityToolkit-WinForms-AI-ModelInfo-TokenUsage 'CommunityToolkit.WinForms.AI.ModelInfo.TokenUsage')
- [OpenAIPromptExecutionSettingsExtensions](#T-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions 'CommunityToolkit.WinForms.AI.OpenAIPromptExecutionSettingsExtensions')
  - [WithDefaultModelParameters(settings,MaxTokens,temperature,topP,frequencyPenalty,presencePenalty,user)](#M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithDefaultModelParameters-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-Nullable{System-Int32},System-Nullable{System-Double},System-Nullable{System-Double},System-Nullable{System-Double},System-Nullable{System-Double},System-String- 'CommunityToolkit.WinForms.AI.OpenAIPromptExecutionSettingsExtensions.WithDefaultModelParameters(Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings,System.Nullable{System.Int32},System.Nullable{System.Double},System.Nullable{System.Double},System.Nullable{System.Double},System.Nullable{System.Double},System.String)')
  - [WithDeveloperPrompt(settings,developerPrompt)](#M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithDeveloperPrompt-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-String- 'CommunityToolkit.WinForms.AI.OpenAIPromptExecutionSettingsExtensions.WithDeveloperPrompt(Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings,System.String)')
  - [WithJsonReturnSchema(settings,returnSchema,schemaName,schemaDescription)](#M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithJsonReturnSchema-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-Text-Json-JsonElement,System-String,System-String- 'CommunityToolkit.WinForms.AI.OpenAIPromptExecutionSettingsExtensions.WithJsonReturnSchema(Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings,System.Text.Json.JsonElement,System.String,System.String)')
  - [WithSystemPrompt(settings,systemPrompt)](#M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithSystemPrompt-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-String- 'CommunityToolkit.WinForms.AI.OpenAIPromptExecutionSettingsExtensions.WithSystemPrompt(Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings,System.String)')
- [PromptFromTypeGenerator](#T-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator')
  - [GetJSonSchema\`\`1()](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetJSonSchema``1 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetJSonSchema``1')
  - [GetJsonType(type)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetJsonType-System-Type- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetJsonType(System.Type)')
  - [GetPreamblePrompt(promptInfo)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPreamblePrompt-CommunityToolkit-WinForms-AI-AITemplateAttribute- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetPreamblePrompt(CommunityToolkit.WinForms.AI.AITemplateAttribute)')
  - [GetPropertiesSchema(type)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPropertiesSchema-System-Type- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetPropertiesSchema(System.Type)')
  - [GetPropertyDescription(property)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPropertyDescription-System-Reflection-PropertyInfo- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetPropertyDescription(System.Reflection.PropertyInfo)')
  - [GetRequiredProperties(type)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetRequiredProperties-System-Type- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetRequiredProperties(System.Type)')
  - [GetTypePrompt(targetType,indentLevel,indentation)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePrompt-System-Type,System-Int32,System-Int32- 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetTypePrompt(System.Type,System.Int32,System.Int32)')
  - [GetTypePromptInfo\`\`1()](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePromptInfo``1 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetTypePromptInfo``1')
  - [GetTypePrompt\`\`1()](#M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePrompt``1 'CommunityToolkit.WinForms.AI.ConverterLogic.PromptFromTypeGenerator.GetTypePrompt``1')
- [RemoveWhiteSpace_0](#T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0')
  - [#ctor()](#M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-#ctor 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.#ctor')
  - [Instance](#F-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-Instance 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.Instance')
- [ResponseTextFormat](#T-CommunityToolkit-WinForms-AI-ResponseTextFormat 'CommunityToolkit.WinForms.AI.ResponseTextFormat')
  - [Html](#F-CommunityToolkit-WinForms-AI-ResponseTextFormat-Html 'CommunityToolkit.WinForms.AI.ResponseTextFormat.Html')
  - [Markdown](#F-CommunityToolkit-WinForms-AI-ResponseTextFormat-Markdown 'CommunityToolkit.WinForms.AI.ResponseTextFormat.Markdown')
  - [MicrosoftRichText](#F-CommunityToolkit-WinForms-AI-ResponseTextFormat-MicrosoftRichText 'CommunityToolkit.WinForms.AI.ResponseTextFormat.MicrosoftRichText')
  - [PlainText](#F-CommunityToolkit-WinForms-AI-ResponseTextFormat-PlainText 'CommunityToolkit.WinForms.AI.ResponseTextFormat.PlainText')
- [ReturnStreamMetaData](#T-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData')
  - [#ctor(Key,Value,Position,WasDedicatedLine)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-#ctor-System-String,System-String,System-Int32,System-Boolean- 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData.#ctor(System.String,System.String,System.Int32,System.Boolean)')
  - [Key](#P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Key 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData.Key')
  - [Position](#P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Position 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData.Position')
  - [Value](#P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Value 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData.Value')
  - [WasDedicatedLine](#P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-WasDedicatedLine 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData.WasDedicatedLine')
- [ReturnTokenParser](#T-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnTokenParser 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnTokenParser')
  - [ProcessTokens(asyncEnumerable,onReceivedMetaDataAction,onReceivedNextParagraphAction,onCodeBlockInfoProvidedAction)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnTokenParser-ProcessTokens-System-Collections-Generic-IAsyncEnumerable{Microsoft-SemanticKernel-StreamingChatMessageContent},System-Action{CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs},System-Action{CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs},System-Action{CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs}- 'CommunityToolkit.WinForms.AI.ConverterLogic.ReturnTokenParser.ProcessTokens(System.Collections.Generic.IAsyncEnumerable{Microsoft.SemanticKernel.StreamingChatMessageContent},System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs},System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs},System.Action{CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs})')
- [Runner](#T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory.Runner')
  - [Scan(inputSpan)](#M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-Scan-System-ReadOnlySpan{System-Char}- 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory.Runner.Scan(System.ReadOnlySpan{System.Char})')
  - [TryFindNextPossibleStartingPosition(inputSpan)](#M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-TryFindNextPossibleStartingPosition-System-ReadOnlySpan{System-Char}- 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory.Runner.TryFindNextPossibleStartingPosition(System.ReadOnlySpan{System.Char})')
  - [TryMatchAtCurrentPosition(inputSpan)](#M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-TryMatchAtCurrentPosition-System-ReadOnlySpan{System-Char}- 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory.Runner.TryMatchAtCurrentPosition(System.ReadOnlySpan{System.Char})')
- [RunnerFactory](#T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory')
  - [CreateInstance()](#M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-CreateInstance 'System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory.CreateInstance')
- [SegmentPurpose](#T-CommunityToolkit-WinForms-AI-SegmentPurpose 'CommunityToolkit.WinForms.AI.SegmentPurpose')
  - [Request](#F-CommunityToolkit-WinForms-AI-SegmentPurpose-Request 'CommunityToolkit.WinForms.AI.SegmentPurpose.Request')
  - [RequestAndResponse](#F-CommunityToolkit-WinForms-AI-SegmentPurpose-RequestAndResponse 'CommunityToolkit.WinForms.AI.SegmentPurpose.RequestAndResponse')
  - [Response](#F-CommunityToolkit-WinForms-AI-SegmentPurpose-Response 'CommunityToolkit.WinForms.AI.SegmentPurpose.Response')
- [SemanticKernelComponent](#T-CommunityToolkit-WinForms-AI-SemanticKernelComponent 'CommunityToolkit.WinForms.AI.SemanticKernelComponent')
  - [ChatHistory](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ChatHistory 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ChatHistory')
  - [DeveloperPromptSchemaAmendment](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-DeveloperPromptSchemaAmendment 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.DeveloperPromptSchemaAmendment')
  - [EffectiveDeveloperPrompt](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-EffectiveDeveloperPrompt 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.EffectiveDeveloperPrompt')
  - [FrequencyPenalty](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-FrequencyPenalty 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.FrequencyPenalty')
  - [JsonSchema](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchema 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.JsonSchema')
  - [JsonSchemaDescription](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaDescription 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.JsonSchemaDescription')
  - [JsonSchemaName](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaName 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.JsonSchemaName')
  - [JsonSchemaString](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaString 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.JsonSchemaString')
  - [Logger](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-Logger 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.Logger')
  - [ModelId](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ModelId 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ModelId')
  - [PresencePenalty](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-PresencePenalty 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.PresencePenalty')
  - [ResourceStreamSource](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ResourceStreamSource 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ResourceStreamSource')
  - [ResponseTextFormat](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ResponseTextFormat 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ResponseTextFormat')
  - [Temperature](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-Temperature 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.Temperature')
  - [TopP](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-TopP 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.TopP')
  - [AddChatItem(isResponse,message)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-AddChatItem-System-Boolean,System-String- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.AddChatItem(System.Boolean,System.String)')
  - [OnJsonSchemaChanged(e)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnJsonSchemaChanged-System-EventArgs- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.OnJsonSchemaChanged(System.EventArgs)')
  - [OnJsonSchemaStringChanged(e)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnJsonSchemaStringChanged-System-EventArgs- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.OnJsonSchemaStringChanged(System.EventArgs)')
  - [OnReceivedNextParagraph(receivedNextParagraphEventArgs)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnReceivedNextParagraph-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.OnReceivedNextParagraph(CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs)')
  - [QueryOpenAiModelInfoAsync(modelName)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-QueryOpenAiModelInfoAsync-System-String- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.QueryOpenAiModelInfoAsync(System.String)')
  - [QueryOpenAiModelNamesAsync()](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-QueryOpenAiModelNamesAsync 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.QueryOpenAiModelNamesAsync')
  - [RequestPromptResponseStreamAsync(valueToProcess,keepChatHistory)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestPromptResponseStreamAsync-System-String,System-Boolean- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.RequestPromptResponseStreamAsync(System.String,System.Boolean)')
  - [RequestStructuredResponseAsync\`\`1(userRequestPrompt)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestStructuredResponseAsync``1-System-String- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.RequestStructuredResponseAsync``1(System.String)')
  - [RequestTextPromptResponseAsync(valueToProcess)](#M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestTextPromptResponseAsync-System-String,System-Boolean- 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.RequestTextPromptResponseAsync(System.String,System.Boolean)')
- [StringAndStringBuilderExtensions](#T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions')
  - [AppendBulletPoint(sb,value,maxLineLength,bulletLevel,bulletLevelChars,indentLevel,indentation)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendBulletPoint-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-String,System-Int32,System-Int32- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.AppendBulletPoint(System.Text.StringBuilder,System.String,System.Int32,System.Int32,System.String,System.Int32,System.Int32)')
  - [AppendBulletPointSubParagraph(sb,value,maxLineLength,bulletLevel,indentLevel,indentation)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendBulletPointSubParagraph-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-Int32,System-Int32- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.AppendBulletPointSubParagraph(System.Text.StringBuilder,System.String,System.Int32,System.Int32,System.Int32,System.Int32)')
  - [AppendParagraph(sb,value,maxLineLength,indentLevel,indentation)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendParagraph-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-Int32- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.AppendParagraph(System.Text.StringBuilder,System.String,System.Int32,System.Int32,System.Int32)')
  - [IndentLines(text,indentLevel,indent)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-IndentLines-System-String,System-Int32,System-Int32- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.IndentLines(System.String,System.Int32,System.Int32)')
  - [Join(strings,joinType)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-Join-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.Join(System.String[],CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType)')
  - [JoinOrDefault(strings,joinType)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinOrDefault-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinOrDefault(System.String[],CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType)')
  - [JoinOrEmpty(strings,joinType)](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinOrEmpty-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType- 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinOrEmpty(System.String[],CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType)')
  - [RemoveWhiteSpace()](#M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-RemoveWhiteSpace 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.RemoveWhiteSpace')
- [StringLiteralConverterExtension](#T-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension 'CommunityToolkit.WinForms.AI.ConverterLogic.StringLiteralConverterExtension')
  - [FromCSharpLiteral(literal,ensureWindowsLineEndings)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension-FromCSharpLiteral-System-String,System-Boolean- 'CommunityToolkit.WinForms.AI.ConverterLogic.StringLiteralConverterExtension.FromCSharpLiteral(System.String,System.Boolean)')
  - [ToCSharpLiteral(input)](#M-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension-ToCSharpLiteral-System-String- 'CommunityToolkit.WinForms.AI.ConverterLogic.StringLiteralConverterExtension.ToCSharpLiteral(System.String)')
- [Usage](#T-CommunityToolkit-WinForms-AI-ModelInfo-Usage 'CommunityToolkit.WinForms.AI.ModelInfo.Usage')
  - [#ctor()](#M-CommunityToolkit-WinForms-AI-ModelInfo-Usage-#ctor-System-Nullable{System-Int32}- 'CommunityToolkit.WinForms.AI.ModelInfo.Usage.#ctor(System.Nullable{System.Int32})')
  - [MaxTokens](#P-CommunityToolkit-WinForms-AI-ModelInfo-Usage-MaxTokens 'CommunityToolkit.WinForms.AI.ModelInfo.Usage.MaxTokens')
- [Utilities](#T-System-Text-RegularExpressions-Generated-Utilities 'System.Text.RegularExpressions.Generated.Utilities')
  - [s_defaultTimeout](#F-System-Text-RegularExpressions-Generated-Utilities-s_defaultTimeout 'System.Text.RegularExpressions.Generated.Utilities.s_defaultTimeout')
  - [s_hasTimeout](#F-System-Text-RegularExpressions-Generated-Utilities-s_hasTimeout 'System.Text.RegularExpressions.Generated.Utilities.s_hasTimeout')
  - [s_whitespace](#F-System-Text-RegularExpressions-Generated-Utilities-s_whitespace 'System.Text.RegularExpressions.Generated.Utilities.s_whitespace')

<a name='T--AIGeneratedAttribute'></a>
## AIGeneratedAttribute `type`

##### Namespace



<a name='M-AIGeneratedAttribute-#ctor-System-String,System-String,System-Int32-'></a>
### #ctor(guid,timeStamp,confidence) `constructor`

##### Summary

Initializes a new instance of the [AIGeneratedAttribute](#T-AIGeneratedAttribute 'AIGeneratedAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| guid | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | A unique identifier for the generated code block (as a string representation of a GUID). |
| timeStamp | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The timestamp when the code was generated, in ISO 8601 format. |
| confidence | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | A value between 0 and 100 representing the AI generation confidence. Default is 100. |

<a name='P-AIGeneratedAttribute-AgentName'></a>
### AgentName `property`

##### Summary

Gets or sets the name of the AI tool or agent responsible for code generation.

<a name='P-AIGeneratedAttribute-Confidence'></a>
### Confidence `property`

##### Summary

Gets the AI generation confidence level.

<a name='P-AIGeneratedAttribute-EnableReviewDiagnostics'></a>
### EnableReviewDiagnostics `property`

##### Summary

Gets or sets a flag indicating whether review diagnostics should be enabled.

<a name='P-AIGeneratedAttribute-Guid'></a>
### Guid `property`

##### Summary

Gets the unique identifier for the generated code block.

<a name='P-AIGeneratedAttribute-Metadata'></a>
### Metadata `property`

##### Summary

Gets or sets additional metadata as a semicolon-delimited string
(e.g., "version=1.0;module=MyModule").

<a name='P-AIGeneratedAttribute-TextSpanRanges'></a>
### TextSpanRanges `property`

##### Summary

Gets or sets an array of text span ranges (encoded as "start,length")
that represent parts of the code modified or generated by AI.

<a name='P-AIGeneratedAttribute-TimeStamp'></a>
### TimeStamp `property`

##### Summary

Gets the timestamp when the code was generated (ISO 8601 format).

<a name='T-CommunityToolkit-WinForms-AI-AITemplateAttribute'></a>
## AITemplateAttribute `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Attribute to define an AI template for structured interactions with a language model.

##### Example

```
   [AITemplate(Prompt = "Provide a detailed description of the task.")]
   public class TaskTemplate
   {
       [AITemplateSegment("Describe the task in detail.")]
       public string? TaskDescription { get; set; }
       [AITemplateSegment("Specify the deadline for the task.")]
       public DateTime Deadline { get; set; }
   }
  
```

##### Remarks

The `AITemplateAttribute` is applied to classes to specify a system/developer prompt that guides
   the language model during a structured roundtrip. The prompt provides detailed instructions and context,
   forming the basis for constructing the complete conversation with the AI.

In a typical implementation, the prompt defined by this attribute is paired with properties decorated with
   the [AITemplateSegmentAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute'). These segment attributes map specific portions of the overall prompt
   to individual properties, thereby facilitating a clear Prompt->Property assignment.

This attribute is primarily used in StructuredMode scenarios, where the AI's input and output are organized
   into discrete segments. In such cases, additional metadata such as the current date, time, time zone,
   and cultural formatting information can be provided to enrich the prompt and ensure consistent localization.

<a name='M-CommunityToolkit-WinForms-AI-AITemplateAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Attribute to define an AI template for structured interactions with a language model.

##### Parameters

This constructor has no parameters.

##### Example

```
   [AITemplate(Prompt = "Provide a detailed description of the task.")]
   public class TaskTemplate
   {
       [AITemplateSegment("Describe the task in detail.")]
       public string? TaskDescription { get; set; }
       [AITemplateSegment("Specify the deadline for the task.")]
       public DateTime Deadline { get; set; }
   }
  
```

##### Remarks

The `AITemplateAttribute` is applied to classes to specify a system/developer prompt that guides
   the language model during a structured roundtrip. The prompt provides detailed instructions and context,
   forming the basis for constructing the complete conversation with the AI.

In a typical implementation, the prompt defined by this attribute is paired with properties decorated with
   the [AITemplateSegmentAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute 'CommunityToolkit.WinForms.AI.AITemplateSegmentAttribute'). These segment attributes map specific portions of the overall prompt
   to individual properties, thereby facilitating a clear Prompt->Property assignment.

This attribute is primarily used in StructuredMode scenarios, where the AI's input and output are organized
   into discrete segments. In such cases, additional metadata such as the current date, time, time zone,
   and cultural formatting information can be provided to enrich the prompt and ensure consistent localization.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-FormatCulture'></a>
### FormatCulture `property`

##### Summary

Gets or sets the culture information used for formatting data in the prompt.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-LanguageCulture'></a>
### LanguageCulture `property`

##### Summary

Gets or sets the culture information used for determining the language of the prompt.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-Prompt'></a>
### Prompt `property`

##### Summary

Gets or sets the system/developer prompt used to instruct the language model.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideDate'></a>
### ProvideDate `property`

##### Summary

Gets or sets a value indicating whether to include the current date in the prompt.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideTime'></a>
### ProvideTime `property`

##### Summary

Gets or sets a value indicating whether to include the current time in the prompt.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateAttribute-ProvideTimeZone'></a>
### ProvideTimeZone `property`

##### Summary

Gets or sets a value indicating whether to include the current time zone information in the prompt.

<a name='T-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute'></a>
## AITemplateSegmentAttribute `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Attribute to map a specific prompt segment to a property in an AI template.

##### Example

```
  public class MyAITemplate
  {
      // This property is used for both input and output.
      [AITemplateSegment("Provide initial input or capture the resulting output.")]
      public string? Interaction { get; set; }
      // This property is used to capture only the generated output.
      [AITemplateSegment("The generated response will be populated here.")]
      public string? GeneratedResponse { get; set; }
  }
 
```

##### Remarks

The `AITemplateSegmentAttribute` is used to annotate properties within an AI template
  class. It assigns a specific segment of the overall prompt (as defined in the system/developer
  prompt) to the property, thereby facilitating a structured Prompt->Property assignment.

This attribute is essential for StructuredMode scenarios where both input and output are
  organized into discrete segments. The optional prompt string provides detailed instructions for
  that segment, while the [SegmentPurpose](#T-CommunityToolkit-WinForms-AI-SegmentPurpose 'CommunityToolkit.WinForms.AI.SegmentPurpose') property (defaulting to Output) indicates the
  intended role of the segment.

The [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') class can be used to define the overall prompt for the AI template,
  while the `AITemplateSegmentAttribute` maps specific segments of that prompt to individual properties.

<a name='M-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-#ctor'></a>
### #ctor() `constructor`

##### Summary

Attribute to map a specific prompt segment to a property in an AI template.

##### Parameters

This constructor has no parameters.

##### Example

```
  public class MyAITemplate
  {
      // This property is used for both input and output.
      [AITemplateSegment("Provide initial input or capture the resulting output.")]
      public string? Interaction { get; set; }
      // This property is used to capture only the generated output.
      [AITemplateSegment("The generated response will be populated here.")]
      public string? GeneratedResponse { get; set; }
  }
 
```

##### Remarks

The `AITemplateSegmentAttribute` is used to annotate properties within an AI template
  class. It assigns a specific segment of the overall prompt (as defined in the system/developer
  prompt) to the property, thereby facilitating a structured Prompt->Property assignment.

This attribute is essential for StructuredMode scenarios where both input and output are
  organized into discrete segments. The optional prompt string provides detailed instructions for
  that segment, while the [SegmentPurpose](#T-CommunityToolkit-WinForms-AI-SegmentPurpose 'CommunityToolkit.WinForms.AI.SegmentPurpose') property (defaulting to Output) indicates the
  intended role of the segment.

The [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') class can be used to define the overall prompt for the AI template,
  while the `AITemplateSegmentAttribute` maps specific segments of that prompt to individual properties.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-Prompt'></a>
### Prompt `property`

##### Summary

Gets the prompt associated with this segment.

##### Remarks

The prompt provides specific instructions for this segment and maps the respective portion
  of the overall AI prompt to the property.

<a name='P-CommunityToolkit-WinForms-AI-AITemplateSegmentAttribute-Purpose'></a>
### Purpose `property`

##### Summary

Gets the purpose of the segment.

##### Remarks

The [SegmentPurpose](#T-CommunityToolkit-WinForms-AI-SegmentPurpose 'CommunityToolkit.WinForms.AI.SegmentPurpose') indicates whether the segment is intended for input, output,
  or both. By default, this is set to [Response](#F-CommunityToolkit-WinForms-AI-SegmentPurpose-Response 'CommunityToolkit.WinForms.AI.SegmentPurpose.Response').

<a name='T-CommunityToolkit-WinForms-AI-ResourceManagement-AITextResourceAttribute'></a>
## AITextResourceAttribute `type`

##### Namespace

CommunityToolkit.WinForms.AI.ResourceManagement

##### Summary

An attribute to mark text resources as the source of truth 
 for automatically maintaining the correlated resource files.

##### Remarks

The [AITextResourceAttribute](#T-CommunityToolkit-WinForms-AI-ResourceManagement-AITextResourceAttribute 'CommunityToolkit.WinForms.AI.ResourceManagement.AITextResourceAttribute') is used to designate certain text 
  resources as the authoritative source. This helps in ensuring that any changes 
  made to these resources are automatically reflected in the related resource files.

<a name='T-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs'></a>
## AsyncCodeBlockInfoProvidedEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Provides data for the AsyncListingFileProvided event.

<a name='M-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-#ctor-CommunityToolkit-Roslyn-Tooling-CodeBlockInfo-'></a>
### #ctor() `constructor`

##### Summary

Provides data for the AsyncListingFileProvided event.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-CodeBlock'></a>
### CodeBlock `property`

##### Summary

Gets the listing file associated with the event.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the listing file is null. |

<a name='P-CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs-Handled'></a>
### Handled `property`

##### Summary

Gets or sets a value indicating whether the 
 event has been handled.

<a name='T-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs'></a>
## AsyncReceivedInlineMetaDataEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Provides data for the asynchronous received inline metadata event.

<a name='M-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs-#ctor-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-'></a>
### #ctor() `constructor`

##### Summary

Provides data for the asynchronous received inline metadata event.

##### Parameters

This constructor has no parameters.

<a name='P-CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs-MetaData'></a>
### MetaData `property`

##### Summary

Gets the metadata associated with the event.

<a name='T-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs'></a>
## AsyncReceivedNextParagraphEventArgs `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Provides data for the event that is triggered when the next paragraph is received asynchronously.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| paragraph | [T:CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs](#T-T-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs 'T:CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs') | The content of the received paragraph. |

<a name='M-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-#ctor-System-String,System-Int32,System-Boolean-'></a>
### #ctor(paragraph,textPosition,isLastParagraph) `constructor`

##### Summary

Provides data for the event that is triggered when the next paragraph is received asynchronously.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| paragraph | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The content of the received paragraph. |
| textPosition | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The position of the text in the document. |
| isLastParagraph | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether this is the last paragraph. |

<a name='P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-IsLastParagraph'></a>
### IsLastParagraph `property`

##### Summary

Gets a value indicating whether this is the last paragraph.

<a name='P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-Paragraph'></a>
### Paragraph `property`

##### Summary

Gets the content of the received paragraph.

<a name='P-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-TextPosition'></a>
### TextPosition `property`

##### Summary

Gets the position of the text in the document.

<a name='T-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent'></a>
## IUsesSemanticKernelComponent `type`

##### Namespace

CommunityToolkit.WinForms.AI.SemanticKernel

##### Summary

Interface for components that use a Semantic Kernel.

##### Remarks

This interface provides properties and methods to interact with a Semantic Kernel component.
  It includes functionality to get and set various parameters related to the Semantic Kernel,
  such as model ID, API key, and other configuration settings.

The interface also includes methods to initialize the Semantic Kernel with default values
  and to provide property processing delegates.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-ModelName'></a>
### ModelName `property`

##### Summary

Gets or sets the model name.

##### Remarks

This property gets or sets the model name for the Semantic Kernel.
  It is used to specify the model to be used for processing.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-OpenAiModelId'></a>
### OpenAiModelId `property`

##### Summary

Gets or sets the function to retrieve the OpenAI model ID.

##### Remarks

This property holds a delegate function that returns the OpenAI model ID.
  It is used to get or set the model ID for the Semantic Kernel.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-SemanticKernel'></a>
### SemanticKernel `property`

##### Summary

Gets the Semantic Kernel component.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when SemanticKernelGetter is not set. |

##### Remarks

This property retrieves the Semantic Kernel component using the SemanticKernelGetter delegate.
  If the delegate is not set, it throws an InvalidOperationException.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-SemanticKernelGetter'></a>
### SemanticKernelGetter `property`

##### Summary

Gets or sets the function to retrieve the Semantic Kernel component.

##### Remarks

This property holds a delegate function that returns the Semantic Kernel component.
  It is used to access the Semantic Kernel instance within the implementing class.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-Initialize'></a>
### Initialize() `method`

##### Summary

Initializes the Semantic Kernel with default values.

##### Parameters

This method has no parameters.

##### Remarks

This method sets default values for various parameters of the Semantic Kernel,
  such as MaxTokens, Temperature, TopP, FrequencyPenalty, PresencePenalty, JsonSchemaString,
  and DeveloperPrompt.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent-ProvidePropertyProcessingDelegates-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent,System-Func{CommunityToolkit-WinForms-AI-SemanticKernelComponent}-'></a>
### ProvidePropertyProcessingDelegates(instance,semanticKernelGetter) `method`

##### Summary

Provides property processing delegates for the instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| instance | [CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent](#T-CommunityToolkit-WinForms-AI-SemanticKernel-IUsesSemanticKernelComponent 'CommunityToolkit.WinForms.AI.SemanticKernel.IUsesSemanticKernelComponent') | The instance of IUsesSemanticKernelComponent. |
| semanticKernelGetter | [System.Func{CommunityToolkit.WinForms.AI.SemanticKernelComponent}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{CommunityToolkit.WinForms.AI.SemanticKernelComponent}') | The delegate function to get the Semantic Kernel component. |

##### Remarks

This static method sets the SemanticKernelGetter delegate for the given instance.
  It is used to provide the necessary delegate functions for property processing.

<a name='T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType'></a>
## JoinType `type`

##### Namespace

CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions

##### Summary

Specifies the type of join operation to perform.

##### Remarks

This enum defines the different types of join operations that can be performed
  when joining an array of strings into a single string.

<a name='F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-Comma'></a>
### Comma `constants`

##### Summary

Join with commas.

<a name='F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-NewLine'></a>
### NewLine `constants`

##### Summary

Join with new lines.

<a name='F-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-Semicolon'></a>
### Semicolon `constants`

##### Summary

Join with semicolons.

<a name='T-CommunityToolkit-WinForms-AI-ModelInfo'></a>
## ModelInfo `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Represents information about a model.

##### Remarks

This class holds details about a model including its ID, object type, creation date,
  owner, and usage information.

<a name='M-CommunityToolkit-WinForms-AI-ModelInfo-#ctor-System-String,System-String,System-Int32,System-String,CommunityToolkit-WinForms-AI-ModelInfo-Usage-'></a>
### #ctor() `constructor`

##### Summary

Represents information about a model.

##### Parameters

This constructor has no parameters.

##### Remarks

This class holds details about a model including its ID, object type, creation date,
  owner, and usage information.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-Created'></a>
### Created `property`

##### Summary

Gets the creation date of the model.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-Id'></a>
### Id `property`

##### Summary

Gets the ID of the model.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-Object'></a>
### Object `property`

##### Summary

Gets the object type of the model.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-OwnedBy'></a>
### OwnedBy `property`

##### Summary

Gets the owner of the model.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-TokenUsage'></a>
### TokenUsage `property`

##### Summary

Gets the usage information of the model.

<a name='T-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions'></a>
## OpenAIPromptExecutionSettingsExtensions `type`

##### Namespace

CommunityToolkit.WinForms.AI

<a name='M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithDefaultModelParameters-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-Nullable{System-Int32},System-Nullable{System-Double},System-Nullable{System-Double},System-Nullable{System-Double},System-Nullable{System-Double},System-String-'></a>
### WithDefaultModelParameters(settings,MaxTokens,temperature,topP,frequencyPenalty,presencePenalty,user) `method`

##### Summary

Configures the default parameters for the OpenAI model execution.

##### Returns

The configured [OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settings | [Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') | The settings object to configure. |
| MaxTokens | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') | The maximum number of tokens (words or parts of words) in the response. Default is 60. |
| temperature | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Controls the randomness of the response. Lower values make the response more focused and deterministic. Default is 0.7. |
| topP | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Controls the diversity of the response. Higher values make the response more diverse. Default is 1.0. |
| frequencyPenalty | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Penalizes new tokens based on their existing frequency in the text so far. Default is 0.0. |
| presencePenalty | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Penalizes new tokens based on whether they appear in the text so far. Default is 0.0. |
| user | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The user identifier for the request. Default is null. |

<a name='M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithDeveloperPrompt-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-String-'></a>
### WithDeveloperPrompt(settings,developerPrompt) `method`

##### Summary

Configures the system prompt for the OpenAI model execution.

##### Returns

The configured [OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settings | [Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') | The settings object to configure. |
| developerPrompt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The system prompt to use. |

<a name='M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithJsonReturnSchema-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-Text-Json-JsonElement,System-String,System-String-'></a>
### WithJsonReturnSchema(settings,returnSchema,schemaName,schemaDescription) `method`

##### Summary

Configures the JSON return schema for the OpenAI model execution.

##### Returns

The configured [OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settings | [Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') | The settings object to configure. |
| returnSchema | [System.Text.Json.JsonElement](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.Json.JsonElement 'System.Text.Json.JsonElement') | The JSON schema to use for the response. |
| schemaName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the schema. |
| schemaDescription | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The description of the schema. |

<a name='M-CommunityToolkit-WinForms-AI-OpenAIPromptExecutionSettingsExtensions-WithSystemPrompt-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings,System-String-'></a>
### WithSystemPrompt(settings,systemPrompt) `method`

##### Summary

Configures the system prompt for the OpenAI model execution.

##### Returns

The configured [OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| settings | [Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings](#T-Microsoft-SemanticKernel-Connectors-OpenAI-OpenAIPromptExecutionSettings 'Microsoft.SemanticKernel.Connectors.OpenAI.OpenAIPromptExecutionSettings') | The settings object to configure. |
| systemPrompt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The system prompt to use. |

<a name='T-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator'></a>
## PromptFromTypeGenerator `type`

##### Namespace

CommunityToolkit.WinForms.AI.ConverterLogic

##### Summary

Provides methods to generate JSON schema and prompts from types decorated with AITemplateAttribute.

##### Remarks

The `PromptFromTypeGenerator` class includes methods to generate JSON schema definitions and
  structured prompts based on types decorated with the [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute').

It ensures that the types are properly annotated and provides detailed instructions and context
  for constructing complete conversations with AI.

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetJSonSchema``1'></a>
### GetJSonSchema\`\`1() `method`

##### Summary

Generates a JSON schema for the specified type.

##### Returns

A JSON schema string.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to generate the JSON schema for. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the type is not decorated with [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute'). |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetJsonType-System-Type-'></a>
### GetJsonType(type) `method`

##### Summary

Gets the JSON type for the specified .NET type.

##### Returns

A string representing the JSON type.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The .NET type to get the JSON type for. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Thrown if the type is not supported. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPreamblePrompt-CommunityToolkit-WinForms-AI-AITemplateAttribute-'></a>
### GetPreamblePrompt(promptInfo) `method`

##### Summary

Gets the preamble prompt based on the specified [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute').

##### Returns

A [StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') containing the preamble prompt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| promptInfo | [CommunityToolkit.WinForms.AI.AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') | The [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') to get the preamble prompt for. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPropertiesSchema-System-Type-'></a>
### GetPropertiesSchema(type) `method`

##### Summary

Gets the schema for the properties of the specified type.

##### Returns

A dictionary representing the properties schema.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type to get the properties schema for. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetPropertyDescription-System-Reflection-PropertyInfo-'></a>
### GetPropertyDescription(property) `method`

##### Summary

Gets the description for the specified property.

##### Returns

A string representing the property description.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| property | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | The property to get the description for. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetRequiredProperties-System-Type-'></a>
### GetRequiredProperties(type) `method`

##### Summary

Gets the required properties for the specified type.

##### Returns

A list of required property names.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type to get the required properties for. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePrompt-System-Type,System-Int32,System-Int32-'></a>
### GetTypePrompt(targetType,indentLevel,indentation) `method`

##### Summary

Gets the prompt for the specified type.

##### Returns

A string representing the prompt.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| targetType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type to get the prompt for. |
| indentLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The indentation level for nested properties. |
| indentation | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of spaces for each indentation level. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the type is not decorated with [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute'). |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePromptInfo``1'></a>
### GetTypePromptInfo\`\`1() `method`

##### Summary

Gets the [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') from the specified type.

##### Returns

The [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute') of the type.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to get the attribute from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown if the type is not decorated with [AITemplateAttribute](#T-CommunityToolkit-WinForms-AI-AITemplateAttribute 'CommunityToolkit.WinForms.AI.AITemplateAttribute'). |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-PromptFromTypeGenerator-GetTypePrompt``1'></a>
### GetTypePrompt\`\`1() `method`

##### Summary

Gets the prompt for the specified type.

##### Returns

A string representing the prompt.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to get the prompt for. |

<a name='T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0'></a>
## RemoveWhiteSpace_0 `type`

##### Namespace

System.Text.RegularExpressions.Generated

##### Summary

Custom [Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')-derived type for the RemoveWhiteSpace method.

<a name='M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes the instance.

##### Parameters

This constructor has no parameters.

<a name='F-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-Instance'></a>
### Instance `constants`

##### Summary

Cached, thread-safe singleton instance.

<a name='T-CommunityToolkit-WinForms-AI-ResponseTextFormat'></a>
## ResponseTextFormat `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Specifies the format of the response text.

<a name='F-CommunityToolkit-WinForms-AI-ResponseTextFormat-Html'></a>
### Html `constants`

##### Summary

HTML format.

<a name='F-CommunityToolkit-WinForms-AI-ResponseTextFormat-Markdown'></a>
### Markdown `constants`

##### Summary

Markdown format.

<a name='F-CommunityToolkit-WinForms-AI-ResponseTextFormat-MicrosoftRichText'></a>
### MicrosoftRichText `constants`

##### Summary

Microsoft Rich Text format.

<a name='F-CommunityToolkit-WinForms-AI-ResponseTextFormat-PlainText'></a>
### PlainText `constants`

##### Summary

Plain text format.

<a name='T-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData'></a>
## ReturnStreamMetaData `type`

##### Namespace

CommunityToolkit.WinForms.AI.ConverterLogic

##### Summary

Holds metadata parsed from the input.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Key | [T:CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData](#T-T-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData 'T:CommunityToolkit.WinForms.AI.ConverterLogic.ReturnStreamMetaData') | Gets the key of the metadata. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-#ctor-System-String,System-String,System-Int32,System-Boolean-'></a>
### #ctor(Key,Value,Position,WasDedicatedLine) `constructor`

##### Summary

Holds metadata parsed from the input.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Key | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Gets the key of the metadata. |
| Value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Gets the value of the metadata. |
| Position | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Gets the absolute position in the text where the metadata appeared. |
| WasDedicatedLine | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Gets a value indicating whether the metadata was on a dedicated line. |

<a name='P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Key'></a>
### Key `property`

##### Summary

Gets the key of the metadata.

<a name='P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Position'></a>
### Position `property`

##### Summary

Gets the absolute position in the text where the metadata appeared.

<a name='P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-Value'></a>
### Value `property`

##### Summary

Gets the value of the metadata.

<a name='P-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnStreamMetaData-WasDedicatedLine'></a>
### WasDedicatedLine `property`

##### Summary

Gets a value indicating whether the metadata was on a dedicated line.

<a name='T-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnTokenParser'></a>
## ReturnTokenParser `type`

##### Namespace

CommunityToolkit.WinForms.AI.ConverterLogic

##### Summary

Parses and processes tokens from a streaming chat message content.

##### Remarks

This class is responsible for parsing tokens from a streaming chat message content and 
  processing them to identify metadata, paragraphs, and code blocks.

It handles the detection of inline code using backticks and processes metadata tokens 
  enclosed in double curly braces.

This implementation deliberately avoids using spans for performance optimization, as the 
  stream comes in token-wise, making it necessary to wait for the data rather than the other 
  way around.

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-ReturnTokenParser-ProcessTokens-System-Collections-Generic-IAsyncEnumerable{Microsoft-SemanticKernel-StreamingChatMessageContent},System-Action{CommunityToolkit-WinForms-AI-AsyncReceivedInlineMetaDataEventArgs},System-Action{CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs},System-Action{CommunityToolkit-WinForms-AI-AsyncCodeBlockInfoProvidedEventArgs}-'></a>
### ProcessTokens(asyncEnumerable,onReceivedMetaDataAction,onReceivedNextParagraphAction,onCodeBlockInfoProvidedAction) `method`

##### Summary

Processes tokens from the given async enumerable and triggers actions based on the
identified content.

##### Returns

An async enumerable of processed token strings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| asyncEnumerable | [System.Collections.Generic.IAsyncEnumerable{Microsoft.SemanticKernel.StreamingChatMessageContent}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IAsyncEnumerable 'System.Collections.Generic.IAsyncEnumerable{Microsoft.SemanticKernel.StreamingChatMessageContent}') | The async enumerable of streaming chat message content. |
| onReceivedMetaDataAction | [System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedInlineMetaDataEventArgs}') | Action to trigger when metadata is received. |
| onReceivedNextParagraphAction | [System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs}') | Action to trigger when a new paragraph is received. |
| onCodeBlockInfoProvidedAction | [System.Action{CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{CommunityToolkit.WinForms.AI.AsyncCodeBlockInfoProvidedEventArgs}') | Action to trigger when code block information is provided. |

##### Remarks

This method reads tokens from the provided async enumerable,
  interpreting metadata, paragraphs, and code blocks. When these elements are identified, the
  corresponding actions are triggered.

The parser uses several groups of variables to manage its state and build content:

A local function 
  `GetWholeWordWhileProcessingParagraphAndCodeBlock` processes completed words to provide
  context that a single token cannot supply. For example, tokens such as ["\`\`", "\`csharp"] may
  split logical code boundaries. To address this, the function converts the synchronous token stream
  into an asynchronous character stream and iterates through individual characters to build complete
  words with the necessary context.

<a name='T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner'></a>
## Runner `type`

##### Namespace

System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0.RunnerFactory

##### Summary

Provides the runner that contains the custom logic implementing the specified regular expression.

<a name='M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-Scan-System-ReadOnlySpan{System-Char}-'></a>
### Scan(inputSpan) `method`

##### Summary

Scan the `inputSpan` starting from base.runtextstart for the next match.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inputSpan | [System.ReadOnlySpan{System.Char}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ReadOnlySpan 'System.ReadOnlySpan{System.Char}') | The text being scanned by the regular expression. |

<a name='M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-TryFindNextPossibleStartingPosition-System-ReadOnlySpan{System-Char}-'></a>
### TryFindNextPossibleStartingPosition(inputSpan) `method`

##### Summary

Search `inputSpan` starting from base.runtextpos for the next location a match could possibly start.

##### Returns

true if a possible match was found; false if no more matches are possible.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inputSpan | [System.ReadOnlySpan{System.Char}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ReadOnlySpan 'System.ReadOnlySpan{System.Char}') | The text being scanned by the regular expression. |

<a name='M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-Runner-TryMatchAtCurrentPosition-System-ReadOnlySpan{System-Char}-'></a>
### TryMatchAtCurrentPosition(inputSpan) `method`

##### Summary

Determine whether `inputSpan` at base.runtextpos is a match for the regular expression.

##### Returns

true if the regular expression matches at the current position; otherwise, false.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inputSpan | [System.ReadOnlySpan{System.Char}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ReadOnlySpan 'System.ReadOnlySpan{System.Char}') | The text being scanned by the regular expression. |

<a name='T-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory'></a>
## RunnerFactory `type`

##### Namespace

System.Text.RegularExpressions.Generated.RemoveWhiteSpace_0

##### Summary

Provides a factory for creating [RegexRunner](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.RegexRunner 'System.Text.RegularExpressions.RegexRunner') instances to be used by methods on [Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex').

<a name='M-System-Text-RegularExpressions-Generated-RemoveWhiteSpace_0-RunnerFactory-CreateInstance'></a>
### CreateInstance() `method`

##### Summary

Creates an instance of a [RegexRunner](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.RegexRunner 'System.Text.RegularExpressions.RegexRunner') used by methods on [Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex').

##### Parameters

This method has no parameters.

<a name='T-CommunityToolkit-WinForms-AI-SegmentPurpose'></a>
## SegmentPurpose `type`

##### Namespace

CommunityToolkit.WinForms.AI

##### Summary

Specifies the intended role of an AI template segment.

##### Example

```
 // Example usage of SegmentPurpose in a conditional check.
 AITemplateSegmentAttribute attribute = new AITemplateSegmentAttribute("Example prompt");
 if (attribute.Purpose == SegmentPurpose.Output)
 {
     // Execute logic specific to output segments.
 }
```

##### Remarks

The `SegmentPurpose` enum defines whether a segment in an AI template is meant for input,
  output, or both. This designation helps in clearly distinguishing the purpose of each segment
  when constructing the prompt and processing the language model's response.

<a name='F-CommunityToolkit-WinForms-AI-SegmentPurpose-Request'></a>
### Request `constants`

##### Summary

Indicates that the segment is intended for input.

<a name='F-CommunityToolkit-WinForms-AI-SegmentPurpose-RequestAndResponse'></a>
### RequestAndResponse `constants`

##### Summary

Indicates that the segment is used for both input and output.

<a name='F-CommunityToolkit-WinForms-AI-SegmentPurpose-Response'></a>
### Response `constants`

##### Summary

Indicates that the segment is intended for output.

<a name='T-CommunityToolkit-WinForms-AI-SemanticKernelComponent'></a>
## SemanticKernelComponent `type`

##### Namespace

CommunityToolkit.WinForms.AI

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ChatHistory'></a>
### ChatHistory `property`

##### Summary

Gets or sets the chat history for the Semantic Kernel scenario.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-DeveloperPromptSchemaAmendment'></a>
### DeveloperPromptSchemaAmendment `property`

##### Summary

Gets or sets an amendment to the system prompt in the case, a JSon schema had been provided, so 
 we need to instruct the model to return the result in JSon according to the schema information.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-EffectiveDeveloperPrompt'></a>
### EffectiveDeveloperPrompt `property`

##### Summary

The SystemPrompt, as it became constructed based on schema information, original SystemPrompt and SystemPrompt event.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-FrequencyPenalty'></a>
### FrequencyPenalty `property`

##### Summary

Gets or sets the frequency penalty to apply during chat completion.

##### Remarks

The frequency penalty is a value between 0 and 1 that penalizes the model for repeating the same response.
 A higher value will make the model less likely to repeat responses.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchema'></a>
### JsonSchema `property`

##### Summary

Gets the JSON schema as a JsonElement.

##### Remarks

This property returns the JSON schema as a JsonElement, which can be used for further processing 
  or validation.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaDescription'></a>
### JsonSchemaDescription `property`

##### Summary

Gets or sets the JSon schema name for the return format.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaName'></a>
### JsonSchemaName `property`

##### Summary

Gets or sets the JSon schema name for the return format.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-JsonSchemaString'></a>
### JsonSchemaString `property`

##### Summary

Gets or sets the JSON schema for the return value.

##### Remarks

This property defines the JSON schema for the return value. It can be set at design-time 
  if the schema is known and constant, or dynamically using the PromptFromTypeSupport methods 
  for flexible scenarios.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-Logger'></a>
### Logger `property`

##### Summary

Gets or sets the console control for logging.

##### Remarks

This property allows setting a console control to capture and display log output.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ModelId'></a>
### ModelId `property`

##### Summary

Gets or sets the model name to use for chat completion.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-PresencePenalty'></a>
### PresencePenalty `property`

##### Summary

Gets or sets the presence penalty to apply during chat completion.

##### Remarks

The presence penalty is a value between 0 and 1 that penalizes the model for generating responses that are too long.
 A higher value will make the model more likely to generate shorter responses.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ResourceStreamSource'></a>
### ResourceStreamSource `property`

##### Summary

Gets or sets the resource string source for the Assistant Instructions.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ResponseTextFormat'></a>
### ResponseTextFormat `property`

##### Summary

Gets or sets the format in which human-readable, non-structured text is requested to be returned from the model.

##### Remarks

This property defines the format for the text returned by the model, such as plain text, HTML, 
  Markdown, or Microsoft Rich Text.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-Temperature'></a>
### Temperature `property`

##### Summary

Gets or sets the temperature value for chat completion.

##### Remarks

The temperature value controls the randomness of the model's responses.
 A higher value will make the responses more random, while a lower value 
 will make them more deterministic.

<a name='P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-TopP'></a>
### TopP `property`

##### Summary

Gets or sets the top-p value for chat completion.

##### Remarks

The top-p value is a value between 0 and 1 that controls the diversity 
 of the model's responses.
 A higher value will make the responses more diverse, while a lower value 
 will make them more focused.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-AddChatItem-System-Boolean,System-String-'></a>
### AddChatItem(isResponse,message) `method`

##### Summary

Adds a chat item to the chat history.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| isResponse | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether the message is a response from the assistant. |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The message to add to the chat history. |

##### Remarks

This method adds a message to the chat history, distinguishing between user messages 
  and assistant responses.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnJsonSchemaChanged-System-EventArgs-'></a>
### OnJsonSchemaChanged(e) `method`

##### Summary

Raises the JsonSchemaChanged event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | The event data. |

##### Remarks

This method is called when the JsonSchema property changes, raising the JsonSchemaChanged event.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnJsonSchemaStringChanged-System-EventArgs-'></a>
### OnJsonSchemaStringChanged(e) `method`

##### Summary

Raises the JsonSchemaStringChanged event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') | The event data. |

##### Remarks

This method is called when the JsonSchemaString property changes, raising the JsonSchemaStringChanged event.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-OnReceivedNextParagraph-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs-'></a>
### OnReceivedNextParagraph(receivedNextParagraphEventArgs) `method`

##### Summary

Raises the [](#E-CommunityToolkit-WinForms-AI-SemanticKernelComponent-AsyncReceivedNextParagraph 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.AsyncReceivedNextParagraph') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| receivedNextParagraphEventArgs | [CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs](#T-CommunityToolkit-WinForms-AI-AsyncReceivedNextParagraphEventArgs 'CommunityToolkit.WinForms.AI.AsyncReceivedNextParagraphEventArgs') | The event data. |

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-QueryOpenAiModelInfoAsync-System-String-'></a>
### QueryOpenAiModelInfoAsync(modelName) `method`

##### Summary

Asynchronously queries the OpenAI API for detailed information about a specified model.

##### Returns

A task representing the asynchronous operation. The task result contains the model information if successful; 
otherwise, `null`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| modelName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the model to query. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when the API key for Open-AI access could not be retrieved. |

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-QueryOpenAiModelNamesAsync'></a>
### QueryOpenAiModelNamesAsync() `method`

##### Summary

Asynchronously queries the OpenAI API for available model names.

##### Returns

A task representing the asynchronous operation. The task result contains a collection of model names if the request is successful; 
otherwise, `null`.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when the API key for Open-AI access could not be retrieved. |

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestPromptResponseStreamAsync-System-String,System-Boolean-'></a>
### RequestPromptResponseStreamAsync(valueToProcess,keepChatHistory) `method`

##### Summary

Requests a prompt response from the OpenAI API as an async stream. Make sure, you set at least the [ApiKeyGetter](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ApiKeyGetter 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ApiKeyGetter') property,
 and the [DeveloperPrompt](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-DeveloperPrompt 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.DeveloperPrompt') property, which is the general description, what the Assistant is suppose to do.

##### Returns

Returns an async stream of strings, which are the responses from the LLM model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| valueToProcess | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value as string which the model should process. |
| keepChatHistory | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates whether to keep the chat history for the session. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when the value to process is null or empty. |

##### Remarks

This method sends a prompt to the OpenAI API and returns the responses as an asynchronous stream of strings.
  It ensures that the necessary properties, such as the API key and system prompt, are set before making the request.

The method handles the chat history based on the keepChatHistory parameter. If keepChatHistory is false, the chat history is cleared,
  and the system prompt is queued for the next request. If keepChatHistory is true, the chat history is maintained across requests.

The responses are processed as an asynchronous stream, allowing the caller to handle each response as it is received.
  The method also raises events for received metadata and paragraphs, enabling subscribers to handle these events accordingly.

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestStructuredResponseAsync``1-System-String-'></a>
### RequestStructuredResponseAsync\`\`1(userRequestPrompt) `method`

##### Summary

Sends a request with the specified prompt to obtain a structured response and deserializes it to the specified type.

##### Returns

A task representing the asynchronous operation. The task result contains the deserialized object of type `T`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userRequestPrompt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The user prompt to send as a request. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to which the JSON response will be deserialized. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') | Thrown when the type prompt is not available or when the text response is empty. |
| [System.FormatException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.FormatException 'System.FormatException') | Thrown if there is an error parsing or constructing the response object from the returned data. |

<a name='M-CommunityToolkit-WinForms-AI-SemanticKernelComponent-RequestTextPromptResponseAsync-System-String,System-Boolean-'></a>
### RequestTextPromptResponseAsync(valueToProcess) `method`

##### Summary

Requests a prompt response from the OpenAI API. Make sure, you set at least the [ApiKeyGetter](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-ApiKeyGetter 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.ApiKeyGetter') property,
 and the [DeveloperPrompt](#P-CommunityToolkit-WinForms-AI-SemanticKernelComponent-DeveloperPrompt 'CommunityToolkit.WinForms.AI.SemanticKernelComponent.DeveloperPrompt') property, which is the general description, what the Assistant is suppose to do.

##### Returns

The result from the LLM Model as plain text string or JSon string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| valueToProcess | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value as string which the model should process. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') |  |

<a name='T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions'></a>
## StringAndStringBuilderExtensions `type`

##### Namespace

CommunityToolkit.WinForms.AI.Extensions

##### Summary

String- and StringBuilder extensions, particularly tailored for formatting
 prompts in a visible structured way.

##### Remarks

This class provides extension methods for the StringBuilder class to format text in a structured way.
  It includes methods to append paragraphs, bullet points, and sub-paragraphs with specific formatting.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendBulletPoint-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-String,System-Int32,System-Int32-'></a>
### AppendBulletPoint(sb,value,maxLineLength,bulletLevel,bulletLevelChars,indentLevel,indentation) `method`

##### Summary

Appends a bullet point to the StringBuilder with specified formatting.

##### Returns

The updated StringBuilder instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The StringBuilder instance to append to. |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text value to append as a bullet point. |
| maxLineLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum length of a line in the bullet point. |
| bulletLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of the bullet point. |
| bulletLevelChars | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The characters to use for different bullet levels. |
| indentLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of indentation for the bullet point. |
| indentation | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of spaces for each indentation level. |

##### Remarks

This method formats the input text into a bullet point with specified maximum line length and indentation.
  It removes extra whitespace and newlines, and splits the text into words to fit within the line length.
  The bullet character is determined by the bullet level.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendBulletPointSubParagraph-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-Int32,System-Int32-'></a>
### AppendBulletPointSubParagraph(sb,value,maxLineLength,bulletLevel,indentLevel,indentation) `method`

##### Summary

Appends a sub-paragraph to a bullet point in the StringBuilder with specified formatting.

##### Returns

The updated StringBuilder instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The StringBuilder instance to append to. |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text value to append as a sub-paragraph. |
| maxLineLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum length of a line in the sub-paragraph. |
| bulletLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of the bullet point. |
| indentLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of indentation for the sub-paragraph. |
| indentation | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of spaces for each indentation level. |

##### Remarks

This method formats the input text into a sub-paragraph with specified maximum line length and indentation.
  It removes extra whitespace and newlines, and splits the text into words to fit within the line length.
  The indentation is combined from both bullet level and indent level.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-AppendParagraph-System-Text-StringBuilder,System-String,System-Int32,System-Int32,System-Int32-'></a>
### AppendParagraph(sb,value,maxLineLength,indentLevel,indentation) `method`

##### Summary

Appends a paragraph to the StringBuilder with specified formatting.

##### Returns

The updated StringBuilder instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sb | [System.Text.StringBuilder](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.StringBuilder 'System.Text.StringBuilder') | The StringBuilder instance to append to. |
| value | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text value to append as a paragraph. |
| maxLineLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum length of a line in the paragraph. |
| indentLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of indentation for the paragraph. |
| indentation | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of spaces for each indentation level. |

##### Remarks

This method formats the input text into a paragraph with specified maximum line length and indentation.
  It removes extra whitespace and newlines, and splits the text into words to fit within the line length.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-IndentLines-System-String,System-Int32,System-Int32-'></a>
### IndentLines(text,indentLevel,indent) `method`

##### Summary

Indents each line of the given text by a specified number of spaces.

##### Returns

The indented text.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to indent. |
| indentLevel | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The level of indentation. |
| indent | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The number of spaces for each indentation level. |

##### Remarks

This method indents each line of the given text by a specified number of spaces.
  It splits the text into lines, adds the indentation, and then joins the lines back together.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-Join-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-'></a>
### Join(strings,joinType) `method`

##### Summary

Joins an array of strings into a single string using the specified join type.

##### Returns

The joined string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The array of strings to join. |
| joinType | [CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType](#T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType') | The type of join operation to perform. |

##### Remarks

This method joins an array of strings into a single string using the specified join type.
  It supports joining with new lines, commas, or semicolons.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinOrDefault-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-'></a>
### JoinOrDefault(strings,joinType) `method`

##### Summary

Joins an array of strings into a single string, or returns null if the array is null or empty.

##### Returns

The joined string, or null if the array is null or empty.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The array of strings to join. |
| joinType | [CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType](#T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType') | The type of join operation to perform. |

##### Remarks

This method joins an array of strings into a single string using the specified join type.
  If the array is null or empty, it returns null.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinOrEmpty-System-String[],CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType-'></a>
### JoinOrEmpty(strings,joinType) `method`

##### Summary

Joins an array of strings into a single string, or returns an empty string if the array is null or empty.

##### Returns

The joined string, or an empty string if the array is null or empty.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| strings | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The array of strings to join. |
| joinType | [CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType](#T-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-JoinType 'CommunityToolkit.WinForms.AI.Extensions.StringAndStringBuilderExtensions.JoinType') | The type of join operation to perform. |

##### Remarks

This method joins an array of strings into a single string using the specified join type.
  If the array is null or empty, it returns an empty string.

<a name='M-CommunityToolkit-WinForms-AI-Extensions-StringAndStringBuilderExtensions-RemoveWhiteSpace'></a>
### RemoveWhiteSpace() `method`

##### Parameters

This method has no parameters.

##### Remarks

Pattern:

```
\\s+
```

Explanation:

```
○ Match a whitespace character atomically at least once.
```

<a name='T-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension'></a>
## StringLiteralConverterExtension `type`

##### Namespace

CommunityToolkit.WinForms.AI.ConverterLogic

##### Summary

Provides extension methods for converting C# string literals.

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension-FromCSharpLiteral-System-String,System-Boolean-'></a>
### FromCSharpLiteral(literal,ensureWindowsLineEndings) `method`

##### Summary

Converts a C# string literal to its corresponding unescaped string value.

##### Returns

The unescaped string value, or null if the literal represents a null.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| literal | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The C# string literal to convert. The literal "null" is treated as a null value. |
| ensureWindowsLineEndings | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If true, ensures that line endings are converted to Windows style. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentException 'System.ArgumentException') | Thrown when the input is not a valid C# string literal or contains an invalid escape sequence. |

<a name='M-CommunityToolkit-WinForms-AI-ConverterLogic-StringLiteralConverterExtension-ToCSharpLiteral-System-String-'></a>
### ToCSharpLiteral(input) `method`

##### Summary

Converts a string value to its corresponding C# string literal representation.

##### Returns

A C# string literal representing the input string.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string value to convert. A null value is represented as the literal "null". |

<a name='T-CommunityToolkit-WinForms-AI-ModelInfo-Usage'></a>
## Usage `type`

##### Namespace

CommunityToolkit.WinForms.AI.ModelInfo

##### Summary

Represents usage information for a model.

##### Remarks

This class holds details about the usage of a model, specifically the maximum number
  of tokens that can be used.

<a name='M-CommunityToolkit-WinForms-AI-ModelInfo-Usage-#ctor-System-Nullable{System-Int32}-'></a>
### #ctor() `constructor`

##### Summary

Represents usage information for a model.

##### Parameters

This constructor has no parameters.

##### Remarks

This class holds details about the usage of a model, specifically the maximum number
  of tokens that can be used.

<a name='P-CommunityToolkit-WinForms-AI-ModelInfo-Usage-MaxTokens'></a>
### MaxTokens `property`

##### Summary

Gets the maximum number of tokens that can be used.

<a name='T-System-Text-RegularExpressions-Generated-Utilities'></a>
## Utilities `type`

##### Namespace

System.Text.RegularExpressions.Generated

##### Summary

Helper methods used by generated [Regex](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')-derived implementations.

<a name='F-System-Text-RegularExpressions-Generated-Utilities-s_defaultTimeout'></a>
### s_defaultTimeout `constants`

##### Summary

Default timeout value set in [AppContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.AppContext 'System.AppContext'), or [InfiniteMatchTimeout](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Regex.InfiniteMatchTimeout 'System.Text.RegularExpressions.Regex.InfiniteMatchTimeout') if none was set.

<a name='F-System-Text-RegularExpressions-Generated-Utilities-s_hasTimeout'></a>
### s_hasTimeout `constants`

##### Summary

Whether [s_defaultTimeout](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Text.RegularExpressions.Generated.Utilities.s_defaultTimeout 'System.Text.RegularExpressions.Generated.Utilities.s_defaultTimeout') is non-infinite.

<a name='F-System-Text-RegularExpressions-Generated-Utilities-s_whitespace'></a>
### s_whitespace `constants`

##### Summary

Supports searching for characters in or not in "\t\n\v\f\r \u0085             \u2028\u2029  　".
