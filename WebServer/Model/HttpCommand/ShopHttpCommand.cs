namespace WebServer.Model.HttpCommand
{
    public class ShopBuyRequest : BaseRequest
    {
        public int ShopId { get; set; }
    }

    public class ShopBuyResponse : BaseResponse
    {
    }
}
