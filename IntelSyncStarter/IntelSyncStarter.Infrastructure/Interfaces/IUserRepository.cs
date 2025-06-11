using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(CrmUser user);
        Task<IEnumerable<CrmUser>> GetAllAsync();
        Task<CrmUser?> GetUserAsync(int userId);
    }
}
