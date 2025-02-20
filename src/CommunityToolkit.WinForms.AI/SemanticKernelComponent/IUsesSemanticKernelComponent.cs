namespace CommunityToolkit.WinForms.AI.SemanticKernel;

/// <summary>
///  Interface for components that use a Semantic Kernel.
/// </summary>
/// <remarks>
///  <para>
///   This interface provides properties and methods to interact with a Semantic Kernel component.
///   It includes functionality to get and set various parameters related to the Semantic Kernel,
///   such as model ID, API key, and other configuration settings.
///  </para>
///  <para>
///   The interface also includes methods to initialize the Semantic Kernel with default values
///   and to provide property processing delegates.
///  </para>
/// </remarks>
public interface IUsesSemanticKernelComponent
{
    /// <summary>
    ///  Gets or sets the function to retrieve the Semantic Kernel component.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds a delegate function that returns the Semantic Kernel component.
    ///   It is used to access the Semantic Kernel instance within the implementing class.
    ///  </para>
    /// </remarks>
    protected Func<SemanticKernelComponent>? SemanticKernelGetter { get; set; }

    /// <summary>
    ///  Gets the Semantic Kernel component.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property retrieves the Semantic Kernel component using the SemanticKernelGetter delegate.
    ///   If the delegate is not set, it throws an InvalidOperationException.
    ///  </para>
    /// </remarks>
    /// <exception cref="InvalidOperationException">Thrown when SemanticKernelGetter is not set.</exception>
    public SemanticKernelComponent SemanticKernel => SemanticKernelGetter?.Invoke()
        ?? throw new InvalidOperationException("SemanticKernelGetter is not set.");

    /// <summary>
    ///  Gets or sets the function to retrieve the OpenAI model ID.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property holds a delegate function that returns the OpenAI model ID.
    ///   It is used to get or set the model ID for the Semantic Kernel.
    ///  </para>
    /// </remarks>
    public Func<string>? OpenAiModelId
    {
        get => SemanticKernel.ApiKeyGetter;
        set => SemanticKernel.ApiKeyGetter = value;
    }

    /// <summary>
    ///  Gets or sets the model name.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This property gets or sets the model name for the Semantic Kernel.
    ///   It is used to specify the model to be used for processing.
    ///  </para>
    /// </remarks>
    public string ModelName
    {
        get => SemanticKernel.ModelId;
        set => SemanticKernel.ModelId = value;
    }

    /// <summary>
    ///  Initializes the Semantic Kernel with default values.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This method sets default values for various parameters of the Semantic Kernel,
    ///   such as MaxTokens, Temperature, TopP, FrequencyPenalty, PresencePenalty, JsonSchemaString,
    ///   and DeveloperPrompt.
    ///  </para>
    /// </remarks>
    private void Initialize()
    {
        SemanticKernel.MaxTokens = 100;
        SemanticKernel.Temperature = 0.7;
        SemanticKernel.TopP = 1.0;
        SemanticKernel.FrequencyPenalty = 0.0;
        SemanticKernel.PresencePenalty = 0.0;
        SemanticKernel.JsonSchemaString = string.Empty;
        SemanticKernel.DeveloperPrompt = string.Empty;
    }

    /// <summary>
    ///  Provides property processing delegates for the instance.
    /// </summary>
    /// <remarks>
    ///  <para>
    ///   This static method sets the SemanticKernelGetter delegate for the given instance.
    ///   It is used to provide the necessary delegate functions for property processing.
    ///  </para>
    /// </remarks>
    /// <param name="instance">The instance of IUsesSemanticKernelComponent.</param>
    /// <param name="semanticKernelGetter">The delegate function to get the Semantic Kernel component.</param>
    static protected void ProvidePropertyProcessingDelegates(
        IUsesSemanticKernelComponent instance,
        Func<SemanticKernelComponent> semanticKernelGetter)
    {
        instance.SemanticKernelGetter = semanticKernelGetter;
    }
}
