using System.Text.Json.Serialization;

namespace OpenAI.GPT3.ObjectModels.SharedModels;

public record ChatMessage
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}