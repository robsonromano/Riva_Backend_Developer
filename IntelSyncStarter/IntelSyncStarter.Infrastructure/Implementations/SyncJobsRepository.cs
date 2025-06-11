using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Domain.Enums;
using IntelSyncStarter.Infrastructure.Interfaces;

namespace IntelSyncStarter.Infrastructure.Implementations
{
    /// <summary>
    /// Manage the access on SyncJob storage (e.g. database)
    /// </summary>
    public class SyncJobsRepository : ISyncJobsRepository
    {
        private static readonly List<SyncJob> _syncJobs = [];

        public async Task AddAsync(SyncJob syncJob)
        {
            await Task.Delay(1); //Simulates database access
            _syncJobs.Add(syncJob);
        }

        public async Task<IEnumerable<SyncJob>> GetAllPendingAsync(int pageSize)
        {
            await Task.Delay(5); //Simulates database access
            return _syncJobs.Where(item => item.SyncStatus == SyncStatus.Pending)
                            .Take(pageSize);
        }

        public async Task UpdateStatusAsync(SyncJob syncJob)
        {
            await Task.Delay(5); //Simulates database update
        }
    }
}
