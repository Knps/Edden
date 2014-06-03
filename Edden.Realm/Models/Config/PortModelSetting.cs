namespace Edden.realm.Models.Config
{
    public class PortModelSetting
    {
        public int Player { get; set; }
        public int Game { get; set; }

        public PortModelSetting()
        {
            Player = 543;
            Game = 544;
        }

        public PortModelSetting(int player, int game)
        {
            Player = player;
            Game = game;
        }
    }
}
