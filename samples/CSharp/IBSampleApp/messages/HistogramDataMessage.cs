using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class HistogramDataMessage
    {
        public int ReqId { get; private set; }
        public Tuple<double, long>[] Data { get; private set; }

        public HistogramDataMessage(int reqId, Tuple<double, long>[] data)
        {
            ReqId = reqId;
            Data = data;
        }
    }
}
