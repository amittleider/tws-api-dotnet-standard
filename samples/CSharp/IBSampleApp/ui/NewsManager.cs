/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
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
        private DataGridView newsProvidersGrid;

        public NewsManager(IBClient ibClient, DataGridView tickNewsDataGrid, DataGridView newsProvidersGrid)
        {
            IbClient = ibClient;
            TickNewsGrid = tickNewsDataGrid;
            NewsProvidersGrid = newsProvidersGrid;
        }

        public void UpdateUI(IBMessage message)
        {
            switch (message.Type)
            {
                case MessageType.TickNews:
                    HandleTickNews((TickNewsMessage)message);
                    break;
                case MessageType.NewsProviders:
                    HandleNewsProviders((NewsProvidersMessage)message);
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

        public void HandleNewsProviders(NewsProvidersMessage newsProvidersMessage)
        {
            newsProvidersGrid.Rows.Clear();
            for (int i = 0; i < newsProvidersMessage.NewsProviders.Length; i++)
            {
                newsProvidersGrid.Rows.Add(1);
                newsProvidersGrid[0, newsProvidersGrid.Rows.Count - 1].Value = newsProvidersMessage.NewsProviders[i].ProviderCode;
                newsProvidersGrid[1, newsProvidersGrid.Rows.Count - 1].Value = newsProvidersMessage.NewsProviders[i].ProviderName;
            }
        }

        public void RequestNewsTicks(Contract contract)
        {
            if (!TickNewsGrid.Visible)
                TickNewsGrid.Visible = true;

            ClearTickNews();
            ibClient.ClientSocket.reqMktData(TICK_NEWS_ID, contract, "mdoff,292", false, false, new List<TagValue>());
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

        public void ClearNewsProviders()
        {
            newsProvidersGrid.Rows.Clear();
        }

        public void RequestNewsProviders()
        {
            if (!NewsProvidersGrid.Visible)
                newsProvidersGrid.Visible = true;

            ClearNewsProviders();

            ibClient.ClientSocket.reqNewsProviders();
        }

        public DataGridView TickNewsGrid
        {
            get { return tickNewsGrid; }
            set { tickNewsGrid = value; }
        }

        public DataGridView NewsProvidersGrid
        {
            get { return newsProvidersGrid; }
            set { newsProvidersGrid = value; }
        }

        public IBClient IbClient
        {
            get { return ibClient; }
            set { ibClient = value; }
        }
    }
}
