/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

package com.ib.client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FilterOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.List;
import java.util.Vector;

public class EClientSocket {

    // Client version history
    //
    // 	6 = Added parentId to orderStatus
    // 	7 = The new execDetails event returned for an order filled status and reqExecDetails
    //     Also market depth is available.
    // 	8 = Added lastFillPrice to orderStatus() event and permId to execution details
    //  9 = Added 'averageCost', 'unrealizedPNL', and 'unrealizedPNL' to updatePortfolio event
    // 10 = Added 'serverId' to the 'open order' & 'order status' events.
    //      We send back all the API open orders upon connection.
    //      Added new methods reqAllOpenOrders, reqAutoOpenOrders()
    //      Added FA support - reqExecution has filter.
    //                       - reqAccountUpdates takes acct code.
    // 11 = Added permId to openOrder event.
    // 12 = requsting open order attributes ignoreRth, hidden, and discretionary
    // 13 = added goodAfterTime
    // 14 = always send size on bid/ask/last tick
    // 15 = send allocation description string on openOrder
    // 16 = can receive account name in account and portfolio updates, and fa params in openOrder
    // 17 = can receive liquidation field in exec reports, and notAutoAvailable field in mkt data
    // 18 = can receive good till date field in open order messages, and request intraday backfill
    // 19 = can receive rthOnly flag in ORDER_STATUS
    // 20 = expects TWS time string on connection after server version >= 20.
    // 21 = can receive bond contract details.
    // 22 = can receive price magnifier in version 2 contract details message
    // 23 = support for scanner
    // 24 = can receive volatility order parameters in open order messages
	// 25 = can receive HMDS query start and end times
	// 26 = can receive option vols in option market data messages
	// 27 = can receive delta neutral order type and delta neutral aux price in place order version 20: API 8.85
	// 28 = can receive option model computation ticks: API 8.9
	// 29 = can receive trail stop limit price in open order and can place them: API 8.91
	// 30 = can receive extended bond contract def, new ticks, and trade count in bars
	// 31 = can receive EFP extensions to scanner and market data, and combo legs on open orders
	//    ; can receive RT bars
	// 32 = can receive TickType.LAST_TIMESTAMP
	//    ; can receive "whyHeld" in order status messages
	// 33 = can receive ScaleNumComponents and ScaleComponentSize is open order messages
	// 34 = can receive whatIf orders / order state
	// 35 = can receive contId field for Contract objects
	// 36 = can receive outsideRth field for Order objects
	// 37 = can receive clearingAccount and clearingIntent for Order objects
	// 38 = can receive multiplier and primaryExchange in portfolio updates
	//    ; can receive cumQty and avgPrice in execution
	//    ; can receive fundamental data
	//    ; can receive underComp for Contract objects
	//    ; can receive reqId and end marker in contractDetails/bondContractDetails
 	//    ; can receive ScaleInitComponentSize and ScaleSubsComponentSize for Order objects
	// 39 = can receive underConId in contractDetails
	// 40 = can receive algoStrategy/algoParams in openOrder
	// 41 = can receive end marker for openOrder
	//    ; can receive end marker for account download
	//    ; can receive end marker for executions download
	// 42 = can receive deltaNeutralValidation
	// 43 = can receive longName(companyName)
	//    ; can receive listingExchange
	//    ; can receive RTVolume tick
	// 44 = can receive end market for ticker snapshot
	// 45 = can receive notHeld field in openOrder
	// 46 = can receive contractMonth, industry, category, subcategory fields in contractDetails
	//    ; can receive timeZoneId, tradingHours, liquidHours fields in contractDetails
	// 47 = can receive gamma, vega, theta, undPrice fields in TICK_OPTION_COMPUTATION
	// 48 = can receive exemptCode in openOrder
	// 49 = can receive hedgeType and hedgeParam in openOrder
	// 50 = can receive optOutSmartRouting field in openOrder
	// 51 = can receive smartComboRoutingParams in openOrder
	// 52 = can receive deltaNeutralConId, deltaNeutralSettlingFirm, deltaNeutralClearingAccount and deltaNeutralClearingIntent in openOrder
	// 53 = can receive orderRef in execution
	// 54 = can receive scale order fields (PriceAdjustValue, PriceAdjustInterval, ProfitOffset, AutoReset,
	//      InitPosition, InitFillQty and RandomPercent) in openOrder
	// 55 = can receive orderComboLegs (price) in openOrder
	// 56 = can receive trailingPercent in openOrder
	// 57 = can receive commissionReport message
	// 58 = can receive CUSIP/ISIN/etc. in contractDescription/bondContractDescription
	// 59 = can receive evRule, evMultiplier in contractDescription/bondContractDescription/executionDetails
	//      can receive multiplier in executionDetails
	// 60 = can receive deltaNeutralOpenClose, deltaNeutralShortSale, deltaNeutralShortSaleSlot and deltaNeutralDesignatedLocation in openOrder
	// 61 = can receive multiplier in openOrder
	//      can receive tradingClass in openOrder, updatePortfolio, execDetails and position
	// 62 = can receive avgCost in position message
	// 63 = can receive verifyMessageAPI, verifyCompleted, displayGroupList and displayGroupUpdated messages
	// 64 = orderSolicited property

    public static final int MIN_VERSION = 100; // envelope encoding, applicable to useV100Plus mode only
    public static final int MAX_VERSION = 100; // ditto
	
    private static final int CLIENT_VERSION = 64;
    private static final int SERVER_VERSION = 38;
    private static final String BAG_SEC_TYPE = "BAG";

    // FA msg data types
    public static final int GROUPS = 1;
    public static final int PROFILES = 2;
    public static final int ALIASES = 3;

    public static String faMsgTypeName(int faDataType) {
        switch (faDataType) {
            case GROUPS:
                return "GROUPS";
            case PROFILES:
                return "PROFILES";
            case ALIASES:
                return "ALIASES";
        }
        return null;
    }

    // outgoing msg id's
    private static final int REQ_MKT_DATA = 1;
    private static final int CANCEL_MKT_DATA = 2;
    protected static final int PLACE_ORDER = 3;
    private static final int CANCEL_ORDER = 4;
    private static final int REQ_OPEN_ORDERS = 5;
    private static final int REQ_ACCOUNT_DATA = 6;
    private static final int REQ_EXECUTIONS = 7;
    private static final int REQ_IDS = 8;
    private static final int REQ_CONTRACT_DATA = 9;
    private static final int REQ_MKT_DEPTH = 10;
    private static final int CANCEL_MKT_DEPTH = 11;
    private static final int REQ_NEWS_BULLETINS = 12;
    private static final int CANCEL_NEWS_BULLETINS = 13;
    private static final int SET_SERVER_LOGLEVEL = 14;
    private static final int REQ_AUTO_OPEN_ORDERS = 15;
    private static final int REQ_ALL_OPEN_ORDERS = 16;
    private static final int REQ_MANAGED_ACCTS = 17;
    private static final int REQ_FA = 18;
    private static final int REPLACE_FA = 19;
    private static final int REQ_HISTORICAL_DATA = 20;
    private static final int EXERCISE_OPTIONS = 21;
    private static final int REQ_SCANNER_SUBSCRIPTION = 22;
    private static final int CANCEL_SCANNER_SUBSCRIPTION = 23;
    private static final int REQ_SCANNER_PARAMETERS = 24;
    private static final int CANCEL_HISTORICAL_DATA = 25;
    private static final int REQ_CURRENT_TIME = 49;
    private static final int REQ_REAL_TIME_BARS = 50;
    private static final int CANCEL_REAL_TIME_BARS = 51;
    private static final int REQ_FUNDAMENTAL_DATA = 52;
    private static final int CANCEL_FUNDAMENTAL_DATA = 53;
    private static final int REQ_CALC_IMPLIED_VOLAT = 54;
    private static final int REQ_CALC_OPTION_PRICE = 55;
    private static final int CANCEL_CALC_IMPLIED_VOLAT = 56;
    private static final int CANCEL_CALC_OPTION_PRICE = 57;
    private static final int REQ_GLOBAL_CANCEL = 58;
    private static final int REQ_MARKET_DATA_TYPE = 59;
    private static final int REQ_POSITIONS = 61;
    private static final int REQ_ACCOUNT_SUMMARY = 62;
    private static final int CANCEL_ACCOUNT_SUMMARY = 63;
    private static final int CANCEL_POSITIONS = 64;
    private static final int VERIFY_REQUEST = 65;
    private static final int VERIFY_MESSAGE = 66;
    private static final int QUERY_DISPLAY_GROUPS = 67;
    private static final int SUBSCRIBE_TO_GROUP_EVENTS = 68;
    private static final int UPDATE_DISPLAY_GROUP = 69;
    private static final int UNSUBSCRIBE_FROM_GROUP_EVENTS = 70;
    private static final int START_API = 71;

