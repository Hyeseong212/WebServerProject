using Microsoft.AspNetCore.Mvc;
using WebServer.Model.HttpCommand;
using WebServer.Service;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        private readonly ShopService _shopService;

        public ShopController(ILogger<ShopController> logger, ShopService shopService)
        {
            _logger = logger;
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<ShopBuyResponse> Buy([FromBody] ShopBuyRequest request)
        {
            var (isSuccess, message) = await _shopService.Buy(request.AccountId, request.ShopId);
            return new ShopBuyResponse
            {
                IsSuccess = isSuccess,
                Message = message
            };
        }
    }
}
