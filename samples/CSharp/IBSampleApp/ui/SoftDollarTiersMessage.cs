using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class SoftDollarTiersMessage : IBMessage
    {
        public int ReqId { get; private set; }
        public IBApi.SoftDollarTier[] Tiers { get; private set; }

        public SoftDollarTiersMessage(int reqId, IBApi.SoftDollarTier[] tiers)
        {
            this.type = MessageType.SoftDollarTiers;
            this.ReqId = reqId;
            this.Tiers = tiers;
        }
    }
}
