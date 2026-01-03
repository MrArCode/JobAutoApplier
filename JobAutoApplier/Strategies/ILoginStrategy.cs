using Microsoft.Playwright;

namespace JobAutoApplier.Strategies;

public interface ILoginStrategy
{
    public Task<IBrowserContext> Login();
}