using IntelSyncStarter.Domain.Enums;

namespace IntelSyncStarter.Domain.Entities
{
    /// <summary>
    /// Represents a CRM user with related sync metadata.
    /// </summary>
    public class CrmUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public CrmPlatform CrmPlatform { get; set; }
        public string CrmToken { get; set; }
    }
}
