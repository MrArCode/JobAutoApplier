using JobAutoApplier.Credentials;

namespace JobAutoApplier.Pracuj;

public static class PracujConstants
{
    // URLs
    public const string StartPageUrl = "https://it.pracuj.pl/praca/praca%20hybrydowa;wm,hybrid?itth=75";
    public const string LoginPageUrl = "https://login.pracuj.pl/";

    // Common elements
    public const string CookiesButtonName = "Akceptuj wszystkie";
    public const int CookiePopupTimeout = 5000;

    // Login page selectors
    public const string LoginInputSelector = "#email";
    public const string PasswordInputSelector = "#password";
    public const string LoginNextButtonSelector = "text=Dalej";
    public const string LoginButtonSelector = "text=Zaloguj";

    // Job listing page selectors
    public const string CollapsedOfferSelector = "[data-test-location='multiple']";
    public const string OfferTileSelector = "[data-test='default-offer']";
    public const string FastApplySelector = "[data-test='text-one-click-apply']";
    public const string OfferLinkSelector = "[data-test='link-offer']";
    public const string NextButtonName = "Następna";

    // JavaScript expressions
    public const string ScrollDownExpression = "window.scrollTo(0, document.body.scrollHeight)";

    // Credentials
    public static string Login { get; private set; } = string.Empty;
    public static string Password { get; private set; } = string.Empty;

    public static void LoadCredentials(PortalCredentials credentials)
    {
        Login = credentials.Login;
        Password = credentials.Password;
    }
}