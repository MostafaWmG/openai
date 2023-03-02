using System.Text.Json.Serialization;

namespace OpenAI.GPT3.ObjectModels.SharedModels;

public record ChatMessage
{
    [JsonPropertyName("role")] public Roles? Role { get; set; }

    [JsonPropertyName("content")] public string? Content { get; set; }
}