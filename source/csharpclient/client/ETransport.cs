using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public interface ETransport
    {
        void Send(EMessage msg);
    }
}
