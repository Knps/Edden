using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.core.Network
{
    public class NetworkMessage<T> where T : IMessageManager
    {
        protected T Manager;

        public NetworkMessage(T manager)
        {
            Manager = manager;
        }

        /// <summary>
        /// Get message id
        /// </summary>
        /// <returns></returns>
        public virtual string GetId()
        {
            return "";
        }

        /// <summary>
        /// Handle packet
        /// </summary>
        /// <param name="packet"></param>
        /// <returns>bytes</returns>
        public virtual void Handle(Packet packet)
        {
            
        }

        /// <summary>
        /// Reset packet
        /// </summary>
        public virtual void Reset()
        {
            
        }

        public virtual bool CanDisplayReceive()
        {
            return true;
        }

        public virtual bool CanDisplaySend()
        {
            return true;
        }

        public string GetReceiveMessage()
        {
            return string.Format("{0} => {1}", GetType().Name, GetReceiveContent());
        }

        protected virtual string GetReceiveContent()
        {
            return "";
        }

        public string GetSendMessage()
        {
            return string.Format("{0} => {1}", GetType().Name, GetSendContent());
        }

        protected virtual string GetSendContent()
        {
            return "";
        }
    }
}
