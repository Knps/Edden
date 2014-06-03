using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.realm.Network.Game.Message;
using KnpsToolkit.KnpsNetwork;

namespace Edden.realm.Network.Game
{
    public class GameManager
    {
        public GameServer Server { get; set; }

        public RealmCore RCore { get; set; }

        public GameManager(RealmCore rCore)
        {
            RCore = rCore;
            Server = new GameServer();
            Server.ClientDisconnected += Server_ClientDisconnected;
            Server.NewClientConntected += Server_NewClientConntected;
            Server.NewDataReceived += Server_NewDataReceived;
            Server.NewDataSended += Server_NewDataSended;
            Server.Started += Server_Started;
            Server.Stoped += Server_Stoped;
        }

        private void Server_Stoped(object sender)
        {
            RCore.Log.WriteInformation(-1, "Server game is stoped");
        }

        private void Server_Started(object sender, int port)
        {
            RCore.Log.WriteInformation(-1, "Server game is started on port " + port);
        }

        private void Server_NewDataSended(GameClient client, byte[] data)
        {
            //RCore.Log.WriteSend(0, Encoding.ASCII.GetString(data));
        }

        private void Server_NewDataReceived(GameClient client, byte[] data, int len)
        {
            client.Manage(Encoding.UTF8.GetString(data, 0, len));
        }

        private void Server_NewClientConntected(GameClient client)
        {
            client.InitManager(this);
            client.Send("AA" + Constants.Version, SendDataType.Utf8);
        }

        private void Server_ClientDisconnected(GameClient client)
        {
            
        }

        public void Start()
        {
            Server.Start(RCore.Setting.Port.Game);
        }

        public void Stop()
        {
            Server.Stop();
        }
    }
}
