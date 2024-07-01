namespace WebServer.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public long Price { get; set; }
    }
    public class MessageModel
    {
        public string Type { get; set; }
        public int MessageCode { get; set; }
        public string Message { get; set; }
    }
}
