namespace Edden.game.Models.Config
{
    public class AuthenticateModelSetting
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public AuthenticateModelSetting()
        {
            Host = "127.0.0.1";
            Port = 544;
        }

        public AuthenticateModelSetting(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
