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

        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ShopBuyResponse Buy([FromBody] ShopBuyRequest request)
        {
            // 아이템을 살 수 있는 유저인가?


            return new ShopBuyResponse();
        }
    }
}
