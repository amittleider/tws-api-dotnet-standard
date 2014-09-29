/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

import java.io.Closeable;
import java.io.DataInputStream;
import java.io.EOFException;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import com.ib.controller.DeltaNeutralContract;
import com.ib.controller.OrderType;


/**
 * This class reads commands from TWS and passes them to the user defined
 * EWrapper.
 *
 * This class is initialized with a DataInputStream that is connected to the
 * TWS. Messages begin with an ID and any relevant data are passed afterwards.
 */
public class EReader extends Thread {

    // incoming msg id's
    static final int END_CONN           = -1;
    static final int TICK_PRICE		= 1;
    static final int TICK_SIZE		= 2;
    static final int ORDER_STATUS	= 3;
    static final int ERR_MSG		= 4;
    static final int OPEN_ORDER         = 5;
    static final int ACCT_VALUE         = 6;
    static final int PORTFOLIO_VALUE    = 7;
    static final int ACCT_UPDATE_TIME   = 8;
    static final int NEXT_VALID_ID      = 9;
    static final int CONTRACT_DATA      = 10;
    static final int EXECUTION_DATA     = 11;
    static final int MARKET_DEPTH     	= 12;
    static final int MARKET_DEPTH_L2    = 13;
    static final int NEWS_BULLETINS    	= 14;
    static final int MANAGED_ACCTS    	= 15;
    static final int RECEIVE_FA    	    = 16;
    static final int HISTORICAL_DATA    = 17;
    static final int BOND_CONTRACT_DATA = 18;
    static final int SCANNER_PARAMETERS = 19;
    static final int SCANNER_DATA       = 20;
    static final int TICK_OPTION_COMPUTATION = 21;
    static final int TICK_GENERIC = 45;
    static final int TICK_STRING = 46;
    static final int TICK_EFP = 47;
    static final int CURRENT_TIME = 49;
    static final int REAL_TIME_BARS = 50;
    static final int FUNDAMENTAL_DATA = 51;
    static final int CONTRACT_DATA_END = 52;
    static final int OPEN_ORDER_END = 53;
    static final int ACCT_DOWNLOAD_END = 54;
    static final int EXECUTION_DATA_END = 55;
    static final int DELTA_NEUTRAL_VALIDATION = 56;
    static final int TICK_SNAPSHOT_END = 57;
    static final int MARKET_DATA_TYPE = 58;
    static final int COMMISSION_REPORT = 59;
    static final int POSITION = 61;
    static final int POSITION_END = 62;
    static final int ACCOUNT_SUMMARY = 63;
    static final int ACCOUNT_SUMMARY_END = 64;
    static final int VERIFY_MESSAGE_API = 65;
    static final int VERIFY_COMPLETED = 66;
    static final int DISPLAY_GROUP_LIST = 67;
    static final int DISPLAY_GROUP_UPDATED = 68;
    static final int VERIFY_AND_AUTH_MESSAGE_API = 69;
    static final int VERIFY_AND_AUTH_COMPLETED = 70;

    static final int MAX_MSG_LENGTH = 0xffffff;

    private EClientSocket 	m_parent;
    private DataInputStream m_dis;
    private IMessageReader  m_messageReader;
    private boolean 		m_useV100Plus;
    
    public void setUseV100Plus() { m_useV100Plus = true; }

    protected EClientSocket parent()    { return m_parent; }
    private EWrapper eWrapper()         { return parent().wrapper(); }

    /**
     * Construct the EReader.
     * @param parent An EClientSocket connected to TWS.
     * @param dis A stream that received data from the TWS.
     */
    public EReader( EClientSocket parent, DataInputStream dis) {
        this("EReader", parent, dis);
    }

    protected EReader( String name, EClientSocket parent, DataInputStream dis) {
        setName( name);
        m_parent = parent;
        m_dis = dis;
    }
    
    /**
     * Read and process messages until interrupted or TWS closes connection.
     */
    public void run() {
        try {
            // loop until thread is terminated
            while( !isInterrupted() && processMsg() );
        }
        catch ( Exception ex ) {
        	if (parent().isConnected()) {
        		if ( ex instanceof EOSException ) { // must come before EOFException
        			System.out.println( "End of stream");
        		}
        		else if( ex instanceof EOFException ) {
            		eWrapper().error(EClientErrors.NO_VALID_ID, EClientErrors.BAD_LENGTH.code(),
            				EClientErrors.BAD_LENGTH.msg() + " " + ex.getMessage());
        		}
        		else {
        			eWrapper().error( ex);
        		}
        	}
        }
        if (parent().isConnected()) {
        	m_parent.close();
        }
        try {
            m_dis.close();
            m_dis = null;
        }
        catch (IOException e) {
        }
    }
    
