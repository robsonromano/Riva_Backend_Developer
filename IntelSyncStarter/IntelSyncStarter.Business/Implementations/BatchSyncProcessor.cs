using IntelSyncStarter.Business.Interfaces;
using IntelSyncStarter.Domain.Entities;
using Microsoft.Extensions.Options;

namespace IntelSyncStarter.Business.Implementations
{
    /// <summary>
    /// Service responsible for processing batch CRM sync jobs.
    /// </summary>
    public class BatchSyncProcessor : IBatchSyncProcessor
    {
        private readonly AppSettings _settings;
        private readonly ISyncJobs _syncJobsService;
        private readonly ISyncValidator<CrmUser> _tokenValidationService;

        /// <summary>
        /// Initializes the processor with services and configuration.
        /// </summary>
        public BatchSyncProcessor(ISyncJobs syncJobsService,
                                         ISyncValidator<CrmUser> tokenValidationService,
                                         IOptions<AppSettings> settings)
        {
            _syncJobsService = syncJobsService;
            _tokenValidationService = tokenValidationService;
            _settings = settings.Value;
        }

        /// <summary>
        /// Processes sync jobs in batches using parallel execution.
        /// </summary>
        public async Task ProcessSyncJobsAsync()
        {
            IEnumerable<SyncJobTask>? syncJobs = null;
            do
            {
                syncJobs = await _syncJobsService.GetAllPendingAsync(_settings.BatchSize);

                await Parallel.ForEachAsync(syncJobs, new ParallelOptions() { MaxDegreeOfParallelism = _settings.ParallelProcess }, async (task, _) =>
                {
                    var result = _tokenValidationService.Validate(task.User);
                    task.SyncJob.SyncTime = DateTime.UtcNow;
                    task.SyncJob.SyncStatus = result.Status;
                    task.SyncJob.ErrorMessage = result.ErrorMessage;

                    await _syncJobsService.UpdateStatusAsync(task.SyncJob);
                    string message = task.SyncJob.ErrorMessage != null ? $"Message: {task.SyncJob.ErrorMessage}" : "";
                    Console.WriteLine($"TaskId: {task.SyncJob.Id}; UserName: {task.User.Email} Status: {task.SyncJob.SyncStatus} {message}");
                });
            }
            while (syncJobs.Any());
        }
    }
}
