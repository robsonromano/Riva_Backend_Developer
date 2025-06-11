using IntelSyncStarter.Domain.Enums;

namespace IntelSyncStarter.Domain.Entities
{
    /// <summary>
    /// Represents the result of a token validation operation.
    /// </summary>
    public class TokenValidationResult
    {
        public SyncStatus Status { get; set; }
        public string? ErrorMessage { get; set; }

        public static TokenValidationResult Success() => new() { Status = SyncStatus.Success };
        public static TokenValidationResult Fail(string message) => new() { Status = SyncStatus.Fail, ErrorMessage = message };
    }
}
