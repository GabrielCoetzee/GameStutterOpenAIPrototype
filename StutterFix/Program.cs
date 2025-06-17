using Integration.AI.Services;
using Integration.AI.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder(args);

host.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>();

host.Services.Configure<OpenAISettings>(host.Configuration.GetSection("OpenAI"));

host.Services.AddTransient<OpenAIService>();
host.Services.AddTransient<ChatSession>();

var serviceProvider = host.Services.BuildServiceProvider();

var openAIService = serviceProvider.GetRequiredService<OpenAIService>();
var chatSession = serviceProvider.GetRequiredService<ChatSession>();

var openAISettings = host.Configuration
    .GetSection("OpenAI")
    .Get<OpenAISettings>();

while (true)
{
    Console.Write("Game: ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Input can't be empty. Please try again.");
        continue;
    }

    chatSession.AddMessage("user", $"```{input}```");

    try
    {
        var response = await openAIService.SendPromptAsync(chatSession.GetMessages(), openAISettings?.ApiKey);

        Console.WriteLine($"OpenAI: {response}");

        chatSession.AddMessage("assistant", response);

        Console.WriteLine(string.Empty);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        break;
    }
}



