using Edden.core.Models;
using Edden.game.Models.Config;

namespace Edden.game
{
    public class GameSetting : SettingModel
    {
        public AuthenticateModelSetting Authenticate { get; set; }
        public CharacterModelSetting Character { get; set; }
        public RateModelSetting Rate { get; set; }
        public MainModelSetting Main { get; set; }

        public GameSetting()
        {
            Authenticate = new AuthenticateModelSetting();
            Character = new CharacterModelSetting();
            Rate = new RateModelSetting();
            Main = new MainModelSetting();
        }
    }
}
