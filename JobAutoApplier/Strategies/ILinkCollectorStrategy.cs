namespace JobAutoApplier.Strategies;

public interface ILinkCollectorStrategy
{
    Task<List<string>> CollectLinks();
}