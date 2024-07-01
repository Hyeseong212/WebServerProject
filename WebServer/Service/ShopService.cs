using WebServer.Repository;
using WebServer.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Principal;

namespace WebServer.Service
{
    public class ShopService
    {
        private readonly ILogger<ShopService> _logger;
        private readonly IAccountRepository _accountRepository; // 추가

        public ShopService(ILogger<ShopService> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository; // 초기화
        }
        public async Task<(bool, string)> Buy(long accountId, int shopId)
        {
            var item = DataManager.Instance.itemHandler.GetItemById(shopId);
            if (item == null)
            {
                return (false, "아이템을 찾을 수 없습니다");
            }

            bool hasEnoughGold = await _accountRepository.CheckGoldAsync(accountId, item.Price);
            if (!hasEnoughGold)
            {
                return (false, "골드가 부족합니다");
            }

            // 아이템 구매 로직 (예: 골드 차감, 인벤토리에 아이템 추가 등)
            var userGold = await _accountRepository.GetGoldAsync(accountId);
            var isSuccess = await _accountRepository.UpdateGoldAsync(accountId, userGold - item.Price);



            if(isSuccess)
            {
                return (true, "구매 성공");
            }
            else
            {
                return (false, "구매 실패");

            }
        }
    }
}