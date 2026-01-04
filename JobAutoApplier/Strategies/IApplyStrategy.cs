using Microsoft.Playwright;

namespace JobAutoApplier.Strategies;

public interface IApplyStrategy
{
    public Task Apply(List<string> links, string state);
}