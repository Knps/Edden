using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Network;
using Edden.game.Models;
using Edden.game.Network.Player.Message;
using KnpsToolkit.KnpsNetwork;

namespace Edden.game.Network.Player
{
    public class PlayerClient : KnpsClient
    {
        public void Manage(byte[] data, int len)
        {
            throw new NotImplementedException();
        }

        public void InitManager(PlayerManager playerManager)
        {
            
        }
    }
}
