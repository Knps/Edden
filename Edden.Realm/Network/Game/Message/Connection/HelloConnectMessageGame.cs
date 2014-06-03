using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Extentions;
using Edden.core.Network;
using KnpsToolkit.KnpsNetwork;

namespace Edden.realm.Network.Game.Message.Connection
{
    public class HelloConnectMessageGame : NetworkMessage<MessageManagerGame>
    {
        private int _answer = -1;
        private int _serverId = -1;
        private string _serverPass = "";

        public HelloConnectMessageGame(MessageManagerGame manager) : base(manager)
        {
        }

        public override string GetId()
        {
            return "AA";
        }

        public override void Handle(Packet packet)
        {
            var pck = packet.Content.Split(';');
            var mManager = Manager;
            var mClient = mManager.GClient;

            if(pck.Length < 2) return;

            _serverId = int.Parse(pck[0]);
            _serverPass = pck[1];
            _answer = IsChecked(_serverId, _serverPass) ? 1:0;
            mClient.Send(string.Format("AB{0}", _answer), SendDataType.Utf8);
        }

        private bool IsChecked(int id, string pass)
        {
            if ((id < 1 && id > 37) || string.IsNullOrEmpty(pass)) return false;
            
            var game = Manager.GClient.Manager.Server.GetClient(g => g.Infos.ServerId == id && g != Manager.GClient);
            
            if (game != null) return false;

            Manager.GClient.Infos.ServerId = Manager.GClient.Manager.RCore.Db.Server.Authenticate(id, pass);

            if (Manager.GClient.Infos.ServerId == -1) return false;

            Manager.GClient.UpdateState(GameState.OnLine);

            return true;
        }

        public override void Reset()
        {
            _answer = -1;
            _serverId = -1;
            _serverPass = "";
        }

        protected override string GetReceiveContent()
        {
            return string.Format("ServerID [{0}], ServerPass [{1}]", _serverId, _serverPass);
        }

        protected override string GetSendContent()
        {
            return string.Format("Answer [{0}]", _answer);
        }
    }
}
