using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Business.Interfaces
{
    public interface ISyncJobs
    {
        Task AddAsync(SyncJob user);
        Task<IEnumerable<SyncJobTask>> GetAllPendingAsync(int pageSize);
        Task UpdateStatusAsync(SyncJob syncJob);
    }
}
