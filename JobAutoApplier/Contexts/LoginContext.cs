using JobAutoApplier.Strategies;

namespace JobAutoApplier.Contexts;

public class LoginContext
{
    public Task<string> Login(ILoginStrategy loginStrategy)
    {
        return loginStrategy.Login();
    }
}