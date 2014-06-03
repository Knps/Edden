using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.realm.Network.Player.Handlers;

namespace Edden.realm.Network.Player
{
   public class PlayerManager
    {
       public RealmCore RCore { get; set; }

       public PlayerServer Server { get; set; }

       public QueueHandler QueueH { get; set; }

       public PlayerManager(RealmCore rCore)
       {
           RCore = rCore;
           Server = new PlayerServer();
           QueueH = new QueueHandler(this);
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
           RCore.Log.WriteException(e);
       }

       private void Server_Stoped(object sender)
       {
           RCore.Log.WriteInformation(-1, "Server player is stoped");
       }

       private void Server_Started(object sender, int port)
       {
           RCore.Log.WriteInformation(-1, "Server player is started on port " + port);
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
           client.SendHcKey();
       }

       private void Server_ClientDisconnected(PlayerClient client)
       {
           client.Dispose();
           Console.WriteLine("Lost client " + client.Infos.HcKey);
       }

       public void Start()
       {
           Server.Start(RCore.Setting.Port.Player);
       }

       public void Stop()
       {
           Server.Stop();
       }
    }
}
