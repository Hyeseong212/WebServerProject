using WebServer.Model.DbEntity;

namespace WebServer.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<bool> IsAlreadyExistAsync(string id);
        Task<bool> CreateAsync(string id, string pw);
        Task<AccountEntity> GetAccountAsync(string id);
    }
}