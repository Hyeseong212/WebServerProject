using Microsoft.EntityFrameworkCore;
using WebServer.Repository.Interface;

namespace WebServer.Repository.Shop
{
    public class InventoryRepositoryFromMySql : IInventoryRepository
    {
        private readonly ILogger<InventoryRepositoryFromMySql> _logger;
        private readonly InventoryDbContext _inventoryDbContext;

        public InventoryRepositoryFromMySql(ILogger<InventoryRepositoryFromMySql> logger, InventoryDbContext inventoryDbContext)
        {
            _logger = logger;
            _inventoryDbContext = inventoryDbContext;
        }
    }
}
 