using AiWrappers.Core.Requests;
using AiWrappers.Core.Text;
using AiWrappers.Perplexity.Core.Models;
using Newtonsoft.Json;

namespace AiWrappers.Perplexity.Core.Text;

public class PerplexityEngine: IAiRequesterByPrompts
{
    private readonly string _token;

    public PerplexityEngine(string token)
    {
        _token = token;
    }
    
    
    public async Task<string?> RunRequest(string prompt)
    {
        
        PerplexityRequestModel perplexityRequestModel = new PerplexityRequestModel();
        var messages = new List<Message>();
        messages.Add(new Message { role = "system", content = "Be precise and concise." });
        messages.Add(new Message { role = "user", content = prompt });
        perplexityRequestModel.model = ModelType.Llama3SonarLarge32kOnline;
        perplexityRequestModel.messages = messages;
        
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new StringValueEnumConverter());
        var serialized = JsonConvert.SerializeObject(perplexityRequestModel, settings);
        var token = _token;

        var response = await FluentRestRequester.Create()
            .BaseAddress("https://api.perplexity.ai/")
            .Endpoint("chat/completions")
            .WithMethod(HttpMethod.Post)
            .WithHeader("accept", "application/json")
            //.WithHeader("Content-Type", "application/json")
            .WithContentType("application/json")
            .WithHeader("authorization", token)
            .WithPayloadModel(serialized)
            .SendAsync<PerplexityResponseModel>();

        if (response is not null)
        {
            var results = response.choices.Select(x => x.message.content).ToList();
            return string.Join(Environment.NewLine, results);
        }

        return "";
    }
}