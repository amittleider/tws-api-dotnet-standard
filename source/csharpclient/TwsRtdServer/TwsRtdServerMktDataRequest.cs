using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using IBApi;
using System.Text;
using System.Globalization;

namespace TwsRtdServer
{
    public class TwsRtdServerMktDataRequest
    {
        private IDictionary<string, TwsRtdServerTopic> m_topics = new ConcurrentDictionary<string, TwsRtdServerTopic>(); // map of topics
        private string m_mktDataRequestStr;
        private int m_twsReqId; // TWS API reqMktData current reqId
        private TwsRtdServerMktDataTicks m_mktDataTicks = new TwsRtdServerMktDataTicks(); // latest ticks (we should save ticks in case of non-streaming market data)
        private TwsRtdServerConnection m_twsRtdServerConnection;

        private Tuple<int, string> m_error;

        // constructor
        public TwsRtdServerMktDataRequest(string mktDataRequestStr, int twsReqId, TwsRtdServerConnection twsRtdServerConnection){

            try
            {
                SetError(TwsRtdServerErrors.NO_ERROR);

                m_twsRtdServerConnection = twsRtdServerConnection;
                m_mktDataRequestStr = mktDataRequestStr;
                m_twsReqId = twsReqId;

                // create empty contract
                Contract contract = new Contract();
                
                // parse string into contract
                contract = ExtractContract(m_mktDataRequestStr);

                if (GetErrorCode() != TwsRtdServerErrors.NO_ERROR)
                {
                    return;
                }

                // extract mkt data options
                List<TagValue> mktDataOptions = ExtractOptions(m_mktDataRequestStr);

                if (GetErrorCode() != TwsRtdServerErrors.NO_ERROR)
                {
                    return;
                }

                // extract generic ticks
                string genericTicks = ExtractGenericTicks(m_mktDataRequestStr, contract.SecType);

                if (GetErrorCode() != TwsRtdServerErrors.NO_ERROR)
                {
                    return;
                }

                // request market data
                EClientSocket socket = twsRtdServerConnection.Socket();
                if (socket == null)
                {
                    SetError(TwsRtdServerErrors.SOCKET_IS_NULL);
                    return;
                }

                socket.reqMktData(m_twsReqId, contract, genericTicks, false, false, mktDataOptions);
            }
            catch
            {
                SetError(TwsRtdServerErrors.REQUEST_MKT_DATA_ERROR);
            }
        }

        public int GetErrorCode()
        {
            return m_error.Item1;
        }

        public string GetErrorText()
        {
            return m_error.Item2;
        }

        public void SetError(int code)
        {
            m_error = new Tuple<int, string>(code, TwsRtdServerErrors.GetErrorText(code));
        }

        public void SetError(int code, string text)
        {
            m_error = new Tuple<int, string>(code, text);
        }

        public void TwsRtdServerMktDataRequestCancel(int reqId, TwsRtdServerConnection connection)
        {
            // cancel market data
            connection.Socket().cancelMktData(reqId);
        }

        public List<int> SetAllTopicsValues(string value)
        {
            // set all topic values to value (e.g. in case of error) and return list of updated topic ids
            List<int> m_updatedTopicIds = new List<int>();
            foreach (TwsRtdServerTopic topic in m_topics.Values)
            {
                topic.TopicValue(value);
                m_updatedTopicIds.Add(topic.TopicId());
            }

            return m_updatedTopicIds;
        }

        public List<int> SetAllLiveTopicsValues(string value)
        {
            // set all live topic values to value (e.g. in case of error) and return list of updated topic ids
            List<int> m_updatedTopicIds = new List<int>();
            foreach (TwsRtdServerTopic topic in m_topics.Values)
            {
                if (Array.IndexOf(TwsRtdServerData.DelayedTopics(), topic.TopicStr()) < 0)
                {
                    topic.TopicValue(value);
                    m_updatedTopicIds.Add(topic.TopicId());
                }
            }

            return m_updatedTopicIds;
        }

        public TwsRtdServerTopic GetOrAddTopic(string topicStr, int topicId)
        {
            // find topic (to reuse existing topic and not create new one)
            TwsRtdServerTopic topic = null;

            if (topicStr != null && !m_topics.TryGetValue(topicStr, out topic))
            {
                // if topic was not found, then create new one
                topic = new TwsRtdServerTopic(topicStr, topicId);
                // add [topicStr=>topic] mapping to collection of topics
                m_topics.Add(topicStr, topic);

                // set initial value of topic (in case of non-streaming market data)
                topic.TopicValue(m_mktDataTicks.GetValue(topicStr));
            }

            return topic;
        }

