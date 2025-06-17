using Flurl.Http;
using Integration.AI.Exceptions;
using Integration.AI.Models;
using Integration.AI.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Integration.AI.Services
{
    public class OpenAIService
    {
        readonly OpenAISettings _settings;

        public OpenAIService(IOptions<OpenAISettings> settings)
        {
            _settings = settings.Value;
        }

        const string RequestUrl = "https://api.openai.com/v1/chat/completions";

        public async Task<string> SendPromptAsync(IEnumerable<object> messages, string apiKey)
        {
            var requestBody = new
            {
                temperature = _settings.Temperature,
                model = _settings.Model,
                messages = messages.ToList()
            };

            var response = await RequestUrl
                .WithOAuthBearerToken(apiKey)
                .AllowAnyHttpStatus()
                .PostJsonAsync(requestBody);

            if (response.StatusCode == StatusCodes.Status429TooManyRequests)
                throw new BillingException($"Please ensure your credit balance is not empty: https://platform.openai.com/settings/organization/billing/overview");

            if (response.StatusCode != StatusCodes.Status200OK)
                throw new InvalidOperationException("Something went wrong, please try again later");

            var body = await response.GetJsonAsync<Response>();

            return body.Choices[0].Message.Content.Trim();
        }
    }
}
