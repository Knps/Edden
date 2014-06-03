using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.data.access.layout.Entities
{
    public class ServerEntity
    {
        public virtual long Id { get; set; }

        public virtual int Identity { get; set; }

        public virtual string Password { get; set; }

        public virtual string Salt { get; set; }
    }
}
