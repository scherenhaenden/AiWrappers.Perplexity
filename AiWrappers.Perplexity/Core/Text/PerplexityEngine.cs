using AiWrappers.Core.Requests;
using AiWrappers.Core.Text;
using AiWrappers.Perplexity.Core.Models;
using Newtonsoft.Json;

namespace AiWrappers.Perplexity.Core.Text;

public class PerplexityEngine: IAiRequesterByPrompts
{
    private readonly string _token;
    private readonly ModelType ?_model;
    private readonly string? _modelString;

    public PerplexityEngine(string token)
    {
        _token = token;
        _model = ModelType.Llama31SonarSmall128kOnline;
    }
    
    
    public PerplexityEngine(string token, ModelType model)
    {
        _token = token;
        _model = model;
    }
    
    public PerplexityEngine(string token, string model)
    {
        _token = token;
        _modelString = model;
    }
    
    public async Task<string?> RunRequest(string prompt)
    {
        
        PerplexityRequestModel perplexityRequestModel = new PerplexityRequestModel();
        var messages = new List<Message>();
        messages.Add(new Message { role = "system", content = "Be precise and concise." });
        messages.Add(new Message { role = "user", content = prompt });
        
        if(string.IsNullOrEmpty(_modelString))
        {
            perplexityRequestModel.model = _model;
        }
        else
        {
            perplexityRequestModel.ModelString = _modelString;
        }
        
        perplexityRequestModel.messages = messages;
        
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new StringValueEnumConverter());
        var serialized = JsonConvert.SerializeObject(perplexityRequestModel, settings);
        var token = _token;

        try
        {
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        

        return "";
    }

    public async Task<string?> RunRequestWithResult(string prompt)
    {
        PerplexityRequestModel perplexityRequestModel = new PerplexityRequestModel();
        var messages = new List<Message>();
        messages.Add(new Message { role = "system", content = "Be precise and concise." });
        messages.Add(new Message { role = "user", content = prompt });
        
        if(string.IsNullOrEmpty(_modelString))
        {
            perplexityRequestModel.model = _model;
        }
        else
        {
            perplexityRequestModel.ModelString = _modelString;
        }
        
        perplexityRequestModel.messages = messages;
        
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new StringValueEnumConverter());
        var serialized = JsonConvert.SerializeObject(perplexityRequestModel, settings);
        var token = _token;

        try
        {
            var response = await FluentRestRequester.Create()
                .BaseAddress("https://api.perplexity.ai/")
                .Endpoint("chat/completions")
                .WithMethod(HttpMethod.Post)
                .WithHeader("accept", "application/json")
                //.WithHeader("Content-Type", "application/json")
                .WithContentType("application/json")
                .WithHeader("authorization", token)
                .WithPayloadModel(serialized)
                .SendAsyncWithResult<PerplexityResponseModel>();
            
            
            if(!response.IsSuccess)
            {
                return response.ErrorMessage;
            }
            

            if (response is not null)
            {
                var results = response.Data.choices.Select(x => x.message.content).ToList();
                return string.Join(Environment.NewLine, results);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        

        return "";
    }
}