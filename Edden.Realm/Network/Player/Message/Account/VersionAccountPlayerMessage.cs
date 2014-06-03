using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Network;

namespace Edden.realm.Network.Player.Message.Account
{
    public class VersionAccountPlayerMessage : NetworkMessage<MessageManagerPlayer>
    {
        private string _version = "";

        public VersionAccountPlayerMessage(MessageManagerPlayer manager) : base(manager)
        {
        }

        public override string GetId()
        {
            return "WV";
        }

        public override void Handle(Packet packet)
        {
            _version = packet.Content;

            if (!_version.Equals(Constants.ClientVersion))
            {
                Manager.PClient.SendMessage("AlEv");
                return;
            }

            Manager.PClient.Infos.AuthenticateState = 1;
        }

        protected override string GetReceiveContent()
        {
            return string.Format("Version [{0}]", _version);
        }

        public override void Reset()
        {
            _version = "";
        }

        protected override string GetSendContent()
        {
            return string.Format("");
        }
    }
}
