# Getting Started with the SemanticKernelComponent

The `SemanticKernelComponent` is a powerful tool designed to facilitate interaction with (Azure) OpenAI's API, 
enabling you to request and process responses from language models. 
This document provides an overview of its features and events, along with placeholders for future API references.

## Typical Workflows

### Simplified Access to the Return Stream
The `SemanticKernelComponent` provides a simplified access to the return stream. 
This means that when you send a prompt to the OpenAI API, the component handles the 
streaming of responses, allowing you to process them asynchronously. 
This is particularly useful for handling large responses or streaming data in real-time.

### Automatic MetaTag Information Extraction
Prompts can ask for MetaTags information, which can then be filtered out by 
the `SemanticKernelComponent` automatically while a return stream comes back. 
The component provides respective events, such as `AsyncReceivedInlineMetaData`, 
when a new MetaTag arrives. This allows you to handle metadata separately from 
the main content.

### Automatic Code-Block Extraction
Properly prompted, the `SemanticKernelComponent` can automatically extract code-blocks 
and provide information about them. This is achieved through specific prompting, and the 
component raises events like `AsyncCodeBlockInfoProvided` to deliver the 
extracted code-block information.

### Querying OpenAI Models
The `SemanticKernelComponent` also allows querying available OpenAI models and getting
specific information about them. This includes methods to query model names and 
detailed information about a specific model, enabling you to choose the most appropriate 
model for your needs.

## Setting up API-Keys

Before you can use the `SemanticKernelComponent`, you need to acquire an API key,
and for that, you need a Developer Account with OpenAI. Currently, only the OpenAI-API 
is supported, but in the future the plan is to add support for Azure OpenAI.

### Developer Account with OpenAI

To use the `SemanticKernelComponent`, you need a Developer Account with OpenAI. 
To set up a Developer Account, follow these steps:

