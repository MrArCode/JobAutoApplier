using System.Text.Json;
using JobAutoApplier.Orchestrators;
using JobAutoApplier.Pracuj;
using Serilog;

namespace JobAutoApplier;

class Program
{
    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        if (!File.Exists("credentials.json"))
        {
            ShowError("❌ Missing credentials.json file!");
            return;
        }

        string json = await File.ReadAllTextAsync("credentials.json");
        var credentials = JsonSerializer.Deserialize<Credentials.Credentials>(json);

        if (credentials is null)
        {
            ShowError("❌ Invalid credentials.json format!");
            return;
        }

        PracujConstants.LoadCredentials(credentials.Pracuj);
        var pracujOrchestrator = new PracujOrchestrator();
        await pracujOrchestrator.ApplyForJobOffers();
    }

    private static void ShowError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ResetColor();
    }
}