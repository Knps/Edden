namespace Edden.realm.Models.Event
{
    public enum ServerMessageType
    {
        Error,
        Warning,
        Information,
        Receive,
        Send
    }

    public class ServerMessageEvent
    {
        public string Message { get; set; }

        public ServerMessageType Type { get; set; }
    }
}
