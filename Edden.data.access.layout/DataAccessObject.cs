using System.Reflection;
using Edden.core.Models;
using Edden.data.access.layout.Entities;
using Edden.data.access.layout.Managers;
using NHibernate;
using NHibernate.Cfg;

namespace Edden.data.access.layout
{
    public class DataAccessObject
    {
        public AccountManager Account { get; set; }

        public ServerManager Server { get; set; }

        public AccountCommunityManager Community { get; set; }

        public AccountLevelManager Level { get; set; }

        public  ISessionFactory SessionFactory { get; set; }

        private string _connectionString;

        public DataAccessObject()
        {
            _connectionString = "";
            Account = new AccountManager(this);
            Server = new ServerManager(this);
            Community = new AccountCommunityManager(this);
            Level = new AccountLevelManager(this);
        }

        public void Setup(SettingModel setting)
        {
            _connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", setting.Database.Host, setting.Database.Name, setting.Database.Username, setting.Database.Password);
            SessionFactory = BuildConfig().BuildSessionFactory();
        }

        public void Setup(string host, string user, string password, string dbname)
        {
            _connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", host, dbname, user, password);
            SessionFactory = BuildConfig().BuildSessionFactory();
        }

        public void GenerateDb()
        {
            new NHibernate.Tool.hbm2ddl.SchemaExport(BuildConfig()).Execute(false, true, false);
        }

        private Configuration BuildConfig()
        {
            return new Configuration().DataBaseIntegration(x =>
            {
                x.ConnectionString = _connectionString;
                x.Driver<NHibernate.Driver.MySqlDataDriver>();
                x.Dialect<NHibernate.Dialect.MySQLDialect>();
            }).AddAssembly(Assembly.GetExecutingAssembly());
        }

        public void InitDb()
        {
            GenerateDb();
            Level.InitializeData();
            Community.InitializeData();
            Server.InitializeData();
            Account.InitializeData();
        }
    }
}
