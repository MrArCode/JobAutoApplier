using JobAutoApplier.Strategies;

namespace JobAutoApplier.Contexts;

public class LinkCollectionContext
{
    public Task<List<string>> CollectLinks(ILinkCollectorStrategy linkCollectorStrategy)
    {
        return linkCollectorStrategy.CollectLinks();
    }
}