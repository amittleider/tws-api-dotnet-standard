using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    class DailyPnLMessage
    {
        public int ReqId { get; private set; }
        public double DailyPnL { get; private set; }

        public DailyPnLMessage(int reqId, double dailyPnL)
        {
            this.ReqId = reqId;
            this.DailyPnL = dailyPnL;
        }
    }
}
