namespace JobAutoApplier.Strategies;

public interface ILoginStrategy
{
    public Task<string> Login();
}