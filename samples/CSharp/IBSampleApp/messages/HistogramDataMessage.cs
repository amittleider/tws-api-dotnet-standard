using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class HistogramDataMessage
    {
        public int ReqId { get; private set; }
        public IBApi.HistogramEntry[] Data { get; private set; }

        public HistogramDataMessage(int reqId, IBApi.HistogramEntry[] data)
        {
            ReqId = reqId;
            Data = data;
        }
    }
}
