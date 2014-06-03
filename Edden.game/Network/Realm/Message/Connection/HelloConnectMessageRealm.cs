using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Extentions;
using Edden.core.Network;

namespace Edden.game.Network.Realm.Message.Connection
{
    class HelloConnectMessageRealm : NetworkMessage<MessageManagerRealm>
    {
        private string _version = "";
        private int _serverId = -1;
        private string _serverPass = "";

        public HelloConnectMessageRealm(MessageManagerRealm manager) : base(manager)
        {
        }

        public override string GetId()
        {
            return "AA";
        }

        public override void Handle(Packet packet)
        {

            if (Manager == null) return;

            var rClient = Manager.RClient;
            var sMain = rClient.GCore.Setting.Main;
            var pck = packet.Content.Split(';');

            if(pck.Length != 1) return;

            _version = pck[0];
            _serverId = sMain.Id;
            _serverPass = sMain.Password;

            if (_version != Constants.Version)
            {
                rClient.Disconnect();
            }
            else
            {
                rClient.SendMessage(string.Format("AA{0};{1}", _serverId, _serverPass));
            }
        }

        public override void Reset()
        {
            _version = "";
            _serverId = -1;
            _serverPass = "";
        }

        protected override string GetReceiveContent()
        {
            return string.Format("Version [{0}]", _version);
        }

        protected override string GetSendContent()
        {
            return string.Format("ServerId [{0}] ServerPass [{1}]", _serverId, _serverPass);
        }
    }
}
