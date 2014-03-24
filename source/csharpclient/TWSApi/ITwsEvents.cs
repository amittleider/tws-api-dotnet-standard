/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("0A77CCF7-052C-11D6-B0EC-00B0D074179C")]
    public interface ITwsEvents
    {
        [DispId(1)]
        void tickPrice(int id, int tickType, double price, int canAutoExecute);
        [DispId(2)]
        void tickSize(int id, int tickType, int size);
        [DispId(3)]
        void connectionClosed();
        [DispId(4)]
        void openOrder1(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol);
        [DispId(5)]
        void openOrder2(int id, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId);
        [DispId(6)]
        void updateAccountTime(string timeStamp);
        [DispId(7)]
        void updateAccountValue(string key, string value, string curency, string accountName);
        [DispId(8)]
        void nextValidId(int id);
        [DispId(10)]
        void permId(int id, int permId);
        [DispId(11)]
        void errMsg(int id, int errorCode, string errorMsg);
        [DispId(12)]
        void updatePortfolio(string symbol, string secType, string expiry, double strike, string right, string curency, string localSymbol, int position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);
        [DispId(13)]
        void orderStatus(int id, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld);
        [DispId(14)]
        void contractDetails(string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, int conId, double minTick, int priceMagnifier, string multiplier, string orderTypes, string validExchanges);
        [DispId(15)]
        void execDetails(int id, string symbol, string secType, string expiry, double strike, string right, string cExchange, string curency, string localSymbol, string execId, string time, string acctNumber, string eExchange, string side, int shares, double price, int permId, int clientId, int isLiquidation);
        [DispId(16)]
        void updateMktDepth(int id, int position, int operation, int side, double price, int size);
        [DispId(17)]
        void updateMktDepthL2(int id, int position, string marketMaker, int operation, int side, double price, int size);
        [DispId(18)]
        void updateNewsBulletin(short msgId, short msgType, string message, string origExchange);
        [DispId(19)]
        void managedAccounts(string accountsList);
        [DispId(20)]
        void openOrder3(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate);
        [DispId(21)]
        void receiveFA(int faDataType, string cxml);
        [DispId(22)]
        void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int barCount, double WAP, int hasGaps);
        [DispId(23)]
        void openOrder4(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate, int ocaType, string rule80A, string settlingFirm, int allOrNone, int minQty, double percentOffset, int eTradeOnly, int firmQuoteOnly, double nbboPriceCap, int auctionStrategy, double startingPrice, double stockRefPrice, double delta, double stockRangeLower, double stockRangeUpper, int blockOrder, int sweepToFill, int ignoreRth, int hidden, double discretionaryAmt, int displaySize, int parentId, int triggerMethod, int shortSaleSlot, string designatedLocation, double volatility, int volatilityType, string deltaNeutralOrderType, double deltaNeutralAuxPrice, int continuousUpdate, int referencePriceType, double trailStopPrice, double basisPoints, int basisPointsType, string legsStr, int scaleInitLevelSize, int scaleSubsLevelSize, double scalePriceIncrement);
        [DispId(24)]
        void bondContractDetails(string symbol, string secType, string cusip, double coupon, string maturity, string issueDate, string ratings, string bondType, string couponType, int convertible, int callable, int putable, string descAppend, string exchange, string curency, string marketName, string tradingClass, int conId, double minTick, string orderTypes, string validExchanges, string nextOptionDate, string nextOptionType, int nextOptionPartial, string notes);
        [DispId(25)]
        void scannerParameters(string xml);
        [DispId(26)]
        void scannerData(int reqId, int rank, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, string distance, string benchmark, string projection, string legsStr);
        [DispId(27)]
        void tickOptionComputation(int id, int tickType, double impliedVol, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice);
        [DispId(28)]
        void tickGeneric(int id, int tickType, double value);
        [DispId(29)]
        void tickString(int id, int tickType, string value);
        [DispId(30)]
        void tickEFP(int tickerId, int field, double basisPoints, string formattedBasisPoints,
                     double totalDividends, int holdDays, string futureExpiry, double dividendImpact,
                     double dividendsToExpiry);
        [DispId(31)]
        void realtimeBar(int tickerId, int time, double open, double high, double low, double close,
                         int volume, double WAP, int count);
        [DispId(32)]
        void currentTime(int time);
        [DispId(33)]
        void scannerDataEnd(int reqId);
        [DispId(34)]
        void fundamentalData(int reqId, string data);
        [DispId(35)]
        void contractDetailsEnd(int reqId);
        [DispId(36)]
        void openOrderEnd();
        [DispId(37)]
        void accountDownloadEnd(string accountName);
        [DispId(38)]
        void execDetailsEnd(int reqId);
        [DispId(39)]
        void deltaNeutralValidation(int reqId, IUnderComp underComp);
        [DispId(40)]
        void tickSnapshotEnd(int reqId);
        [DispId(41)]
        void marketDataType(int reqId, int marketDataType);
        [DispId(100)]
        void contractDetailsEx(int reqId, IContractDetails contractDetails);
        [DispId(101)]
        void openOrderEx(int orderId, IContract contract, IOrder order, IOrderState orderState);
        [DispId(102)]
        void execDetailsEx(int reqId, IContract contract, IExecution execution);
        [DispId(103)]
        void updatePortfolioEx(IContract contract, int position, double marketPrice,
            double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);
        [DispId(104)]
        void scannerDataEx(int reqId, int rank, IContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr);
        [DispId(105)]
        void commissionReport(ICommissionReport commissionReport);
        [DispId(106)]
        void position(string account, IContract contract, int position, double avgCost);
        [DispId(107)]
        void positionEnd();
        [DispId(108)]
        void accountSummary(int reqId, string account, string tag, string value, string curency);
        [DispId(109)]
        void accountSummaryEnd(int reqId);
        [DispId(110)]
        void verifyMessageAPI(string apiData);
        [DispId(111)]
        void verifyCompleted(bool isSuccessful, string errorText);
        [DispId(112)]
        void displayGroupList(int reqId, string groups);
        [DispId(113)]
        void displayGroupUpdated(int reqId, string contractInfo);
    }
}
