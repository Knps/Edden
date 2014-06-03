using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class AccountLevelEntity
    {
        public virtual long Id { get; set; }

        public virtual int Identity { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<AccountEntity> Accounts { get; set; }
    }
}
