using JobAutoApplier.Strategies;

namespace JobAutoApplier.Contexts;

public class ApplicationContext
{
    public void Apply(IApplyStrategy applyStrategy, List<string> links, string state)
    {
        applyStrategy.Apply(links,state);
    }
}