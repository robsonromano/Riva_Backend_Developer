namespace IntelSyncStarter.Models;

public class IntelSyncEntry
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string CrmPlatform { get; set; }
    public string CrmToken { get; set; }
    public string ObjectType { get; set; } // e.g., "Contact", "Meeting"
    public string Payload { get; set; }
    public DateTime SyncTime { get; set; }
    public string SyncStatus { get; set; }
    public string ErrorMessage { get; set; }
}
