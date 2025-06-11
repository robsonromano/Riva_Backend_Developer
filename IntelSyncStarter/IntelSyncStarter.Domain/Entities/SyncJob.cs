using IntelSyncStarter.Domain.Enums;

namespace IntelSyncStarter.Domain.Entities
{
    /// <summary>
    /// Represents a synchronization job that links a CRM user to a specific sync operation.
    /// </summary>
    public class SyncJob
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ObjectType ObjectType { get; set; }
        public SyncStatus SyncStatus { get; set; } = SyncStatus.Pending;
        public string Payload { get; set; }
        public DateTime SyncTime { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
