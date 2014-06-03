using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.game.Models
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
