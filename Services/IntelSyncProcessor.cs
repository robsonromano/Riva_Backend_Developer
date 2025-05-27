using IntelSyncStarter.Models;

namespace IntelSyncStarter.Services;

public class IntelSyncProcessor
{
    private List<IntelSyncEntry> _syncJobs = new()
    {
        new IntelSyncEntry
        {
            Id = 1,
            UserName = "alice@example.com",
            CrmPlatform = "Salesforce",
            CrmToken = "token123",
            ObjectType = "Contact",
            Payload = "{ \"email\": \"alice@example.com\", \"name\": \"Alice\" }",
            SyncTime = DateTime.UtcNow,
            SyncStatus = "Pending",
            ErrorMessage = ""
        }
    };

    public void ProcessSyncJobs()
    {
        foreach (var job in _syncJobs)
        {
            Console.WriteLine($"Processing sync for {job.ObjectType} on {job.CrmPlatform} for {job.UserName}...");
            job.SyncStatus = string.IsNullOrWhiteSpace(job.CrmToken) ? "Failed" : "Success";
            job.ErrorMessage = string.IsNullOrWhiteSpace(job.CrmToken) ? "Missing CRM token" : "";
            Console.WriteLine($"Status: {job.SyncStatus}");
        }
    }
}
