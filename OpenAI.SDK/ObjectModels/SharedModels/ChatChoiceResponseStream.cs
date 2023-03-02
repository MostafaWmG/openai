using System.Text.Json.Serialization;

namespace OpenAI.GPT3.ObjectModels.SharedModels;

public record ChatChoiceResponseStream
{
    [JsonPropertyName("delta")] public ChatMessage Delta { get; set; }

    [JsonPropertyName("index")] public int? Index { get; set; }

    [JsonPropertyName("finish_reason")] public string FinishReason { get; set; }
}