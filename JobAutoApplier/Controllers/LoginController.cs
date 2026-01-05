using JobAutoApplier.Strategies;

namespace JobAutoApplier.Controllers;

public class LoginController
{
    public Task<string> Login(ILoginStrategy loginStrategy)
    {
        return loginStrategy.Login();
    }
}