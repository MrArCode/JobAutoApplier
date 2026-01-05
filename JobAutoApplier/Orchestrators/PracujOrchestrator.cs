using JobAutoApplier.Contexts;
using JobAutoApplier.Pracuj;

namespace JobAutoApplier.Orchestrators;

public class PracujOrchestrator
{
    public async Task ApplyForJobOffers()
    {
        var linkCollectorController = new LinkCollectionContext();
        var links = await linkCollectorController.CollectLinks(new PracujLinkCollector());

        var loginController = new LoginContext();
        string context = await loginController.Login(new PracujLogin());

        var applyController = new ApplicationContext();
        applyController.Apply(new PracujApplyExecutor(), links, context);
    }
}