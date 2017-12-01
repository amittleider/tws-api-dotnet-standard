using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class TickByTickMidPointMessage
    {
        public int ReqId { get; private set; }
        public long Time { get; private set; }
        public double MidPoint { get; private set; }

        public TickByTickMidPointMessage(int reqId, long time, double midPoint)
        {
            ReqId = reqId;
            Time = time;
            MidPoint = midPoint;
        }
    }
}