    protected boolean processMsg() throws IOException {
    	if ( !readMessageToInternalBuf() ) {
    		return false;
    	}
    	
    	int msgId = readInt();

        switch( msgId) {
            case END_CONN:
                return false;
            case TICK_PRICE: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                double price = readDouble();
                int size = 0;
                if( version >= 2) {
                    size = readInt();
                }
                int canAutoExecute = 0;
                if (version >= 3) {
                    canAutoExecute = readInt();
                }
                eWrapper().tickPrice( tickerId, tickType, price, canAutoExecute);

                if( version >= 2) {
                    int sizeTickType = -1 ; // not a tick
                    switch (tickType) {
                        case 1: // BID
                            sizeTickType = 0 ; // BID_SIZE
                            break ;
                        case 2: // ASK
                            sizeTickType = 3 ; // ASK_SIZE
                            break ;
                        case 4: // LAST
                            sizeTickType = 5 ; // LAST_SIZE
                            break ;
                    }
                    if (sizeTickType != -1) {
                        eWrapper().tickSize( tickerId, sizeTickType, size);
                    }
                }
                break;
            }
            case TICK_SIZE: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                int size = readInt();

                eWrapper().tickSize( tickerId, tickType, size);
                break;
            }

            case POSITION:{
                int version = readInt();
                String account = readStr();

                Contract contract = new Contract();
                contract.conid(readInt());
                contract.symbol(readStr());
                contract.secType(readStr());
                contract.expiry(readStr());
                contract.strike(readDouble());
                contract.right(readStr());
                contract.multiplier(readStr());
                contract.exchange(readStr());
                contract.currency(readStr());
                contract.localSymbol(readStr());
                if (version >= 2) {
                	contract.tradingClass(readStr());
                }

                int pos = readInt();
                double avgCost = 0;
                if (version >= 3) {
                	avgCost = readDouble();
                }

                eWrapper().position( account, contract, pos, avgCost);
                break;
            }

            case POSITION_END:{
                int version = readInt();
                eWrapper().positionEnd();
                break;
            }

            case ACCOUNT_SUMMARY:{
                int version = readInt();
                int reqId = readInt();
                String account = readStr();
                String tag = readStr();
                String value = readStr();
                String currency = readStr();
                eWrapper().accountSummary(reqId, account, tag, value, currency);
                break;
            }

            case ACCOUNT_SUMMARY_END:{
                int version = readInt();
                int reqId = readInt();
                eWrapper().accountSummaryEnd(reqId);
                break;
            }

            case TICK_OPTION_COMPUTATION: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                double impliedVol = readDouble();
            	if (impliedVol < 0) { // -1 is the "not yet computed" indicator
            		impliedVol = Double.MAX_VALUE;
            	}
                double delta = readDouble();
            	if (Math.abs(delta) > 1) { // -2 is the "not yet computed" indicator
            		delta = Double.MAX_VALUE;
            	}
            	double optPrice = Double.MAX_VALUE;
            	double pvDividend = Double.MAX_VALUE;
            	double gamma = Double.MAX_VALUE;
            	double vega = Double.MAX_VALUE;
            	double theta = Double.MAX_VALUE;
            	double undPrice = Double.MAX_VALUE;
            	if (version >= 6 || tickType == TickType.MODEL_OPTION.index()) { // introduced in version == 5
            		optPrice = readDouble();
            		if (optPrice < 0) { // -1 is the "not yet computed" indicator
            			optPrice = Double.MAX_VALUE;
            		}
            		pvDividend = readDouble();
            		if (pvDividend < 0) { // -1 is the "not yet computed" indicator
            			pvDividend = Double.MAX_VALUE;
            		}
            	}
            	if (version >= 6) {
            		gamma = readDouble();
            		if (Math.abs(gamma) > 1) { // -2 is the "not yet computed" indicator
            			gamma = Double.MAX_VALUE;
            		}
            		vega = readDouble();
            		if (Math.abs(vega) > 1) { // -2 is the "not yet computed" indicator
            			vega = Double.MAX_VALUE;
            		}
            		theta = readDouble();
            		if (Math.abs(theta) > 1) { // -2 is the "not yet computed" indicator
            			theta = Double.MAX_VALUE;
            		}
            		undPrice = readDouble();
            		if (undPrice < 0) { // -1 is the "not yet computed" indicator
            			undPrice = Double.MAX_VALUE;
            		}
            	}

