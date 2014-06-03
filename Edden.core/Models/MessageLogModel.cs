using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.core.Models
{
    public enum MessageLogType
    {
        Error,
        Information,
        Send,
        Receive
    }

    public class MessageLogModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public MessageLogType Type { get; set; }
    }
}
