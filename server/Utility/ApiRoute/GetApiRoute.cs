namespace server.Utility.ApiRoute
{
    public class GetApiRoute : IGetApiRoute
    {
        public const string appRoute = "api";
        public const string version = "v1";
        public const string DefaultRoute = $"{appRoute}/{version}/[controller]/[action]";

    }
}
