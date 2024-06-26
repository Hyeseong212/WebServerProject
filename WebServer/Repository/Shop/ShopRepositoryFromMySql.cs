using Microsoft.EntityFrameworkCore;
using WebServer.Repository.Interface;

namespace WebServer.Repository.Shop
{
    public class ShopRepositoryFromMySql : IShopRepository
    {
        private readonly ILogger<ShopRepositoryFromMySql> _logger;
        private readonly ShopDbContext _shopDbContext;

        public ShopRepositoryFromMySql(ILogger<ShopRepositoryFromMySql> logger, ShopDbContext shopDbContext)
        {
            _logger = logger;
            _shopDbContext = shopDbContext;
        }
        public async Task<bool> CheckGoldAsync(long accountId, long itemGold)
        {
            var userGold = await _shopDbContext.AccountCurrency
                .Where(ac => ac.AccountId == accountId)
                .Select(ac => ac.Gold)
                .FirstOrDefaultAsync();

            return userGold >= itemGold;
        }
    }
}
