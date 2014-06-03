using System;
using System.Linq;
using Edden.data.access.layout.Entities;
using Edden.data.access.layout.Models;
using KnpsToolkit.KnpsExtentions;

namespace Edden.data.access.layout.Managers
{
    public enum AccountStateEnum
    {
        Banned = -2,
        Maintenanced = -1,
        Connected = 0
    }

    public class AccountManager : BaseManager
    {
        public AccountManager(DataAccessObject dao) : base(dao)
        {
        }

        public override void InitializeData()
        {
            CreateAccount(new AccountCreateModel
            {
                Username = "snaps",
                Password = "admin",
                SecretAnswer = "Yes",
                SecretQuestion = "Yes ?",
                Pseudo = "SnapsPseudo",
                CommunityIdentity = 0,
                Levelidentity = 2
            });

            CreateAccount(new AccountCreateModel
            {
                Username = "knps",
                Password = "admin",
                SecretAnswer = "Yes",
                SecretQuestion = "Yes ?",
                Pseudo = "KnpsPseudo",
                CommunityIdentity = 0,
                Levelidentity = 2
            });

            CreateAccount(new AccountCreateModel
            {
                Username = "admin",
                Password = "admin",
                SecretAnswer = "Yes",
                SecretQuestion = "Yes ?",
                Pseudo = "AdminPseudo",
                CommunityIdentity = 0,
                Levelidentity = 2
            });
        }

        public void ChangeState(int id, AccountStateEnum state)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var acc = session.Get<AccountEntity>(id).State.Identity = (int)state;
                session.Save(acc);
                tx.Commit();
            }
        }

        public AccountStateEntity GetStateById(long id)
        {
            if(id < 1) return null;

            using (var session = Dao.SessionFactory.OpenSession())
            {
                var acc = session.Get<AccountEntity>(id);

                if(acc == null) return null;

                var state = acc.State;

                return new AccountStateEntity
                {
                    Id = state.Id,
                    BannedAt = state.BannedAt,
                    Identity = state.Identity,
                    SubscribedAt = state.SubscribedAt
                };
            }
        }

        public void CreateAccount(AccountCreateModel model)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var level = session.QueryOver<AccountLevelEntity>().Where(l => l.Identity == model.Levelidentity).List().FirstOrDefault();
                var community = session.QueryOver<AccountCommunityEntity>().Where(c => c.Identity == model.CommunityIdentity).List().FirstOrDefault();

                if (level == null || community == null) return;

                var salt = DateTime.Now.ToString("yy-MM-dd").Md5Hash();
                var passEncrypted = model.Password.Md5Hash(salt);
                var account = new AccountEntity
                {
                    Community = community,
                    Level = level,
                    Profile = new AccountProfileEntity
                    {
                        Pseudo = model.Pseudo,
                        SecretAnswer = model.SecretAnswer,
                        SecretQuestion = model.SecretQuestion
                    },
                    Trace = new AccountTraceEntity
                    {
                        LastConnectionDate = DateTime.Now,
                        LastConnectionHost = ""
                    },
                    State = new AccountStateEntity
                    {
                        BannedAt = DateTime.Now,
                        Identity = 0,
                        SubscribedAt = DateTime.Now
                    },
                    Username = model.Username,
                    Salt = salt,
                    Password = passEncrypted
                };
                session.Save(account);
                tx.Commit();
            }
        }

        public long Authenticate(string username, string passeword)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            {
                var account = session.QueryOver<AccountEntity>().Where(a => a.Username == username).List().FirstOrDefault();
                return account != null && passeword.Md5Hash(account.Salt) == account.Password ? account.Id : -1;
            }
        }

        public bool IsSubscribed(long accountId)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            {
                var account = session.Get<AccountEntity>(accountId);
                if (account == null) return false;
                return account.State.SubscribedAt > DateTime.Now;
            }
        }

        public AccountEntity GetById(long id)
        {
            using (var session = Dao.SessionFactory.OpenSession())
            {
                return session.Get<AccountEntity>(id);
            }
        }
    }
}
