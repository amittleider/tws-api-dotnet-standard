using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using IBApi;
using System.Threading;

namespace TwsRtdServer
{
    // class represents TWS connection
    public class TwsRtdServerConnection
    {
        private int m_twsReqIdNext; // TWS API reqMktData next reqId

        // vars
        private EClientSocket m_eClientSocket;
        private EReaderSignal m_eReaderSignal = new EReaderMonitorSignal();
        private TwsRtdServerWrapper m_twsRtdServerWrapper;

        private string m_host;
        private int m_port;
        private int m_clientId;
        private Tuple<int, string> m_error;

        private IDictionary<int, TwsRtdServerMktDataRequest> m_mktDataRequests = new Dictionary<int, TwsRtdServerMktDataRequest>(); // mktDataRequest map: twsReqId => TwsRtdServerMktDataRequest
        private IDictionary<string, int> m_mktDataRequestsStrToIdMapping = new Dictionary<string, int>(); // map: mktDataRequestStr(e.g. "IBM_STK_...") => twsReqId

        // constructor
        public TwsRtdServerConnection(TwsRtdServer twsRtdServer, string connectionStr)
        {
            try
            {
                SetError(TwsRtdServerErrors.NO_ERROR);

                m_twsReqIdNext = 0;

                // parse connection string to host/port
                ExtractConnectionParams(connectionStr);

                // check for error
                if (GetErrorCode() != TwsRtdServerErrors.NO_ERROR)
                {
                    return;
                }

                m_twsRtdServerWrapper = new TwsRtdServerWrapper(twsRtdServer, this);

                this.m_eClientSocket = new EClientSocket(m_twsRtdServerWrapper, m_eReaderSignal);

                // connect to TWS
                this.m_eClientSocket.eConnect(m_host, m_port, m_clientId, false);

                if (m_eClientSocket.ServerVersion == 0)
                {
                    SetError(TwsRtdServerErrors.CANNOT_CONNECT_TO_TWS); // TwsRtdServer: error connecting to TWS
                    return;
                }

                var reader = new EReader(m_eClientSocket, m_eReaderSignal);

                reader.Start();

                new Thread(() =>
                {
                    while (m_eClientSocket.IsConnected())
                    {
                        m_eReaderSignal.waitForSignal();
                        reader.processMsgs();
                    }
                }) { IsBackground = true }.Start();

                // wait 5 seconds till fully connected
                int i = 0;
                while (m_twsRtdServerWrapper.NextOrderId <= 0 && i < 50)
                {
                    Thread.Sleep(100);
                    i++;
                }
                if (i >= 50)
                {
                    SetError(TwsRtdServerErrors.CANNOT_CONNECT_TO_TWS); // TwsRtdServer: error connecting to TWS
                }

                // send request market data type
                this.m_eClientSocket.reqMarketDataType(2);
                this.m_eClientSocket.reqMarketDataType(4);
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_CONNECT_TO_TWS); // TwsRtdServer: error connecting to TWS
            }

        }

        public TwsRtdServerMktDataRequest GetOrAddMktDataRequest(string mktDataRequestStr)
        {
            TwsRtdServerMktDataRequest mktDataRequest = null;

            int mktDataRequestId;

            // find mktdata request (TWS reqMktData) (to reuse existing mktdata request and not to create new one)
            if (mktDataRequestStr != null && (!m_mktDataRequestsStrToIdMapping.TryGetValue(mktDataRequestStr, out mktDataRequestId) || 
                                                !m_mktDataRequests.TryGetValue(mktDataRequestId, out mktDataRequest)))
            {
                // if marketdata request was not found, then create new one
                mktDataRequest = new TwsRtdServerMktDataRequest(mktDataRequestStr, m_twsReqIdNext, this);
                    
                // mktdata request was successfully sent to TWS
                m_mktDataRequests.Add(m_twsReqIdNext, mktDataRequest);
                m_mktDataRequestsStrToIdMapping.Add(mktDataRequestStr, m_twsReqIdNext);
                m_twsReqIdNext++;
            }

            return mktDataRequest;
        }
        
