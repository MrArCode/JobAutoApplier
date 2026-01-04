using JobAutoApplier.Strategies;
using JobAutoApplier.Utils;
using Microsoft.Playwright;

namespace JobAutoApplier.Pracuj;

public class PracujApplyExecutor : IApplyStrategy
{
    public async Task Apply(List<string> links, string state)
    {
        IPlaywright playwright = await Playwright.CreateAsync();
        IBrowser browser = await PlaywrightUtils.CreateBrowser(playwright);
        var contextOption = new BrowserNewContextOptions
        {
            StorageState = state
        };
        IBrowserContext context = await browser.NewContextAsync(contextOption);
        IPage page = await context.NewPageAsync();

        foreach (string link in links)
        {
            await page.GotoAsync(link);
            await page.ClickAsync("#offer-sidebar [data-test='anchor-apply']");
            
            Thread.Sleep(5_000);
        }
    }
}