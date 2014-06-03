using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Utils;

namespace Edden.core.Network
{
    public class MessageManager<T> : IMessageManager where T : IMessageManager
    {
        protected List<NetworkMessage<T>> Messages;

        public MessageLog Log { get; set; }

        public MessageManager()
        {
            Log = new MessageLog();
        }

        /// <summary>
        /// Initialize Network message list
        /// </summary>
        public virtual void InitMessages()
        {
            Messages = new List<NetworkMessage<T>>();
        }

        /// <summary>
        /// Get message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NetworkMessage<T> GetMessage(string id)
        {
            return Messages.Find(m => m.GetId() == id);
        }

        public void Parse(byte[] data, bool sended = false)
        {
            var packets = Packet.GetPackets(data);
            foreach (var packet in packets)
            {
                Handle(packet, sended);
            }
        }

        protected virtual void OnFormatted(ref Packet packet)
        {
            
        }

        private void Handle(Packet packet, bool sended)
        {
            try
            {
                if (!packet.IsDeserialized)
                {
                    Log.WriteError(3, "Failed to deserialize packet");
                    return;
                }

                OnFormatted(ref packet);

                var message = GetMessage(packet.Id);

                if (message == null)
                {
                    Log.WriteReceive(4, string.Format("Unknow Message [{0}]", packet.Id));
                    return;
                }

                if (sended)
                {
                    if (message.CanDisplaySend())
                        Log.WriteSend(5, message.GetSendMessage());
                    return;
                }

                message.Reset();
                message.Handle(packet);

                if(message.CanDisplayReceive())
                    Log.WriteReceive(6, message.GetReceiveMessage());
            }
            catch (Exception e)
            {
                Log.WriteException(e);
            }
        }
    }
}
