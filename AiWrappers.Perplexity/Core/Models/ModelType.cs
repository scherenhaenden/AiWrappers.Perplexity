namespace AiWrappers.Perplexity.Core.Models;

public enum ModelType
{
    [StringValue("llama-3-sonar-small-32k-chat")]
    Llama3SonarSmall32kChat,

    [StringValue("llama-3-sonar-small-32k-online")]
    Llama3SonarSmall32kOnline,

    [StringValue("llama-3-sonar-large-32k-chat")]
    Llama3SonarLarge32kChat,

    [StringValue("llama-3-sonar-large-32k-online")]
    Llama3SonarLarge32kOnline,

    [StringValue("llama-3-8b-instruct")]
    Llama38bInstruct,

    [StringValue("llama-3-70b-instruct")]
    Llama370bInstruct
}