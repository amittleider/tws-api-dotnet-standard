/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBSampleApp.messages;
using System.Windows.Forms;
using IBSampleApp.util;
using IBApi;

namespace IBSampleApp.ui
{
    public class NewsManager
    {
        private const int TICK_NEWS_ID_BASE = 90000000;
        private const int TICK_NEWS_ID = TICK_NEWS_ID_BASE;

        int rowCountTickNewsGrid = 0;

        private IBClient ibClient;
        private DataGridView tickNewsGrid;

        public NewsManager(IBClient ibClient, DataGridView tickNewsDataGrid)
        {
            IbClient = ibClient;
            TickNewsGrid = tickNewsDataGrid;
        }

        public void UpdateUI(IBMessage message)
        {
            switch (message.Type)
            {
                case MessageType.TickNews:
                    HandleTickNews((TickNewsMessage)message);
                    break;
            }
        }

        private void HandleTickNews(TickNewsMessage tickNewsMessage)
        {
            if (tickNewsMessage.TickerId == TICK_NEWS_ID)
            {
                TickNewsGrid.Rows.Add();
                TickNewsGrid[0, rowCountTickNewsGrid].Value = Utils.UnixMillisecondsToString(tickNewsMessage.TimeStamp, "yyyy-MM-dd HH:mm:ss");
                TickNewsGrid[1, rowCountTickNewsGrid].Value = tickNewsMessage.ProviderCode;
                TickNewsGrid[2, rowCountTickNewsGrid].Value = tickNewsMessage.ArticleId;
                TickNewsGrid[3, rowCountTickNewsGrid].Value = tickNewsMessage.Headline;
                TickNewsGrid[4, rowCountTickNewsGrid].Value = tickNewsMessage.ExtraData;
                rowCountTickNewsGrid++;
            }
        }

        public void RequestNewsTicks(Contract contract)
        {
            if (!TickNewsGrid.Visible)
                TickNewsGrid.Visible = true;

            ClearTickNews();
            ibClient.ClientSocket.reqMktData(TICK_NEWS_ID, contract, "mdoff,292", false, new List<TagValue>());
        }

        public void ClearTickNews()
        {
            rowCountTickNewsGrid = 0;
            TickNewsGrid.Rows.Clear();
        }

        public void CancelTickNews()
        {
            ibClient.ClientSocket.cancelMktData(TICK_NEWS_ID);
            ClearTickNews();
        }

        public DataGridView TickNewsGrid
        {
            get { return tickNewsGrid; }
            set { tickNewsGrid = value; }
        }

        public IBClient IbClient
        {
            get { return ibClient; }
            set { ibClient = value; }
        }
    }
}
