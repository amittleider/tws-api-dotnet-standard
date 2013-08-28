using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using IBApi;
using IBSampleApp.messages;
using System.Globalization;
using System.Windows.Forms;

namespace IBSampleApp.ui
{
    public class HistoricalDataManager : DataManager
    {
        private string fullDatePattern = "yyyyMMdd  HH:mm:ss";
        private string yearMonthDayPattern = "yyyyMMdd";

        protected int barCounter = -1;
        protected DataGridView gridView;

        public HistoricalDataManager(IBClient ibClient, Chart chart, DataGridView gridView) : base(ibClient, chart) 
        {
            Chart historicalChart = (Chart)uiControl;
            historicalChart.Series[0]["PriceUpColor"] = "Green";
            historicalChart.Series[0]["PriceDownColor"] = "Red";
            this.gridView = gridView;
        }

        public void AddRequest(Contract contract, string endDateTime, string durationString, string barSizeSetting, string whatToShow, int useRTH, int dateFormat)
        {
            Clear();
            ibClient.ClientSocket.reqHistoricalData(currentTicker, contract, endDateTime, durationString, barSizeSetting, whatToShow, useRTH, 1);
        }

        public override void Clear()
        {
            barCounter = -1;
            Chart historicalChart = (Chart)uiControl;
            historicalChart.Series[0].Points.Clear();
            gridView.Rows.Clear();
        }

        public override void NotifyError(int requestId)
        {
        }

        protected override void Populate(IBMessage message)
        {
            barCounter++;
            Chart historicalChart = (Chart)uiControl;
            HistoricalDataMessage historicalBar = (HistoricalDataMessage)message;
            DateTime dt;

            if (historicalBar.Date.Length == fullDatePattern.Length)
                DateTime.TryParseExact(historicalBar.Date, fullDatePattern, null, DateTimeStyles.None, out dt);
            else if (historicalBar.Date.Length == yearMonthDayPattern.Length)
                DateTime.TryParseExact(historicalBar.Date, yearMonthDayPattern, null, DateTimeStyles.None, out dt);
            else
                return;//Ignore it...

            // adding date and high
            historicalChart.Series[0].Points.AddXY(dt, historicalBar.High);
            // adding low
            historicalChart.Series[0].Points[barCounter].YValues[1] = historicalBar.Low;
            //adding open
            historicalChart.Series[0].Points[barCounter].YValues[2] = historicalBar.Open;
            // adding close
            historicalChart.Series[0].Points[barCounter].YValues[3] = historicalBar.Close;
            UpdateGrid(message);
        }

        protected void UpdateGrid(IBMessage message)
        {
            if (gridView.InvokeRequired)
            {
                UpdateUICallback callback = new UpdateUICallback(UpdateGrid);
                gridView.Invoke(callback, new object[] { message });
            }
            else
            {
                PopulateGrid(message);
            }
        }


        protected void PopulateGrid(IBMessage message)
        {
            HistoricalDataMessage bar = (HistoricalDataMessage)message;
            gridView.Rows.Add(1);
            gridView[0, barCounter].Value = bar.Date;
            gridView[1, barCounter].Value = bar.Open;
            gridView[2, barCounter].Value = bar.High;
            gridView[3, barCounter].Value = bar.Low;
            gridView[4, barCounter].Value = bar.Close;
            gridView[5, barCounter].Value = bar.Volume;
            gridView[6, barCounter].Value = bar.Wap;
        }
    }
}
