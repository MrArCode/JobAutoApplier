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


        // LinkCollector linkCollector = new LinkCollector();
        // List<string> links =  await linkCollector.CollectLinks(new PracujLinkCollector());
        // foreach (string link in links)
        // {
        //     Console.WriteLine(link);
        // }

        PracujLogin pracujLogin = new PracujLogin();
        string state = await pracujLogin.Login();


        PracujApplyExecutor executor = new PracujApplyExecutor();
        List<string> test =
        [
            "https://www.pracuj.pl/praca/data-engineering-manager-katowice-wroclawska-54,oferta,1004523102?s=b547587c&searchId=MTc2NzQ2MzIzMTQzMy43MTMx"
        ];
        await executor.Apply(test, state);
        

    }
}