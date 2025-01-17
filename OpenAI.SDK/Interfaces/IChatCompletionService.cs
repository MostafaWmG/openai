using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI.GPT3.Interfaces;

/// <summary>
///     Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of
///     alternative tokens at each position.
/// </summary>
public interface IChatCompletionService
{
    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters
    /// </summary>
    /// <param name="modelId">The ID of the model to use for this request</param>
    /// <param name="createCompletionModel"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<ChatCompletionCreateResponse> CreateCompletion(ChatCompletionCreateRequest createCompletionModel, string? modelId = null, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters and returns a stream of CompletionCreateRequests
    /// </summary>
    /// <param name="modelId">The ID of the model to use for this request</param>
    /// <param name="createCompletionModel"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    IAsyncEnumerable<ChatCompletionCreateResponseStream> CreateCompletionAsStream(ChatCompletionCreateRequest createCompletionModel, string? modelId = null, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters
    /// </summary>
    /// <param name="createCompletionModel"></param>
    /// <param name="modelId">The ID of the model to use for this request</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<ChatCompletionCreateResponse> Create(ChatCompletionCreateRequest createCompletionModel, Models.Model modelId, CancellationToken cancellationToken = default)
    {
        return CreateCompletion(createCompletionModel, modelId.EnumToString(), cancellationToken);
    }
}