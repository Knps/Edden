using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.game.Network.Realm;

namespace Edden.game.Network.Player
{
    public class PlayerManager
    {
        public RealmClient RClient { get; set; }

        public PlayerServer Server { get; set; }

        public PlayerManager(RealmClient rClient)
        {
            RClient = rClient;
            Server = new PlayerServer();
            Server.ClientDisconnected += Server_ClientDisconnected;
            Server.NewClientConntected += Server_NewClientConntected;
            Server.NewDataReceived += Server_NewDataReceived;
            Server.NewDataSended += Server_NewDataSended;
            Server.Started += Server_Started;
            Server.Stoped += Server_Stoped;
            Server.NewException += Server_NewException;
        }

        private void Server_NewException(Exception e)
        {
            RClient.GCore.Log.WriteException(e);
        }

        private void Server_Stoped(object sender)
        {
            RClient.GCore.Log.WriteInformation(-1, "Server player is stoped");
        }

        private void Server_Started(object sender, int port)
        {
            RClient.GCore.Log.WriteInformation(-1, "Server player is started on port " + port);
        }

        private void Server_NewDataSended(PlayerClient client, byte[] data)
        {
            
        }

        private void Server_NewDataReceived(PlayerClient client, byte[] data, int len)
        {
            client.Manage(data, len);
        }

        private void Server_NewClientConntected(PlayerClient client)
        {
            client.InitManager(this);
        }

        private void Server_ClientDisconnected(PlayerClient client)
        {
            client.Dispose();
            Console.WriteLine("Lost client ");
        }

        public void Start()
        {
            Server.Start(RClient.GCore.Setting.Main.Port);
        }

        public void Stop()
        {
            Server.Stop();
        }
    }
}
