using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Models;

namespace Edden.core.Utils
{
    public class MessageLog
    {
        public delegate void NewMessageDelegate(MessageLogModel message);

        public event NewMessageDelegate NewMessage;

        protected virtual void OnNewMessage(MessageLogModel message)
        {
            NewMessageDelegate handler = NewMessage;
            if (handler != null) handler(message);
        }

        public delegate void NewExceptionDelegate(Exception ex);

        public event NewExceptionDelegate NewException;

        protected virtual void OnNewException(Exception ex)
        {
            NewExceptionDelegate handler = NewException;
            if (handler != null) handler(ex);
        }

        public void WriteSend(int id, string message)
        {
            OnNewMessage(new MessageLogModel
            {
                Id = id,
                Message = message,
                Type = MessageLogType.Send
            });
        }

        public void WriteReceive(int id, string message)
        {
            OnNewMessage(new MessageLogModel
            {
                Id = id,
                Message = message,
                Type = MessageLogType.Receive
            });
        }

        public void Write(MessageLogModel message)
        {
            OnNewMessage(message);
        }

        public void WriteInformation(int id, string message)
        {
            OnNewMessage(new MessageLogModel
            {
                Id = id,
                Message = message,
                Type = MessageLogType.Information
            });
        }

        public void WriteError(int id, string message)
        {
            OnNewMessage(new MessageLogModel
            {
                Id = id,
                Message = message,
                Type = MessageLogType.Error
            });
        }

        public void WriteException(Exception ex)
        {
            OnNewException(ex);
        }
    }
}
