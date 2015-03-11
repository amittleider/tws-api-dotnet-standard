using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    interface EClientMsgSink
    {
        void serverVersion(int version, string time);
        void redirect(string host);
    }
}
