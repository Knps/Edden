using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class AccountEntity
    {
        public virtual long Id { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual string Salt { get; set; }

        public virtual AccountTraceEntity Trace { get; set; }

        public virtual AccountProfileEntity Profile { get; set; }

        public virtual AccountStateEntity State { get; set; }

        public virtual AccountLevelEntity Level { get; set; }

        public virtual AccountCommunityEntity Community { get; set; }
    }
}
