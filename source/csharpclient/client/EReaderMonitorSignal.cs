using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IBApi
{
    public class EReaderMonitorSignal : EReaderSignal
    {
        object cs = new object();
        bool open = false;

        public void issueSignal()
        {
            lock (cs)
            {
                open = true;

                Monitor.PulseAll(cs);
            }
        }

        public void waitForSignal()
        {
            lock (cs)
            {
                while (!open)
                    Monitor.Wait(cs);

                open = false;
            }
        }
    }
}
