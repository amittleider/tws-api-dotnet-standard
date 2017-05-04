using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    class SoftDollarTiersMessage
    {
        public int ReqId { get; private set; }
        public IBApi.SoftDollarTier[] Tiers { get; private set; }

        public SoftDollarTiersMessage(int reqId, IBApi.SoftDollarTier[] tiers)
        {
            this.ReqId = reqId;
            this.Tiers = tiers;
        }
    }
}
