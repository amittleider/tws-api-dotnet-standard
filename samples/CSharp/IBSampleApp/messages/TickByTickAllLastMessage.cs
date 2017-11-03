using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class TickByTickAllLastMessage
    {
        public int ReqId { get; private set; }
        public int TickType { get; private set; }
        public long Time { get; private set; }
        public double Price { get; private set; }
        public long Size { get; private set; }
        public TickAttrib Attribs { get; private set; }
        public string Exchange { get; private set; }
        public string SpecialConditions { get; private set; }

        public TickByTickAllLastMessage(int reqId, int tickType, long time, double price, long size, TickAttrib attribs, string exchange, string specialConditions)
        {
            ReqId = reqId;
            TickType = tickType;
            Time = time;
            Price = price;
            Size = size;
            Attribs = attribs;
            Exchange = exchange;
            SpecialConditions = specialConditions;
        }
    }
}
