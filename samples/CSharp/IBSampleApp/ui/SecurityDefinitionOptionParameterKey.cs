using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSampleApp.ui
{
    class SecDefOptParamKey
    {
        string exchange;
        private int underlyingConId;
        private string tradingClass;
        private string multiplier;

        public SecDefOptParamKey(string exchange, int underlyingConId, string tradingClass, string multiplier)
        {
            this.exchange = exchange;
            this.underlyingConId = underlyingConId;
            this.tradingClass = tradingClass;
            this.multiplier = multiplier;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SecDefOptParamKey))
                return false;

            SecDefOptParamKey left = obj as SecDefOptParamKey;

            return left.underlyingConId == underlyingConId && left.tradingClass == tradingClass && left.multiplier == multiplier;
        }

        public override int GetHashCode()
        {
            return exchange.GetHashCode() + underlyingConId + tradingClass.GetHashCode() + multiplier.GetHashCode();
        }

        public override string ToString()
        {
            return exchange + " " + underlyingConId + " " + tradingClass + " " + multiplier;
        }
    }
}
