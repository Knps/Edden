using System;
using System.Text;
using Edden.core.Network;
using Edden.realm.Models;
using Edden.realm.Network.Player.Message;
using KnpsToolkit.KnpsNetwork;

namespace Edden.realm.Network.Player
{
    public class PlayerClient : KnpsClient
    {
        public PlayerManager Manager { get; set; }

        public PlayerClientInfo Infos { get; set; }

        private readonly MessageManagerPlayer _mManager;

        public PlayerClient()
        {
            Infos = new PlayerClientInfo();
            _mManager = new MessageManagerPlayer(this);
            _mManager.InitMessages();
            _mManager.Log.NewMessage += Log_NewMessage;
            _mManager.Log.NewException += Log_NewException;
        }

        private void Log_NewException(Exception ex)
        {
            Manager.RCore.Log.WriteException(ex);
        }

        private void Log_NewMessage(core.Models.MessageLogModel message)
        {
            Manager.RCore.Log.Write(message);
        }

        public void InitManager(PlayerManager manager)
        {
            Manager = manager;
        }

        public void SendHcKey()
        {
            SendMessage("HC" + Infos.HcKey);
        }

        public void SendMessage(string packet)
        {
            Send(Packet.Format(packet), SendDataType.Utf8);
        }

        public void Manage(byte[] data, int len)
        {
            var id = "";
            var loc = Encoding.UTF8.GetString(data);

            switch (Infos.AuthenticateState)
            {
                case 0:
                    id = "WV";
                    break;
                case 1:
                    id = "WA";
                    break;
            }

            _mManager.Parse(Encoding.UTF8.GetBytes(id + loc));
        }
    }
}
