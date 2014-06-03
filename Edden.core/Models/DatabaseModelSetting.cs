using System;
using Newtonsoft.Json;

namespace Edden.core.Models
{
    public class DatabaseModelSetting
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public DatabaseModelSetting()
        {
            Host = "127.0.0.1";
            Username = "root";
            Password = "";
            Name = "edden";
        }

        public DatabaseModelSetting(string host, string username, string password, string name)
        {
            Host = host;
            Username = username;
            Password = password;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", Host, Username, Password, Name);
        }
    }
}
