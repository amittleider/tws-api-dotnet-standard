using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Text;

namespace TwsRtdServer
{
    [ProgId("Tws.TwsRtdServerCtrl")]
    [Guid("77F86AC4-9BE9-4245-BBE3-DF18996EADFE")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]

    public partial class TwsRtdServer : IRtdServer
    {
        // vars
        private IRTDUpdateEvent m_callback;
        private IDictionary<string, TwsRtdServerConnection> m_connections; // connections map: connectionStr(e.g. 127.0.0.1_4001_1) => TwsRtdServerConnection
        private IDictionary<int, TwsRtdServerTopicIdMap> m_topicIdMap; // map: topicId => TwsRtdServerTopicIdMap(connectionStr/mktDataRequestId/topicStr) - to quickly find connection/mktDataRequest/topic
        private List<int> m_updatedTopicIds = new List<int>(); // list of updated topicIds (need to sent updates back to Excel)

        // constructor
        public TwsRtdServer() {}

        // this method is called when RTD server is started
        public int ServerStart(IRTDUpdateEvent callback)
        {
            Console.WriteLine("TwsRtdServer Start");
            // create empty arrays/lists
            if (m_topicIdMap == null)
            {
                m_topicIdMap = new Dictionary<int, TwsRtdServerTopicIdMap>();
            }

            if (m_connections == null)
            {
                m_connections = new Dictionary<string, TwsRtdServerConnection>();
            }

            m_callback = callback;

            return 1;
        }

        // this method is called when RTD server is stopped (last topic is removed)
        public void ServerTerminate()
        {
            Console.WriteLine("TwsRtdServer Terminate");

            foreach (var connectionStr in m_connections.Keys.ToArray())
            {
                TwsRtdServerConnection connection = null;
                if (m_connections.TryGetValue(connectionStr, out connection))
                {
                    if (connection.MktDataRequestsCount() <= 0)
                    {
                        connection.TwsRtdServerConnectionDisconnect();
                        m_connections.Remove(connectionStr);
                    }
                }
            }
        }

        public int Heartbeat()
        {
            return 1;
        }

        // this method is called when new topic is requested
        public object ConnectData(int topicId, ref Array strings, ref bool newValues)
        {
            string connectionStr, mktDataRequestStr, topicStr;

            newValues = true;

            try
            {
                // parse input strings (connection, marketDataRequest and topic)
                connectionStr = TwsRtdServerConnection.ParseConnectionStrings(strings);
                mktDataRequestStr = TwsRtdServerMktDataRequest.ParseMktDataRequestStrings(strings);
                topicStr = TwsRtdServerTopic.ParseTopicStrings(strings);

                // check that connectioStr, mktDataRequestStr and topicStr is not null
                if (connectionStr == null)
                {
                    return "TwsRtdServer: Cannot parse connection strings";
                }
                if (mktDataRequestStr == null)
                {
                    return "TwsRtdServer: Cannot parse mktDataRequest strings";
                }
                if (topicStr == null)
                {
                    return "TwsRtdServer: Cannot parse topic strings";
                }

                TwsRtdServerConnection connection = null;
                // find connection from RTD server to TWS (to reuse existing connection and not to create new one)
                if (!m_connections.TryGetValue(connectionStr, out connection))
                {
                    // if connection is not found, then create new one and add it to collection
                    connection = new TwsRtdServerConnection(this, connectionStr);

                    // save connection
                    m_connections.Add(connectionStr, connection);
                }

                if (connection != null && connection.GetErrorCode() != -1)
                {
                    // error connecting to TWS
                    return "TwsRtdServer error: " + connection.GetErrorText();
                }

                TwsRtdServerMktDataRequest mktDataRequest = connection.GetOrAddMktDataRequest(mktDataRequestStr);
                string errorStr = null;

                if (mktDataRequest != null)
                {
                    // save topicId -> connection/mktDataRequest/topicStr map
                    m_topicIdMap.Add(topicId, new TwsRtdServerTopicIdMap(connectionStr, mktDataRequest.TwsReqId(), topicStr));
                    if (mktDataRequest.GetErrorCode() != -1 
                        && mktDataRequest.GetErrorCode() != TwsRtdServerErrors.REQUESTED_MARKET_DATA_NOT_SUBSCRIBED)
                    {
                        // error creating market data request
                        return errorStr = "TwsRtdServer error: " + mktDataRequest.GetErrorText();
                    }
                } 
                else
                {
                    // error creating market data request
                    return errorStr = "TwsRtdServer error: market data request creation error";
                }

                TwsRtdServerTopic topic = mktDataRequest.GetOrAddTopic(topicStr, topicId);
                if (topic == null)
                {
                    // error creating topic
                    return errorStr = "TwsRtdServer error: topic creation error";
                }

                // check if topic is delayed type
                if (topic != null && Array.IndexOf(TwsRtdServerData.DelayedTopics(), topic.TopicStr()) < 0 
                    && mktDataRequest.GetErrorCode() == TwsRtdServerErrors.REQUESTED_MARKET_DATA_NOT_SUBSCRIBED)
                {
                    errorStr = "TwsRtdServer error: " + mktDataRequest.GetErrorText();
                }

                return ((topic != null && errorStr == null) ? topic.TopicValue() : errorStr);
            }
            catch
            {
                return "RTDServer: Error connecting data";
            }
        }
        