        public bool ContainsTopic(string topicStr)
        {
            return m_topics.ContainsKey(topicStr);
        }

        public int TopicsCount()
        {
            return m_topics.Count;
        }

        public TwsRtdServerTopic GetTopic(string topicStr)
        {
            TwsRtdServerTopic topic;
            return m_topics.TryGetValue(topicStr, out topic) ? topic : null;
        }

        public void RemoveTopic(string topicStr)
        {
            m_topics.Remove(topicStr);
        }

        public string MktDataRequestStr()
        {
            return m_mktDataRequestStr;
        }

        public int TwsReqId()
        {
            return m_twsReqId;
        }

        public Contract ExtractContract(string mktDataRequest)
        {
            Contract contract = new Contract();

            string[] strings = mktDataRequest.Split(TwsRtdServerData.CHAR_UNDERSCORE);
            if (strings.Length != 16)
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_CONTRACT, "Cannot extract contract from " + mktDataRequest);
                return contract;
            }

            try
            {
                if (strings[0] != null && strings[0].Length > 0)
                {
                    contract.ConId = StrToInt(strings[0]);
                }
                contract.Symbol = strings[1];
                contract.SecType = strings[2];
                contract.LastTradeDateOrContractMonth = strings[3];
                if (strings[4] != null && strings[4].Length > 0)
                {
                    contract.Strike = StrToDouble(strings[4]);
                }
                contract.Right = strings[5];
                contract.Multiplier = strings[6];
                contract.Exchange = strings[7];
                contract.PrimaryExch = strings[8];
                contract.Currency = strings[9];
                contract.LocalSymbol = strings[10];
                contract.TradingClass = strings[11];
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_CONTRACT, "Exception during contract extraction from " + mktDataRequest);
                return contract;
            }

            // parse combo legs
            string comboStr = strings[12];
            try 
            {
                if (comboStr != null && comboStr.Length > 0)
                {
                    contract.ComboLegs = new List<ComboLeg>();
                    string[] comboLegsStr = comboStr.Split(TwsRtdServerData.CHAR_SEMICOLON);
                    foreach (string comboLegStr in comboLegsStr)
                    {
                        if (comboLegStr != null && comboLegStr.Length > 0)
                        {
                            ComboLeg comboLeg = new ComboLeg();
                            string[] comboParams = comboLegStr.Split(TwsRtdServerData.CHAR_HASH);
                            if (comboParams.Length == 4)
                            {
                                comboLeg.ConId = StrToInt(comboParams[0]);
                                comboLeg.Ratio = StrToInt(comboParams[1]);
                                string action = comboParams[2];
                                if (action != null && action.Length > 0)
                                {
                                    if (action == TwsRtdServerData.ACTION_SELL_1 || (action == TwsRtdServerData.ACTION_SELL_2))
                                    {
                                        comboLeg.Action = TwsRtdServerData.ACTION_SELL_1;
                                    }
                                    else if (action == TwsRtdServerData.ACTION_SELL_SHORT_1 || (action == TwsRtdServerData.ACTION_SELL_SHORT_2))
                                    {
                                        comboLeg.Action = TwsRtdServerData.ACTION_SELL_SHORT_1;
                                    }
                                    else // default
                                    {
                                        comboLeg.Action = TwsRtdServerData.ACTION_BUY_1;
                                    }
                                 }
                                comboLeg.Exchange = comboParams[3];
                                contract.ComboLegs.Add(comboLeg);
                            }
                            else
                            {
                                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_COMBO_LEGS, "Cannot extract combo legs from " + comboStr);
                                return contract;
                            }
                        }
                    }
                }
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_COMBO_LEGS, "Exception during combo legs extraction from " + comboStr);
                return contract;
            }

            // parse under comp
            string underCompStr = strings[13];

            try 
            {
                if (underCompStr != null && underCompStr.Length > 0)
                {
                    contract.UnderComp = new UnderComp();

                    string[] underCompParams = underCompStr.Split(TwsRtdServerData.CHAR_HASH);
                    if (underCompParams != null && underCompParams.Length >= 3)
                    {
                        try
                        {
                            contract.UnderComp.ConId = StrToInt(underCompParams[0]);
                        }
                        catch
                        {
                            SetError(TwsRtdServerErrors.CANNOT_EXTRACT_UNDER_COMP, "Cannot convert conid from " + underCompParams[0] + " : " + StrToInt(underCompParams[0]));
                            return contract;
                        }
                        try
                        {
                            contract.UnderComp.Delta = StrToDouble(underCompParams[1]);
                        }
                        catch
                        {
                            SetError(TwsRtdServerErrors.CANNOT_EXTRACT_UNDER_COMP, "Cannot convert delta from " + underCompParams[1] + " : " + StrToDouble(underCompParams[1]));
                            return contract;
                        }
                        try
                        {
                            contract.UnderComp.Price = StrToDouble(underCompParams[2]);
                        }
                        catch
                        {
                            SetError(TwsRtdServerErrors.CANNOT_EXTRACT_UNDER_COMP, "Cannot convert price from " + underCompParams[2] + " : " + StrToDouble(underCompParams[2]));
                            return contract;
                        }
                    }
                    else
                    {
                        SetError(TwsRtdServerErrors.CANNOT_EXTRACT_UNDER_COMP, "Cannot extract under comp from " + underCompStr);
                        return contract;
                    }
                }
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_UNDER_COMP, "Exception during under comp extraction from " + underCompStr);
            }

            return contract;
        }

        public List<TagValue> ExtractOptions(string mktDataRequest)
        {
            List<TagValue> options = new List<TagValue>();

            try
            {
                string[] strings = mktDataRequest.Split(TwsRtdServerData.CHAR_UNDERSCORE);
                if (strings.Length == 16)
                {
                    // parse options
                    string optionsStr = strings[14];
                    if (optionsStr != null && optionsStr.Length > 0)
                    {
                        string[] optionsParams = optionsStr.Split(TwsRtdServerData.CHAR_SEMICOLON);
                        foreach (string optionsParam in optionsParams)
                        {
                            if (optionsParam != null && optionsParam.Length > 0)
                            {
                                TagValue tagValue = new TagValue();
                                string[] tagValueStr = optionsParam.Split(TwsRtdServerData.CHAR_HASH);
                                if (tagValueStr.Length == 2)
                                {
                                    tagValue.Tag = tagValueStr[0];
                                    tagValue.Value = tagValueStr[1];
                                }
                                options.Add(tagValue);
                            }
                        }
                    }
                }
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_OPTIONS);
            }

            return options;
        }


        public string ExtractGenericTicks(string mktDataRequest, string secTypeStr)
        {
            string genericTicksStr = null;
            try
            {
                string[] strings = mktDataRequest.Split(TwsRtdServerData.CHAR_UNDERSCORE);
                if (strings.Length == 16)
                {
                    // parse generic ticks list
                    genericTicksStr = strings[15];
                }

                if ((genericTicksStr == null || genericTicksStr == "") && secTypeStr != null)
                {
                    // generic ticks
                    switch (secTypeStr)
                    {
                        case "STK":
                        case "OPT":
                            genericTicksStr = TwsRtdServerData.GENERIC_TICKS_STK;
                            break;
                        case "FUT":
                        case "FOP":
                        case "WAR":
                        case "CFD":
                        case "BOND":
                        case "CASH":
                            genericTicksStr = TwsRtdServerData.GENERIC_TICKS_FUT;
                            break;
                        case "IND":
                            genericTicksStr = TwsRtdServerData.GENERIC_TICKS_IND;
                            break;
                        default:
                            genericTicksStr = TwsRtdServerData.GENERIC_TICKS_BASE;
                            break;
                    }
                }
            }
            catch
            {
               SetError(TwsRtdServerErrors.CANNOT_EXTRACT_GENERIC_TICKS);
            }

            return genericTicksStr;
        }

        private static double StrToDouble(string str)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = TwsRtdServerData.CHAR_DOT.ToString();
            double num;
            return (double.TryParse(str, NumberStyles.AllowDecimalPoint, provider, out num) ? num : 0);
        }

        private int StrToInt(string str){
            int number;
            return (int.TryParse(str, out number) ? number : 0);
        }

        public static string ParseMktDataRequestStrings(Array strings)
        {
            string mktDataRequestStr = null;

            // contract
            string symbolStr = null;
            string exchStr = null;
            string primExchStr = null;
            string secTypeStr = null;
            string expirationStr = null;
            string rightStr = null;
            string strikeStr = null;
            string currencyStr = null;
            string multiplierStr = null;
            string localSymbolStr = null;
            string conIdStr = null;
            string tradingClassStr = null;
            string comboStr = null;
            string underCompStr = null;
            string optionsStr = null;
            string genTicksStr = null;

            if (strings != null)
            {
                // simple syntax: first string should represent ticker
                if (strings.Length > 0)
                {
                    string tickerStr = (string)strings.GetValue(0);
                    if (tickerStr.IndexOf(TwsRtdServerData.CHAR_EQUAL) < 0)
                    {
                        if (tickerStr.IndexOf(TwsRtdServerData.CHAR_SPACE) >= 0)
                        {
                            // parse ticker string like IBM@SMART Bid, BRK B@SMART Bid, where the topic is specified within the ticker string itself
                            string lastStr = tickerStr.Substring(tickerStr.LastIndexOf(TwsRtdServerData.CHAR_SPACE) + 1, tickerStr.Length - 1 - tickerStr.LastIndexOf(TwsRtdServerData.CHAR_SPACE)).ToUpper();

                            if (Array.IndexOf(TwsRtdServerData.AllowedTopics(), lastStr) >= 0)
                            {
                                tickerStr = tickerStr.ToUpper().Substring(0, tickerStr.LastIndexOf(TwsRtdServerData.CHAR_SPACE));
                            }
                        }

                        if (tickerStr.IndexOf(TwsRtdServerData.CHAR_DOT) >= 0 && tickerStr.ToLower().IndexOf(TwsRtdServerData.HOST_STR) < 0 &&
                            tickerStr.ToLower().IndexOf(TwsRtdServerData.UNDERCOMP_STR) < 0 && tickerStr.ToUpper().IndexOf(TwsRtdServerData.CHAR_SLASH + TwsRtdServerData.CASH_STR) >= 0)
                        {
                            // parse string like "EUR.USD/CASH"
                            string[] contractStrings = tickerStr.ToUpper().Split(TwsRtdServerData.CHAR_SLASH);
                            if (contractStrings.Length >= 2)
                            {
                                secTypeStr = contractStrings[1].ToUpper();
                            }
                            // "EUR.USD"
                            string symbolAndCashStr = contractStrings[0].ToUpper();
                            symbolStr = symbolAndCashStr.Substring(0, symbolAndCashStr.IndexOf(TwsRtdServerData.CHAR_DOT));
                            currencyStr = symbolAndCashStr.Substring(symbolAndCashStr.IndexOf(TwsRtdServerData.CHAR_DOT) + 1, symbolAndCashStr.Length - symbolAndCashStr.IndexOf(TwsRtdServerData.CHAR_DOT) - 1);
                            exchStr = TwsRtdServerData.DEFAULT_CASH_EXCHANGE;
                            //break;
                        }
                        else if (tickerStr.IndexOf(TwsRtdServerData.CHAR_SLASH) >= 0)
                        {
                            // parse string like "IBM@SMART/NYSE/OPT/201701/C/90/USD"
                            string[] contractStrings = tickerStr.ToUpper().Split(TwsRtdServerData.CHAR_SLASH);
                            if (contractStrings.Length >= 7)
                            {
                                currencyStr = contractStrings[6].ToUpper();
                            }
                            if (contractStrings.Length >= 6)
                            {
                                strikeStr = contractStrings[5].ToUpper();
                            }
                            if (contractStrings.Length >= 5)
                            {
                                rightStr = contractStrings[4].ToUpper();
                            }
                            if (contractStrings.Length >= 4)
                            {
                                expirationStr = contractStrings[3].ToUpper();
                            }
                            if (contractStrings.Length >= 3)
                            {
                                secTypeStr = contractStrings[2].ToUpper();
                            }
                            if (contractStrings.Length >= 2)
                            {
                                primExchStr = contractStrings[1].ToUpper();
                            }
                            string symbolAndExchStr = contractStrings[0].ToUpper();
                            if (symbolAndExchStr.IndexOf(TwsRtdServerData.CHAR_AT) >= 0)
                            {
                                // symbol can contain dot (".") and case sensitive
                                symbolStr = symbolAndExchStr.Substring(0, symbolAndExchStr.IndexOf(TwsRtdServerData.CHAR_AT));
                                exchStr = symbolAndExchStr.Substring(symbolAndExchStr.IndexOf(TwsRtdServerData.CHAR_AT) + 1, symbolAndExchStr.Length - symbolAndExchStr.IndexOf(TwsRtdServerData.CHAR_AT) - 1);
                            }
                            else
                            {
                                symbolStr = symbolAndExchStr;
                                exchStr = TwsRtdServerData.DEFAULT_EXCHANGE;
                            }
                            //break;
                        }
                        else if (tickerStr.IndexOf(TwsRtdServerData.CHAR_AT) >= 0)
                        {
                            // parse string like "IBM@ARCA"
                            symbolStr = tickerStr.ToUpper().Substring(0, tickerStr.IndexOf(TwsRtdServerData.CHAR_AT));
                            exchStr = tickerStr.ToUpper().Substring(tickerStr.IndexOf(TwsRtdServerData.CHAR_AT) + 1, tickerStr.Length - tickerStr.IndexOf(TwsRtdServerData.CHAR_AT) - 1);
                            //break;
                        }
                        else
                        {
                            // parse string like "IBM"
                            symbolStr = tickerStr.ToUpper();
                        }
                    }
                }


                // complex syntax
                foreach (string s in strings)
                {
                    if (symbolStr == null && s.ToLower().IndexOf(TwsRtdServerData.SYMBOL_STR) >= 0)
                    {
                        // parse string like "sym=IBM"
                        symbolStr = s.Substring(TwsRtdServerData.SYMBOL_STR.Length, s.Length - TwsRtdServerData.SYMBOL_STR.Length);
                    }
                    if (secTypeStr == null && s.ToLower().IndexOf(TwsRtdServerData.SECTYPE_STR) >= 0)
                    {
                        // parse string like "sec=OPT"
                        secTypeStr = s.Substring(TwsRtdServerData.SECTYPE_STR.Length, s.Length - TwsRtdServerData.SECTYPE_STR.Length).ToUpper();
                    }
                    if (expirationStr == null && s.ToLower().IndexOf(TwsRtdServerData.EXPIRATION_STR) >= 0)
                    {
                        // parse string like "exp=20170101"
                        expirationStr = s.Substring(TwsRtdServerData.EXPIRATION_STR.Length, s.Length - TwsRtdServerData.EXPIRATION_STR.Length).ToUpper();
                    }
                    if (strikeStr == null && s.ToLower().IndexOf(TwsRtdServerData.STRIKE_STR) >= 0)
                    {
                        // parse string like "strike=90"
                        strikeStr = s.Substring(TwsRtdServerData.STRIKE_STR.Length, s.Length - TwsRtdServerData.STRIKE_STR.Length).ToUpper();
                    }
                    if (rightStr == null && s.ToLower().IndexOf(TwsRtdServerData.RIGHT_STR) >= 0)
                    {
                        // parse string like "right=C"
                        rightStr = s.Substring(TwsRtdServerData.RIGHT_STR.Length, s.Length - TwsRtdServerData.RIGHT_STR.Length).ToUpper();
                    }
                    if (multiplierStr == null && s.ToLower().IndexOf(TwsRtdServerData.MULTIPLIER_STR) >= 0)
                    {
                        // parse string like "mult=100"
                        multiplierStr = s.Substring(TwsRtdServerData.MULTIPLIER_STR.Length, s.Length - TwsRtdServerData.MULTIPLIER_STR.Length).ToUpper();
                    }
                    if (exchStr == null && s.ToLower().IndexOf(TwsRtdServerData.EXCHANGE_STR) >= 0)
                    {
                        // parse string like "exch=SMART"
                        exchStr = s.Substring(TwsRtdServerData.EXCHANGE_STR.Length, s.Length - TwsRtdServerData.EXCHANGE_STR.Length).ToUpper();
                    }
                    if (primExchStr == null && s.ToLower().IndexOf(TwsRtdServerData.PRIMARYEXCH_STR) >= 0)
                    {
                        // parse string like "prim=NYSE"
                        primExchStr = s.Substring(TwsRtdServerData.PRIMARYEXCH_STR.Length, s.Length - TwsRtdServerData.PRIMARYEXCH_STR.Length).ToUpper();
                    }
                    if (currencyStr == null && s.ToLower().IndexOf(TwsRtdServerData.CURRENCY_STR) >= 0)
                    {
                        // parse string like "cur=USD"
                        currencyStr = s.Substring(TwsRtdServerData.CURRENCY_STR.Length, s.Length - TwsRtdServerData.CURRENCY_STR.Length).ToUpper();
                    }
                    if (conIdStr == null && s.ToLower().IndexOf(TwsRtdServerData.CONID_STR) >= 0)
                    {
                        // parse string like "conid=8314"
                        conIdStr = s.Substring(TwsRtdServerData.CONID_STR.Length, s.Length - TwsRtdServerData.CONID_STR.Length).ToUpper();
                    }
                    if (localSymbolStr == null && s.ToLower().IndexOf(TwsRtdServerData.LOCALSYMBOL_STR) >= 0)
                    {
                        // parse string like "loc=IBM1DM7"
                        localSymbolStr = s.Substring(TwsRtdServerData.LOCALSYMBOL_STR.Length, s.Length - TwsRtdServerData.LOCALSYMBOL_STR.Length);
                    }
                    if (tradingClassStr == null && s.ToLower().IndexOf(TwsRtdServerData.TRADINGCLASS_STR) >= 0)
                    {
                        // parse string like "tc=IBM1D"
                        tradingClassStr = s.Substring(TwsRtdServerData.TRADINGCLASS_STR.Length, s.Length - TwsRtdServerData.TRADINGCLASS_STR.Length).ToUpper();
                    }
                    if (comboStr == null && s.ToLower().IndexOf(TwsRtdServerData.COMBO_STR) >= 0)
                    {
                        // parse string like "cmb=..."
                        comboStr = s.Substring(TwsRtdServerData.COMBO_STR.Length, s.Length - TwsRtdServerData.COMBO_STR.Length).ToUpper();
                    }
                    if (underCompStr == null && s.ToLower().IndexOf(TwsRtdServerData.UNDERCOMP_STR) >= 0)
                    {
                        // parse string like "und=..."
                        underCompStr = s.Substring(TwsRtdServerData.UNDERCOMP_STR.Length, s.Length - TwsRtdServerData.UNDERCOMP_STR.Length).ToUpper();
                    }
                    if (optionsStr == null && s.ToLower().IndexOf(TwsRtdServerData.OPTIONS_STR) >= 0)
                    {
                        // parse string like "opt=..."
                        optionsStr = s.Substring(TwsRtdServerData.OPTIONS_STR.Length, s.Length - TwsRtdServerData.OPTIONS_STR.Length).ToUpper();
                    }
                    if (genTicksStr == null && s.ToLower().IndexOf(TwsRtdServerData.GENTICKS_STR) >= 0)
                    {
                        // parse string like "genticks=..."
                        genTicksStr = s.Substring(TwsRtdServerData.GENTICKS_STR.Length, s.Length - TwsRtdServerData.GENTICKS_STR.Length).ToUpper();
                    }
                }
            }

            // defaults
            if (localSymbolStr == null || localSymbolStr.Length <= 0)
            {
                if ((secTypeStr == null || secTypeStr.Length <= 0) && conIdStr == null)
                {
                    secTypeStr = TwsRtdServerData.DEFAULT_SECTYPE;
                }
                if (exchStr == null || exchStr.Length <= 0)
                {
                    exchStr = TwsRtdServerData.DEFAULT_EXCHANGE;
                }
                if ((currencyStr == null || currencyStr.Length <= 0) && conIdStr == null)
                {
                    currencyStr = TwsRtdServerData.DEFAULT_CURRENCY;
                }
            }

            mktDataRequestStr = conIdStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                symbolStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                secTypeStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                expirationStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                strikeStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                rightStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                multiplierStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                exchStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                primExchStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                currencyStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                localSymbolStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                tradingClassStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                comboStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                underCompStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                optionsStr + TwsRtdServerData.CHAR_UNDERSCORE +
                                genTicksStr;

            return mktDataRequestStr;

        }

        public void SetMktDataTickValue(string topicStr, Object value)
        {
            m_mktDataTicks.SetValue(topicStr, value);
        }

        public Object GetMktDataTickValue(string topicStr)
        {
            return m_mktDataTicks.GetValue(topicStr);
        }
    }
}
