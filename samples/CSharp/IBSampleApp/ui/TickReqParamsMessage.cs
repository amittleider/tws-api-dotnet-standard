using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class TickReqParamsMessage : IBMessage
    {
        public int TickerId { get; private set; }
        public double MinTick { get; private set; }
        public string BboExchange { get; private set; }
        public int SnapshotPermissions { get; private set; }

        public TickReqParamsMessage(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            type = MessageType.TickReqParams;
            TickerId = tickerId;
            MinTick = minTick;
            BboExchange = bboExchange;
            SnapshotPermissions = snapshotPermissions;
        }
    }
}
