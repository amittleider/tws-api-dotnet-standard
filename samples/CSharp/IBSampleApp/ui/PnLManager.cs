using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class PnLManager
    {
        private int pnlReqId = 0;
        private IBClient ibClient;
        private int pnlSingleReqId = 0;

        public void ReqPnL(string account, string modelCode)
        {
            pnlReqId = new Random(DateTime.Now.Millisecond).Next();

            ibClient.ClientSocket.reqPnL(pnlReqId, account, modelCode);
        }

        public void CancelPnL()
        {
            if (pnlReqId != 0)
            {
                ibClient.ClientSocket.cancelPnL(pnlReqId);

                pnlReqId = 0;
            }
        }

        public void ReqPnLSingle(string account, string modelCode, int conId)
        {
            pnlSingleReqId = new Random(DateTime.Now.Millisecond).Next();

            ibClient.ClientSocket.reqPnLSingle(pnlSingleReqId, account, modelCode, conId);
        }

        public void CancelPnLSingle()
        {
            if (pnlSingleReqId != 0)
            {
                ibClient.ClientSocket.cancelPnLSingle(pnlSingleReqId);

                pnlSingleReqId = 0;
            }
        }

        public PnLManager(IBClient ibClient)
        {
            this.ibClient = ibClient;
        }
    }
}
