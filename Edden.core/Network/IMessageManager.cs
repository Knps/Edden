using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edden.core.Network
{
    public interface IMessageManager
    {
        void Parse(byte[] data, bool sended = false);
        void InitMessages();
    }
}
