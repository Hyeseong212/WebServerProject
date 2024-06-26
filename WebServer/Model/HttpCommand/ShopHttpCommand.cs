namespace WebServer.Model.HttpCommand
{
    public class ShopBuyRequest : BaseRequest
    {
        //어카운트 ID
        public long AccountId { get; set; }
        //상품 ID
        public int ShopId { get; set; }
    }

    public class ShopBuyResponse : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
