namespace JobAutoApplier.Pracuj;

public static class PracujConstants
{
    public const string StartPageUrl = "https://it.pracuj.pl/praca/praca%20hybrydowa;wm,hybrid?itth=75";
    public const string CookiesButtonName = "Akceptuj wszystkie";
    public const string NextButtonName = "Następna";
    public const string CollapsedOfferSelector = "[data-test-location='multiple']";
    public const string OfferTileSelector = "[data-test='default-offer']";
    public const string FastApplySelector = "[data-test='text-one-click-apply']";
    public const string OfferLinkSelector = "[data-test='link-offer']";
    public const string ScrollDownExpression = "window.scrollTo(0, document.body.scrollHeight)";
    public const int CookiePopupTimeout = 5000;
    
    // Login
    public const string LoginPageUrl = "https://login.pracuj.pl/";
    
    public const string LoginInputSelector = "#login";
    public const string PasswordInputSelector = "#password";
    
    public const string Login = "";
    public const string Password = "";
    
    public const string LoginNextButtonSelector = "text=Dalej";
    public const string LoginButtonSelector = "text=Zaloguj";
}