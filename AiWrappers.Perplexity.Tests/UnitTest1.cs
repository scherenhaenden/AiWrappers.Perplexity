using AiWrappers.Perplexity.Core.Text;

namespace AiWrappers.Perplexity.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        
        var tokenPerplexity = "<TOKEN>";
        var aiRequesterByPrompts = new PerplexityEngine(tokenPerplexity, "llama-3.1-sonar-large-128k-online");
        var result = await aiRequesterByPrompts.RunRequest("What is the capital of France?");
        
        Assert.NotNull(result);
    }
}