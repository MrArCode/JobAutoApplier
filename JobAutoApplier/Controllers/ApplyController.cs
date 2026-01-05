using JobAutoApplier.Strategies;

namespace JobAutoApplier.Controllers;

public class ApplyController
{
    public void Apply(IApplyStrategy applyStrategy, List<string> links, string state)
    {
        applyStrategy.Apply(links,state);
    }
}