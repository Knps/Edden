using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.game.Models;
using Edden.game.Network.Realm;
using KnpsToolkit.KnpsNetwork;

namespace Edden.game.Network.Player
{
    public class PlayerServer : KnpsServer<PlayerClient>
    {
    }
}
