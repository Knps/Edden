using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class AccountProfileEntity
    {
        public virtual long Id { get; set; }

        public virtual string Pseudo { get; set; }

        public virtual string SecretAnswer { get; set; }

        public virtual string SecretQuestion { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
