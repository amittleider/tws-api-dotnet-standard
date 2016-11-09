using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class SmartComponentsMessage : IBMessage
    {
        public int BitNumber { get; private set; }
        public string Exchange { get; private set; }
        public char ExchangeChar { get; private set; }

        public SmartComponentsMessage(int bitNumber, string exchange, char exchangeChar)
        {
            type = MessageType.SmartComponents;
            BitNumber = bitNumber;
            Exchange = exchange;
            ExchangeChar = exchangeChar;
        }
    }
}
