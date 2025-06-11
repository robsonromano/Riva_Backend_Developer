using IntelSyncStarter.Domain.Entities;

namespace IntelSyncStarter.Infrastructure.Interfaces
{
    public interface ISyncJobsRepository
    {
        Task AddAsync(SyncJob job);
        Task<IEnumerable<SyncJob>> GetAllPendingAsync(int pageSize);
        Task UpdateStatusAsync(SyncJob syncJob);
    }
}
