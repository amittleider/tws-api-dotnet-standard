using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.ui
{
    class SecurityDefinitionOptionParameterMessage : IBMessage
    {
        public int ReqId { get; private set; }
        public string Exchange { get; private set; }
        public int UnderlyingConId { get; private set; }
        public string TradingClass { get; private set; }
        public string Multiplier { get; private set; }
        public HashSet<string> Expirations { get; private set; }
        public HashSet<double> Strikes { get; private set; }

        public SecurityDefinitionOptionParameterMessage(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            this.Type = MessageType.SecurityDefinitionOptionParameter;
            this.ReqId = reqId;
            this.Exchange = exchange;
            this.UnderlyingConId = underlyingConId;
            this.TradingClass = tradingClass;
            this.Multiplier = multiplier;
            this.Expirations = expirations;
            this.Strikes = strikes;
        }
    }
}
