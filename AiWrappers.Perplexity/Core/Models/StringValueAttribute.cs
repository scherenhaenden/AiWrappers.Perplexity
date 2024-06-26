namespace AiWrappers.Perplexity.Core.Models;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
sealed class StringValueAttribute : Attribute
{
    public string Value { get; private set; }

    public StringValueAttribute(string value)
    {
        Value = value;
    }
}