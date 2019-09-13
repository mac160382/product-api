namespace BookStore.Configuration.Constants
{
    public class Routes
    {
        public const string Product = "/product";

        public const string Ping = "/ping";

        public const string ProductList = "/v{v:apiVersion}/product-list";

        public const string Id = "{id:guid}";
    }
}
