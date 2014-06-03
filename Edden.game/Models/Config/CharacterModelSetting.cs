namespace Edden.game.Models.Config
{
    public class CharacterModelSetting
    {
        public int Level { get; set; }
        public int Kamas { get; set; }
        public int Limit { get; set; }

        public CharacterModelSetting()
        {
            Level = 1;
            Kamas = 0;
            Limit = 5;
        }

        public CharacterModelSetting(int level, int kamas, int limit)
        {
            Level = level;
            Kamas = kamas;
            Limit = limit;
        }
    }
}
