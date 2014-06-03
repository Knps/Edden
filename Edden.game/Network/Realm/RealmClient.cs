using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Network;
using Edden.game.Models;
using Edden.game.Network.Player;
using Edden.game.Network.Realm.Message;
using KnpsToolkit.KnpsNetwork;

namespace Edden.game.Network.Realm
{
    public class RealmClient : KnpsClient
    {
        public GameCore GCore { get; set; }

        public PlayerManager PManager { get; set; }

        private readonly MessageManagerRealm _mManager;

        public RealmClient(GameCore gCore)
        {
            GCore = gCore;
            PManager = new PlayerManager(this);
            _mManager = new MessageManagerRealm(this);
            _mManager.InitMessages();
            _mManager.Log.NewMessage += Log_NewMessage;
            _mManager.Log.NewException += Log_NewException;
        }

        private void Log_NewException(Exception ex)
        {
            GCore.Log.WriteException(ex);
        }

        private void Log_NewMessage(core.Models.MessageLogModel message)
        {
            GCore.Log.Write(message);
        }

        public void Manage(byte[] data, int len)
        {
            _mManager.Parse(data);
        }

        public void SendMessage(string packet)
        {
            Send(Packet.Format(packet), SendDataType.Utf8);
        }
    }
}
