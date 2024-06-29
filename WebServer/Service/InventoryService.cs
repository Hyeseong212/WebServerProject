using WebServer.Repository.Interface;

namespace WebServer.Service
{
    public class InventoryService
    {
        private readonly ILogger<InventoryService> _logger;
        private readonly IShopRepository _shopRepository;
        private readonly IAccountRepository _accountRepository; // 추가
        private readonly MessageHandler _messageHandler;
        private readonly ItemHandler _itemHandler;

        public InventoryService(ILogger<InventoryService> logger, IShopRepository shopRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            _shopRepository = shopRepository;
            _accountRepository = accountRepository; // 초기화
            _messageHandler = new MessageHandler("Resources/MessagesInfo.csv");
            _itemHandler = new ItemHandler("Resources/ShopItem.csv");
        }
    }
}
