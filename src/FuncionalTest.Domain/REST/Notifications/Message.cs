namespace FuncionalTest.Domain.REST.Notifications
{
    public class Message
    {
        public Message(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Message(string value)
        {
            Key = "";
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
