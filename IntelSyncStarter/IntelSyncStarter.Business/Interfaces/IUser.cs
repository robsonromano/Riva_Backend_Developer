using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Business.Interfaces
{
    public interface IUser
    {
        Task AddAsync(CrmUser user);
        Task<CrmUser?> GetUserAsync(int userId);
    }
}
