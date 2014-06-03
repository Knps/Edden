namespace Edden.realm.Models.Config
{
    public class MainModelSetting
    {
        public int Blacklog { get; set; }

        public MainModelSetting()
        {
            Blacklog = 200;
        }

        public MainModelSetting(int blacklog)
        {
            Blacklog = blacklog;
        }
    }
}
