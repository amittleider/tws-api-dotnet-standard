/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;
using System.Threading;

namespace Samples
{
    public class RequestContractDetails : EWrapperImpl
    {
        private bool isFinished = false;

        public bool IsFinished
        {
            get { return isFinished; }
            set { isFinished = value; }
        }
        
        public static int Main(string[] args)
        {
            RequestContractDetails testImpl = new RequestContractDetails();
            testImpl.ClientSocket.eConnect("127.0.0.1", 7496, 0);
            while (testImpl.NextOrderId <= 0) { }

            //We can request the whole option's chain by giving a brief description of the contract
            //i.e. we only specify symbol, currency, secType and exchange (SMART)
            Contract optionContract = ContractSamples.OptionForQuery();

            testImpl.ClientSocket.reqContractDetails(1, optionContract);

            while (!testImpl.isFinished) { }
            Thread.Sleep(10000);
            Console.WriteLine("Disconnecting...");
            testImpl.ClientSocket.eDisconnect();
            return 0;
        }
        
        public override void contractDetailsEnd(int reqId)
        {
            Console.WriteLine("Finished receiving all matching contracts.");
            isFinished = true;
        }

        public override void contractDetails(int reqId, ContractDetails contractDetails)
        {
            Console.WriteLine("/*******Incoming Contract Details - RequestId "+reqId+"************/");
            Console.WriteLine(contractDetails.Contract.Symbol + " " + contractDetails.Contract.SecType + " @ " + contractDetails.Contract.Exchange);
            Console.WriteLine("lastTradeDate: " + contractDetails.Contract.LastTradeDateOrContractMonth + ", Right: " + contractDetails.Contract.Right);
            Console.WriteLine("Strike: " + contractDetails.Contract.Strike + ", Multiplier: " + contractDetails.Contract.Multiplier);
            Console.WriteLine("/*******     End     *************/\n");
        }

    }
}
