using Edden.core;
using Edden.core.Models;
using Edden.realm.Models.Config;

namespace Edden.realm
{
    public class RealmSetting : SettingModel
    {
        public PortModelSetting Port { get; set; }
        public MainModelSetting Main { get; set; }

        public RealmSetting()
        {
            Port = new PortModelSetting();
            Main = new MainModelSetting();
        }
    }
}
