using Microsoft.AspNetCore.Mvc;
using WebServer.Model.HttpCommand;
using WebServer.Service;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService _accountService;

        public AccountController(ILogger<AccountController> logger, AccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<AccountCreateResponse> Create([FromBody] AccountCreateRequest request)
        {
            var (isSuccess, message) = await _accountService.CreateAsync(request.Id, request.Password);
            return new AccountCreateResponse
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }

        [HttpPost]
        public async Task<AccountLoginResponse> Login([FromBody] AccountLoginRequest request)
        {
            var (isSuccess, message) = await _accountService.LoginAsync(request.Id, request.Password);
            return new AccountLoginResponse
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }
    }
}
