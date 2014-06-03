namespace Edden.game.Models.Config
{
    public class RateModelSetting
    {
        public int Xp { get; set; }
        public int Kamas { get; set; }
        public int Honor { get; set; }
        public int Job { get; set; }
        public int Drop { get; set; }
        public int All { get; set; }

        public RateModelSetting()
        {
            Xp = 1;
            Kamas = 1;
            Honor = 1;
            Job = 1;
            Drop = 1;
            All = 1;
        }

        public RateModelSetting(int xp, int kamas, int honor, int job, int drop, int all)
        {
            Xp = xp;
            Kamas = kamas;
            Honor = honor;
            Job = job;
            Drop = drop;
            All = all;
        }
    }
}
