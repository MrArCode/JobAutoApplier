using JobAutoApplier.Controllers;
using JobAutoApplier.Pracuj;
using Microsoft.Playwright;
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

        PracujLinkCollector pracujLinkCollector = new PracujLinkCollector();
        var links = await pracujLinkCollector.CollectLinks();

        PracujLogin login = new PracujLogin();
        string state = await login.Login();

        PracujApplyExecutor executor = new PracujApplyExecutor();
        await executor.Apply(links, state);

    }
}