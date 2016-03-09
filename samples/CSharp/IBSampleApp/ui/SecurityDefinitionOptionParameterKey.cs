using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSampleApp.ui
{
    class SecDefOptParamKey
    {
        private int underlyingConId;
        private string tradingClass;
        private string multiplier;

        public SecDefOptParamKey(int underlyingConId, string tradingClass, string multiplier)
        {
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
            return underlyingConId + tradingClass.GetHashCode() + multiplier.GetHashCode();
        }

        public override string ToString()
        {
            return underlyingConId + " " + tradingClass + " " + multiplier;
        }
    }
}
