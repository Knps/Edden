using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class AccountTraceEntity
    {
        public virtual long Id { get; set; }

        public virtual DateTime LastConnectionDate { get; set; }

        public virtual string LastConnectionHost { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
