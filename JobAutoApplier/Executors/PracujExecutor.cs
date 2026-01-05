using JobAutoApplier.Controllers;
using JobAutoApplier.Pracuj;

namespace JobAutoApplier.Executors;

public class PracujExecutor
{
    public async Task ApplyForJobOffers()
    {
        var linkCollectorController = new LinkCollectorController();
        var links = await linkCollectorController.CollectLinks(new PracujLinkCollector());

        var loginController = new LoginController();
        string context = await loginController.Login(new PracujLogin());

        var applyController = new ApplyController();
        applyController.Apply(new PracujApplyExecutor(), links, context);
    }
}