using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    class DailyPnLSingleMessage
    {
        public int ReqId { get; private set; }
        public int Pos { get; private set; }
        public double DailyPnL { get; private set; }
        public double Value { get; private set; }

        public DailyPnLSingleMessage(int reqId, int pos, double dailyPnL, double value)
        {
            // TODO: Complete member initialization
            this.ReqId = reqId;
            this.Pos = pos;
            this.DailyPnL = dailyPnL;
            this.Value = value;
        }
    }
}
