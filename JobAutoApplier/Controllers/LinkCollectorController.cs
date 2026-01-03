using JobAutoApplier.Strategies;

namespace JobAutoApplier.Controllers;

public class LinkCollectorController
{
    public Task<List<string>> CollectLinks(ILinkCollectorStrategy linkCollectorStrategy)
    {
        return linkCollectorStrategy.CollectLinks();
    }
}