using Newtonsoft.Json;

namespace AiWrappers.Perplexity.Core.Models;

public class PerplexityRequestModel
{
    [JsonIgnore] // This will hide the enum from JSON serialization
    public ModelType? model { get; set; }

    // This string stores any model, even if it's not part of the enum
    private string _modelString;

    [JsonProperty("model")] // This is the exposed string property
    public string ModelString
    {
        get => _modelString ?? model?.ToString(); // Use the raw string or convert enum to string
        set
        {
            _modelString = value; // Always store the string

            // Try to parse the string to the enum, but don't throw an error if it fails
            if (Enum.TryParse(value, out ModelType parsedModel))
            {
                model = parsedModel; // Convert string back to enum if valid
            }
            else
            {
                model = null; // Invalidate the enum if it's not a known model
            }
        }
    }

    public List<Message> messages { get; set; }
}