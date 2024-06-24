namespace WebServer.Model.HttpCommand
{
    public class AccountCreateRequest : BaseRequest
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class AccountCreateResponse : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class AccountLoginRequest : BaseRequest
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class AccountLoginResponse : BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
