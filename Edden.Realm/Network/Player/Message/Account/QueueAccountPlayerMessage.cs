using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Network;

namespace Edden.realm.Network.Player.Message.Account
{
    public class QueueAccountPlayerMessage : NetworkMessage<MessageManagerPlayer>
    {
        public QueueAccountPlayerMessage(MessageManagerPlayer manager) : base(manager)
        {
        }

        public override string GetId()
        {
            return "Af";
        }

        public override void Handle(Packet packet)
        {
            Manager.PClient.Manager.QueueH.Handle(Manager.PClient, this);
        }

        public override void Reset()
        {
            
        }

        public override bool CanDisplayReceive()
        {
            return false;
        }

        public override bool CanDisplaySend()
        {
            return false;
        }

        protected override string GetReceiveContent()
        {
            return "";
        }

        protected override string GetSendContent()
        {
            return "";
        }
    }
}
