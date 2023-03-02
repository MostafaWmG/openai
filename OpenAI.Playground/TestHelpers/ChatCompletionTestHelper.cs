using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.SharedModels;

namespace OpenAI.Playground.TestHelpers;

internal static class ChatCompletionTestHelper
{
    public static async Task RunSimpleChatCompletionTest(IOpenAIService sdk, CancellationToken cancellationToken = default)
    {
        ConsoleExtensions.WriteLine("Completion Testing is starting:", ConsoleColor.Cyan);

        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Test:", ConsoleColor.DarkCyan);
            var completionResult = await sdk.ChatCompletions.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>() {
                            new ChatMessage
                    {
                        Role = Roles.User.ToString().ToLowerInvariant(),
                        Content = "what is the capital of france?",
                    }
                },
                MaxTokens = 150,
            }, "gpt-3.5-turbo", cancellationToken);

            if (completionResult.Successful)
            {
                Console.WriteLine(completionResult.Choices.FirstOrDefault());
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }

            Console.WriteLine(completionResult.Choices.FirstOrDefault());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async Task RunSimpleChatCompletionStreamTest(IOpenAIService sdk)
    {
        ConsoleExtensions.WriteLine("Chat Completion Stream Testing is starting:", ConsoleColor.Cyan);
        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Stream Test:", ConsoleColor.DarkCyan);
            var completionResult = sdk.ChatCompletions.CreateCompletionAsStream(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>() {
                            new ChatMessage
                    {
                        Role = Roles.User.ToString().ToLowerInvariant(),
                        Content = "what is the capital of france?",
                    }
                },
                MaxTokens = 500
            }, "gpt-3.5-turbo");

            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    Console.Write(completion.Choices.FirstOrDefault());
                }
                else
                {
                    if (completion.Error == null)
                    {
                        throw new Exception("Unknown Error");
                    }

                    Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Complete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}