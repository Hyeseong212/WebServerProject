using WebServer.Model.DbEntity;

namespace WebServer.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<bool> IsAlreadyExistAsync(string id);
        Task<bool> CreateAccountAsync(string id, string pw);
        Task<AccountEntity> GetAccountAsync(string id);
        Task<bool> ModifyNickName(long accountId, string nickname);
        Task<long> GetGoldAsync(long accountId);
        Task<bool> UpdateGoldAsync(long accountId, long newGoldAmount);
        Task<bool> CheckGoldAsync(long accountId, long itemGold);

    }
}