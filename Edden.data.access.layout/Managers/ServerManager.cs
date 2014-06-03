using System;
using System.Linq;
using Edden.data.access.layout.Entities;
using KnpsToolkit.KnpsExtentions;

namespace Edden.data.access.layout.Managers
{
    public class ServerManager : BaseManager
    {
        public ServerManager(DataAccessObject dao) : base(dao)
        {
        }

        public override void InitializeData()
        {
            CreateServer(1, "jiva");
            CreateServer(20, "otomai");
            CreateServer(22, "heroique");
        }

        public void CreateServer(int identity, string password)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var salt = DateTime.Now.ToString("yy-MM-dd").Md5Hash();
                var encryptedPass = password.Md5Hash(salt);
                var server = new ServerEntity
                {
                    Identity = identity,
                    Password = encryptedPass,
                    Salt = salt
                };

                session.Save(server);
                tx.Commit();
            }
        }

        public long Authenticate(int identity, string password)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            {
                var server = session.QueryOver<ServerEntity>().Where(s => s.Identity == identity).List().FirstOrDefault();
                return server != null && password.Md5Hash(server.Salt) == server.Password ? server.Id : -1;
            }
        }
    }
}
