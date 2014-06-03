using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Utils;

namespace Edden.realm.Models
{
    public class PlayerClientInfo
    {
        public string HcKey { get; set; }

        public long AccountId { get; set; }

        public int AuthenticateState { get; set; }

        public PlayerClientInfo()
        {
            HcKey = Crypt.GenKey(32);
            AccountId = -1;
            AuthenticateState = 0;
        }
    }
}
