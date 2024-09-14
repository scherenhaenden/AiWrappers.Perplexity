namespace AiWrappers.Perplexity.Core.Models;

public enum ModelType
{
    // Perplexity Sonar Models
    [StringValue("llama-3.1-sonar-small-128k-online")]
    Llama31SonarSmall128kOnline,

    [StringValue("llama-3.1-sonar-large-128k-online")]
    Llama31SonarLarge128kOnline,

    [StringValue("llama-3.1-sonar-huge-128k-online")]
    Llama31SonarHuge128kOnline,

    // Perplexity Chat Models
    [StringValue("llama-3.1-sonar-small-128k-chat")]
    Llama31SonarSmall128kChat,

    [StringValue("llama-3.1-sonar-large-128k-chat")]
    Llama31SonarLarge128kChat,

    // Open-Source Models
    [StringValue("llama-3.1-8b-instruct")]
    Llama318bInstruct,

    [StringValue("llama-3.1-70b-instruct")]
    Llama3170bInstruct
}