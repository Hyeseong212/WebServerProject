namespace WebServer.Repository.Interface
{
    public interface IShopRepository
    {
        Task<bool> CheckGoldAsync(long accountId, long itemGold);
    }
}
