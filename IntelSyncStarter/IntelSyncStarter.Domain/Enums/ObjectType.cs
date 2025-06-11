namespace IntelSyncStarter.Domain.Enums
{
    public class ObjectType
    {
        public static readonly ObjectType Contact = new("Contact");
        public static readonly ObjectType Meeting = new("Meeting");

        private string Value { get; }

        public ObjectType(string value) => Value = value;

        public override string ToString() => Value;
    }
}