	private static final int MIN_SERVER_VER_REAL_TIME_BARS = 34;
	private static final int MIN_SERVER_VER_SCALE_ORDERS = 35;
	private static final int MIN_SERVER_VER_SNAPSHOT_MKT_DATA = 35;
	private static final int MIN_SERVER_VER_SSHORT_COMBO_LEGS = 35;
	private static final int MIN_SERVER_VER_WHAT_IF_ORDERS = 36;
	private static final int MIN_SERVER_VER_CONTRACT_CONID = 37;
	private static final int MIN_SERVER_VER_PTA_ORDERS = 39;
	private static final int MIN_SERVER_VER_FUNDAMENTAL_DATA = 40;
	private static final int MIN_SERVER_VER_UNDER_COMP = 40;
	private static final int MIN_SERVER_VER_CONTRACT_DATA_CHAIN = 40;
	private static final int MIN_SERVER_VER_SCALE_ORDERS2 = 40;
	private static final int MIN_SERVER_VER_ALGO_ORDERS = 41;
	private static final int MIN_SERVER_VER_EXECUTION_DATA_CHAIN = 42;
	private static final int MIN_SERVER_VER_NOT_HELD = 44;
	private static final int MIN_SERVER_VER_SEC_ID_TYPE = 45;
	private static final int MIN_SERVER_VER_PLACE_ORDER_CONID = 46;
	private static final int MIN_SERVER_VER_REQ_MKT_DATA_CONID = 47;
    private static final int MIN_SERVER_VER_REQ_CALC_IMPLIED_VOLAT = 49;
    private static final int MIN_SERVER_VER_REQ_CALC_OPTION_PRICE = 50;
    private static final int MIN_SERVER_VER_CANCEL_CALC_IMPLIED_VOLAT = 50;
    private static final int MIN_SERVER_VER_CANCEL_CALC_OPTION_PRICE = 50;
    private static final int MIN_SERVER_VER_SSHORTX_OLD = 51;
    private static final int MIN_SERVER_VER_SSHORTX = 52;
    private static final int MIN_SERVER_VER_REQ_GLOBAL_CANCEL = 53;
    private static final int MIN_SERVER_VER_HEDGE_ORDERS = 54;
    private static final int MIN_SERVER_VER_REQ_MARKET_DATA_TYPE = 55;
    private static final int MIN_SERVER_VER_OPT_OUT_SMART_ROUTING = 56;
    private static final int MIN_SERVER_VER_SMART_COMBO_ROUTING_PARAMS = 57;
    private static final int MIN_SERVER_VER_DELTA_NEUTRAL_CONID = 58;
    private static final int MIN_SERVER_VER_SCALE_ORDERS3 = 60;
    private static final int MIN_SERVER_VER_ORDER_COMBO_LEGS_PRICE = 61;
    private static final int MIN_SERVER_VER_TRAILING_PERCENT = 62;
    protected static final int MIN_SERVER_VER_DELTA_NEUTRAL_OPEN_CLOSE = 66;
    private static final int MIN_SERVER_VER_ACCT_SUMMARY = 67;
    protected static final int MIN_SERVER_VER_TRADING_CLASS = 68;
    protected static final int MIN_SERVER_VER_SCALE_TABLE = 69;
    protected static final int MIN_SERVER_VER_LINKING = 70;
    protected static final int MIN_SERVER_VER_ALGO_ID = 71;
    protected static final int MIN_SERVER_VER_OPTIONAL_CAPABILITIES = 72;
    protected static final int MIN_SERVER_VER_ORDER_SOLICITED = 73;

    private AnyWrapper m_anyWrapper;    // msg handler
    protected DataOutputStream m_dos;   // the socket output stream
    private boolean m_connected;        // true if we are connected
    private EReader m_reader;           // thread which reads msgs from socket
    protected int m_serverVersion;
    private String m_TwsTime;
    private int m_clientId;
    private boolean m_extraAuth;
    private boolean m_useV100Plus;
    private String m_optionalCapabilities;
    private String m_connectOptions; // iServer rails are used for Connection if this is not null
    private int m_port;

    public int serverVersion()          { return m_serverVersion;   }
    public String TwsConnectionTime()   { return m_TwsTime; }
    public AnyWrapper wrapper() 		{ return m_anyWrapper; }
    public EReader reader()             { return m_reader; }
    public boolean isConnected() 		{ return m_connected; }

    // set
    protected synchronized void setExtraAuth(boolean extraAuth) { m_extraAuth = extraAuth; }
    public void OptionalCapabilities(String val) 		{ m_optionalCapabilities = val; }

    // get
    public String OptionalCapabilities() { return m_optionalCapabilities; }

    public EClientSocket( AnyWrapper anyWrapper) {
        m_anyWrapper = anyWrapper;
        m_clientId = -1;
        m_extraAuth = false;
        m_optionalCapabilities = "";
        m_connected = false;
        m_serverVersion = 0;
    }
    
    // iServer rails are used for Connection if connectOptions != null
    public void setUseV100Plus(String connectOptions) { 
    	if( m_connected ) {
            m_anyWrapper.error(EClientErrors.NO_VALID_ID, EClientErrors.ALREADY_CONNECTED.code(),
                    EClientErrors.ALREADY_CONNECTED.msg());
    		return;
  		}
    	m_connectOptions = connectOptions; 
    	m_useV100Plus = true; 
   	} 

    public synchronized void eConnect( String host, int port, int clientId) {
        eConnect(host, port, clientId, false);
    }
    
    public synchronized void eConnect( String host, int port, int clientId, boolean extraAuth) {
        // already connected?
        host = checkConnected(host);

        m_port = port;
        m_clientId = clientId;
        m_extraAuth = extraAuth;

        if(host == null){
            return;
        }
        try{
            Socket socket = new Socket( host, port);
            eConnect(socket);
        }
        catch( Exception e) {
        	eDisconnect();
            connectionError();
        }
    }

    protected void connectionError() {
        m_anyWrapper.error( EClientErrors.NO_VALID_ID, EClientErrors.CONNECT_FAIL.code(),
                EClientErrors.CONNECT_FAIL.msg());
        m_reader = null;
    }

    protected String checkConnected(String host) {
        if( m_connected) {
            m_anyWrapper.error(EClientErrors.NO_VALID_ID, EClientErrors.ALREADY_CONNECTED.code(),
                    EClientErrors.ALREADY_CONNECTED.msg());
            return null;
        }
        if( IsEmpty( host) ) {
            host = "127.0.0.1";
        }
        return host;
    }

    public EReader createReader(EClientSocket socket, DataInputStream dis) {
        return new EReader(socket, dis);
    }

    public synchronized void eConnect(Socket socket, int clientId) throws IOException {
        m_clientId = clientId;
        eConnect(socket);
    }
    
    public synchronized void eConnect(Socket socket) throws IOException {
        // create io streams
        m_dos = new DataOutputStream( socket.getOutputStream() );

        // send client version (unless logon via iserver and/or Version > 100)
        if( !m_useV100Plus || m_connectOptions == null ) {
        	send( CLIENT_VERSION); // Do not add length prefix here, because Server does not know Client's version yet
        }
        else {
        	// Switch to GW API (Version 100+ requires length prefix)
        	sendV100APIHeader();
        }

        // start reader thread
        m_reader = createReader(this, new DataInputStream(socket.getInputStream()));
        if( m_useV100Plus ) {
            m_reader.setUseV100Plus();
        }
        
        // check server version
    	if( !m_reader.readMessageToInternalBuf() ) {
    	    return;
    	}  
        m_serverVersion = m_reader.readInt();
        System.out.println("Server Version:" + m_serverVersion);
        
        if ( m_serverVersion >= 20 ){
        	// currently with Unified both server version and time sent in one message
            m_TwsTime = m_reader.readStr();
            System.out.println("TWS Time at connection:" + m_TwsTime);
        }
    	if( m_useV100Plus && (m_serverVersion < MIN_VERSION || m_serverVersion > MAX_VERSION) ) {
    		eDisconnect();
    		m_anyWrapper.error(EClientErrors.NO_VALID_ID, EClientErrors.UNSUPPORTED_VERSION.code(), EClientErrors.UNSUPPORTED_VERSION.msg());
    		return;
   		}
        if( m_serverVersion < SERVER_VERSION) {
        	eDisconnect();
            m_anyWrapper.error( EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(), EClientErrors.UPDATE_TWS.msg());
            return;
        }

        // set connected flag
        m_connected = true;

        // Send the client id
        if ( m_serverVersion >= 3 ){
            if ( m_serverVersion < MIN_SERVER_VER_LINKING) {
                send( m_clientId);
            }
            else if (!m_extraAuth){
                startAPI();
            }
        }

        m_reader.start();

    }

    public synchronized void eDisconnect() {
        // not connected?
        if( m_dos == null) {
            return;
        }

        m_connected = false;
        m_extraAuth = false;
        m_clientId = -1;
        m_serverVersion = 0;
        m_TwsTime = "";

        FilterOutputStream dos = m_dos;
        m_dos = null;

        EReader reader = m_reader;
        m_reader = null;

        try {
            // stop reader thread; reader thread will close input stream
            if( reader != null) {
                reader.interrupt();
            }
        }
        catch( Exception e) {
        }

        try {
            // close output stream
            if( dos != null) {
                dos.close();
            }
        }
        catch( Exception e) {
        }
    }

    protected synchronized void startAPI() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 2;

