using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class AccountStateEntity
    {
        public virtual long Id { get; set; }

        public virtual int Identity { get; set; }

        public virtual DateTime BannedAt { get; set; }

        public virtual DateTime SubscribedAt { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
