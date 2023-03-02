using System.Text.Json.Serialization;
using OpenAI.GPT3.ObjectModels.SharedModels;

namespace OpenAI.GPT3.ObjectModels.ResponseModels;

public record ChatCompletionCreateResponseStream : BaseResponse, IOpenAiModels.IId, IOpenAiModels.ICreatedAt
{
    [JsonPropertyName("model")] public string Model { get; set; }

    [JsonPropertyName("choices")] public List<ChatChoiceResponseStream> Choices { get; set; }

    [JsonPropertyName("usage")] public UsageResponse Usage { get; set; }

    [JsonPropertyName("created")] public int CreatedAt { get; set; }

    [JsonPropertyName("id")] public string Id { get; set; }
}