            	eWrapper().tickOptionComputation( tickerId, tickType, impliedVol, delta, optPrice, pvDividend, gamma, vega, theta, undPrice);
            	break;
            }

            case TICK_GENERIC: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                double value = readDouble();

                eWrapper().tickGeneric( tickerId, tickType, value);
                break;
            }

            case TICK_STRING: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                String value = readStr();

                eWrapper().tickString( tickerId, tickType, value);
                break;
            }

            case TICK_EFP: {
                int version = readInt();
                int tickerId = readInt();
                int tickType = readInt();
                double basisPoints = readDouble();
                String formattedBasisPoints = readStr();
                double impliedFuturesPrice = readDouble();
                int holdDays = readInt();
                String futureExpiry = readStr();
                double dividendImpact = readDouble();
                double dividendsToExpiry = readDouble();
                eWrapper().tickEFP( tickerId, tickType, basisPoints, formattedBasisPoints,
                					impliedFuturesPrice, holdDays, futureExpiry, dividendImpact, dividendsToExpiry);
                break;
            }

            case ORDER_STATUS: {
                int version = readInt();
                int id = readInt();
                String status = readStr();
                int filled = readInt();
                int remaining = readInt();
                double avgFillPrice = readDouble();

                int permId = 0;
                if( version >= 2) {
                    permId = readInt();
                }

                int parentId = 0;
                if( version >= 3) {
                    parentId = readInt();
                }

                double lastFillPrice = 0;
                if( version >= 4) {
                    lastFillPrice = readDouble();
                }

                int clientId = 0;
                if( version >= 5) {
                    clientId = readInt();
                }

                String whyHeld = null;
                if( version >= 6) {
                	whyHeld = readStr();
                }

                eWrapper().orderStatus( id, status, filled, remaining, avgFillPrice,
                                permId, parentId, lastFillPrice, clientId, whyHeld);
                break;
            }

            case ACCT_VALUE: {
                int version = readInt();
                String key = readStr();
                String val  = readStr();
                String cur = readStr();
                String accountName = null ;
                if( version >= 2) {
                    accountName = readStr();
                }
                eWrapper().updateAccountValue(key, val, cur, accountName);
                break;
            }

            case PORTFOLIO_VALUE: {
                int version = readInt();
                Contract contract = new Contract();
                if (version >= 6) {
                	contract.conid(readInt());
                }
                contract.symbol(readStr());
                contract.secType(readStr());
                contract.expiry(readStr());
                contract.strike(readDouble());
                contract.right(readStr());
                if (version >= 7) {
                	contract.multiplier(readStr());
                	contract.primaryExch(readStr());
                }
                contract.currency(readStr());
                if ( version >= 2 ) {
                    contract.localSymbol(readStr());
                }
                if (version >= 8) {
                    contract.tradingClass(readStr());
                }

                int position  = readInt();
                double marketPrice = readDouble();
                double marketValue = readDouble();
                double  averageCost = 0.0;
                double  unrealizedPNL = 0.0;
                double  realizedPNL = 0.0;
                if (version >=3 ) {
                    averageCost = readDouble();
                    unrealizedPNL = readDouble();
                    realizedPNL = readDouble();
                }

                String accountName = null ;
                if( version >= 4) {
                    accountName = readStr();
                }

                if(version == 6 && m_parent.serverVersion() == 39) {
                	contract.primaryExch(readStr());
                }

                eWrapper().updatePortfolio(contract, position, marketPrice, marketValue,
                                averageCost, unrealizedPNL, realizedPNL, accountName);

                break;
            }

            case ACCT_UPDATE_TIME: {
                int version = readInt();
                String timeStamp = readStr();
                eWrapper().updateAccountTime(timeStamp);
                break;
            }

            case ERR_MSG: {
                int version = readInt();
                if(version < 2) {
                    String msg = readStr();
                    m_parent.error( msg);
                } else {
                    int id = readInt();
                    int errorCode    = readInt();
                    String errorMsg = readStr();
                    m_parent.error(id, errorCode, errorMsg);
                }
                break;
            }

            case OPEN_ORDER: {
                // read version
                int version = readInt();

                // read order id
                Order order = new Order();
                order.orderId(readInt());

                // read contract fields
                Contract contract = new Contract();
                if (version >= 17) {
                	contract.conid(readInt());
                }
                contract.symbol(readStr());
                contract.secType(readStr());
                contract.expiry(readStr());
                contract.strike(readDouble());
                contract.right(readStr());
                if ( version >= 32) {
                   contract.multiplier(readStr());
                }
                contract.exchange(readStr());
                contract.currency(readStr());
                if ( version >= 2 ) {
                    contract.localSymbol(readStr());
                }
                if (version >= 32) {
                    contract.tradingClass(readStr());
                }

                // read order fields
                order.action(readStr());
                order.totalQuantity(readInt());
                order.orderType(readStr());
                if (version < 29) {
                    order.lmtPrice(readDouble());
                }
                else {
                    order.lmtPrice(readDoubleMax());
                }
                if (version < 30) {
                    order.auxPrice(readDouble());
                }
                else {
                    order.auxPrice(readDoubleMax());
                }
                order.tif(readStr());
                order.ocaGroup(readStr());
                order.account(readStr());
                order.openClose(readStr());
                order.origin(readInt());
                order.orderRef(readStr());

                if(version >= 3) {
                    order.clientId(readInt());
                }

                if( version >= 4 ) {
                    order.permId(readInt());
                    if ( version < 18) {
                        // will never happen
                    	/* order.m_ignoreRth = */ readBoolFromInt();
                    }
                    else {
                    	order.outsideRth(readBoolFromInt());
                    }
                    order.hidden(readInt() == 1);
                    order.discretionaryAmt(readDouble());
                }

                if ( version >= 5 ) {
                    order.goodAfterTime(readStr());
                }

                if ( version >= 6 ) {
                	// skip deprecated sharesAllocation field
                    readStr();
                }

                if ( version >= 7 ) {
                    order.faGroup(readStr());
                    order.faMethod(readStr());
                    order.faPercentage(readStr());
                    order.faProfile(readStr());
                }

                if ( version >= 8 ) {
                    order.goodTillDate(readStr());
                }

                if ( version >= 9) {
                    order.rule80A(readStr());
                    order.percentOffset(readDoubleMax());
                    order.settlingFirm(readStr());
                    order.shortSaleSlot(readInt());
                    order.designatedLocation(readStr());
                    if ( m_parent.serverVersion() == 51){
                        readInt(); // exemptCode
                    }
                    else if ( version >= 23){
                    	order.exemptCode(readInt());
                    }
                    order.auctionStrategy(readInt());
                    order.startingPrice(readDoubleMax());
                    order.stockRefPrice(readDoubleMax());
                    order.delta(readDoubleMax());
                    order.stockRangeLower(readDoubleMax());
                    order.stockRangeUpper(readDoubleMax());
                    order.displaySize(readInt());
                    if ( version < 18) {
                        // will never happen
                    	/* order.m_rthOnly = */ readBoolFromInt();
                    }
                    order.blockOrder(readBoolFromInt());
                    order.sweepToFill(readBoolFromInt());
                    order.allOrNone(readBoolFromInt());
                    order.minQty(readIntMax());
                    order.ocaType(readInt());
                    order.eTradeOnly(readBoolFromInt());
                    order.firmQuoteOnly(readBoolFromInt());
                    order.nbboPriceCap(readDoubleMax());
                }

                if ( version >= 10) {
                    order.parentId(readInt());
                    order.triggerMethod(readInt());
                }

                if (version >= 11) {
                    order.volatility(readDoubleMax());
                    order.volatilityType(readInt());
                    if (version == 11) {
                    	int receivedInt = readInt();
                    	order.deltaNeutralOrderType( (receivedInt == 0) ? "NONE" : "MKT" );
                    } else { // version 12 and up
                    	order.deltaNeutralOrderType(readStr());
                    	order.deltaNeutralAuxPrice(readDoubleMax());

                        if (version >= 27 && !Util.StringIsEmpty(order.getDeltaNeutralOrderType())) {
                            order.deltaNeutralConId(readInt());
                            order.deltaNeutralSettlingFirm(readStr());
                            order.deltaNeutralClearingAccount(readStr());
                            order.deltaNeutralClearingIntent(readStr());
                        }

                        if (version >= 31 && !Util.StringIsEmpty(order.getDeltaNeutralOrderType())) {
                            order.deltaNeutralOpenClose(readStr());
                            order.deltaNeutralShortSale(readBoolFromInt());
                            order.deltaNeutralShortSaleSlot(readInt());
                            order.deltaNeutralDesignatedLocation(readStr());
                        }
                    }
                    order.continuousUpdate(readInt());
                    if (m_parent.serverVersion() == 26) {
                    	order.stockRangeLower(readDouble());
                    	order.stockRangeUpper(readDouble());
                    }
                    order.referencePriceType(readInt());
                }

                if (version >= 13) {
                	order.trailStopPrice(readDoubleMax());
                }

                if (version >= 30) {
                	order.trailingPercent(readDoubleMax());
                }

                if (version >= 14) {
                	order.basisPoints(readDoubleMax());
                	order.basisPointsType(readIntMax());
                	contract.comboLegsDescrip(readStr());
                }

                if (version >= 29) {
                	int comboLegsCount = readInt();
                	if (comboLegsCount > 0) {
                		contract.comboLegs(new ArrayList<ComboLeg>(comboLegsCount));
                		for (int i = 0; i < comboLegsCount; ++i) {
                			int conId = readInt();
                			int ratio = readInt();
                			String action = readStr();
                			String exchange = readStr();
                			int openClose = readInt();
                			int shortSaleSlot = readInt();
                			String designatedLocation = readStr();
                			int exemptCode = readInt();

                			ComboLeg comboLeg = new ComboLeg(conId, ratio, action, exchange, openClose,
                					shortSaleSlot, designatedLocation, exemptCode);
                			contract.comboLegs().add(comboLeg);
                		}
                	}

                	int orderComboLegsCount = readInt();
                	if (orderComboLegsCount > 0) {
                		order.orderComboLegs(new ArrayList<OrderComboLeg>(orderComboLegsCount));
                		for (int i = 0; i < orderComboLegsCount; ++i) {
                			double price = readDoubleMax();

                			OrderComboLeg orderComboLeg = new OrderComboLeg(price);
                			order.orderComboLegs().add(orderComboLeg);
                		}
                	}
                }

                if (version >= 26) {
                	int smartComboRoutingParamsCount = readInt();
                	if (smartComboRoutingParamsCount > 0) {
                		order.smartComboRoutingParams(new ArrayList<TagValue>(smartComboRoutingParamsCount));
                		for (int i = 0; i < smartComboRoutingParamsCount; ++i) {
                			TagValue tagValue = new TagValue();
                			tagValue.m_tag = readStr();
                			tagValue.m_value = readStr();
                			order.smartComboRoutingParams().add(tagValue);
                		}
                	}
                }

                if (version >= 15) {
                	if (version >= 20) {
                		order.scaleInitLevelSize(readIntMax());
                		order.scaleSubsLevelSize(readIntMax());
                	}
                	else {
                		/* int notSuppScaleNumComponents = */ readIntMax();
                		order.scaleInitLevelSize(readIntMax());
                	}
                	order.scalePriceIncrement(readDoubleMax());
                }

                if (version >= 28 && order.scalePriceIncrement() > 0.0 && order.scalePriceIncrement() != Double.MAX_VALUE) {
                    order.scalePriceAdjustValue(readDoubleMax());
                    order.scalePriceAdjustInterval(readIntMax());
                    order.scaleProfitOffset(readDoubleMax());
                    order.scaleAutoReset(readBoolFromInt());
                    order.scaleInitPosition(readIntMax());
                    order.scaleInitFillQty(readIntMax());
                    order.scaleRandomPercent(readBoolFromInt());
                }

                if (version >= 24) {
                	order.hedgeType(readStr());
                    if (!Util.StringIsEmpty(order.getHedgeType())) {
                		order.hedgeParam(readStr());
                	}
                }

                if (version >= 25) {
                	order.optOutSmartRouting(readBoolFromInt());
                }

                if (version >= 19) {
                	order.clearingAccount(readStr());
                	order.clearingIntent(readStr());
                }

                if (version >= 22) {
                	order.notHeld(readBoolFromInt());
                }

                if (version >= 20) {
                    if (readBoolFromInt()) {
                        DeltaNeutralContract underComp = new DeltaNeutralContract();
                        underComp.conid(readInt());
                        underComp.delta(readDouble());
                        underComp.price(readDouble());
                        contract.underComp(underComp);
                    }
                }

                if (version >= 21) {
                	order.algoStrategy(readStr());
                    if (!Util.StringIsEmpty(order.getAlgoStrategy())) {
                		int algoParamsCount = readInt();
                		if (algoParamsCount > 0) {
                			for (int i = 0; i < algoParamsCount; ++i) {
                				TagValue tagValue = new TagValue();
                				tagValue.m_tag = readStr();
                				tagValue.m_value = readStr();
                				order.algoParams().add(tagValue);
                			}
                		}
                	}
                }
                
                if (version >= 33) {
                	order.solicited(readBoolFromInt());
                }

                OrderState orderState = new OrderState();

                if (version >= 16) {
                	order.whatIf(readBoolFromInt());

                	orderState.status(readStr());
                	orderState.initMargin(readStr());
                	orderState.maintMargin(readStr());
                	orderState.equityWithLoan(readStr());
                	orderState.commission(readDoubleMax());
                	orderState.minCommission(readDoubleMax());
                	orderState.maxCommission(readDoubleMax());
                	orderState.commissionCurrency(readStr());
                	orderState.warningText(readStr());
                }

                eWrapper().openOrder( order.orderId(), contract, order, orderState);
                break;
            }

            case NEXT_VALID_ID: {
                int version = readInt();
                int orderId = readInt();
                eWrapper().nextValidId( orderId);
                break;
            }

            case SCANNER_DATA: {
                ContractDetails contract = new ContractDetails();
                int version = readInt();
                int tickerId = readInt();
                int numberOfElements = readInt();
                for (int ctr=0; ctr < numberOfElements; ctr++) {
                    int rank = readInt();
                    if (version >= 3) {
                    	contract.contract().conid(readInt());
                    }
                    contract.contract().symbol(readStr());
                    contract.contract().secType(readStr());
                    contract.contract().expiry(readStr());
                    contract.contract().strike(readDouble());
                    contract.contract().right(readStr());
                    contract.contract().exchange(readStr());
                    contract.contract().currency(readStr());
                    contract.contract().localSymbol(readStr());
                    contract.marketName(readStr());
                    contract.contract().tradingClass(readStr());
                    String distance = readStr();
                    String benchmark = readStr();
                    String projection = readStr();
                    String legsStr = null;
                    if (version >= 2) {
                    	legsStr = readStr();
                    }
                    eWrapper().scannerData(tickerId, rank, contract, distance,
                        benchmark, projection, legsStr);
                }
                eWrapper().scannerDataEnd(tickerId);
                break;
            }

            case CONTRACT_DATA: {
                int version = readInt();

                int reqId = -1;
                if (version >= 3) {
                	reqId = readInt();
                }

                ContractDetails contract = new ContractDetails();
                contract.contract().symbol(readStr());
                contract.contract().secType(readStr());
                contract.contract().expiry(readStr());
                contract.contract().strike(readDouble());
                contract.contract().right(readStr());
                contract.contract().exchange(readStr());
                contract.contract().currency(readStr());
                contract.contract().localSymbol(readStr());
                contract.marketName(readStr());
                contract.contract().tradingClass(readStr());
                contract.contract().conid(readInt());
                contract.minTick(readDouble());
                contract.contract().multiplier(readStr());
                contract.orderTypes(readStr());
                contract.validExchanges(readStr());
                if (version >= 2) {
                    contract.priceMagnifier(readInt());
                }
                if (version >= 4) {
                	contract.underConid(readInt());
                }
                if( version >= 5) {
                   contract.longName(readStr());
                   contract.contract().primaryExch(readStr());
                }
                if( version >= 6) {
                    contract.contractMonth(readStr());
                    contract.industry(readStr());
                    contract.category(readStr());
                    contract.subcategory(readStr());
                    contract.timeZoneId(readStr());
                    contract.tradingHours(readStr());
                    contract.liquidHours(readStr());
                 }
                if (version >= 8) {
                    contract.evRule(readStr());
                    contract.evMultiplier(readDouble());
                }
                if (version >= 7) {
                    int secIdListCount = readInt();
                        if (secIdListCount  > 0) {
                            contract.secIdList(new ArrayList<TagValue>(secIdListCount));
                            for (int i = 0; i < secIdListCount; ++i) {
                                TagValue tagValue = new TagValue();
                                tagValue.m_tag = readStr();
                                tagValue.m_value = readStr();
                                contract.secIdList().add(tagValue);
                            }
                        }
                }

                eWrapper().contractDetails( reqId, contract);
                break;
            }
            case BOND_CONTRACT_DATA: {
                int version = readInt();

                int reqId = -1;
                if (version >= 3) {
                	reqId = readInt();
                }

                ContractDetails contract = new ContractDetails();

                contract.contract().symbol(readStr());
                contract.contract().secType(readStr());
                contract.cusip(readStr());
                contract.coupon(readDouble());
                contract.maturity(readStr());
                contract.issueDate(readStr());
                contract.ratings(readStr());
                contract.bondType(readStr());
                contract.couponType(readStr());
                contract.convertible(readBoolFromInt());
                contract.callable(readBoolFromInt());
                contract.putable(readBoolFromInt());
                contract.descAppend(readStr());
                contract.contract().exchange(readStr());
                contract.contract().currency(readStr());
                contract.marketName(readStr());
                contract.contract().tradingClass(readStr());
                contract.contract().conid(readInt());
                contract.minTick(readDouble());
                contract.orderTypes(readStr());
                contract.validExchanges(readStr());
                if (version >= 2) {
                	contract.nextOptionDate(readStr());
                	contract.nextOptionType(readStr());
                	contract.nextOptionPartial(readBoolFromInt());
                	contract.notes(readStr());
                }
                if( version >= 4) {
                   contract.longName(readStr());
                }
                if ( version >= 6) {
                    contract.evRule(readStr());
                    contract.evMultiplier(readDouble());
                }
                if (version >= 5) {
                    int secIdListCount = readInt();
                    if (secIdListCount  > 0) {
                        contract.secIdList(new ArrayList<TagValue>(secIdListCount));
                        for (int i = 0; i < secIdListCount; ++i) {
                            TagValue tagValue = new TagValue();
                            tagValue.m_tag = readStr();
                            tagValue.m_value = readStr();
                            contract.secIdList().add(tagValue);
                        }
                    }
                }

                eWrapper().bondContractDetails( reqId, contract);
                break;
            }
            case EXECUTION_DATA: {
                int version = readInt();

                int reqId = -1;
                if (version >= 7) {
                	reqId = readInt();
                }

                int orderId = readInt();

                // read contract fields
                Contract contract = new Contract();
                if (version >= 5) {
                	contract.conid(readInt());
                }
                contract.symbol(readStr());
                contract.secType(readStr());
                contract.expiry(readStr());
                contract.strike(readDouble());
                contract.right(readStr());
                if (version >= 9) {
                    contract.multiplier(readStr());
                }
                contract.exchange(readStr());
                contract.currency(readStr());
                contract.localSymbol(readStr());
                if (version >= 10) {
                    contract.tradingClass(readStr());
                }

                Execution exec = new Execution();
                exec.orderId(orderId);
                exec.execId(readStr());
                exec.time(readStr());
                exec.acctNumber(readStr());
                exec.exchange(readStr());
                exec.side(readStr());
                exec.shares(readInt());
                exec.price(readDouble());
                if ( version >= 2 ) {
                    exec.permId(readInt());
                }
                if ( version >= 3) {
                    exec.clientId(readInt());
                }
                if ( version >= 4) {
                    exec.liquidation(readInt());
                }
                if (version >= 6) {
                	exec.cumQty(readInt());
                	exec.avgPrice(readDouble());
                }
                if (version >= 8) {
                    exec.orderRef(readStr());
                }
                if (version >= 9) {
                    exec.evRule(readStr());
                    exec.evMultiplier(readDouble());
                }

                eWrapper().execDetails( reqId, contract, exec);
                break;
            }
            case MARKET_DEPTH: {
                int version = readInt();
                int id = readInt();

                int position = readInt();
                int operation = readInt();
                int side = readInt();
                double price = readDouble();
                int size = readInt();

                eWrapper().updateMktDepth(id, position, operation,
                                side, price, size);
                break;
            }
            case MARKET_DEPTH_L2: {
                int version = readInt();
                int id = readInt();

                int position = readInt();
                String marketMaker = readStr();
                int operation = readInt();
                int side = readInt();
                double price = readDouble();
                int size = readInt();

                eWrapper().updateMktDepthL2(id, position, marketMaker,
                                operation, side, price, size);
                break;
            }
            case NEWS_BULLETINS: {
                int version = readInt();
                int newsMsgId = readInt();
                int newsMsgType = readInt();
                String newsMessage = readStr();
                String originatingExch = readStr();

                eWrapper().updateNewsBulletin( newsMsgId, newsMsgType, newsMessage, originatingExch);
                break;
            }
            case MANAGED_ACCTS: {
                int version = readInt();
                String accountsList = readStr();

                eWrapper().managedAccounts( accountsList);
                break;
            }
            case RECEIVE_FA: {
              int version = readInt();
              int faDataType = readInt();
              String xml = readStr();

              eWrapper().receiveFA(faDataType, xml);
              break;
            }
            case HISTORICAL_DATA: {
              int version = readInt();
              int reqId = readInt();
        	  String startDateStr;
        	  String endDateStr;
        	  String completedIndicator = "finished";
              if (version >= 2) {
            	  startDateStr = readStr();
            	  endDateStr = readStr();
            	  completedIndicator += "-" + startDateStr + "-" + endDateStr;
              }
              int itemCount = readInt();
              for (int ctr = 0; ctr < itemCount; ctr++) {
                String date = readStr();
                double open = readDouble();
                double high = readDouble();
                double low = readDouble();
                double close = readDouble();
                int volume = readInt();
                double WAP = readDouble();
                String hasGaps = readStr();
                int barCount = -1;
                if (version >= 3) {
                	barCount = readInt();
                }
                eWrapper().historicalData(reqId, date, open, high, low,
                                        close, volume, barCount, WAP,
                                        Boolean.valueOf(hasGaps).booleanValue());
              }
              // send end of dataset marker
              eWrapper().historicalData(reqId, completedIndicator, -1, -1, -1, -1, -1, -1, -1, false);
              break;
            }
            case SCANNER_PARAMETERS: {
                int version = readInt();
                String xml = readStr();
                eWrapper().scannerParameters(xml);
                break;
            }
            case CURRENT_TIME: {
                /*int version =*/ readInt();
                long time = readLong();
                eWrapper().currentTime(time);
                break;
            }
            case REAL_TIME_BARS: {
                /*int version =*/ readInt();
                int reqId = readInt();
                long time = readLong();
                double open = readDouble();
                double high = readDouble();
                double low = readDouble();
                double close = readDouble();
                long volume = readLong();
                double wap = readDouble();
                int count = readInt();
                eWrapper().realtimeBar(reqId, time, open, high, low, close, volume, wap, count);
                break;
            }
            case FUNDAMENTAL_DATA: {
                /*int version =*/ readInt();
                int reqId = readInt();
                String data = readStr();
                eWrapper().fundamentalData(reqId, data);
                break;
            }
            case CONTRACT_DATA_END: {
                /*int version =*/ readInt();
                int reqId = readInt();
                eWrapper().contractDetailsEnd(reqId);
                break;
            }
            case OPEN_ORDER_END: {
                /*int version =*/ readInt();
                eWrapper().openOrderEnd();
                break;
            }
            case ACCT_DOWNLOAD_END: {
                /*int version =*/ readInt();
                String accountName = readStr();
                eWrapper().accountDownloadEnd( accountName);
                break;
            }
            case EXECUTION_DATA_END: {
                /*int version =*/ readInt();
                int reqId = readInt();
                eWrapper().execDetailsEnd( reqId);
                break;
            }
            case DELTA_NEUTRAL_VALIDATION: {
                /*int version =*/ readInt();
                int reqId = readInt();

                DeltaNeutralContract underComp = new DeltaNeutralContract(readInt(), readDouble(), readDouble());
                eWrapper().deltaNeutralValidation( reqId, underComp);
                break;
            }
            case TICK_SNAPSHOT_END: {
                /*int version =*/ readInt();
                int reqId = readInt();

                eWrapper().tickSnapshotEnd( reqId);
                break;
            }
            case MARKET_DATA_TYPE: {
                /*int version =*/ readInt();
                int reqId = readInt();
                int marketDataType = readInt();

                eWrapper().marketDataType( reqId, marketDataType);
                break;
            }
            case COMMISSION_REPORT: {
                /*int version =*/ readInt();

                CommissionReport commissionReport = new CommissionReport();
                commissionReport.m_execId = readStr();
                commissionReport.m_commission = readDouble();
                commissionReport.m_currency = readStr();
                commissionReport.m_realizedPNL = readDouble();
                commissionReport.m_yield = readDouble();
                commissionReport.m_yieldRedemptionDate = readInt();

                eWrapper().commissionReport( commissionReport);
                break;
            }
            case VERIFY_MESSAGE_API: {
                /*int version =*/ readInt();
                String apiData = readStr();

                eWrapper().verifyMessageAPI(apiData);
                break;
            }
            case VERIFY_COMPLETED: {
                /*int version =*/ readInt();
                String isSuccessfulStr = readStr();
                boolean isSuccessful = "true".equals(isSuccessfulStr);
                String errorText = readStr();


                if (isSuccessful) {
                    m_parent.startAPI();
                }

                eWrapper().verifyCompleted(isSuccessful, errorText);
                break;
            }
            case DISPLAY_GROUP_LIST: {
                /*int version =*/ readInt();
                int reqId = readInt();
                String groups = readStr();

                eWrapper().displayGroupList(reqId, groups);
                break;
            }
            case DISPLAY_GROUP_UPDATED: {
                /*int version =*/ readInt();
                int reqId = readInt();
                String contractInfo = readStr();

                eWrapper().displayGroupUpdated(reqId, contractInfo);
                break;
            }
            case VERIFY_AND_AUTH_MESSAGE_API: {
                /*int version =*/ readInt();
                String apiData = readStr();
                String xyzChallenge = readStr();

                eWrapper().verifyAndAuthMessageAPI(apiData, xyzChallenge);
                break;
            }
            case VERIFY_AND_AUTH_COMPLETED: {
                /*int version =*/ readInt();
                String isSuccessfulStr = readStr();
                boolean isSuccessful = "true".equals(isSuccessfulStr);
                String errorText = readStr();


                if (isSuccessful) {
                    m_parent.startAPI();
                }

                eWrapper().verifyAndAuthCompleted(isSuccessful, errorText);
                break;
            }

            default: {
                m_parent.error( EClientErrors.NO_VALID_ID, EClientErrors.UNKNOWN_ID.code(), EClientErrors.UNKNOWN_ID.msg());
                return false;
            }
        }
        
        m_messageReader.close();
        return true;
    }

    public boolean readMessageToInternalBuf() throws IOException {
    	if ( m_useV100Plus ) {
	    	try {
	    		m_messageReader = new LengthPrefixedMessageReader( m_dis );
	    	}
	    	catch ( InvalidMessageLengthException ex ) {
	    		eWrapper().error(EClientErrors.NO_VALID_ID, EClientErrors.BAD_LENGTH.code(),
	    				EClientErrors.BAD_LENGTH.msg() + " " + ex.getMessage() );
	    		m_messageReader = null;
	    	}
    	}
    	else {
    		m_messageReader = new PreV100MessageReader( m_dis );
    	}
    	return m_messageReader != null;
    }
    
    protected String readStr() throws IOException {
    	return m_messageReader.readStr();
    }

    boolean readBoolFromInt() throws IOException {
        String str = readStr();
        return str == null ? false : (Integer.parseInt( str) != 0);
    }

    protected int readInt() throws IOException {
        String str = readStr();
        return str == null ? 0 : Integer.parseInt( str);
    }

    protected int readIntMax() throws IOException {
        String str = readStr();
        return (str == null || str.length() == 0) ? Integer.MAX_VALUE
        	                                      : Integer.parseInt( str);
    }

    protected long readLong() throws IOException {
        String str = readStr();
        return str == null ? 0l : Long.parseLong(str);
    }

    protected double readDouble() throws IOException {
        String str = readStr();
        return str == null ? 0 : Double.parseDouble( str);
    }

    protected double readDoubleMax() throws IOException {
        String str = readStr();
        return (str == null || str.length() == 0) ? Double.MAX_VALUE
        	                                      : Double.parseDouble( str);
    }
    
    /** Message reader interface */
    private interface IMessageReader extends Closeable {
    	public abstract String readStr() throws IOException;
    }
    
    /** Buffered reading implementation for a length prefixed message */
    private static class LengthPrefixedMessageReader implements IMessageReader {
    	private final byte[] m_buffer;
    	private int m_currentPos = 0;
    	
    	public LengthPrefixedMessageReader( InputStream din ) throws IOException {
    		long length = readUnsignedIntLength( din );
    		if ( length > MAX_MSG_LENGTH ) {
    			throw new InvalidMessageLengthException( "message is too long: " + length );
    		}
    		m_buffer = readFully( din, (int)length );
    	}
    	
        public final long readUnsignedIntLength( InputStream in ) throws IOException {
            int ch1 = in.read();
            if ( ch1 < 0 ) {
            	throw new EOSException( "eos");
            }
            int ch2 = in.read();
            int ch3 = in.read();
            int ch4 = in.read();
            if ((ch2 | ch3 | ch4) < 0) {
                throw new EOFException();
            }
            return ((ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0)) & 0xffffffffL;
        }
        
        public final byte[] readFully( InputStream in, int len ) throws IOException {
        	byte[] b = new byte[ len ];
            for ( int n = 0, count; n < len; n+= count ) {
                count = in.read( b, n, len - n );
                if ( count < 0) {
                    throw new EOFException();
                }
            }
            return b;
        }
    	
    	@Override public String readStr() throws IOException {
    		int startPos = m_currentPos;
    		int bufferLength = m_buffer.length;
            for ( int currentPos = startPos; currentPos < bufferLength; ++currentPos ) {
                if ( m_buffer[ currentPos ] == 0 ) {
                	m_currentPos = currentPos + 1;
                	return currentPos > startPos 
                			? new String( m_buffer, startPos, currentPos - startPos )
                			: null;
                }
            }
            m_currentPos = m_buffer.length;
    		throw new EOFException( "attempt to read past the end of buffer" );
        }

        @Override public void close() {
            m_currentPos = m_buffer.length;
        }
    }
    
    /** Non-buffered reading implementation for old style, non length prefixed message *** */
    private static class PreV100MessageReader implements IMessageReader {
    	private final DataInputStream m_din;
    	
    	public PreV100MessageReader( DataInputStream din ) {
    		m_din = din;
    	}
    	
    	@Override public String readStr() throws IOException {
    		 StringBuffer buf = new StringBuffer();
 	         while( true) {
 	            int c = m_din.read();
 	            if( c <= 0) {
 	            	if ( c < 0 ) {
 	            		throw new EOFException();
 	            	}
 	                break;
 	            }
 	            buf.append( (char)c);
 	        }
 	
 	        String str = buf.toString();
 	        return str.length() == 0 ? null : str;    
 	    }
    	
    	@Override public void close() {
    	    /** noop in pre-v100 */
    	}
    }
    
    @SuppressWarnings("serial")
	private static class InvalidMessageLengthException extends IOException {
		public InvalidMessageLengthException(String message) {
			super(message);
		}
    }
    
    @SuppressWarnings("serial")
    private static class EOSException extends EOFException {
    	public EOSException(String message) {
    		super(message);
    	}
    }
}
