namespace Edden.game.Models.Config
{
    public class MainModelSetting
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public bool EnableHeroic { get; set; }

        public int SaveTime { get; set; }

        public int MaxPlayers { get; set; }

        public bool EnableMultiAccount { get; set; }

        public MainModelSetting()
        {
            Id = 1;
            Name = "Jiva";
            Host = "127.0.0.1";
            Port = 5555;
            Password = "edden";
            EnableHeroic = false;
            SaveTime = 1728000;
            MaxPlayers = 2000;
            EnableMultiAccount = true;
        }

        public MainModelSetting(int id, string name, string host, int port, string password, bool enableHeroic, int saveTime, int maxPlayers, bool enableMultiAccount)
        {
            Id = id;
            Name = name;
            Host = host;
            Port = port;
            Password = password;
            EnableHeroic = enableHeroic;
            SaveTime = saveTime;
            MaxPlayers = maxPlayers;
            EnableMultiAccount = enableMultiAccount;
        }
    }
}
