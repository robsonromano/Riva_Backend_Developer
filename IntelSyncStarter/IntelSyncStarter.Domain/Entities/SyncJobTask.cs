namespace IntelSyncStarter.Domain.Entities
{
    public class SyncJobTask
    {
        public SyncJob SyncJob { get; set; }
        public CrmUser User { get; set; }
    }
}
