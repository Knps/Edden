using System.Collections.Generic;
using Edden.core.Network;
using Edden.realm.Network.Game.Message.Connection;

namespace Edden.realm.Network.Game.Message
{
    public class MessageManagerGame : MessageManager<MessageManagerGame>
    {
        public GameClient GClient { get; set; }

        public MessageManagerGame(GameClient gClient)
        {
            GClient = gClient;
        }

        public override void InitMessages()
        {
            Messages = new List<NetworkMessage<MessageManagerGame>>
            {
                new HelloConnectMessageGame(this)
            };
        }

        protected override void OnFormatted(ref Packet packet)
        {
            packet.Content = packet.Content.Remove(packet.Content.Length - 1);
        }
    }
}
