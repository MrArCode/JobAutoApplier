using JobAutoApplier.Strategies;
using JobAutoApplier.Utils;
using Microsoft.Playwright;
using Serilog;


namespace JobAutoApplier.Pracuj;

public class PracujLogin : ILoginStrategy
{
    private static readonly ILogger Logger = Log.ForContext<PracujLogin>();

    public async Task<IBrowserContext> Login()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using IBrowser browser = await PlaywrightUtils.CreateBrowser(playwright);
        IBrowserContext context = await PlaywrightUtils.CreateContext(browser);

        IPage page = await context.NewPageAsync();

        await page.GotoAsync(PracujConstants.LoginPageUrl);

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

        await page.FillAsync(PracujConstants.LoginInputSelector, PracujConstants.Login);
        await page.ClickAsync(PracujConstants.LoginNextButtonSelector);

        await page.FillAsync(PracujConstants.PasswordInputSelector, PracujConstants.Password);
        await page.ClickAsync(PracujConstants.LoginButtonSelector);
        
        return context;
    }
}