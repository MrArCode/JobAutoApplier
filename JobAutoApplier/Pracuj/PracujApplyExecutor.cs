using JobAutoApplier.Strategies;
using Microsoft.Playwright;

namespace JobAutoApplier.Pracuj;

public class PracujApplyExecutor : IApplyStrategy
{
    public async Task Apply(List<string> links, IBrowserContext context)
    {
        IPage page = await context.NewPageAsync();

        foreach (var link in links)
        {
            await page.GotoAsync(link);
            
        }
    }
}