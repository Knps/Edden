using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Network;

namespace Edden.game.Network.Realm.Message.Connection
{
    class AnswerConnectMessageRealm : NetworkMessage<MessageManagerRealm>
    {
        private int _answer = -1;

        public AnswerConnectMessageRealm(MessageManagerRealm manager) : base(manager)
        {
        }

        public override void Reset()
        {
            _answer = -1;
        }

        protected override string GetReceiveContent()
        {
            return string.Format("Answer [{0}]", _answer);
        }

        public override void Handle(Packet packet)
        {
            var pck = packet.Content.Split(';');

            if(pck.Length != 1) return;

            var rClient = Manager.RClient;

            _answer = int.Parse(pck[0]);

            if (_answer == 0)
            {
                rClient.Disconnect();
            }
            else
            {
                rClient.PManager.Start();
            }
        }

        public override string GetId()
        {
            return "AB";
        }
    }
}
