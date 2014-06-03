using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Network;

namespace Edden.game.Network.Player.Message
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
                
            };
        }
    }
}
