namespace IntelSyncStarter.Domain.Enums
{
    public class CrmPlatform
    {
        public static readonly CrmPlatform Salesforce = new("Salesforce");
        public static readonly CrmPlatform Outlook = new("Outlook");

        public string Value { get; }

        private CrmPlatform(string value) => Value = value;

        public override string ToString() => Value;
    }
}
