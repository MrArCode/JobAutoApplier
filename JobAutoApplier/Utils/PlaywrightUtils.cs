using Microsoft.Playwright;

namespace JobAutoApplier.Utils;

public static class PlaywrightUtils
{
    public static async Task<IBrowser> CreateBrowser(IPlaywright playwright)
    {
        var options = new BrowserTypeLaunchOptions
        {
            Headless = false,
            Args = ["--disable-blink-features=AutomationControlled"]
        };
        
        IBrowser browser = await playwright.Chromium.LaunchAsync(options);

        return browser;
    }

    public static async Task<IBrowserContext> CreateContext(IBrowser browser)
    {
        var options = new BrowserNewContextOptions
        {
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
        };

        IBrowserContext context = await browser.NewContextAsync(options);
        return context;
    }
}