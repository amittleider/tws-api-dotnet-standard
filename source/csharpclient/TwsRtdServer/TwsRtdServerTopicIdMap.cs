namespace TwsRtdServer
{
    // class to map topicId to connectionStr/mktDataRequestId/topicStr
    // required to quickly access connectionStr/mktDataRequestId/topicStr by topicId
    class TwsRtdServerTopicIdMap
    {
        private string m_connectionStr = ""; // connection string
        private int m_twsReqId = -1; // TWS API reqMktData reqId
        private string m_topicStr = ""; // topic string

        // constructor
        public TwsRtdServerTopicIdMap(string connectionStr, int twsReqId, string topicStr)
        {
            m_connectionStr = connectionStr;
            m_twsReqId = twsReqId;
            m_topicStr = topicStr;
        }

        // gets
        public string ConnectionStr() 
        { 
            return m_connectionStr; 
        }
        
        public int TwsReqId() 
        { 
            return m_twsReqId; 
        }
        
        public string TopicStr() 
        { 
            return m_topicStr; 
        }
    }
}
