using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using IntelSyncStarter.Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace IntelSyncStarter.Business.Implementations
{
    /// <summary>
    /// Service class responsible for handling synchronization job operations.
    /// Implements the <see cref="ISyncJobs"/> interface.
    /// </summary>
    public class SyncJobs : ISyncJobs
    {
        private readonly ISyncJobsRepository _syncJobsRepository;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor for injecting dependencies.
        /// </summary>
        /// <param name="syncJobsRepository">Repository to handle sync jobs.</param>
        /// <param name="userRepository">Repository to handle users.</param>
        public SyncJobs(ISyncJobsRepository syncJobsRepository, 
                               IUserRepository userRepository)
        {
            _syncJobsRepository = syncJobsRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Adds a new sync job to the system.
        /// </summary>
        /// <param name="syncJob">Add sync job on storage.</param>
        /// <exception cref="ValidationException">Thrown if the sync job is null.</exception>
        public async Task AddAsync(SyncJob syncJob)
        {
            if (syncJob == null)
                throw new ValidationException("SyncJob invalid");

            await _syncJobsRepository.AddAsync(syncJob);
        }

        /// <summary>
        /// Retrieves all pending sync jobs up to a specified limit,
        /// and joins each job with its corresponding user.
        /// </summary>
        /// <param name="pageSize">The maximum number of jobs to return.</param>
        /// <returns>A collection of <see cref="SyncJobTask"/> combining jobs and users.</returns>
        public async Task<IEnumerable<SyncJobTask>> GetAllPendingAsync(int pageSize)
        {
            var jobs = await _syncJobsRepository.GetAllPendingAsync(pageSize);
            var users = await _userRepository.GetAllAsync();

            return from j in jobs
                   join u in users on j.UserId equals u.Id
                   select new SyncJobTask()
                   {
                       SyncJob = j,
                       User = u
                   };
        }
        /// <summary>
        /// Updates the status of a given sync job.
        /// </summary>
        /// <param name="syncJob">The sync job with updated status.</param>
        public async Task UpdateStatusAsync(SyncJob syncJob) => await _syncJobsRepository.UpdateStatusAsync(syncJob);
    }
}
