using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    class PnLMessage
    {
        public int ReqId { get; private set; }
        public double DailyPnL { get; private set; }
        public double UnrealizedPnL { get; private set; }

        public PnLMessage(int reqId, double dailyPnL, double unrealizedPnL)
        {
            ReqId = reqId;
            DailyPnL = dailyPnL;
            UnrealizedPnL = unrealizedPnL;
        }
    }
}
