namespace eShop.ClientApp;

public class GlobalSetting
{
    public const string AzureTag = "Azure";
    public const string MockTag = "Mock";
    public const string DefaultEndpoint = "http://localhost:18848"; // i.e.: "http://YOUR_IP" or "http://YOUR_DNS_NAME"

    private string _baseIdentityEndpoint;
    private string _baseGatewayShoppingEndpoint;
    private string _baseGatewayMarketingEndpoint;

    public GlobalSetting()
    {
        AuthToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjE4ODQ4IiwiYXVkIjoiZVNob3BPbkF6dXJlIiwiZXhwIjoxNzE2MjM5MDIyLCJuYmYiOjE0OTMyMTI5MzYsImlhdCI6MTQ5MzIxMjkzNiwianRpIjoidW5pcXVlLWp3dC1pZCIsInN1YiI6InVzZXItaWQiLCJlbWFpbCI6Imdlbi52aW5uaWtvdkBnbWFpbC5jb20iLCJyb2xlIjoiQWRtaW4ifQ.VJyiC49CY0_rt0krftHOtirkAA1oa8IHFrIrVYFgmcw";

        BaseIdentityEndpoint = DefaultEndpoint;
        BaseGatewayShoppingEndpoint = DefaultEndpoint;
        BaseGatewayMarketingEndpoint = DefaultEndpoint;
    }

    public static GlobalSetting Instance { get; } = new GlobalSetting();

    public string BaseIdentityEndpoint
    {
        get => _baseIdentityEndpoint;
        set
        {
            _baseIdentityEndpoint = value;
            UpdateEndpoint(_baseIdentityEndpoint);
        }
    }

    public string BaseGatewayShoppingEndpoint
    {
        get => _baseGatewayShoppingEndpoint;
        set
        {
            _baseGatewayShoppingEndpoint = value;
            UpdateGatewayShoppingEndpoint(_baseGatewayShoppingEndpoint);
        }
    }

    public string BaseGatewayMarketingEndpoint
    {
        get => _baseGatewayMarketingEndpoint;
        set
        {
            _baseGatewayMarketingEndpoint = value;
            UpdateGatewayMarketingEndpoint(_baseGatewayMarketingEndpoint);
        }
    }

    public string ClientId { get; } = "xamarin";

    public string ClientSecret { get; } = "secret";

    public string AuthToken { get; set; }

    public string RegisterWebsite { get; set; }

    public string AuthorizeEndpoint { get; set; }

    public string UserInfoEndpoint { get; set; }

    public string TokenEndpoint { get; set; }

    public string LogoutEndpoint { get; set; }

    public string Callback { get; set; }

    public string LogoutCallback { get; set; }

    public string GatewayShoppingEndpoint { get; set; }

    public string GatewayMarketingEndpoint { get; set; }

    private void UpdateEndpoint(string endpoint)
    {
        RegisterWebsite = $"{endpoint}/Account/Register";
        LogoutCallback = $"{endpoint}/Account/Redirecting";

        var connectBaseEndpoint = $"{endpoint}/connect";
        AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
        UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
        TokenEndpoint = $"{connectBaseEndpoint}/token";
        LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

        var baseUri = GlobalSetting.ExtractBaseUri(endpoint);
        Callback = $"{baseUri}/xamarincallback";
    }

    private void UpdateGatewayShoppingEndpoint(string endpoint)
    {
        GatewayShoppingEndpoint = endpoint;
    }

    private void UpdateGatewayMarketingEndpoint(string endpoint)
    {
        GatewayMarketingEndpoint = endpoint;
    }

    private static string ExtractBaseUri(string endpoint)
    {
        try
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(UriPartial.Authority);

            return baseUri;
        }
        catch (Exception ex)
        {
            _ = ex;
            return DefaultEndpoint;
        }
    }
}
