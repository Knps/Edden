using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Edden.realm.Network.Player.Message.Account;

namespace Edden.realm.Network.Player.Handlers
{
    public class ClientQueue
    {
        public PlayerClient Client { get; set; }

        public bool CanConnect { get; set; }

        public ClientQueue(PlayerClient client)
        {
            Client = client;
            CanConnect = false;
        }
    }

    public class QueueHandler
    {
        public List<ClientQueue> Players { get; set; }

        public PlayerManager Manager { get; set; }

        public QueueHandler(PlayerManager manager)
        {
            Players = new List<ClientQueue>();
            Manager = manager;
            ManageTask().Start();
        }

        private Task ManageTask()
        {
            return new Task(() =>
            {
                while (true)
                {
                    foreach (var player in Players.Where(player => !player.CanConnect))
                    {
                        player.CanConnect = true;
                        break;
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        public void Handle(PlayerClient nClient, QueueAccountPlayerMessage queue)
        {
            var client = Players.Find(p => p.Client == nClient);

            if (client == null)
            {
                client = new ClientQueue(nClient);
                Players.Add(client);
            }

            var position = (Players.IndexOf(client) + 1);
            client.Client.SendMessage(FormatData(position, GetMaxSubscriber(), GetMaxNoSubscriber(), IsSubscribed(nClient.Infos.AccountId)));
            
            if(!client.CanConnect) return;
            
            client.Client.SendMessage("Adxprpgy\0Ac4\0AH601;1;75;1|602;1;75;1\0AlK0\0AQQuel+est+mon+joueur+de+football+pr%C3%A9f%C3%A9r%C3%A9+%3F");
            Players.Remove(client);
        }

        private int GetMaxSubscriber()
        {
            return Players.FindAll(p => IsSubscribed(p.Client.Infos.AccountId)).Count;
        }

        private bool IsSubscribed(long id)
        {
            return Manager.RCore.Db.Account.IsSubscribed(id);
        }

        private int GetMaxNoSubscriber()
        {
            return Players.FindAll(p => !IsSubscribed(p.Client.Infos.AccountId)).Count;
        }

        private string FormatData(int position, int maxSubscriber, int maxNoSubscriber, bool isSubscribed = false)
        {
            return string.Format("Af{0}|{1}|{2}|{3}|-1", position, maxSubscriber, maxNoSubscriber, isSubscribed == false ? "" : "1");
        }
    }
}
