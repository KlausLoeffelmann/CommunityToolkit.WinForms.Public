using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text.Json;

namespace CommunityToolkit.WinForms.AI;

public static class OpenAIPromptExecutionSettingsExtensions
{
    /// <summary>
    ///  Configures the default parameters for the OpenAI model execution.
    /// </summary>
    /// <param name="settings">The settings object to configure.</param>
    /// <param name="MaxTokens">The maximum number of tokens (words or parts of words) in the response. Default is 60.</param>
    /// <param name="temperature">Controls the randomness of the response. Lower values make the response more focused and deterministic. Default is 0.7.</param>
    /// <param name="topP">Controls the diversity of the response. Higher values make the response more diverse. Default is 1.0.</param>
    /// <param name="frequencyPenalty">Penalizes new tokens based on their existing frequency in the text so far. Default is 0.0.</param>
    /// <param name="presencePenalty">Penalizes new tokens based on whether they appear in the text so far. Default is 0.0.</param>
    /// <param name="user">The user identifier for the request. Default is null.</param>
    /// <returns>The configured <see cref="OpenAIPromptExecutionSettings"/> object.</returns>
    public static OpenAIPromptExecutionSettings WithDefaultModelParameters(
        this OpenAIPromptExecutionSettings settings,
        int? MaxTokens = default,
        double? temperature = default,
        double? topP = default,
        double? frequencyPenalty = default,
        double? presencePenalty = default,
        string? user = default)
    {
        settings.MaxTokens = MaxTokens ?? 1000;
        settings.Temperature = temperature ?? 0.7;
        settings.TopP = topP ?? 1.0;
        settings.FrequencyPenalty = frequencyPenalty ?? 0.0;
        settings.PresencePenalty = presencePenalty ?? 0.0;
        settings.User = user;

        return settings;
    }

    /// <summary>
    /// Configures the system prompt for the OpenAI model execution.
    /// </summary>
    /// <param name="settings">The settings object to configure.</param>
    /// <param name="systemPrompt">The system prompt to use.</param>
    /// <returns>The configured <see cref="OpenAIPromptExecutionSettings"/> object.</returns>
    public static OpenAIPromptExecutionSettings WithSystemPrompt(
        this OpenAIPromptExecutionSettings settings,
        string systemPrompt)
    {
        settings.ChatSystemPrompt = systemPrompt;
        return settings;
    }

    /// <summary>
    /// Configures the system prompt for the OpenAI model execution.
    /// </summary>
    /// <param name="settings">The settings object to configure.</param>
    /// <param name="developerPrompt">The system prompt to use.</param>
    /// <returns>The configured <see cref="OpenAIPromptExecutionSettings"/> object.</returns>
    public static OpenAIPromptExecutionSettings WithDeveloperPrompt(
        this OpenAIPromptExecutionSettings settings,
        string developerPrompt)
    {
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        settings.ChatDeveloperPrompt = developerPrompt;
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        return settings;
    }

#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    /// <summary>
    /// Configures the JSON return schema for the OpenAI model execution.
    /// </summary>
    /// <param name="settings">The settings object to configure.</param>
    /// <param name="returnSchema">The JSON schema to use for the response.</param>
    /// <param name="schemaName">The name of the schema.</param>
    /// <param name="schemaDescription">The description of the schema.</param>
    /// <returns>The configured <see cref="OpenAIPromptExecutionSettings"/> object.</returns>
    public static OpenAIPromptExecutionSettings WithJsonReturnSchema(
        this OpenAIPromptExecutionSettings settings,
        JsonElement returnSchema,
        string? schemaName,
        string? schemaDescription)
    {
        ChatResponseFormatJson responseFormat = ChatResponseFormat.ForJsonSchema(
            schema: returnSchema,
            schemaName: schemaName,
            schemaDescription: schemaDescription);

        settings.ResponseFormat = responseFormat;
        return settings;
    }
}
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
