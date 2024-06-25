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
            // 중복된 유저가 있는지 확인
            if (await IsAlreadyExistAsync(id))
            {
                return false;
            }

            // 계정 생성 및 AccountId 가져오기
            var accountId = await CreateAccountInfo(id, pw);

            if (accountId != -1)
            {
                // 추가 정보 생성
                await CreateCurrencyInfo(accountId);
                await CreateCharacterInfo(accountId);
                return true;
            }

            return false;
        }

        public async Task<AccountEntity> GetAccountAsync(string id)
        {
            return await _accountDbContext.Account.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == id);
        }

        private async Task<long> CreateAccountInfo(string id, string pw)
        {
            var accountEntity = new AccountEntity
            {
                UserId = id,
                UserPassword = pw
            };
            await _accountDbContext.Account.AddAsync(accountEntity);
            await _accountDbContext.SaveChangesAsync();

            return accountEntity.AccountId; // 생성된 AccountId 반환
        }

        private async Task CreateCurrencyInfo(long accountId)
        {
            var accountCurrencyEntity = new AccountCurrencyEntity
            {
                AccountId = accountId,
                Gold = 0 // 기본 값 설정
            };
            await _accountDbContext.AccountCurrency.AddAsync(accountCurrencyEntity);
            await _accountDbContext.SaveChangesAsync();
        }

        private async Task CreateCharacterInfo(long accountId)
        {
            var accountCharacterEntity = new AccountCharacterEntity
            {
                AccountId = accountId,
                AccountCharacter = 1 // 기본 값 설정
            };
            await _accountDbContext.AccountCharacter.AddAsync(accountCharacterEntity);
            await _accountDbContext.SaveChangesAsync();
        }
    }
}
