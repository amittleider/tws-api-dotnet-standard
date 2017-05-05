using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class DailyPnLManager
    {
        private int dailyPnLReqId = 0;
        private IBClient ibClient;
        private int dailyPnLSingleReqId = 0;

        public void ReqDailyPnL(string account, string modelCode)
        {
            dailyPnLReqId = new Random(DateTime.Now.Millisecond).Next();

            ibClient.ClientSocket.reqDailyPnL(dailyPnLReqId, account, modelCode);
        }

        public void CancelDailyPnL()
        {
            if (dailyPnLReqId != 0)
            {
                ibClient.ClientSocket.cancelDailyPnL(dailyPnLReqId);

                dailyPnLReqId = 0;
            }
        }

        public void ReqDailyPnLSingle(string account, string modelCode, int conId)
        {
            dailyPnLSingleReqId = new Random(DateTime.Now.Millisecond).Next();

            ibClient.ClientSocket.reqDailyPnLSingle(dailyPnLSingleReqId, account, modelCode, conId);
        }

        public void CancelDailyPnLSingle()
        {
            if (dailyPnLSingleReqId != 0)
            {
                ibClient.ClientSocket.cancelDailyPnLSingle(dailyPnLSingleReqId);

                dailyPnLSingleReqId = 0;
            }
        }

        public DailyPnLManager(IBClient ibClient)
        {
            this.ibClient = ibClient;
        }
    }
}
