using JobAutoApplier.Strategies;
using JobAutoApplier.Utils;
using Microsoft.Playwright;
using Serilog;

namespace JobAutoApplier.Pracuj;

public class PracujLinkCollector : ILinkCollectorStrategy
{
    private static readonly ILogger Logger = Log.ForContext<PracujLinkCollector>();

    public async Task<List<string>> CollectLinks()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using IBrowser browser = await PlaywrightUtils.CreateBrowser(playwright);
        await using IBrowserContext context = await PlaywrightUtils.CreateContext(browser);
        IPage page = await context.NewPageAsync();

        Logger.Information("Starting link collection from Pracuj.pl website");

        await GoToStartingPage(page);
        await ManageCookies(page);
        var links = await CollectLinks(page);

        return links;
    }

    private async Task GoToStartingPage(IPage page)
    {
        Logger.Information("Navigating to starting page {Url}", PracujConstants.StartPageUrl);
        await page.GotoAsync(PracujConstants.StartPageUrl);
        await page.WaitForLoadStateAsync(LoadState.Load);
    }

    private async Task ManageCookies(IPage page)
    {
        try
        {
            var options = new PageGetByRoleOptions
            {
                Name = PracujConstants.CookiesButtonName
            };

            await page
                .GetByRole(AriaRole.Button, options)
                .ClickAsync(new LocatorClickOptions { Timeout = PracujConstants.CookiePopupTimeout });

            Logger.Information("Cookies accepted");
        }
        catch (TimeoutException)
        {
            Logger.Debug("No cookies popup found");
        }
    }

    private async Task<List<string>> CollectLinks(IPage page)
    {
        var links = new HashSet<string>();
        var pageNumber = 1;

        while (true)
        {
            Logger.Information("Processing page [{PageNumber}]", pageNumber);

            await page.WaitForLoadStateAsync(LoadState.Load);
            await page.EvaluateAsync(PracujConstants.ScrollDownExpression);

            var collapsedPanels = await page.Locator(PracujConstants.CollapsedOfferSelector).AllAsync();

            foreach (ILocator panel in collapsedPanels)
            {
                await panel.ClickAsync();
            }

            var offerTiles = await page.Locator(PracujConstants.OfferTileSelector).AllAsync();

            foreach (ILocator tile in offerTiles)
            {
                try
                {
                    ILocator fastApply = tile.Locator(PracujConstants.FastApplySelector);
                    var hasFastApply = await fastApply.CountAsync() > 0;

                    if (hasFastApply)
                    {
                        ILocator linkElement = tile.Locator(PracujConstants.OfferLinkSelector).First;
                        var href = await linkElement.GetAttributeAsync("href");

                        if (href is not null)
                        {
                            links.Add(href);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex, "Failed to process tile");
                }
            }

            Logger.Information("Page: [{PageNumber}] Total fast-apply offers found: [{Total}]",
                pageNumber, links.Count);

            ILocator nextButton = page.GetByText(PracujConstants.NextButtonName);
            var isVisible = await nextButton.IsVisibleAsync();

            if (!isVisible)
            {
                Logger.Information("No more pages available. Finished at page {PageNumber}", pageNumber);
                break;
            }

            Logger.Debug("Going to next page button");
            await page.GetByText(PracujConstants.NextButtonName).ClickAsync();
            pageNumber++;
        }

        Logger.Information("Link collection completed. Total fast-apply links: [{Total}]", links.Count);

        return links.ToList();
    }
}