1. 1. Visit the [OpenAI website](https://www.openai.com/).
2. Click on "Sign Up" and create an account.
3. Once your account is created, navigate to the API section.
4. Generate a new API key for your project.

**Importance of Not Hardcoding the API Key**: It is crucial to never hardcode 
the API key in your source code. Hardcoding keys can lead to security 
vulnerabilities and unauthorized access. Instead, store the API key in 
an environment variable. This approach ensures that the 
key is not exposed in your source code and can be easily managed.

This method is the preferred method for developing purposes, but isn't still the best 
practice for production scenarios

**Note:** For production scenarios, it is best practice, even for WinForms, WPF or WinUI Apps,
to have a dedicated Backend API that acts as a proxy to the OpenAI API.

**Tip:** OpenAI provides keys per project, allowing developers to get reports 
of API usage by categories for evaluating cost-benefit effects.

### Code Snippet to Query the API Key

Here are both code snippets for C# and Visual Basic, to query the API key from an environment variable:

```csharp
public class ClassInWichToUseTheSemanticKernelComponent
{
    private static readonly string Key_OpenAI_Standard = "AI:OpenAI:ApiKey";
    .
    .
    .
    public ClassInWichToUseTheSemanticKernelComponent()
    {
        _skComponent = new()
        {
            ApiKeyGetter = () => Environment.GetEnvironmentVariable(Key_OpenAI_Standard)
                ?? throw new NullReferenceException($"The environment variable '{Key_OpenAI_Standard}' is not set.")
        };
    }
    .
    .
    .
}
```

```Visual Basic
Public Class ClassInWichToUseTheSemanticKernelComponent
    Private Const Key_OpenAI_Standard As String = "AI:OpenAi:ApiKey"
    .
    .
    Public Sub New()
        _skComponent = New SemanticKernelComponent With {
            .ApiKeyGetter = Function() Environment.GetEnvironmentVariable(Key_OpenAI_Standard) _
                ?? Throw New NullReferenceException($"The environment variable '{Key_OpenAI_Standard}' is not set.")
    End Sub
    .
    .
End Class
```

### Setting Up Environment Variable in Windows 11

To set up the environment variable in Windows 11, follow these steps:

1. Open the Start Menu and search for "Environment Variables".
2. Select "Edit the system environment variables".
3. In the System Properties window, click on the "Environment Variables" button.
4. In the Environment Variables window, click "New" under the "User variables" section.
5. Enter the variable name (e.g., "OPENAI_API_KEY") and the API key as the variable value.
6. Click "OK" to save the new environment variable.
7. Log off and log back on to ensure the environment variable is recognized by the system.

## Prompt engineering

Prompt engineering is a critical aspect of working with language models. It involves crafting prompts 
that guide the model to produce the desired output. Understanding the different roles in prompt 
engineering is essential for creating effective prompts.

### Roles in Prompt Engineering

* **System (Developer):** The System role, also known as the Developer role, is responsible for setting 
up the initial context and instructions for the language model. This includes defining the system prompt, 
which provides the model with guidelines on how to behave and what to consider when generating responses. 
A well-crafted system prompt sets the stage for successful interactions by establishing
clear expectations and boundaries.

* **Assistant**: The Assistant role represents the language model itself. The Assistant follows the 
instructions provided in the system prompt and responds to user prompts accordingly. 
The quality and relevance of the Assistant's responses depend heavily on the clarity and 
specificity of the system prompt.

* **User** The User role involves interacting with the language model by providing prompts and queries. 
The User's prompts are influenced by the context and instructions set by the System role. A good system
prompt helps the User get accurate and relevant responses from the Assistant.

### Importance of Crafting a Good System Prompt

Crafting a good system prompt is crucial for the success of user prompts. A well-defined system 
prompt ensures that the language model understands the context, guidelines, and expectations, 
leading to more accurate and relevant responses. Here are some tips for creating effective system prompts:

1. **Be Clear and Specific**: Provide clear and specific instructions to the model. 
   Avoid ambiguity and ensure that the model understands the desired behavior and output.

2. **Set Boundaries**: Define the scope and limitations of the model's responses. 
   This helps prevent irrelevant or off-topic answers.

3. **Provide Context**: Include relevant context and background information to help the model 
   understand the situation and generate appropriate responses.

4. **Use Examples**: Provide examples of desired responses to guide the model. 
   This helps the model understand the format and style of the expected output.

## SemanticKernelComponent Features

### Requesting Text Prompt Responses
The `SemanticKernelComponent` allows you to request text prompt responses from the OpenAI API. 
You need to set the `ApiKeyGetter` and `SystemPrompt` properties to use this feature.

### Requesting Prompt Response Streams
You can also request prompt responses as an asynchronous stream, which is useful for handling large responses or streaming data.

### Querying OpenAI Model Names
The component provides a method to query available model names from the OpenAI API.

### Querying OpenAI Model Information
You can query detailed information about a specific model using its name.

### Requesting Structured Responses
The component allows you to send a request with a specified prompt and obtain a structured response, deserialized to a specified type.

## Events

### 1. AsyncRequestAssistanceInstructions (Concept, due to change)
This event is triggered to request assistant instructions asynchronously, 
allowing subscribers to provide custom instructions for the assistant.

### 2. AsyncRequestExecutionSettings (Concept, due to change)
This event is triggered to request execution settings asynchronously, 
allowing subscribers to provide custom execution settings for the assistant.

### 3. AsyncReceivedNextParagraph
This event is triggered when the next paragraph is received asynchronously, 
allowing subscribers to handle the received paragraph data.

### 4. AsyncCodeBlockInfoProvided
This event is triggered when code block information is provided asynchronously.
A code block is a specific section of text that is formatted as code by markdown.
This event allows subscribers to handle the provided code block information.
Meta-Information can be extracted from the code block, such as:

- Language/code-block type
- the actual Code (or markdown or text)
- Title Suggestion
- Filename-Suggestion

**Prerequisite:** The prompt must be properly phrased so that the respective Parameters are set.
The Meta-Tag requests for that need to be in the Format {{MetaTagKey:Value}}.
The MetaTagKeys for the above meta data are defined by the ``SemanticKernelComponent`` via its
static properties `CodeBlockFilenameMetaTag`, `CodeBlockTypeMetaTag`, and `CodeBlockDescriptionMetaTag`. 

### 5. AsyncReceivedInlineMetaData
This event is triggered when inline metadata is received asynchronously, 
allowing subscribers to handle the received metadata. Note, that the above listed MetaTags are not
parsed out. The will be used to enrich the CodeBlockInfo passed in the event args, but you will 
still receive them as separate events once they get recognized.

### 6. JsonSchemaStringChanged
This event is triggered when the JSON schema string changes.

### 7. JsonSchemaChanged
This event is triggered when the JSON schema changes.

## Placeholders for Future API References

- **Properties**
  - `ApiKeyGetter`
  - `DeveloperPrompt`
  - `ModelId`
  - `MaxTokens`
  - `FrequencyPenalty`
  - `PresencePenalty`
  - `Temperature`
  - `TopP`
  - `JsonSchemaString`
  - `JsonSchemaName`
  - `JsonSchemaDescription`
  - `ResponseTextFormat`
  - `Logger`
  - `ChatHistory`

- **Methods**
  - `RequestTextPromptResponseAsync`
  - `RequestPromptResponseStreamAsync`
  - `QueryOpenAiModelNamesAsync`
  - `QueryOpenAiModelInfoAsync`
  - `RequestStructuredResponseAsync`
  - `AddChatItem`
