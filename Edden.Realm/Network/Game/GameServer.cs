using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.realm.Models.Event;
using KnpsToolkit.KnpsNetwork;

namespace Edden.realm.Network.Game
{
    public class GameServer : KnpsServer<GameClient>
    {
    }
}
