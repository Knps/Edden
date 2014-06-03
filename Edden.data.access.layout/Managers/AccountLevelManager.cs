using Edden.data.access.layout.Entities;

namespace Edden.data.access.layout.Managers
{
    public class AccountLevelManager : BaseManager
    {
        public AccountLevelManager(DataAccessObject dao) : base(dao)
        {
        }

        public override void InitializeData()
        {
            using (var session = Dao.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var level1 = new AccountLevelEntity
                {
                    Name = "admin",
                    Identity = 2
                };

                var level2 = new AccountLevelEntity
                {
                    Name = "moderator",
                    Identity = 1
                };

                var level3 = new AccountLevelEntity
                {
                    Name = "user",
                    Identity = 0
                };
                session.Save(level1);
                session.Save(level2);
                session.Save(level3);
                tx.Commit();
            }
            
        }
    }
}
