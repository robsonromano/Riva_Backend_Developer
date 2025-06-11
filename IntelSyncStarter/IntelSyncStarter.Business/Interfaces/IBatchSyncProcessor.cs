namespace IntelSyncStarter.Business.Interfaces
{
    public interface IBatchSyncProcessor
    {
        Task ProcessSyncJobsAsync();
    }
}