        try {
        	Builder b = prepareBuffer(); 
        	
            b.send(START_API);
            b.send(VERSION);
            b.send(m_clientId);
            
            if (m_serverVersion >= MIN_SERVER_VER_OPTIONAL_CAPABILITIES) {
                b.send(m_optionalCapabilities);
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID,
                   EClientErrors.FAIL_SEND_STARTAPI, "" + e);
            close();
        }
    }

    public synchronized void cancelScannerSubscription( int tickerId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < 24) {
          error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                "  It does not support API scanner subscription.");
          return;
        }

        final int VERSION = 1;

        // send cancel mkt data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_SCANNER_SUBSCRIPTION);
            b.send( VERSION);
            b.send( tickerId);
            
            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_CANSCANNER, "" + e);
            close();
        }
    }

    public synchronized void reqScannerParameters() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < 24) {
          error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                "  It does not support API scanner subscription.");
          return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send(REQ_SCANNER_PARAMETERS);
            b.send(VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID,
                   EClientErrors.FAIL_SEND_REQSCANNERPARAMETERS, "" + e);
            close();
        }
    }

    public synchronized void reqScannerSubscription( int tickerId, ScannerSubscription subscription, Vector<TagValue> scannerSubscriptionOptions) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < 24) {
          error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                "  It does not support API scanner subscription.");
          return;
        }

        final int VERSION = 4;

        try {
            Builder b = prepareBuffer(); 

            b.send(REQ_SCANNER_SUBSCRIPTION);
            b.send(VERSION);
            b.send(tickerId);
            b.sendMax(subscription.numberOfRows());
            b.send(subscription.instrument());
            b.send(subscription.locationCode());
            b.send(subscription.scanCode());
            b.sendMax(subscription.abovePrice());
            b.sendMax(subscription.belowPrice());
            b.sendMax(subscription.aboveVolume());
            b.sendMax(subscription.marketCapAbove());
            b.sendMax(subscription.marketCapBelow());
            b.send(subscription.moodyRatingAbove());
            b.send(subscription.moodyRatingBelow());
            b.send(subscription.spRatingAbove());
            b.send(subscription.spRatingBelow());
            b.send(subscription.maturityDateAbove());
            b.send(subscription.maturityDateBelow());
            b.sendMax(subscription.couponRateAbove());
            b.sendMax(subscription.couponRateBelow());
            b.send(subscription.excludeConvertible());
            if (m_serverVersion >= 25) {
                b.sendMax(subscription.averageOptionVolumeAbove());
                b.send(subscription.scannerSettingPairs());
            }
            if (m_serverVersion >= 27) {
                b.send(subscription.stockTypeFilter());
            }
            
            // send scannerSubscriptionOptions parameter
            if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
                StringBuilder scannerSubscriptionOptionsStr = new StringBuilder();
                int scannerSubscriptionOptionsCount = scannerSubscriptionOptions == null ? 0 : scannerSubscriptionOptions.size();
                if( scannerSubscriptionOptionsCount > 0) {
                    for( int i = 0; i < scannerSubscriptionOptionsCount; ++i) {
                        TagValue tagValue = (TagValue)scannerSubscriptionOptions.get(i);
                        scannerSubscriptionOptionsStr.append( tagValue.m_tag);
                        scannerSubscriptionOptionsStr.append( "=");
                        scannerSubscriptionOptionsStr.append( tagValue.m_value);
                        scannerSubscriptionOptionsStr.append( ";");
                    }
                }
                b.send( scannerSubscriptionOptionsStr.toString());
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_REQSCANNER, "" + e);
            close();
        }
    }

    public synchronized void reqMktData(int tickerId, Contract contract,
    		String genericTickList, boolean snapshot, List<TagValue> mktDataOptions) {
        if (!m_connected) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.NOT_CONNECTED, "");
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_SNAPSHOT_MKT_DATA && snapshot) {
        	error(tickerId, EClientErrors.UPDATE_TWS,
        			"  It does not support snapshot market data requests.");
        	return;
        }

        if (m_serverVersion < MIN_SERVER_VER_UNDER_COMP) {
        	if (contract.m_underComp != null) {
        		error(tickerId, EClientErrors.UPDATE_TWS,
        			"  It does not support delta-neutral orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_REQ_MKT_DATA_CONID) {
            if (contract.m_conId > 0) {
                error(tickerId, EClientErrors.UPDATE_TWS,
                    "  It does not support conId parameter.");
                return;
            }
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass)) {
                error(tickerId, EClientErrors.UPDATE_TWS,
                    "  It does not support tradingClass parameter in reqMarketData.");
                return;
            }
        }

        final int VERSION = 11;

        try {
            // send req mkt data msg
            Builder b = prepareBuffer(); 

            b.send(REQ_MKT_DATA);
            b.send(VERSION);
            b.send(tickerId);

            // send contract fields
            if (m_serverVersion >= MIN_SERVER_VER_REQ_MKT_DATA_CONID) {
                b.send(contract.m_conId);
            }
            b.send(contract.m_symbol);
            b.send(contract.m_secType);
            b.send(contract.m_expiry);
            b.send(contract.m_strike);
            b.send(contract.m_right);
            if (m_serverVersion >= 15) {
                b.send(contract.m_multiplier);
            }
            b.send(contract.m_exchange);
            if (m_serverVersion >= 14) {
                b.send(contract.m_primaryExch);
            }
            b.send(contract.m_currency);
            if(m_serverVersion >= 2) {
                b.send( contract.m_localSymbol);
            }
            if(m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send( contract.m_tradingClass);
            }
            if(m_serverVersion >= 8 && BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
                if ( contract.m_comboLegs == null ) {
                    b.send( 0);
                }
                else {
                    b.send( contract.m_comboLegs.size());

                    ComboLeg comboLeg;
                    for (int i=0; i < contract.m_comboLegs.size(); i ++) {
                        comboLeg = contract.m_comboLegs.get(i);
                        b.send( comboLeg.m_conId);
                        b.send( comboLeg.m_ratio);
                        b.send( comboLeg.m_action);
                        b.send( comboLeg.m_exchange);
                    }
                }
            }

            if (m_serverVersion >= MIN_SERVER_VER_UNDER_COMP) {
         	   if (contract.m_underComp != null) {
         		   UnderComp underComp = contract.m_underComp;
         		   b.send( true);
         		   b.send( underComp.m_conId);
         		   b.send( underComp.m_delta);
         		   b.send( underComp.m_price);
         	   }
         	   else {
         		   b.send( false);
         	   }
            }

            if (m_serverVersion >= 31) {
            	/*
            	 * Note: Even though SHORTABLE tick type supported only
            	 *       starting server version 33 it would be relatively
            	 *       expensive to expose this restriction here.
            	 *
            	 *       Therefore we are relying on TWS doing validation.
            	 */
            	b.send( genericTickList);
            }
            if (m_serverVersion >= MIN_SERVER_VER_SNAPSHOT_MKT_DATA) {
            	b.send (snapshot);
            }
            
            // send mktDataOptions parameter
            if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
                StringBuilder mktDataOptionsStr = new StringBuilder();
                int mktDataOptionsCount = mktDataOptions == null ? 0 : mktDataOptions.size();
                if( mktDataOptionsCount > 0) {
                    for( int i = 0; i < mktDataOptionsCount; ++i) {
                        TagValue tagValue = (TagValue)mktDataOptions.get(i);
                        mktDataOptionsStr.append( tagValue.m_tag);
                        mktDataOptionsStr.append( "=");
                        mktDataOptionsStr.append( tagValue.m_value);
                        mktDataOptionsStr.append( ";");
                    }
                }
                b.send( mktDataOptionsStr.toString());
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_REQMKT, "" + e);
            close();
        }
    }

    public synchronized void cancelHistoricalData( int tickerId ) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < 24) {
          error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                "  It does not support historical data query cancellation.");
          return;
        }

        final int VERSION = 1;

        // send cancel mkt data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_HISTORICAL_DATA);
            b.send( VERSION);
            b.send( tickerId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_CANHISTDATA, "" + e);
            close();
        }
    }

    public void cancelRealTimeBars(int tickerId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REAL_TIME_BARS) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                  "  It does not support realtime bar data query cancellation.");
            return;
        }

        final int VERSION = 1;

        // send cancel mkt data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_REAL_TIME_BARS);
            b.send( VERSION);
            b.send( tickerId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_CANRTBARS, "" + e);
            close();
        }
    }

    /** Note that formatData parameter affects intra-day bars only; 1-day bars always return with date in YYYYMMDD format. */
    public synchronized void reqHistoricalData( int tickerId, Contract contract,
                                                String endDateTime, String durationStr,
                                                String barSizeSetting, String whatToShow,
                                                int useRTH, int formatDate, List<TagValue> chartOptions) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 6;

        try {
          if (m_serverVersion < 16) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                  "  It does not support historical data backfill.");
            return;
          }

          if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
              if (!IsEmpty(contract.m_tradingClass) || (contract.m_conId > 0)) {
                  error(tickerId, EClientErrors.UPDATE_TWS,
                      "  It does not support conId and tradingClass parameters in reqHistroricalData.");
                  return;
              }
          }

          Builder b = prepareBuffer(); 

          b.send(REQ_HISTORICAL_DATA);
          b.send(VERSION);
          b.send(tickerId);

          // send contract fields
          if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
              b.send(contract.m_conId);
          }
          b.send(contract.m_symbol);
          b.send(contract.m_secType);
          b.send(contract.m_expiry);
          b.send(contract.m_strike);
          b.send(contract.m_right);
          b.send(contract.m_multiplier);
          b.send(contract.m_exchange);
          b.send(contract.m_primaryExch);
          b.send(contract.m_currency);
          b.send(contract.m_localSymbol);
          if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
              b.send(contract.m_tradingClass);
          }
          if (m_serverVersion >= 31) {
        	  b.send(contract.m_includeExpired ? 1 : 0);
          }
          if (m_serverVersion >= 20) {
              b.send(endDateTime);
              b.send(barSizeSetting);
          }
          b.send(durationStr);
          b.send(useRTH);
          b.send(whatToShow);
          if (m_serverVersion > 16) {
              b.send(formatDate);
          }
          if (BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
              if (contract.m_comboLegs == null) {
                  b.send(0);
              }
              else {
                  b.send(contract.m_comboLegs.size());

                  ComboLeg comboLeg;
                  for (int i = 0; i < contract.m_comboLegs.size(); i++) {
                      comboLeg = contract.m_comboLegs.get(i);
                      b.send(comboLeg.m_conId);
                      b.send(comboLeg.m_ratio);
                      b.send(comboLeg.m_action);
                      b.send(comboLeg.m_exchange);
                  }
              }
          }
          
          // send chartOptions parameter
          if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
              StringBuilder chartOptionsStr = new StringBuilder();
              int chartOptionsCount = chartOptions == null ? 0 : chartOptions.size();
              if( chartOptionsCount > 0) {
                  for( int i = 0; i < chartOptionsCount; ++i) {
                      TagValue tagValue = (TagValue)chartOptions.get(i);
                      chartOptionsStr.append( tagValue.m_tag);
                      chartOptionsStr.append( "=");
                      chartOptionsStr.append( tagValue.m_value);
                      chartOptionsStr.append( ";");
                  }
              }
              b.send( chartOptionsStr.toString());
          }
          closeAndSend(b);
        }
        catch (Exception e) {
          error(tickerId, EClientErrors.FAIL_SEND_REQHISTDATA, "" + e);
          close();
        }
    }

    public synchronized void reqRealTimeBars(int tickerId, Contract contract, int barSize, String whatToShow, boolean useRTH, Vector<TagValue> realTimeBarsOptions) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REAL_TIME_BARS) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                  "  It does not support real time bars.");
            return;
        }
        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass) || (contract.m_conId > 0)) {
                  error(tickerId, EClientErrors.UPDATE_TWS,
                      "  It does not support conId and tradingClass parameters in reqRealTimeBars.");
                  return;
            }
        }

        final int VERSION = 3;

        try {
            // send req mkt data msg
            Builder b = prepareBuffer(); 

            b.send(REQ_REAL_TIME_BARS);
            b.send(VERSION);
            b.send(tickerId);

            // send contract fields
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_conId);
            }
            b.send(contract.m_symbol);
            b.send(contract.m_secType);
            b.send(contract.m_expiry);
            b.send(contract.m_strike);
            b.send(contract.m_right);
            b.send(contract.m_multiplier);
            b.send(contract.m_exchange);
            b.send(contract.m_primaryExch);
            b.send(contract.m_currency);
            b.send(contract.m_localSymbol);
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }
            b.send(barSize);  // this parameter is not currently used
            b.send(whatToShow);
            b.send(useRTH);

            // send realTimeBarsOptions parameter
            if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
                StringBuilder realTimeBarsOptionsStr = new StringBuilder();
                int realTimeBarsOptionsCount = realTimeBarsOptions == null ? 0 : realTimeBarsOptions.size();
                if( realTimeBarsOptionsCount > 0) {
                    for( int i = 0; i < realTimeBarsOptionsCount; ++i) {
                        TagValue tagValue = (TagValue)realTimeBarsOptions.get(i);
                        realTimeBarsOptionsStr.append( tagValue.m_tag);
                        realTimeBarsOptionsStr.append( "=");
                        realTimeBarsOptionsStr.append( tagValue.m_value);
                        realTimeBarsOptionsStr.append( ";");
                    }
                }
                b.send( realTimeBarsOptionsStr.toString());
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_REQRTBARS, "" + e);
            close();
        }
    }

    public synchronized void reqContractDetails(int reqId, Contract contract) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >=4
        if( m_serverVersion < 4) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(),
                            EClientErrors.UPDATE_TWS.msg());
            return;
        }

        if( m_serverVersion < MIN_SERVER_VER_SEC_ID_TYPE) {
        	if (!IsEmpty(contract.m_secIdType) || !IsEmpty(contract.m_secId)) {
        		error(reqId, EClientErrors.UPDATE_TWS,
        			"  It does not support secIdType and secId parameters.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass)) {
                  error(reqId, EClientErrors.UPDATE_TWS,
                      "  It does not support tradingClass parameter in reqContractDetails.");
                  return;
            }
        }

        final int VERSION = 7;

        try {
            // send req mkt data msg
            Builder b = prepareBuffer(); 

            b.send( REQ_CONTRACT_DATA);
            b.send( VERSION);

            if (m_serverVersion >= MIN_SERVER_VER_CONTRACT_DATA_CHAIN) {
            	b.send( reqId);
            }

            // send contract fields
            if (m_serverVersion >= MIN_SERVER_VER_CONTRACT_CONID) {
            	b.send(contract.m_conId);
            }
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_expiry);
            b.send( contract.m_strike);
            b.send( contract.m_right);
            if (m_serverVersion >= 15) {
                b.send(contract.m_multiplier);
            }
            b.send( contract.m_exchange);
            b.send( contract.m_currency);
            b.send( contract.m_localSymbol);
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }
            if (m_serverVersion >= 31) {
                b.send(contract.m_includeExpired);
            }
            if (m_serverVersion >= MIN_SERVER_VER_SEC_ID_TYPE) {
            	b.send( contract.m_secIdType);
            	b.send( contract.m_secId);
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQCONTRACT, "" + e);
            close();
        }
    }

    public synchronized void reqMktDepth( int tickerId, Contract contract, int numRows, Vector<TagValue> mktDepthOptions) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >=6
        if( m_serverVersion < 6) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(),
                    EClientErrors.UPDATE_TWS.msg());
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass) || (contract.m_conId > 0)) {
                  error(tickerId, EClientErrors.UPDATE_TWS,
                      "  It does not support conId and tradingClass parameters in reqMktDepth.");
                  return;
            }
        }

        final int VERSION = 5;

        try {
            // send req mkt data msg
            Builder b = prepareBuffer(); 

            b.send( REQ_MKT_DEPTH);
            b.send( VERSION);
            b.send( tickerId);

            // send contract fields
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_conId);
            }
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_expiry);
            b.send( contract.m_strike);
            b.send( contract.m_right);
            if (m_serverVersion >= 15) {
              b.send(contract.m_multiplier);
            }
            b.send( contract.m_exchange);
            b.send( contract.m_currency);
            b.send( contract.m_localSymbol);
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }
            if (m_serverVersion >= 19) {
                b.send( numRows);
            }
            
            // send mktDepthOptions parameter
            if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
                StringBuilder mktDepthOptionsStr = new StringBuilder();
                int mktDepthOptionsCount = mktDepthOptions == null ? 0 : mktDepthOptions.size();
                if( mktDepthOptionsCount > 0) {
                    for( int i = 0; i < mktDepthOptionsCount; ++i) {
                        TagValue tagValue = (TagValue)mktDepthOptions.get(i);
                        mktDepthOptionsStr.append( tagValue.m_tag);
                        mktDepthOptionsStr.append( "=");
                        mktDepthOptionsStr.append( tagValue.m_value);
                        mktDepthOptionsStr.append( ";");
                    }
                }
                b.send( mktDepthOptionsStr.toString());
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_REQMKTDEPTH, "" + e);
            close();
        }
    }

    public synchronized void cancelMktData( int tickerId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send cancel mkt data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_MKT_DATA);
            b.send( VERSION);
            b.send( tickerId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_CANMKT, "" + e);
            close();
        }
    }

    public synchronized void cancelMktDepth( int tickerId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >=6
        if( m_serverVersion < 6) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(),
                    EClientErrors.UPDATE_TWS.msg());
            return;
        }

        final int VERSION = 1;

        // send cancel mkt data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_MKT_DEPTH);
            b.send( VERSION);
            b.send( tickerId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( tickerId, EClientErrors.FAIL_SEND_CANMKTDEPTH, "" + e);
            close();
        }
    }

    public synchronized void exerciseOptions( int tickerId, Contract contract,
                                              int exerciseAction, int exerciseQuantity,
                                              String account, int override) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 2;

        try {
          if (m_serverVersion < 21) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                  "  It does not support options exercise from the API.");
            return;
          }

          if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
              if (!IsEmpty(contract.m_tradingClass) || (contract.m_conId > 0)) {
                    error(tickerId, EClientErrors.UPDATE_TWS,
                        "  It does not support conId and tradingClass parameters in exerciseOptions.");
                    return;
              }
          }

          Builder b = prepareBuffer(); 

          b.send(EXERCISE_OPTIONS);
          b.send(VERSION);
          b.send(tickerId);

          // send contract fields
          if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
              b.send(contract.m_conId);
          }
          b.send(contract.m_symbol);
          b.send(contract.m_secType);
          b.send(contract.m_expiry);
          b.send(contract.m_strike);
          b.send(contract.m_right);
          b.send(contract.m_multiplier);
          b.send(contract.m_exchange);
          b.send(contract.m_currency);
          b.send(contract.m_localSymbol);
          if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
              b.send(contract.m_tradingClass);
          }
          b.send(exerciseAction);
          b.send(exerciseQuantity);
          b.send(account);
          b.send(override);

          closeAndSend(b);
      }
      catch (Exception e) {
        error(tickerId, EClientErrors.FAIL_SEND_REQMKT, "" + e);
        close();
      }
    }

    public synchronized void placeOrder( int id, Contract contract, Order order) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_SCALE_ORDERS) {
        	if (order.m_scaleInitLevelSize != Integer.MAX_VALUE ||
        		order.m_scalePriceIncrement != Double.MAX_VALUE) {
        		error(id, EClientErrors.UPDATE_TWS,
            		"  It does not support Scale orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SSHORT_COMBO_LEGS) {
        	if (!contract.m_comboLegs.isEmpty()) {
                ComboLeg comboLeg;
                for (int i = 0; i < contract.m_comboLegs.size(); ++i) {
                    comboLeg = contract.m_comboLegs.get(i);
                    if (comboLeg.m_shortSaleSlot != 0 ||
                    	!IsEmpty(comboLeg.m_designatedLocation)) {
                		error(id, EClientErrors.UPDATE_TWS,
                			"  It does not support SSHORT flag for combo legs.");
                		return;
                    }
                }
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_WHAT_IF_ORDERS) {
        	if (order.m_whatIf) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support what-if orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_UNDER_COMP) {
        	if (contract.m_underComp != null) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support delta-neutral orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SCALE_ORDERS2) {
        	if (order.m_scaleSubsLevelSize != Integer.MAX_VALUE) {
        		error(id, EClientErrors.UPDATE_TWS,
            		"  It does not support Subsequent Level Size for Scale orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_ALGO_ORDERS) {
        	if (!IsEmpty(order.m_algoStrategy)) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support algo orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_NOT_HELD) {
        	if (order.m_notHeld) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support notHeld parameter.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SEC_ID_TYPE) {
        	if (!IsEmpty(contract.m_secIdType) || !IsEmpty(contract.m_secId)) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support secIdType and secId parameters.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_PLACE_ORDER_CONID) {
        	if (contract.m_conId > 0) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support conId parameter.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SSHORTX) {
        	if (order.m_exemptCode != -1) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support exemptCode parameter.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SSHORTX) {
        	if (!contract.m_comboLegs.isEmpty()) {
                ComboLeg comboLeg;
                for (int i = 0; i < contract.m_comboLegs.size(); ++i) {
                    comboLeg = contract.m_comboLegs.get(i);
                    if (comboLeg.m_exemptCode != -1) {
                		error(id, EClientErrors.UPDATE_TWS,
                			"  It does not support exemptCode parameter.");
                		return;
                    }
                }
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_HEDGE_ORDERS) {
        	if (!IsEmpty(order.m_hedgeType)) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support hedge orders.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_OPT_OUT_SMART_ROUTING) {
        	if (order.m_optOutSmartRouting) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support optOutSmartRouting parameter.");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_DELTA_NEUTRAL_CONID) {
        	if (order.m_deltaNeutralConId > 0
        			|| !IsEmpty(order.m_deltaNeutralSettlingFirm)
        			|| !IsEmpty(order.m_deltaNeutralClearingAccount)
        			|| !IsEmpty(order.m_deltaNeutralClearingIntent)
        			) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support deltaNeutral parameters: ConId, SettlingFirm, ClearingAccount, ClearingIntent");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_DELTA_NEUTRAL_OPEN_CLOSE) {
        	if (!IsEmpty(order.m_deltaNeutralOpenClose)
        			|| order.m_deltaNeutralShortSale
        			|| order.m_deltaNeutralShortSaleSlot > 0
        			|| !IsEmpty(order.m_deltaNeutralDesignatedLocation)
        			) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support deltaNeutral parameters: OpenClose, ShortSale, ShortSaleSlot, DesignatedLocation");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_SCALE_ORDERS3) {
        	if (order.m_scalePriceIncrement > 0 && order.m_scalePriceIncrement != Double.MAX_VALUE) {
        		if (order.m_scalePriceAdjustValue != Double.MAX_VALUE ||
        			order.m_scalePriceAdjustInterval != Integer.MAX_VALUE ||
        			order.m_scaleProfitOffset != Double.MAX_VALUE ||
        			order.m_scaleAutoReset ||
        			order.m_scaleInitPosition != Integer.MAX_VALUE ||
        			order.m_scaleInitFillQty != Integer.MAX_VALUE ||
        			order.m_scaleRandomPercent) {
        			error(id, EClientErrors.UPDATE_TWS,
        				"  It does not support Scale order parameters: PriceAdjustValue, PriceAdjustInterval, " +
        				"ProfitOffset, AutoReset, InitPosition, InitFillQty and RandomPercent");
        			return;
        		}
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_ORDER_COMBO_LEGS_PRICE && BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
        	if (!order.m_orderComboLegs.isEmpty()) {
        		OrderComboLeg orderComboLeg;
        		for (int i = 0; i < order.m_orderComboLegs.size(); ++i) {
        			orderComboLeg = order.m_orderComboLegs.get(i);
        			if (orderComboLeg.m_price != Double.MAX_VALUE) {
        			error(id, EClientErrors.UPDATE_TWS,
        				"  It does not support per-leg prices for order combo legs.");
        			return;
        			}
        		}
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_TRAILING_PERCENT) {
        	if (order.m_trailingPercent != Double.MAX_VALUE) {
        		error(id, EClientErrors.UPDATE_TWS,
        			"  It does not support trailing percent parameter");
        		return;
        	}
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass)) {
                  error(id, EClientErrors.UPDATE_TWS,
                      "  It does not support tradingClass parameters in placeOrder.");
                  return;
            }
        }
        
        if (m_serverVersion < MIN_SERVER_VER_ALGO_ID && !IsEmpty(order.m_algoId) ) {
        		  error(id, EClientErrors.UPDATE_TWS, " It does not support algoId parameter");
        	}

        if (m_serverVersion < MIN_SERVER_VER_SCALE_TABLE) {
            if (!IsEmpty(order.m_scaleTable) || !IsEmpty(order.m_activeStartTime) || !IsEmpty(order.m_activeStopTime)) {
                  error(id, EClientErrors.UPDATE_TWS,
                      "  It does not support scaleTable, activeStartTime and activeStopTime parameters.");
                  return;
            }
        }
        
        if (m_serverVersion < MIN_SERVER_VER_ORDER_SOLICITED) {
        	if (order.m_orderSolicited) {
        		error(id, EClientErrors.UPDATE_TWS,
                        "  It does not support orderSolicited parameter.");
                return;
        	}
        }

        int VERSION = (m_serverVersion < MIN_SERVER_VER_NOT_HELD) ? 27 : 44;

        // send place order msg
        try {
            Builder b = prepareBuffer(); 

            b.send( PLACE_ORDER);
            b.send( VERSION);
            b.send( id);

            // send contract fields
            if( m_serverVersion >= MIN_SERVER_VER_PLACE_ORDER_CONID) {
                b.send(contract.m_conId);
            }
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_expiry);
            b.send( contract.m_strike);
            b.send( contract.m_right);
            if (m_serverVersion >= 15) {
                b.send(contract.m_multiplier);
            }
            b.send( contract.m_exchange);
            if( m_serverVersion >= 14) {
              b.send(contract.m_primaryExch);
            }
            b.send( contract.m_currency);
            if( m_serverVersion >= 2) {
                b.send (contract.m_localSymbol);
            }
            if (m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }
            if( m_serverVersion >= MIN_SERVER_VER_SEC_ID_TYPE){
            	b.send( contract.m_secIdType);
            	b.send( contract.m_secId);
            }

            // send main order fields
            b.send( order.m_action);
            b.send( order.m_totalQuantity);
            b.send( order.m_orderType);
            if (m_serverVersion < MIN_SERVER_VER_ORDER_COMBO_LEGS_PRICE) {
                b.send( order.m_lmtPrice == Double.MAX_VALUE ? 0 : order.m_lmtPrice);
            }
            else {
                b.sendMax( order.m_lmtPrice);
            }
            if (m_serverVersion < MIN_SERVER_VER_TRAILING_PERCENT) {
                b.send( order.m_auxPrice == Double.MAX_VALUE ? 0 : order.m_auxPrice);
            }
            else {
                b.sendMax( order.m_auxPrice);
            }

            // send extended order fields
            b.send( order.m_tif);
            b.send( order.m_ocaGroup);
            b.send( order.m_account);
            b.send( order.m_openClose);
            b.send( order.m_origin);
            b.send( order.m_orderRef);
            b.send( order.m_transmit);
            if( m_serverVersion >= 4 ) {
                b.send (order.m_parentId);
            }

            if( m_serverVersion >= 5 ) {
                b.send (order.m_blockOrder);
                b.send (order.m_sweepToFill);
                b.send (order.m_displaySize);
                b.send (order.m_triggerMethod);
                if (m_serverVersion < 38) {
                	// will never happen
                	b.send(/* order.m_ignoreRth */ false);
                }
                else {
                	b.send (order.m_outsideRth);
                }
            }

            if(m_serverVersion >= 7 ) {
                b.send(order.m_hidden);
            }

            // Send combo legs for BAG requests
            if(m_serverVersion >= 8 && BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
                if ( contract.m_comboLegs == null ) {
                    b.send( 0);
                }
                else {
                    b.send( contract.m_comboLegs.size());

                    ComboLeg comboLeg;
                    for (int i=0; i < contract.m_comboLegs.size(); i ++) {
                        comboLeg = contract.m_comboLegs.get(i);
                        b.send( comboLeg.m_conId);
                        b.send( comboLeg.m_ratio);
                        b.send( comboLeg.m_action);
                        b.send( comboLeg.m_exchange);
                        b.send( comboLeg.m_openClose);

                        if (m_serverVersion >= MIN_SERVER_VER_SSHORT_COMBO_LEGS) {
                        	b.send( comboLeg.m_shortSaleSlot);
                        	b.send( comboLeg.m_designatedLocation);
                        }
                        if (m_serverVersion >= MIN_SERVER_VER_SSHORTX_OLD) {
                            b.send( comboLeg.m_exemptCode);
                        }
                    }
                }
            }

            // Send order combo legs for BAG requests
            if(m_serverVersion >= MIN_SERVER_VER_ORDER_COMBO_LEGS_PRICE && BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
                if ( order.m_orderComboLegs == null ) {
                    b.send( 0);
                }
                else {
                    b.send( order.m_orderComboLegs.size());

                    for (int i = 0; i < order.m_orderComboLegs.size(); i++) {
                        OrderComboLeg orderComboLeg = order.m_orderComboLegs.get(i);
                        b.sendMax( orderComboLeg.m_price);
                    }
                }
            }

            if(m_serverVersion >= MIN_SERVER_VER_SMART_COMBO_ROUTING_PARAMS && BAG_SEC_TYPE.equalsIgnoreCase(contract.m_secType)) {
                java.util.Vector smartComboRoutingParams = order.m_smartComboRoutingParams;
                int smartComboRoutingParamsCount = smartComboRoutingParams == null ? 0 : smartComboRoutingParams.size();
                b.send( smartComboRoutingParamsCount);
                if( smartComboRoutingParamsCount > 0) {
                    for( int i = 0; i < smartComboRoutingParamsCount; ++i) {
                        TagValue tagValue = (TagValue)smartComboRoutingParams.get(i);
                        b.send( tagValue.m_tag);
                        b.send( tagValue.m_value);
                    }
                }
            }

            if ( m_serverVersion >= 9 ) {
            	// send deprecated sharesAllocation field
                b.send( "");
            }

            if ( m_serverVersion >= 10 ) {
                b.send( order.m_discretionaryAmt);
            }

            if ( m_serverVersion >= 11 ) {
                b.send( order.m_goodAfterTime);
            }

            if ( m_serverVersion >= 12 ) {
                b.send( order.m_goodTillDate);
            }

            if ( m_serverVersion >= 13 ) {
               b.send( order.m_faGroup);
               b.send( order.m_faMethod);
               b.send( order.m_faPercentage);
               b.send( order.m_faProfile);
           }
           if (m_serverVersion >= 18) { // institutional short sale slot fields.
               b.send( order.m_shortSaleSlot);      // 0 only for retail, 1 or 2 only for institution.
               b.send( order.m_designatedLocation); // only populate when order.m_shortSaleSlot = 2.
           }
           if (m_serverVersion >= MIN_SERVER_VER_SSHORTX_OLD) {
               b.send( order.m_exemptCode);
           }
           if (m_serverVersion >= 19) {
               b.send( order.m_ocaType);
               if (m_serverVersion < 38) {
            	   // will never happen
            	   b.send( /* order.m_rthOnly */ false);
               }
               b.send( order.m_rule80A);
               b.send( order.m_settlingFirm);
               b.send( order.m_allOrNone);
               b.sendMax( order.m_minQty);
               b.sendMax( order.m_percentOffset);
               b.send( order.m_eTradeOnly);
               b.send( order.m_firmQuoteOnly);
               b.sendMax( order.m_nbboPriceCap);
               b.sendMax( order.m_auctionStrategy);
               b.sendMax( order.m_startingPrice);
               b.sendMax( order.m_stockRefPrice);
               b.sendMax( order.m_delta);
        	   // Volatility orders had specific watermark price attribs in server version 26
        	   double lower = (m_serverVersion == 26 && order.m_orderType.equals("VOL"))
        	   		? Double.MAX_VALUE
        	   		: order.m_stockRangeLower;
        	   double upper = (m_serverVersion == 26 && order.m_orderType.equals("VOL"))
   	   				? Double.MAX_VALUE
   	   				: order.m_stockRangeUpper;
               b.sendMax( lower);
               b.sendMax( upper);
           }

           if (m_serverVersion >= 22) {
               b.send( order.m_overridePercentageConstraints);
           }

           if (m_serverVersion >= 26) { // Volatility orders
               b.sendMax( order.m_volatility);
               b.sendMax( order.m_volatilityType);
               if (m_serverVersion < 28) {
            	   b.send( order.m_deltaNeutralOrderType.equalsIgnoreCase("MKT"));
               } else {
            	   b.send( order.m_deltaNeutralOrderType);
            	   b.sendMax( order.m_deltaNeutralAuxPrice);

                   if (m_serverVersion >= MIN_SERVER_VER_DELTA_NEUTRAL_CONID && !IsEmpty(order.m_deltaNeutralOrderType)){
                       b.send( order.m_deltaNeutralConId);
                       b.send( order.m_deltaNeutralSettlingFirm);
                       b.send( order.m_deltaNeutralClearingAccount);
                       b.send( order.m_deltaNeutralClearingIntent);
                   }

                   if (m_serverVersion >= MIN_SERVER_VER_DELTA_NEUTRAL_OPEN_CLOSE && !IsEmpty(order.m_deltaNeutralOrderType)){
                       b.send( order.m_deltaNeutralOpenClose);
                       b.send( order.m_deltaNeutralShortSale);
                       b.send( order.m_deltaNeutralShortSaleSlot);
                       b.send( order.m_deltaNeutralDesignatedLocation);
                   }
               }
               b.send( order.m_continuousUpdate);
               if (m_serverVersion == 26) {
            	   // Volatility orders had specific watermark price attribs in server version 26
            	   double lower = order.m_orderType.equals("VOL") ? order.m_stockRangeLower : Double.MAX_VALUE;
            	   double upper = order.m_orderType.equals("VOL") ? order.m_stockRangeUpper : Double.MAX_VALUE;
                   b.sendMax( lower);
                   b.sendMax( upper);
               }
               b.sendMax( order.m_referencePriceType);
           }

           if (m_serverVersion >= 30) { // TRAIL_STOP_LIMIT stop price
               b.sendMax( order.m_trailStopPrice);
           }

           if( m_serverVersion >= MIN_SERVER_VER_TRAILING_PERCENT){
               b.sendMax( order.m_trailingPercent);
           }

           if (m_serverVersion >= MIN_SERVER_VER_SCALE_ORDERS) {
        	   if (m_serverVersion >= MIN_SERVER_VER_SCALE_ORDERS2) {
        		   b.sendMax (order.m_scaleInitLevelSize);
        		   b.sendMax (order.m_scaleSubsLevelSize);
        	   }
        	   else {
        		   b.send ("");
        		   b.sendMax (order.m_scaleInitLevelSize);

        	   }
        	   b.sendMax (order.m_scalePriceIncrement);
           }

           if (m_serverVersion >= MIN_SERVER_VER_SCALE_ORDERS3 && order.m_scalePriceIncrement > 0.0 && order.m_scalePriceIncrement != Double.MAX_VALUE) {
               b.sendMax (order.m_scalePriceAdjustValue);
               b.sendMax (order.m_scalePriceAdjustInterval);
               b.sendMax (order.m_scaleProfitOffset);
               b.send (order.m_scaleAutoReset);
               b.sendMax (order.m_scaleInitPosition);
               b.sendMax (order.m_scaleInitFillQty);
               b.send (order.m_scaleRandomPercent);
           }

           if (m_serverVersion >= MIN_SERVER_VER_SCALE_TABLE) {
               b.send (order.m_scaleTable);
               b.send (order.m_activeStartTime);
               b.send (order.m_activeStopTime);
           }

           if (m_serverVersion >= MIN_SERVER_VER_HEDGE_ORDERS) {
        	   b.send (order.m_hedgeType);
        	   if (!IsEmpty(order.m_hedgeType)) {
        		   b.send (order.m_hedgeParam);
        	   }
           }

           if (m_serverVersion >= MIN_SERVER_VER_OPT_OUT_SMART_ROUTING) {
               b.send (order.m_optOutSmartRouting);
           }

           if (m_serverVersion >= MIN_SERVER_VER_PTA_ORDERS) {
        	   b.send (order.m_clearingAccount);
        	   b.send (order.m_clearingIntent);
           }

           if (m_serverVersion >= MIN_SERVER_VER_NOT_HELD) {
        	   b.send (order.m_notHeld);
           }

           if (m_serverVersion >= MIN_SERVER_VER_UNDER_COMP) {
        	   if (contract.m_underComp != null) {
        		   UnderComp underComp = contract.m_underComp;
        		   b.send( true);
        		   b.send( underComp.m_conId);
        		   b.send( underComp.m_delta);
        		   b.send( underComp.m_price);
        	   }
        	   else {
        		   b.send( false);
        	   }
           }

           if (m_serverVersion >= MIN_SERVER_VER_ALGO_ORDERS) {
        	   b.send( order.m_algoStrategy);
        	   if( !IsEmpty(order.m_algoStrategy)) {
        		   java.util.Vector algoParams = order.m_algoParams;
        		   int algoParamsCount = algoParams == null ? 0 : algoParams.size();
        		   b.send( algoParamsCount);
        		   if( algoParamsCount > 0) {
        			   for( int i = 0; i < algoParamsCount; ++i) {
        				   TagValue tagValue = (TagValue)algoParams.get(i);
        				   b.send( tagValue.m_tag);
        				   b.send( tagValue.m_value);
        			   }
        		   }
        	   }
           }
           
           if (m_serverVersion >= MIN_SERVER_VER_ALGO_ID) {
        	   b.send(order.m_algoId);
           }

           if (m_serverVersion >= MIN_SERVER_VER_WHAT_IF_ORDERS) {
        	   b.send (order.m_whatIf);
           }
           
           // send orderMiscOptions parameter
           if(m_serverVersion >= MIN_SERVER_VER_LINKING) {
               StringBuilder orderMiscOptionsStr = new StringBuilder();
               java.util.Vector orderMiscOptions = order.m_orderMiscOptions;
               int orderMiscOptionsCount = orderMiscOptions == null ? 0 : orderMiscOptions.size();
               if( orderMiscOptionsCount > 0) {
                   for( int i = 0; i < orderMiscOptionsCount; ++i) {
                       TagValue tagValue = (TagValue)orderMiscOptions.get(i);
                       orderMiscOptionsStr.append( tagValue.m_tag);
                       orderMiscOptionsStr.append( "=");
                       orderMiscOptionsStr.append( tagValue.m_value);
                       orderMiscOptionsStr.append( ";");
                   }
               }
               b.send( orderMiscOptionsStr.toString());
           }
           
           if (m_serverVersion >= MIN_SERVER_VER_ORDER_SOLICITED) {
        	   b.send(order.m_orderSolicited);
           }
           closeAndSend(b);
        }
        catch( Exception e) {
            error( id, EClientErrors.FAIL_SEND_ORDER, "" + e);
            close();
        }
    }

    public synchronized void reqAccountUpdates(boolean subscribe, String acctCode) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 2;

        // send account data msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_ACCOUNT_DATA );
            b.send( VERSION);
            b.send( subscribe);

            // Send the account code. This will only be used for FA clients
            if ( m_serverVersion >= 9 ) {
                b.send( acctCode);
            }
            closeAndSend(b);
       }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_ACCT, "" + e);
            close();
        }
    }

    public synchronized void reqExecutions(int reqId, ExecutionFilter filter) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 3;

        // send executions msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_EXECUTIONS);
            b.send( VERSION);

            if (m_serverVersion >= MIN_SERVER_VER_EXECUTION_DATA_CHAIN) {
            	b.send( reqId);
            }

            // Send the execution rpt filter data
            if ( m_serverVersion >= 9 ) {
                b.send( filter.m_clientId);
                b.send( filter.m_acctCode);

                // Note that the valid format for m_time is "yyyymmdd-hh:mm:ss"
                b.send( filter.m_time);
                b.send( filter.m_symbol);
                b.send( filter.m_secType);
                b.send( filter.m_exchange);
                b.send( filter.m_side);
            }
            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_EXEC, "" + e);
            close();
        }
    }

    public synchronized void cancelOrder( int id) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send cancel order msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_ORDER);
            b.send( VERSION);
            b.send( id);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( id, EClientErrors.FAIL_SEND_CORDER, "" + e);
            close();
        }
    }

    public synchronized void reqOpenOrders() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send open orders msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_OPEN_ORDERS);
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_OORDER, "" + e);
            close();
        }
    }

    public synchronized void reqIds( int numIds) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_IDS);
            b.send( VERSION);
            b.send( numIds);

            closeAndSend(b);
       }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_CORDER, "" + e);
            close();
        }
    }

    public synchronized void reqNewsBulletins( boolean allMsgs) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_NEWS_BULLETINS);
            b.send( VERSION);
            b.send( allMsgs);

            closeAndSend(b);
       }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_CORDER, "" + e);
            close();
        }
    }

    public synchronized void cancelNewsBulletins() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send cancel news bulletins msg
        try {
            Builder b = prepareBuffer(); 

            b.send( CANCEL_NEWS_BULLETINS);
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_CORDER, "" + e);
            close();
        }
    }

    public synchronized void setServerLogLevel(int logLevel) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

                // send the set server logging level message
                try {
                    Builder b = prepareBuffer(); 

                    b.send( SET_SERVER_LOGLEVEL);
                    b.send( VERSION);
                    b.send( logLevel);

                    closeAndSend(b);
               }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_SERVER_LOG_LEVEL, "" + e);
            close();
        }
    }

    public synchronized void reqAutoOpenOrders(boolean bAutoBind) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send req open orders msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_AUTO_OPEN_ORDERS);
            b.send( VERSION);
            b.send( bAutoBind);

            closeAndSend(b);
        }
        catch( Exception e) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_OORDER, "" + e);
            close();
        }
    }

    public synchronized void reqAllOpenOrders() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send req all open orders msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_ALL_OPEN_ORDERS);
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_OORDER, "" + e);
            close();
        }
    }

    public synchronized void reqManagedAccts() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        final int VERSION = 1;

        // send req FA managed accounts msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_MANAGED_ACCTS);
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_OORDER, "" + e);
            close();
        }
    }

    public synchronized void requestFA( int faDataType ) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >= 13
        if( m_serverVersion < 13) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(),
                    EClientErrors.UPDATE_TWS.msg());
            return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_FA );
            b.send( VERSION);
            b.send( faDataType);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( faDataType, EClientErrors.FAIL_SEND_FA_REQUEST, "" + e);
            close();
        }
    }

    public synchronized void replaceFA( int faDataType, String xml ) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >= 13
        if( m_serverVersion < 13) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS.code(),
                    EClientErrors.UPDATE_TWS.msg());
            return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send( REPLACE_FA );
            b.send( VERSION);
            b.send( faDataType);
            b.send( xml);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( faDataType, EClientErrors.FAIL_SEND_FA_REPLACE, "" + e);
            close();
        }
    }

    public synchronized void reqCurrentTime() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        // This feature is only available for versions of TWS >= 33
        if( m_serverVersion < 33) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                  "  It does not support current time requests.");
            return;
        }

        final int VERSION = 1;

        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_CURRENT_TIME );
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQCURRTIME, "" + e);
            close();
        }
    }

    public synchronized void reqFundamentalData(int reqId, Contract contract, String reportType) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if( m_serverVersion < MIN_SERVER_VER_FUNDAMENTAL_DATA) {
        	error( reqId, EClientErrors.UPDATE_TWS,
        			"  It does not support fundamental data requests.");
        	return;
        }

        if( m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if( contract.m_conId > 0) {
                  error(reqId, EClientErrors.UPDATE_TWS,
                      "  It does not support conId parameter in reqFundamentalData.");
                  return;
            }
        }

        final int VERSION = 2;

        try {
            // send req fund data msg
            Builder b = prepareBuffer(); 

            b.send( REQ_FUNDAMENTAL_DATA);
            b.send( VERSION);
            b.send( reqId);

            // send contract fields
            if( m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_conId);
            }
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_exchange);
            b.send( contract.m_primaryExch);
            b.send( contract.m_currency);
            b.send( contract.m_localSymbol);

            b.send( reportType);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_REQFUNDDATA, "" + e);
            close();
        }
    }

    public synchronized void cancelFundamentalData(int reqId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if( m_serverVersion < MIN_SERVER_VER_FUNDAMENTAL_DATA) {
        	error( reqId, EClientErrors.UPDATE_TWS,
        			"  It does not support fundamental data requests.");
        	return;
        }

        final int VERSION = 1;

        try {
            // send cancel fundamental data msg
            Builder b = prepareBuffer(); 

            b.send( CANCEL_FUNDAMENTAL_DATA);
            b.send( VERSION);
            b.send( reqId);

            closeAndSend(b);
       }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_CANFUNDDATA, "" + e);
            close();
        }
    }

    public synchronized void calculateImpliedVolatility(int reqId, Contract contract,
            double optionPrice, double underPrice) {

        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REQ_CALC_IMPLIED_VOLAT) {
            error(reqId, EClientErrors.UPDATE_TWS,
                    "  It does not support calculate implied volatility requests.");
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass)) {
                  error(reqId, EClientErrors.UPDATE_TWS,
                      "  It does not support tradingClass parameter in calculateImpliedVolatility.");
                  return;
            }
        }

        final int VERSION = 2;

        try {
            // send calculate implied volatility msg
            Builder b = prepareBuffer(); 

            b.send( REQ_CALC_IMPLIED_VOLAT);
            b.send( VERSION);
            b.send( reqId);

            // send contract fields
            b.send( contract.m_conId);
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_expiry);
            b.send( contract.m_strike);
            b.send( contract.m_right);
            b.send( contract.m_multiplier);
            b.send( contract.m_exchange);
            b.send( contract.m_primaryExch);
            b.send( contract.m_currency);
            b.send( contract.m_localSymbol);
            if( m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }

            b.send( optionPrice);
            b.send( underPrice);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_REQCALCIMPLIEDVOLAT, "" + e);
            close();
        }
    }

    public synchronized void cancelCalculateImpliedVolatility(int reqId) {

        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_CANCEL_CALC_IMPLIED_VOLAT) {
            error(reqId, EClientErrors.UPDATE_TWS,
                    "  It does not support calculate implied volatility cancellation.");
            return;
        }

        final int VERSION = 1;

        try {
            // send cancel calculate implied volatility msg
            Builder b = prepareBuffer(); 

            b.send( CANCEL_CALC_IMPLIED_VOLAT);
            b.send( VERSION);
            b.send( reqId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_CANCALCIMPLIEDVOLAT, "" + e);
            close();
        }
    }

    public synchronized void calculateOptionPrice(int reqId, Contract contract,
            double volatility, double underPrice) {

        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REQ_CALC_OPTION_PRICE) {
            error(reqId, EClientErrors.UPDATE_TWS,
                    "  It does not support calculate option price requests.");
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_TRADING_CLASS) {
            if (!IsEmpty(contract.m_tradingClass)) {
                  error(reqId, EClientErrors.UPDATE_TWS,
                      "  It does not support tradingClass parameter in calculateOptionPrice.");
                  return;
            }
        }

        final int VERSION = 2;

        try {
            // send calculate option price msg
            Builder b = prepareBuffer(); 

            b.send( REQ_CALC_OPTION_PRICE);
            b.send( VERSION);
            b.send( reqId);

            // send contract fields
            b.send( contract.m_conId);
            b.send( contract.m_symbol);
            b.send( contract.m_secType);
            b.send( contract.m_expiry);
            b.send( contract.m_strike);
            b.send( contract.m_right);
            b.send( contract.m_multiplier);
            b.send( contract.m_exchange);
            b.send( contract.m_primaryExch);
            b.send( contract.m_currency);
            b.send( contract.m_localSymbol);
            if( m_serverVersion >= MIN_SERVER_VER_TRADING_CLASS) {
                b.send(contract.m_tradingClass);
            }

            b.send( volatility);
            b.send( underPrice);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_REQCALCOPTIONPRICE, "" + e);
            close();
        }
    }

    public synchronized void cancelCalculateOptionPrice(int reqId) {

        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_CANCEL_CALC_OPTION_PRICE) {
            error(reqId, EClientErrors.UPDATE_TWS,
                    "  It does not support calculate option price cancellation.");
            return;
        }

        final int VERSION = 1;

        try {
            // send cancel calculate option price msg
            Builder b = prepareBuffer(); 

            b.send( CANCEL_CALC_OPTION_PRICE);
            b.send( VERSION);
            b.send( reqId);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( reqId, EClientErrors.FAIL_SEND_CANCALCOPTIONPRICE, "" + e);
            close();
        }
    }

    public synchronized void reqGlobalCancel() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REQ_GLOBAL_CANCEL) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                    "  It does not support globalCancel requests.");
            return;
        }

        final int VERSION = 1;

        // send request global cancel msg
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_GLOBAL_CANCEL);
            b.send( VERSION);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQGLOBALCANCEL, "" + e);
            close();
        }
    }

    public synchronized void reqMarketDataType(int marketDataType) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_REQ_MARKET_DATA_TYPE) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
                    "  It does not support marketDataType requests.");
            return;
        }

        final int VERSION = 1;

        // send the reqMarketDataType message
        try {
            Builder b = prepareBuffer(); 

            b.send( REQ_MARKET_DATA_TYPE);
            b.send( VERSION);
            b.send( marketDataType);

            closeAndSend(b);
        }
        catch( Exception e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQMARKETDATATYPE, "" + e);
            close();
        }
    }

    public synchronized void reqPositions() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_ACCT_SUMMARY) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support position requests.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( REQ_POSITIONS);
        b.send( VERSION);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQPOSITIONS, "" + e);
        }
    }

    public synchronized void cancelPositions() {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_ACCT_SUMMARY) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support position cancellation.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( CANCEL_POSITIONS);
        b.send( VERSION);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_CANPOSITIONS, "" + e);
        }
    }

    public synchronized void reqAccountSummary( int reqId, String group, String tags) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_ACCT_SUMMARY) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support account summary requests.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( REQ_ACCOUNT_SUMMARY);
        b.send( VERSION);
        b.send( reqId);
        b.send( group);
        b.send( tags);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_REQACCOUNTDATA, "" + e);
        }
    }

	public synchronized void cancelAccountSummary( int reqId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_ACCT_SUMMARY) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support account summary cancellation.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( CANCEL_ACCOUNT_SUMMARY);
        b.send( VERSION);
        b.send( reqId);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_CANACCOUNTDATA, "" + e);
        }
    }
    public synchronized void verifyRequest( String apiName, String apiVersion) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support verification request.");
            return;
        }

        if (!m_extraAuth) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_VERIFYMESSAGE,
            "  Intent to authenticate needs to be expressed during initial connect request.");
            return;
            
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();
        b.send( VERIFY_REQUEST);
        b.send( VERSION);
        b.send( apiName);
        b.send( apiVersion);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_VERIFYREQUEST, "" + e);
        }
    }

    public synchronized void verifyMessage( String apiData) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support verification message sending.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();
        b.send( VERIFY_MESSAGE);
        b.send( VERSION);
        b.send( apiData);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_VERIFYMESSAGE, "" + e);
        }
    }

	public synchronized void queryDisplayGroups( int reqId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support queryDisplayGroups request.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( QUERY_DISPLAY_GROUPS);
        b.send( VERSION);
        b.send( reqId);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_QUERYDISPLAYGROUPS, "" + e);
        }
    }
	
	public synchronized void subscribeToGroupEvents( int reqId, int groupId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support subscribeToGroupEvents request.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( SUBSCRIBE_TO_GROUP_EVENTS);
        b.send( VERSION);
        b.send( reqId);
        b.send( groupId);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_SUBSCRIBETOGROUPEVENTS, "" + e);
        }
    }	

	public synchronized void updateDisplayGroup( int reqId, String contractInfo) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support updateDisplayGroup request.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( UPDATE_DISPLAY_GROUP);
        b.send( VERSION);
        b.send( reqId);
        b.send( contractInfo);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_UPDATEDISPLAYGROUP, "" + e);
        }
    }	

	public synchronized void unsubscribeFromGroupEvents( int reqId) {
        // not connected?
        if( !m_connected) {
            notConnected();
            return;
        }

        if (m_serverVersion < MIN_SERVER_VER_LINKING) {
            error(EClientErrors.NO_VALID_ID, EClientErrors.UPDATE_TWS,
            "  It does not support unsubscribeFromGroupEvents request.");
            return;
        }

        final int VERSION = 1;

        Builder b = prepareBuffer();

        b.send( UNSUBSCRIBE_FROM_GROUP_EVENTS);
        b.send( VERSION);
        b.send( reqId);

        try {
            closeAndSend(b);
        }
        catch (IOException e) {
            error( EClientErrors.NO_VALID_ID, EClientErrors.FAIL_SEND_UNSUBSCRIBEFROMGROUPEVENTS, "" + e);
        }
    }	
	
    /** @deprecated, never called. */
    protected synchronized void error( String err) {
        m_anyWrapper.error( err);
    }

    protected synchronized void error( int id, int errorCode, String errorMsg) {
        m_anyWrapper.error( id, errorCode, errorMsg);
    }

    protected void close() {
        eDisconnect();
        wrapper().connectionClosed();
    }

    protected void error(int id, EClientErrors.CodeMsgPair pair, String tail) {
        error(id, pair.code(), pair.msg() + tail);
    }

    protected Builder prepareBuffer() {
        Builder buf = new Builder( 1024 );
        if( m_useV100Plus ) {
            buf.allocateLengthHeader();
        }
        return buf;
    }
    
    protected void closeAndSend(Builder buf) throws IOException {
    	if( m_useV100Plus ) {
    		buf.updateLength( 0 ); // New buffer means length header position is always zero
    	}
    	buf.writeTo( m_dos );
    }
    
   // Sends String without length prefix (pre-V100 style)
   protected void send( String str) throws IOException {
        // Write string to data buffer
    	Builder b = new Builder( 1024 );
    	
    	b.send(str);
    	b.writeTo( m_dos );
    }

    private void sendV100APIHeader() throws IOException {
    	Builder bos = new Builder(1024);
    	bos.send("API\0".getBytes());
    
    	String out = "v" + (( MIN_VERSION < MAX_VERSION ) 
    			? MIN_VERSION + ".." + MAX_VERSION
				: MIN_VERSION);
    	
    	if ( !IsEmpty( m_connectOptions ) ) { 
    		out += " " + m_connectOptions;
    	}

    	int lengthPos = bos.allocateLengthHeader();
    	bos.send( out.getBytes() );
    	bos.updateLength( lengthPos );
    	bos.writeTo( m_dos );
    }

    protected void send( int val) throws IOException {
        send( String.valueOf( val) );
    }

    private static boolean IsEmpty(String str) {
    	return Util.StringIsEmpty(str);
    }

    protected void notConnected() {
        error(EClientErrors.NO_VALID_ID, EClientErrors.NOT_CONNECTED, "");
    }
}
