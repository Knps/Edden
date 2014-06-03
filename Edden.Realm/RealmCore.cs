using Edden.core.Models;
using Edden.core.Utils;
using Edden.data.access.layout;
using Edden.realm.Network.Game;
using Edden.realm.Network.Player;

namespace Edden.realm
{
    public class RealmCore
    {
        public MessageLog Log { get; set; }

        public RealmSetting Setting { get; set; }

        public GameManager GManager { get; set; }

        public PlayerManager PManager { get; set; }

        public DataAccessObject Db { get; set; }

        public RealmCore()
        {
            Log = new MessageLog();
            Db = new DataAccessObject();
            Setting = SettingModel.Load<RealmSetting>();
            Db.Setup(Setting);
            GManager = new GameManager(this);
            PManager = new PlayerManager(this);
        }

        public void Run()
        {
            GManager.Start();
            PManager.Start();
        }

        public void Stop()
        {
            GManager.Stop();
            PManager.Stop();
        }
    }
}