        public void RemoveMktDataRequest(int twsReqId)
        {
            TwsRtdServerMktDataRequest mktDataRequest = null;
            if (m_mktDataRequests.TryGetValue(twsReqId, out mktDataRequest))
            {
                // if collection of topics is empty, then remove mktdatarequest
                if (mktDataRequest.TopicsCount() <= 0)
                {
                    // cancel TWS market data request
                    mktDataRequest.TwsRtdServerMktDataRequestCancel(twsReqId, this);

                    // remove mktDataRequest from collection using key==reqId
                    m_mktDataRequests.Remove(twsReqId);

                    // remove str->reqId mapping using key==str
                    m_mktDataRequestsStrToIdMapping.Remove(mktDataRequest.MktDataRequestStr());
                }
            }
        }

        public void TwsRtdServerConnectionDisconnect()
        {
            if (m_eClientSocket != null)
            {
                m_eClientSocket.eDisconnect();
            }
        }

        public TwsRtdServerMktDataRequest GetMktDataRequest(int twsReqId)
        {
            TwsRtdServerMktDataRequest mktDataRequest;
            return m_mktDataRequests.TryGetValue(twsReqId, out mktDataRequest) ? mktDataRequest : null;
        }

        public int MktDataRequestsCount()
        {
            return m_mktDataRequests.Count;
        }

        public EClientSocket Socket()
        {
            return m_eClientSocket;
        }

        private void ExtractConnectionParams(string connectionString)
        {
            try
            {
                string[] connectionParams = connectionString.Split(TwsRtdServerData.CHAR_UNDERSCORE);
                if (connectionParams != null && connectionParams.Length >= 3)
                {
                    m_host = connectionParams[0];
                    m_port = int.Parse(connectionParams[1]);
                    m_clientId = int.Parse(connectionParams[2]);
                }
            }
            catch
            {
                SetError(TwsRtdServerErrors.CANNOT_EXTRACT_CONNECTION_PARAMS);
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

        public static string ParseConnectionStrings(Array strings)
        {
            string hostStr = null;
            string portStr = null;
            string clientIdStr = null;

            if (strings != null)
            {
                foreach (string s in strings)
                {
                    if (hostStr == null && s.ToLower().IndexOf(TwsRtdServerData.HOST_STR) >= 0)
                    {
                        // parse string like "host=127.0.0.1"
                        hostStr = s.Substring(TwsRtdServerData.HOST_STR.Length, s.Length - TwsRtdServerData.HOST_STR.Length).ToUpper();
                    }

                    if (portStr == null && s.ToLower().IndexOf(TwsRtdServerData.PORT_STR) >= 0)
                    {
                        // parse string like "port=7496"
                        portStr = s.Substring(TwsRtdServerData.PORT_STR.Length, s.Length - TwsRtdServerData.PORT_STR.Length).ToUpper();
                    }

                    if (clientIdStr == null && s.ToLower().IndexOf(TwsRtdServerData.CLIENT_ID_STR) >= 0)
                    {
                        // parse string like "clientid=1"
                        clientIdStr = s.Substring(TwsRtdServerData.CLIENT_ID_STR.Length, s.Length - TwsRtdServerData.CLIENT_ID_STR.Length).ToUpper();
                    }

                    if (portStr == null && s.ToLower().CompareTo(TwsRtdServerData.PAPER_STR) == 0)
                    {
                        // parse string "paper"
                        portStr = TwsRtdServerData.PAPER_PORT; // 7497
                    }

                    if (portStr == null && s.ToLower().CompareTo(TwsRtdServerData.GATEWAY_STR) == 0)
                    {
                        // parse string "gw"
                        portStr = TwsRtdServerData.GATEWAY_PORT; // 4001
                    }

                    if (portStr == null && s.ToLower().CompareTo(TwsRtdServerData.GATEWAY_PAPER_STR) == 0)
                    {
                        // parse string "gwpaper"
                        portStr = TwsRtdServerData.GATEWAY_PAPER_PORT; // 4002
                    }
                }
            }

            if (hostStr == null)
            {
                // host not found, use default
                hostStr = TwsRtdServerData.DEFAULT_HOST;
            }

            if (portStr == null)
            {
                // port not found, use default
                portStr = TwsRtdServerData.DEFAULT_PORT;
            }

            if (clientIdStr == null)
            {
                // clientId not found, use default
                clientIdStr = TwsRtdServerData.DEFAULT_CLIENT_ID.ToString();
            }

            return hostStr + TwsRtdServerData.CHAR_UNDERSCORE + portStr + TwsRtdServerData.CHAR_UNDERSCORE + clientIdStr;
        }
    }
}
