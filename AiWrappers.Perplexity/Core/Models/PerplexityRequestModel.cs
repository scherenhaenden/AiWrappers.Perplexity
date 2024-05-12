using Newtonsoft.Json;

namespace AiWrappers.Perplexity.Core.Models;

public class PerplexityRequestModel
{
    [JsonProperty("model")]
    public ModelType model { get; set; }
    public List<Message> messages { get; set; }
}