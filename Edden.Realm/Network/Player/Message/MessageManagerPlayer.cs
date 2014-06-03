using System.Collections.Generic;
using Edden.core.Network;
using Edden.realm.Network.Player.Message.Account;

namespace Edden.realm.Network.Player.Message
{
    public class MessageManagerPlayer : MessageManager<MessageManagerPlayer>
    {
        public PlayerClient PClient { get; set; }

        public MessageManagerPlayer(PlayerClient pClient)
        {
            PClient = pClient;
        }

        public override void InitMessages()
        {
            Messages = new List<NetworkMessage<MessageManagerPlayer>>
            {
                new AuthenticateAccountPlayerMessage(this),
                new VersionAccountPlayerMessage(this),
                new QueueAccountPlayerMessage(this)
            };
        }
    }
}
