/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBSampleApp.messages;
using System.Windows.Forms;
using IBSampleApp.util;

namespace IBSampleApp.ui
{
    public class AcctPosMultiManager
    {
        private const int ACCTPOSMULTI_ID_BASE = 80000000;

        private const int POSITIONS_MULTI_ID = ACCTPOSMULTI_ID_BASE + 1;
        private const int ACCOUNT_UPDATES_MULTI_ID = ACCTPOSMULTI_ID_BASE + 100000;

        private IBClient ibClient;
        private DataGridView positionsMultiGrid;
        private DataGridView accountUpdatesMultiGrid;

        private bool positionsMultiRequestActive = false;
        private bool accountUpdatesMultiRequestActive = false;

        public AcctPosMultiManager(IBClient ibClient, DataGridView positionsMultiGrid, DataGridView accountUpdatesMultiGrid)
        {
            IbClient = ibClient;
            PositionsMultiGrid = positionsMultiGrid;
            AccountUpdatesMultiGrid = accountUpdatesMultiGrid;
        }

        public void UpdateUI(IBMessage message)
        {
            switch (message.Type)
            {
                case MessageType.PositionMulti:
                    HandlePositionMulti((PositionMultiMessage)message);
                    break;
                case MessageType.PositionMultiEnd:
                    break;
                case MessageType.AccountUpdateMulti:
                    HandleAccountUpdateMulti((AccountUpdateMultiMessage)message);
                    break;
                case MessageType.AccountUpdateMultiEnd:
                    break;
            }
        }

        private void  HandleAccountUpdateMulti(AccountUpdateMultiMessage accountUpdateMultiMessage)
        {
            for (int i = 0; i < accountUpdatesMultiGrid.Rows.Count; i++)
            {
                if (accountUpdatesMultiGrid[2, i].Value.Equals(accountUpdateMultiMessage.Key) && accountUpdatesMultiGrid[4, i].Value.Equals(accountUpdateMultiMessage.Currency))
                {
                    accountUpdatesMultiGrid[0, i].Value = accountUpdateMultiMessage.Account;
                    accountUpdatesMultiGrid[1, i].Value = accountUpdateMultiMessage.ModelCode;
                    accountUpdatesMultiGrid[3, i].Value = accountUpdateMultiMessage.Value;
                    return;
                }
            }
            accountUpdatesMultiGrid.Rows.Add(1);
            accountUpdatesMultiGrid[0, accountUpdatesMultiGrid.Rows.Count - 1].Value = accountUpdateMultiMessage.Account;
            accountUpdatesMultiGrid[1, accountUpdatesMultiGrid.Rows.Count - 1].Value = accountUpdateMultiMessage.ModelCode;
            accountUpdatesMultiGrid[2, accountUpdatesMultiGrid.Rows.Count - 1].Value = accountUpdateMultiMessage.Key;
            accountUpdatesMultiGrid[3, accountUpdatesMultiGrid.Rows.Count - 1].Value = accountUpdateMultiMessage.Value;
            accountUpdatesMultiGrid[4, accountUpdatesMultiGrid.Rows.Count - 1].Value = accountUpdateMultiMessage.Currency;
        }

        public void HandlePositionMulti(PositionMultiMessage positionMultiMessage)
        {
            for (int i = 0; i < positionsMultiGrid.Rows.Count; i++)
            {

                if (positionsMultiGrid[0, i].Value.Equals(Utils.ContractToString(positionMultiMessage.Contract)))
                {
                    positionsMultiGrid[1, i].Value = positionMultiMessage.Account;
                    positionsMultiGrid[2, i].Value = positionMultiMessage.ModelCode;
                    positionsMultiGrid[3, i].Value = positionMultiMessage.Position;
                    positionsMultiGrid[4, i].Value = positionMultiMessage.AverageCost;
                    return;
                }
            }

            positionsMultiGrid.Rows.Add(1);
            positionsMultiGrid[0, positionsMultiGrid.Rows.Count - 1].Value = Utils.ContractToString(positionMultiMessage.Contract);
            positionsMultiGrid[1, positionsMultiGrid.Rows.Count - 1].Value = positionMultiMessage.Account;
            positionsMultiGrid[2, positionsMultiGrid.Rows.Count - 1].Value = positionMultiMessage.ModelCode;
            positionsMultiGrid[3, positionsMultiGrid.Rows.Count - 1].Value = positionMultiMessage.Position;
            positionsMultiGrid[4, positionsMultiGrid.Rows.Count - 1].Value = positionMultiMessage.AverageCost;
        }

        public void RequestPositionsMulti(string account, string modelCode)
        {
            if (!positionsMultiRequestActive)
            {
                positionsMultiRequestActive = true;
                positionsMultiGrid.Rows.Clear();
                ibClient.ClientSocket.reqPositionsMulti(POSITIONS_MULTI_ID, account, modelCode);
            }
            else
            {
                ibClient.ClientSocket.cancelPositionsMulti(POSITIONS_MULTI_ID);
            }
        }

        public void RequestAccountUpdatesMulti(string account, string modelCode, bool ledgerAndNLV)
        {
            if (!accountUpdatesMultiRequestActive)
            {
                accountUpdatesMultiRequestActive = true;
                accountUpdatesMultiGrid.Rows.Clear();
                ibClient.ClientSocket.reqAccountUpdatesMulti(ACCOUNT_UPDATES_MULTI_ID, account, modelCode, ledgerAndNLV);
            }
            else
            {
                ibClient.ClientSocket.cancelAccountUpdatesMulti(ACCOUNT_UPDATES_MULTI_ID);
            }
        }

        public DataGridView AccountUpdatesMultiGrid
        {
            get { return accountUpdatesMultiGrid; }
            set { accountUpdatesMultiGrid = value; }
        }

        public DataGridView PositionsMultiGrid
        {
            get { return positionsMultiGrid; }
            set { positionsMultiGrid = value; }
        }

        public IBClient IbClient
        {
            get { return ibClient; }
            set { ibClient = value; }
        }
    }
}
