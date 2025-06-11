namespace IntelSyncStarter.Domain.Enums
{
    public sealed class SyncStatus
    {
        public static readonly SyncStatus Pending = new("Pending");
        public static readonly SyncStatus Success = new("Success");
        public static readonly SyncStatus Fail = new("Fail");

        public string Value { get; }

        private SyncStatus(string value) => Value = value;

        public override string ToString() => Value;
    }
}
