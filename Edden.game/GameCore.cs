using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core.Models;
using Edden.core.Utils;
using Edden.data.access.layout;
using Edden.game.Network.Realm;

namespace Edden.game
{
    public class GameCore
    {
        public MessageLog Log { get; set; }

        public GameSetting Setting { get; set; }

        public RealmClient RClient { get; set; }

        public DataAccessObject Db { get; set; }

        public GameCore()
        {
            Log = new MessageLog();
            Db = new DataAccessObject();
            Setting = SettingModel.Load<GameSetting>();
            Db.Setup(Setting);
            RClient = new RealmClient(this);
            RClient.NewException += RClient_NewException;
            RClient.Connected += RClient_Connected;
            RClient.Disconnected += RClient_Disconnected;
            RClient.DataReceived += RClient_DataReceived;
            RClient.DataSended += RClient_DataSended;
        }

        private void RClient_DataSended(object sender, byte[] data)
        {
            
        }

        private void RClient_DataReceived(object sender, byte[] data, int len)
        {
            RClient.Manage(data, len);
        }

        private void RClient_Disconnected(object sender)
        {
            RClient.PManager.Stop();
        }

        private void RClient_Connected(object sender)
        {
            Log.WriteInformation(-1, "Connect to realm successfull");
        }

        private void RClient_NewException(Exception e)
        {
            Log.WriteException(e);
        }

        public void Run()
        {
            RClient.Connect(Setting.Authenticate.Host, Setting.Authenticate.Port);
        }

        public void Stop()
        {
            RClient.Disconnect();
        }
    }
}