        // this method is called when topic is removed
        public void DisconnectData(int topicId)
        {
            try
            {
                // find appropriate connection, mktDataRequest and topic
                TwsRtdServerTopicIdMap twsRtdServerTopicIdMap = null;
                if (!m_topicIdMap.TryGetValue(topicId, out twsRtdServerTopicIdMap))
                {
                    return;
                }

                // get appropriate connection
                TwsRtdServerConnection connection = null;
                if (!m_connections.TryGetValue(twsRtdServerTopicIdMap.ConnectionStr(), out connection))
                {
                    return;
                }

                // get appropriate mktDataRequest
                TwsRtdServerMktDataRequest mktDataRequest = connection.GetMktDataRequest(twsRtdServerTopicIdMap.TwsReqId());
                if (mktDataRequest != null)
                {
                    // get appropriate topic
                    TwsRtdServerTopic topic = mktDataRequest.GetTopic(twsRtdServerTopicIdMap.TopicStr());
                    if (topic != null)
                    {
                        // remove topic
                        mktDataRequest.RemoveTopic(twsRtdServerTopicIdMap.TopicStr());
                    }

                    m_topicIdMap.Remove(topicId);
                    // remove topicId from updatedTopicIds
                    lock (m_updatedTopicIds)
                    {
                        m_updatedTopicIds.Remove(topicId);
                    }

                    // try to remove mktDataRequest
                    connection.RemoveMktDataRequest(twsRtdServerTopicIdMap.TwsReqId());
                }
            }
            catch
            {
                // error disconnecting data
            }
        }

        // method is called when there are new data to update
        public Array RefreshData(ref int topicCount)
        {

            object[,] data = null;

            try
            {
                TwsRtdServerConnection connection = null;
                TwsRtdServerMktDataRequest mktDataRequest = null;
                TwsRtdServerTopic topic = null;

                // in loop - update all topics from updatedTopicIds array
                int[] updatedTopicIds;
                lock (m_updatedTopicIds)
                {
                    updatedTopicIds = m_updatedTopicIds.ToArray();
                    m_updatedTopicIds.Clear();
                }

                topicCount = updatedTopicIds.Length;
                data = new object[2, topicCount];

                int n = 0;
                foreach(var topicId in updatedTopicIds)
                {
                    TwsRtdServerTopicIdMap twsRtdServerTopicIdMap = null;
                    if (m_topicIdMap.TryGetValue(topicId, out twsRtdServerTopicIdMap))
                    {
                        // get appropriate connection
                        if (m_connections.TryGetValue(twsRtdServerTopicIdMap.ConnectionStr(), out connection))
                        {
                            // get appropriate mktDataRequest
                            mktDataRequest = connection.GetMktDataRequest(twsRtdServerTopicIdMap.TwsReqId());
                            if (mktDataRequest != null)
                            {
                                // get appropriate topic
                                topic = mktDataRequest.GetTopic(twsRtdServerTopicIdMap.TopicStr());
                            }
                            if (topic != null)
                            {
                                // update data array with topic.Id and topic.Value
                                data[0, n] = topic.TopicId();
                                data[1, n] = topic.TopicValue();
                                n++;
                            }
                        }
                    }
                }
            }
            catch //(COMException comException)
            {
                // comException.Message = "The message filter indicated that the application is busy. (Exception from HRESULT: 0x8001010A (RPC_E_SERVERCALL_RETRYLATER))"
                // Console.WriteLine(comException.Message);
            }

            return data;
        }

        public void AddUpdatedTopicId(int topicId)
        {
            try
            {
                lock (m_updatedTopicIds)
                {
                    if (!m_updatedTopicIds.Contains(topicId))
                    {
                        m_updatedTopicIds.Add(topicId);
                    }
                }
                m_callback.UpdateNotify();
            }
            catch //(COMException comException)
            {
                 // comException.Message = "The message filter indicated that the application is busy. (Exception from HRESULT: 0x8001010A (RPC_E_SERVERCALL_RETRYLATER))"
                 // Console.WriteLine(comException.Message);
            }
        }
        public void AddUpdatedTopicIds(List<int> topicIds)
        {
            try
            {
                lock (m_updatedTopicIds)
                {
                    m_updatedTopicIds.AddRange(topicIds);
                }
                m_callback.UpdateNotify();
            }
            catch //(COMException comException)
            {
                // comException.Message = "The message filter indicated that the application is busy. (Exception from HRESULT: 0x8001010A (RPC_E_SERVERCALL_RETRYLATER))"
                // Console.WriteLine(comException.Message);
            }
        }

    } //TwsRtdServer

}
