using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Network;
using Edden.game.Network.Realm.Message.Connection;

namespace Edden.game.Network.Realm.Message
{
    public class MessageManagerRealm : MessageManager<MessageManagerRealm>
    {
        public RealmClient RClient { get; set; }

        public MessageManagerRealm(RealmClient rClient)
        {
            RClient = rClient;
        }

        public override void InitMessages()
        {
            Messages = new List<NetworkMessage<MessageManagerRealm>>
            {
                new HelloConnectMessageRealm(this),
                new AnswerConnectMessageRealm(this)
            };
        }
    }
}
