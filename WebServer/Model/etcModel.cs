namespace WebServer.Model
{
    public class etcModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public long Price { get; set; }
    }
    public class MessageModel
    {
        public string TYPE { get; set; }
        public int MessageCode { get; set; }
        public string Message { get; set; }
    }
}
