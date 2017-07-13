/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace IBApi
{
    public static class IBParamsList
    {
        public static void AddParameter(this BinaryWriter source, OutgoingMessages msgId)
        {
            AddParameter(source, (int)msgId);
        }

        public static void AddParameter(this BinaryWriter source, int value)
        {
            AddParameter(source, value.ToString(CultureInfo.InvariantCulture));
        }

        public static void AddParameter(this BinaryWriter source, double value)
        {
            AddParameter(source, value.ToString(CultureInfo.InvariantCulture));
        }

        public static void AddParameter(this BinaryWriter source, bool value)
        {
            if (value)
                AddParameter(source, "1");
            else
                AddParameter(source, "0");

        }

        public static void AddParameter(this BinaryWriter source, string value)
        {
            if (value != null)
                source.Write(UTF8Encoding.UTF8.GetBytes(value));
            source.Write(Constants.EOL);
        }

        public static void AddParameter(this BinaryWriter source, Contract value)
        {
            source.AddParameter(value.ConId);
            source.AddParameter(value.Symbol);
            source.AddParameter(value.SecType);
            source.AddParameter(value.LastTradeDateOrContractMonth);
            source.AddParameter(value.Strike);
            source.AddParameter(value.Right);
            source.AddParameter(value.Multiplier);
            source.AddParameter(value.Exchange);
            source.AddParameter(value.PrimaryExch);
            source.AddParameter(value.Currency);
            source.AddParameter(value.LocalSymbol);
            source.AddParameter(value.TradingClass);
            source.AddParameter(value.IncludeExpired);
        }

        public static void AddParameter(this BinaryWriter source, List<TagValue> options)
        {
            StringBuilder tagValuesStr = new StringBuilder();
            int tagValuesCount = options == null ? 0 : options.Count;

            for (int i = 0; i < tagValuesCount; i++)
            {
                TagValue tagValue = options[i];
                tagValuesStr.Append(tagValue.Tag).Append("=").Append(tagValue.Value).Append(";");
            }
            
            source.AddParameter(tagValuesStr.ToString());
        }

        public static void AddParameterMax(this BinaryWriter source, double value)
        {
            if (value == Double.MaxValue)
                source.Write(Constants.EOL);
            else
                source.AddParameter(value);

        }

        public static void AddParameterMax(this BinaryWriter source, int value)
        {
            if (value == Int32.MaxValue)
                source.Write(Constants.EOL);
            else
                source.AddParameter(value);
        }

    }
}
