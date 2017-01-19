/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBApi;
using IBSampleApp.messages;
using IBSampleApp.util;

namespace IBSampleApp.ui
{
    public class NewsManager
    {
        private const int TICK_NEWS_ID_BASE = 90000000;
        private const int TICK_NEWS_ID = TICK_NEWS_ID_BASE;

        private const int NEWS_ARTICLE_ID = TICK_NEWS_ID_BASE + 10000;
        private const int HISTORICAL_NEWS_ID = TICK_NEWS_ID_BASE + 20000;

        int rowCountHistoricalNewsGrid = 0;
        int rowCountTickNewsGrid = 0;

        private IBClient ibClient;
        private DataGridView tickNewsGrid;
        private DataGridView newsProvidersGrid;
        private TextBox textBoxArticleText;
        private DataGridView historicalNewsGrid;

        public NewsManager(IBClient ibClient, DataGridView tickNewsDataGrid, DataGridView newsProvidersGrid, TextBox textBoxArticleText, DataGridView historicalNewsGrid)
        {
            IbClient = ibClient;
            TickNewsGrid = tickNewsDataGrid;
            NewsProvidersGrid = newsProvidersGrid;
            TextBoxArticleText = textBoxArticleText;
            HistoricalNewsGrid = historicalNewsGrid;
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
                case MessageType.NewsArticle:
                    HandleNewsArticle((NewsArticleMessage)message);
                    break;
                case MessageType.HistoricalNews:
                    HandleHistoricalNews((HistoricalNewsMessage)message);
                    break;
                case MessageType.HistoricalNewsEnd:
                    HandleHistoricalNewsEnd((HistoricalNewsEndMessage)message);
                    break;
            }
        }

        private void HandleHistoricalNews(HistoricalNewsMessage historicalNewsMessage)
        {
            if (historicalNewsMessage.RequestId == HISTORICAL_NEWS_ID)
            {
                HistoricalNewsGrid.Rows.Add();
                HistoricalNewsGrid[0, rowCountHistoricalNewsGrid].Value = historicalNewsMessage.Time;
                HistoricalNewsGrid[1, rowCountHistoricalNewsGrid].Value = historicalNewsMessage.ProviderCode;
                HistoricalNewsGrid[2, rowCountHistoricalNewsGrid].Value = historicalNewsMessage.ArticleId;
                HistoricalNewsGrid[3, rowCountHistoricalNewsGrid].Value = historicalNewsMessage.Headline;
                rowCountHistoricalNewsGrid++;
            }
        }

        private void HandleHistoricalNewsEnd(HistoricalNewsEndMessage historicalNewsEndMessage)
        {
            if (historicalNewsEndMessage.RequestId == HISTORICAL_NEWS_ID)
            {
                if (historicalNewsEndMessage.HasMore)
                {
                    HistoricalNewsGrid.Rows.Add();
                    HistoricalNewsGrid[3, rowCountHistoricalNewsGrid].Value = "has more ...";
                }
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

        private void  HandleNewsArticle(NewsArticleMessage newsArticleMessage)
        {
            if (newsArticleMessage.ArticleType == 0)
            {
                textBoxArticleText.Text = newsArticleMessage.ArticleText;
            }
            else if (newsArticleMessage.ArticleType == 1)
            {
                textBoxArticleText.Text = "News article text is binary/pdf and cannot be displayed.";
            }
        }

        public void RequestNewsArticle(string providerCode, string articleId)
        {
            textBoxArticleText.Clear();
            ibClient.ClientSocket.reqNewsArticle(NEWS_ARTICLE_ID, providerCode, articleId);
        }

        public void ClearArticleText()
        {
            textBoxArticleText.Clear();
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

        public void RequestHistoricalNews(int conId, string providerCodes, string startDateTime, string endDateTime, int totalResults)
        {
            if (!HistoricalNewsGrid.Visible)
                HistoricalNewsGrid.Visible = true;

            ClearHistoricalNews();
            IbClient.ClientSocket.reqHistoricalNews(HISTORICAL_NEWS_ID, conId, providerCodes, startDateTime, endDateTime, totalResults);
        }

        public void ClearHistoricalNews() {
            rowCountHistoricalNewsGrid = 0;
            HistoricalNewsGrid.Rows.Clear();
        }

        public DataGridView HistoricalNewsGrid
        {
            get { return historicalNewsGrid; }
            set { historicalNewsGrid = value; }
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

        public TextBox TextBoxArticleText
        {
            get { return textBoxArticleText; }
            set { textBoxArticleText = value; }
        }

        public IBClient IbClient
        {
            get { return ibClient; }
            set { ibClient = value; }
        }
    }
}
