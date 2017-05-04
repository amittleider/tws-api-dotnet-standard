/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBApi;
using IBSampleApp.messages;
using IBSampleApp.util;
using IBSampleApp.types;

namespace IBSampleApp.ui
{
    public class MarketDataManager : DataManager
    {
        public const int TICK_ID_BASE = 10000000;

        private const int DESCRIPTION_INDEX = 0;

        private const int MARKET_DATA_TYPE_INDEX = 1;

        private const int BID_PRICE_INDEX = 3;
        private const int ASK_PRICE_INDEX = 4;
        private const int CLOSE_PRICE_INDEX = 9;
        private const int LAST_PRICE_INDEX = 6;
        private const int OPEN_PRICE_INDEX = 10;
        private const int HIGH_PRICE_INDEX = 11;
        private const int LOW_PRICE_INDEX = 12;
        private const int FUTURES_OPEN_INTEREST_INDEX = 13;

        private const int BID_SIZE_INDEX = 2;
        private const int ASK_SIZE_INDEX = 5;
        private const int LAST_SIZE_INDEX = 7;
        private const int VOLUME_SIZE_INDEX = 8;

        private bool active = false;

        private List<Contract> activeRequests = new List<Contract>();

        public MarketDataManager(IBClient client, DataGridView dataGrid)
            : base(client, dataGrid)
        {
        }

        public bool isActive() { return active; }
        public void setActive() { active = true; }
        public void unsetActive() { active = false; }

        public void AddRequest(Contract contract, string genericTickList)
        {
            activeRequests.Add(contract);
            int nextReqId = TICK_ID_BASE + (currentTicker++);
            checkToAddRow(nextReqId);
            ibClient.ClientSocket.reqMktData(nextReqId, contract, genericTickList, false, false, new List<TagValue>());

            if (!uiControl.Visible)
                uiControl.Visible = true;
        }

        public void RequestMarketDataType(int marketDataType)
        {
            ibClient.ClientSocket.reqMarketDataType(marketDataType);
        }

        public override void NotifyError(int requestId)
        {
            //activeRequests.RemoveAt(GetIndex(requestId));
            //currentTicker-=1;
        }

        public override void Clear()
        {
            ((DataGridView)uiControl).Rows.Clear();
            activeRequests.Clear();
            uiControl.Visible = false;
            currentTicker = 1;
        }

        public void StopActiveRequests(bool clearTable)
        {
            for (int i = 1; i < currentTicker; i++)
            {
                ibClient.ClientSocket.cancelMktData(i + TICK_ID_BASE);
            }
            if (clearTable)
                Clear();
        }

        private void checkToAddRow(int requestId)
        {
            DataGridView grid = (DataGridView)uiControl;
            if (grid.Rows.Count < (requestId - TICK_ID_BASE))
            {
                grid.Rows.Add(GetIndex(requestId), 0);
                grid[DESCRIPTION_INDEX, GetIndex(requestId)].Value = Utils.ContractToString(activeRequests[GetIndex(requestId)]);
                grid[MARKET_DATA_TYPE_INDEX, GetIndex(requestId)].Value = MarketDataType.Real_Time.Name; // default
            }
        }

        private int GetIndex(int requestId)
        {
            return requestId - TICK_ID_BASE - 1;
        }

        public void HandleMarketDataTypeMessage(MarketDataTypeMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.get(dataMessage.MarketDataType).Name;
        }

        public bool IsUIUpdateRequired(MarketDataMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            return grid.Rows.Count >= dataMessage.RequestId - TICK_ID_BASE;
        }

        public void UpdateUI(TickPriceMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            if ((grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value.Equals(MarketDataType.Real_Time.Name)) &&
                (dataMessage.Field == 66 ||
                dataMessage.Field == 67 ||
                dataMessage.Field == 75 ||
                dataMessage.Field == 76 ||
                dataMessage.Field == 68 ||
                dataMessage.Field == 72 ||
                dataMessage.Field == 73))
            {
                grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.Delayed.Name;
            }

            switch (dataMessage.Field)
            {
                case 1:
                case 66:
                    {
                        //BID, DELAYED_BID
                        grid[BID_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 2:
                case 67:
                    {
                        //ASK, DELAYED_ASK
                        grid[ASK_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 9:
                case 75:
                    {
                        //CLOSE, DELAYED_CLOSE
                        grid[CLOSE_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 14:
                case 76:
                    {
                        //OPEN, DELAYED_OPEN
                        grid[OPEN_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 4:
                case 68:
                    {
                        //LAST, DELAYED_LAST
                        grid[LAST_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 6:
                case 72:
                    {
                        //HIGH, DELAYED_HIGH
                        grid[HIGH_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
                case 7:
                case 73:
                    {
                        //LOW, DELAYED_LOW
                        grid[LOW_PRICE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Price;
                        break;
                    }
            }
        }

        public void UpdateUI(TickSizeMessage dataMessage)
        {
            DataGridView grid = (DataGridView)uiControl;

            if ((grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value.Equals(MarketDataType.Real_Time.Name)) &&
                (dataMessage.Field == 69 ||
                dataMessage.Field == 70 ||
                dataMessage.Field == 71 ||
                dataMessage.Field == 74))
            {
                grid[MARKET_DATA_TYPE_INDEX, GetIndex(dataMessage.RequestId)].Value = MarketDataType.Delayed.Name;
            }
            switch (dataMessage.Field)
            {
                case 0:
                case 69:
                    {
                        //BID SIZE, DELAYED_BID_SIZE
                        grid[BID_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case 3:
                case 70:
                    {
                        //ASK SIZE, DELAYED_ASK_SIZE
                        grid[ASK_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case 5:
                case 71:
                    {
                        //LAST_SIZE, DELAYED_LAST_SIZE
                        grid[LAST_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case 8:
                case 74:
                    {
                        //VOLUME, DELAYED_VOLUME
                        grid[VOLUME_SIZE_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }
                case 86:
                    {
                        //FUTURES_OPEN_INTEREST
                        grid[FUTURES_OPEN_INTEREST_INDEX, GetIndex(dataMessage.RequestId)].Value = dataMessage.Size;
                        break;
                    }

            }
        }

    }

}


