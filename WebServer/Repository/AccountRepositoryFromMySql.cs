using Microsoft.EntityFrameworkCore;
using WebServer.Model.DbEntity;
using WebServer.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebServer.Repository
{
    public class AccountRepositoryFromMySql : IAccountRepository
    {
        private readonly ILogger<AccountRepositoryFromMySql> _logger;
        private readonly AccountDbContext _accountDbContext;

        public AccountRepositoryFromMySql(ILogger<AccountRepositoryFromMySql> logger, AccountDbContext accountDbContext)
        {
            _logger = logger;
            _accountDbContext = accountDbContext;
        }

        public async Task<bool> IsAlreadyExistAsync(string id)
        {
            return await _accountDbContext.Account.AnyAsync(x => x.UserId == id);
        }

        public async Task<bool> CreateAsync(string id, string pw)
        {
            // 중복된 유저가 있는지?
            if (await IsAlreadyExistAsync(id))
            {
                return false;
            }

            var accountEntity = new AccountEntity
            {
                UserId = id,
                UserPassword = pw
            };
            await _accountDbContext.Account.AddAsync(accountEntity);
            await _accountDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<AccountEntity> GetAccountAsync(string id)
        {
            return await _accountDbContext.Account.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == id);
        }
    }
}