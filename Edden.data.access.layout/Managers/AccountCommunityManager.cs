using Edden.data.access.layout.Entities;

namespace Edden.data.access.layout.Managers
{
    public class AccountCommunityManager : BaseManager
    {
        public AccountCommunityManager(DataAccessObject dao) : base(dao)
        {
        }

        public override void InitializeData()
        {
            using (var session = Dao.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var community = new AccountCommunityEntity
                {
                    Name = "french",
                    Identity = 0
                };
                session.Save(community);
                tx.Commit();
            }
        }
    }
}
