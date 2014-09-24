#include "StdAfx.h"
#include <Winsock2.h>
#include <assert.h>
#include <string>
#include "EWrapper.h"
#include "Order.h"
#include "Contract.h"
#include "OrderState.h"
#include "Execution.h"
#include "CommissionReport.h"
#include "EClient.h"
#include "TwsSocketClientErrors.h"
#include "EDecoder.h"


EDecoder::EDecoder(EClient *parent, EWrapper *callback, int serverVersion) {
    m_pEWrapper = callback;
    m_serverVersion = serverVersion;
    m_pEClient = parent;
}

int EDecoder::processTickPriceMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    double price;

    int size;
    int canAutoExecute;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);
    DECODE_FIELD( price);

    DECODE_FIELD( size); // ver 2 field
    DECODE_FIELD( canAutoExecute); // ver 3 field

    m_pEWrapper->tickPrice( tickerId, (TickType)tickTypeInt, price, canAutoExecute);

    // process ver 2 fields
    {
        TickType sizeTickType = NOT_SET;
        switch( (TickType)tickTypeInt) {
        case BID:
            sizeTickType = BID_SIZE;
            break;
        case ASK:
            sizeTickType = ASK_SIZE;
            break;
        case LAST:
            sizeTickType = LAST_SIZE;
            break;
        }
        if( sizeTickType != NOT_SET)
            m_pEWrapper->tickSize( tickerId, sizeTickType, size);
    }

    return 0;
}

int EDecoder::processTickSizeMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    int size;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);
    DECODE_FIELD( size);

    m_pEWrapper->tickSize( tickerId, (TickType)tickTypeInt, size);

    return 0;
}

int EDecoder::processTickOptionComputationMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    double impliedVol;
    double delta;

    double optPrice = DBL_MAX;
    double pvDividend = DBL_MAX;

    double gamma = DBL_MAX;
    double vega = DBL_MAX;
    double theta = DBL_MAX;
    double undPrice = DBL_MAX;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);

    DECODE_FIELD( impliedVol);
    DECODE_FIELD( delta);

    if( impliedVol < 0) { // -1 is the "not computed" indicator
        impliedVol = DBL_MAX;
    }
    if( delta > 1 || delta < -1) { // -2 is the "not computed" indicator
        delta = DBL_MAX;
    }

    if( version >= 6 || tickTypeInt == MODEL_OPTION) { // introduced in version == 5

        DECODE_FIELD( optPrice);
        DECODE_FIELD( pvDividend);

        if( optPrice < 0) { // -1 is the "not computed" indicator
            optPrice = DBL_MAX;
        }
        if( pvDividend < 0) { // -1 is the "not computed" indicator
            pvDividend = DBL_MAX;
        }
    }
    if( version >= 6) {

        DECODE_FIELD( gamma);
        DECODE_FIELD( vega);
        DECODE_FIELD( theta);
        DECODE_FIELD( undPrice);

        if( gamma > 1 || gamma < -1) { // -2 is the "not yet computed" indicator
            gamma = DBL_MAX;
        }
        if( vega > 1 || vega < -1) { // -2 is the "not yet computed" indicator
            vega = DBL_MAX;
        }
        if( theta > 1 || theta < -1) { // -2 is the "not yet computed" indicator
            theta = DBL_MAX;
        }
        if( undPrice < 0) { // -1 is the "not computed" indicator
            undPrice = DBL_MAX;
        }
    }
    m_pEWrapper->tickOptionComputation( tickerId, (TickType)tickTypeInt,
        impliedVol, delta, optPrice, pvDividend, gamma, vega, theta, undPrice);

    return 0;
}

int EDecoder::processTickGenericMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    double value;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);
    DECODE_FIELD( value);

    m_pEWrapper->tickGeneric( tickerId, (TickType)tickTypeInt, value);

    return 0;
}

int EDecoder::processTickStringMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    std::string value;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);
    DECODE_FIELD( value);

    m_pEWrapper->tickString( tickerId, (TickType)tickTypeInt, value);

    return 0;
}

int EDecoder::processTickEfpMsg(const char* ptr, const char* endPtr) {
    int version;
    int tickerId;
    int tickTypeInt;
    double basisPoints;
    std::string formattedBasisPoints;
    double impliedFuturesPrice;
    int holdDays;
    std::string futureExpiry;
    double dividendImpact;
    double dividendsToExpiry;

    DECODE_FIELD( version);
    DECODE_FIELD( tickerId);
    DECODE_FIELD( tickTypeInt);
    DECODE_FIELD( basisPoints);
    DECODE_FIELD( formattedBasisPoints);
    DECODE_FIELD( impliedFuturesPrice);
    DECODE_FIELD( holdDays);
    DECODE_FIELD( futureExpiry);
    DECODE_FIELD( dividendImpact);
    DECODE_FIELD( dividendsToExpiry);

    m_pEWrapper->tickEFP( tickerId, (TickType)tickTypeInt, basisPoints, formattedBasisPoints,
        impliedFuturesPrice, holdDays, futureExpiry, dividendImpact, dividendsToExpiry);

    return 0;
}

int EDecoder::processOrderStatusMsg(const char* ptr, const char* endPtr) {
    int version;
    int orderId;
    std::string status;
    int filled;
    int remaining;
    double avgFillPrice;
    int permId;
    int parentId;
    double lastFillPrice;
    int clientId;
    std::string whyHeld;

    DECODE_FIELD( version);
    DECODE_FIELD( orderId);
    DECODE_FIELD( status);
    DECODE_FIELD( filled);
    DECODE_FIELD( remaining);
    DECODE_FIELD( avgFillPrice);

    DECODE_FIELD( permId); // ver 2 field
    DECODE_FIELD( parentId); // ver 3 field
    DECODE_FIELD( lastFillPrice); // ver 4 field
    DECODE_FIELD( clientId); // ver 5 field
    DECODE_FIELD( whyHeld); // ver 6 field

    m_pEWrapper->orderStatus( orderId, status, filled, remaining,
        avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld);


    return 0;
}

int EDecoder::processErrMsgMsg(const char* ptr, const char* endPtr) {
    int version;
    int id; // ver 2 field
    int errorCode; // ver 2 field
    std::string errorMsg;

    DECODE_FIELD( version);
    DECODE_FIELD( id);
    DECODE_FIELD( errorCode);
    DECODE_FIELD( errorMsg);

    m_pEWrapper->error( id, errorCode, errorMsg);

    return 0;
}

int EDecoder::processOpenOrderMsg(const char* ptr, const char* endPtr) {
    // read version
    int version;
    DECODE_FIELD( version);

    // read order id
    Order order;
    DECODE_FIELD( order.orderId);

    // read contract fields
    Contract contract;
    DECODE_FIELD( contract.conId); // ver 17 field
    DECODE_FIELD( contract.symbol);
    DECODE_FIELD( contract.secType);
    DECODE_FIELD( contract.expiry);
    DECODE_FIELD( contract.strike);
    DECODE_FIELD( contract.right);
    if (version >= 32) {
        DECODE_FIELD( contract.multiplier);
    }
    DECODE_FIELD( contract.exchange);
    DECODE_FIELD( contract.currency);
    DECODE_FIELD( contract.localSymbol); // ver 2 field
    if (version >= 32) {
        DECODE_FIELD( contract.tradingClass);
    }

    // read order fields
    DECODE_FIELD( order.action);
    DECODE_FIELD( order.totalQuantity);
    DECODE_FIELD( order.orderType);
    if (version < 29) { 
        DECODE_FIELD( order.lmtPrice);
    }
    else {
        DECODE_FIELD_MAX( order.lmtPrice);
    }
    if (version < 30) { 
        DECODE_FIELD( order.auxPrice);
    }
    else {
        DECODE_FIELD_MAX( order.auxPrice);
    }
    DECODE_FIELD( order.tif);
    DECODE_FIELD( order.ocaGroup);
    DECODE_FIELD( order.account);
    DECODE_FIELD( order.openClose);

    int orderOriginInt;
    DECODE_FIELD( orderOriginInt);
    order.origin = (Origin)orderOriginInt;

    DECODE_FIELD( order.orderRef);
    DECODE_FIELD( order.clientId); // ver 3 field
    DECODE_FIELD( order.permId); // ver 4 field

    //if( version < 18) {
    //	// will never happen
    //	/* order.ignoreRth = */ readBoolFromInt();
    //}

    DECODE_FIELD( order.outsideRth); // ver 18 field
    DECODE_FIELD( order.hidden); // ver 4 field
    DECODE_FIELD( order.discretionaryAmt); // ver 4 field
    DECODE_FIELD( order.goodAfterTime); // ver 5 field

    {
        std::string sharesAllocation;
        DECODE_FIELD( sharesAllocation); // deprecated ver 6 field
    }

    DECODE_FIELD( order.faGroup); // ver 7 field
    DECODE_FIELD( order.faMethod); // ver 7 field
    DECODE_FIELD( order.faPercentage); // ver 7 field
    DECODE_FIELD( order.faProfile); // ver 7 field

    DECODE_FIELD( order.goodTillDate); // ver 8 field

    DECODE_FIELD( order.rule80A); // ver 9 field
    DECODE_FIELD_MAX( order.percentOffset); // ver 9 field
    DECODE_FIELD( order.settlingFirm); // ver 9 field
    DECODE_FIELD( order.shortSaleSlot); // ver 9 field
    DECODE_FIELD( order.designatedLocation); // ver 9 field
    if( m_serverVersion == MIN_SERVER_VER_SSHORTX_OLD){
        int exemptCode;
        DECODE_FIELD( exemptCode);
    }
    else if( version >= 23){
        DECODE_FIELD( order.exemptCode);
    }
    DECODE_FIELD( order.auctionStrategy); // ver 9 field
    DECODE_FIELD_MAX( order.startingPrice); // ver 9 field
    DECODE_FIELD_MAX( order.stockRefPrice); // ver 9 field
    DECODE_FIELD_MAX( order.delta); // ver 9 field
    DECODE_FIELD_MAX( order.stockRangeLower); // ver 9 field
    DECODE_FIELD_MAX( order.stockRangeUpper); // ver 9 field
    DECODE_FIELD( order.displaySize); // ver 9 field

    //if( version < 18) {
    //		// will never happen
    //		/* order.rthOnly = */ readBoolFromInt();
    //}

    DECODE_FIELD( order.blockOrder); // ver 9 field
    DECODE_FIELD( order.sweepToFill); // ver 9 field
    DECODE_FIELD( order.allOrNone); // ver 9 field
    DECODE_FIELD_MAX( order.minQty); // ver 9 field
    DECODE_FIELD( order.ocaType); // ver 9 field
    DECODE_FIELD( order.eTradeOnly); // ver 9 field
    DECODE_FIELD( order.firmQuoteOnly); // ver 9 field
    DECODE_FIELD_MAX( order.nbboPriceCap); // ver 9 field

    DECODE_FIELD( order.parentId); // ver 10 field
    DECODE_FIELD( order.triggerMethod); // ver 10 field

    DECODE_FIELD_MAX( order.volatility); // ver 11 field
    DECODE_FIELD( order.volatilityType); // ver 11 field
    DECODE_FIELD( order.deltaNeutralOrderType); // ver 11 field (had a hack for ver 11)
    DECODE_FIELD_MAX( order.deltaNeutralAuxPrice); // ver 12 field

    if (version >= 27 && !order.deltaNeutralOrderType.empty()) {
        DECODE_FIELD( order.deltaNeutralConId);
        DECODE_FIELD( order.deltaNeutralSettlingFirm);
        DECODE_FIELD( order.deltaNeutralClearingAccount);
        DECODE_FIELD( order.deltaNeutralClearingIntent);
    }

    if (version >= 31 && !order.deltaNeutralOrderType.empty()) {
        DECODE_FIELD( order.deltaNeutralOpenClose);
        DECODE_FIELD( order.deltaNeutralShortSale);
        DECODE_FIELD( order.deltaNeutralShortSaleSlot);
        DECODE_FIELD( order.deltaNeutralDesignatedLocation);
    }

    DECODE_FIELD( order.continuousUpdate); // ver 11 field

    // will never happen
    //if( m_serverVersion == 26) {
    //	order.stockRangeLower = readDouble();
    //	order.stockRangeUpper = readDouble();
    //}

    DECODE_FIELD( order.referencePriceType); // ver 11 field

    DECODE_FIELD_MAX( order.trailStopPrice); // ver 13 field

    if (version >= 30) {
        DECODE_FIELD_MAX( order.trailingPercent);
    }

    DECODE_FIELD_MAX( order.basisPoints); // ver 14 field
    DECODE_FIELD_MAX( order.basisPointsType); // ver 14 field
    DECODE_FIELD( contract.comboLegsDescrip); // ver 14 field

    if (version >= 29) {
        int comboLegsCount = 0;
        DECODE_FIELD( comboLegsCount);

        if (comboLegsCount > 0) {
            Contract::ComboLegListSPtr comboLegs( new Contract::ComboLegList);
            comboLegs->reserve( comboLegsCount);
            for (int i = 0; i < comboLegsCount; ++i) {
                ComboLegSPtr comboLeg( new ComboLeg());
                DECODE_FIELD( comboLeg->conId);
                DECODE_FIELD( comboLeg->ratio);
                DECODE_FIELD( comboLeg->action);
                DECODE_FIELD( comboLeg->exchange);
                DECODE_FIELD( comboLeg->openClose);
                DECODE_FIELD( comboLeg->shortSaleSlot);
                DECODE_FIELD( comboLeg->designatedLocation);
                DECODE_FIELD( comboLeg->exemptCode);

                comboLegs->push_back( comboLeg);
            }
            contract.comboLegs = comboLegs;
        }

        int orderComboLegsCount = 0;
        DECODE_FIELD( orderComboLegsCount);
        if (orderComboLegsCount > 0) {
            Order::OrderComboLegListSPtr orderComboLegs( new Order::OrderComboLegList);
            orderComboLegs->reserve( orderComboLegsCount);
            for (int i = 0; i < orderComboLegsCount; ++i) {
                OrderComboLegSPtr orderComboLeg( new OrderComboLeg());
                DECODE_FIELD_MAX( orderComboLeg->price);

                orderComboLegs->push_back( orderComboLeg);
            }
            order.orderComboLegs = orderComboLegs;
        }
    }

    if (version >= 26) {
        int smartComboRoutingParamsCount = 0;
        DECODE_FIELD( smartComboRoutingParamsCount);
        if( smartComboRoutingParamsCount > 0) {
            TagValueListSPtr smartComboRoutingParams( new TagValueList);
            smartComboRoutingParams->reserve( smartComboRoutingParamsCount);
            for( int i = 0; i < smartComboRoutingParamsCount; ++i) {
                TagValueSPtr tagValue( new TagValue());
                DECODE_FIELD( tagValue->tag);
                DECODE_FIELD( tagValue->value);
                smartComboRoutingParams->push_back( tagValue);
            }
            order.smartComboRoutingParams = smartComboRoutingParams;
        }
    }

    if( version >= 20) {
        DECODE_FIELD_MAX( order.scaleInitLevelSize);
        DECODE_FIELD_MAX( order.scaleSubsLevelSize);
    }
    else {
        // ver 15 fields
        int notSuppScaleNumComponents = 0;
        DECODE_FIELD_MAX( notSuppScaleNumComponents);
        DECODE_FIELD_MAX( order.scaleInitLevelSize); // scaleComponectSize
    }
    DECODE_FIELD_MAX( order.scalePriceIncrement); // ver 15 field

    if (version >= 28 && order.scalePriceIncrement > 0.0 && order.scalePriceIncrement != UNSET_DOUBLE) {
        DECODE_FIELD_MAX( order.scalePriceAdjustValue);
        DECODE_FIELD_MAX( order.scalePriceAdjustInterval);
        DECODE_FIELD_MAX( order.scaleProfitOffset);
        DECODE_FIELD( order.scaleAutoReset);
        DECODE_FIELD_MAX( order.scaleInitPosition);
        DECODE_FIELD_MAX( order.scaleInitFillQty);
        DECODE_FIELD( order.scaleRandomPercent);
    }

    if( version >= 24) {
        DECODE_FIELD( order.hedgeType);
        if( !order.hedgeType.empty()) {
            DECODE_FIELD( order.hedgeParam);
        }
    }

    if( version >= 25) {
        DECODE_FIELD( order.optOutSmartRouting);
    }

    DECODE_FIELD( order.clearingAccount); // ver 19 field
    DECODE_FIELD( order.clearingIntent); // ver 19 field

    if( version >= 22) {
        DECODE_FIELD( order.notHeld);
    }

    UnderComp underComp;
    if( version >= 20) {
        bool underCompPresent = false;
        DECODE_FIELD(underCompPresent);
        if( underCompPresent){
            DECODE_FIELD(underComp.conId);
            DECODE_FIELD(underComp.delta);
            DECODE_FIELD(underComp.price);
            contract.underComp = &underComp;
        }
    }


    if( version >= 21) {
        DECODE_FIELD( order.algoStrategy);
        if( !order.algoStrategy.empty()) {
            int algoParamsCount = 0;
            DECODE_FIELD( algoParamsCount);
            if( algoParamsCount > 0) {
                TagValueListSPtr algoParams( new TagValueList);
                algoParams->reserve( algoParamsCount);
                for( int i = 0; i < algoParamsCount; ++i) {
                    TagValueSPtr tagValue( new TagValue());
                    DECODE_FIELD( tagValue->tag);
                    DECODE_FIELD( tagValue->value);
                    algoParams->push_back( tagValue);
                }
                order.algoParams = algoParams;
            }
        }
    }

    if (version >= 33) {
        DECODE_FIELD(order.solicited);
    }

    OrderState orderState;

    DECODE_FIELD( order.whatIf); // ver 16 field

    DECODE_FIELD( orderState.status); // ver 16 field
    DECODE_FIELD( orderState.initMargin); // ver 16 field
    DECODE_FIELD( orderState.maintMargin); // ver 16 field
    DECODE_FIELD( orderState.equityWithLoan); // ver 16 field
    DECODE_FIELD_MAX( orderState.commission); // ver 16 field
    DECODE_FIELD_MAX( orderState.minCommission); // ver 16 field
    DECODE_FIELD_MAX( orderState.maxCommission); // ver 16 field
    DECODE_FIELD( orderState.commissionCurrency); // ver 16 field
    DECODE_FIELD( orderState.warningText); // ver 16 field

    m_pEWrapper->openOrder( (OrderId)order.orderId, contract, order, orderState);
    
    return 0;
} 

int EDecoder::parseAndProcessMsg(const char*& beginPtr, const char* endPtr) {
    // process a single message from the buffer;
    // return number of bytes consumed

    assert( beginPtr && beginPtr < endPtr);

    try {

        const char* ptr = beginPtr;

        int msgId;
        DECODE_FIELD( msgId);

        switch( msgId) {
        case TICK_PRICE:
            return processTickPriceMsg(ptr, endPtr);

        case TICK_SIZE:
            return processTickSizeMsg(ptr, endPtr);

        case TICK_OPTION_COMPUTATION:
            return processTickOptionComputationMsg(ptr, endPtr);

        case TICK_GENERIC:
            return processTickGenericMsg(ptr, endPtr);

        case TICK_STRING:
            return processTickStringMsg(ptr, endPtr);

        case TICK_EFP:
            return processTickEfpMsg(ptr, endPtr);

        case ORDER_STATUS:
            return processOrderStatusMsg(ptr, endPtr);

        case ERR_MSG:
            return processErrMsgMsg(ptr, endPtr);

        case OPEN_ORDER:
            return processOpenOrderMsg(ptr, endPtr);

        case ACCT_VALUE:
            {
                int version;
                std::string key;
                std::string val;
                std::string cur;
                std::string accountName;

                DECODE_FIELD( version);
                DECODE_FIELD( key);
                DECODE_FIELD( val);
                DECODE_FIELD( cur);
                DECODE_FIELD( accountName); // ver 2 field

                m_pEWrapper->updateAccountValue( key, val, cur, accountName);
                break;
            }

        case PORTFOLIO_VALUE:
            {
                // decode version
                int version;
                DECODE_FIELD( version);

                // read contract fields
                Contract contract;
                DECODE_FIELD( contract.conId); // ver 6 field
                DECODE_FIELD( contract.symbol);
                DECODE_FIELD( contract.secType);
                DECODE_FIELD( contract.expiry);
                DECODE_FIELD( contract.strike);
                DECODE_FIELD( contract.right);

                if( version >= 7) {
                    DECODE_FIELD( contract.multiplier);
                    DECODE_FIELD( contract.primaryExchange);
                }

                DECODE_FIELD( contract.currency);
                DECODE_FIELD( contract.localSymbol); // ver 2 field
                if (version >= 8) {
                    DECODE_FIELD( contract.tradingClass);
                }

                int     position;
                double  marketPrice;
                double  marketValue;
                double  averageCost;
                double  unrealizedPNL;
                double  realizedPNL;

                DECODE_FIELD( position);
                DECODE_FIELD( marketPrice);
                DECODE_FIELD( marketValue);
                DECODE_FIELD( averageCost); // ver 3 field
                DECODE_FIELD( unrealizedPNL); // ver 3 field
                DECODE_FIELD( realizedPNL); // ver 3 field

                std::string accountName;
                DECODE_FIELD( accountName); // ver 4 field

                if( version == 6 && m_serverVersion == 39) {
                    DECODE_FIELD( contract.primaryExchange);
                }

                m_pEWrapper->updatePortfolio( contract,
                    position, marketPrice, marketValue, averageCost,
                    unrealizedPNL, realizedPNL, accountName);

                break;
            }

        case ACCT_UPDATE_TIME:
            {
                int version;
                std::string accountTime;

                DECODE_FIELD( version);
                DECODE_FIELD( accountTime);

                m_pEWrapper->updateAccountTime( accountTime);
                break;
            }

        case NEXT_VALID_ID:
            {
                int version;
                int orderId;

                DECODE_FIELD( version);
                DECODE_FIELD( orderId);

                m_pEWrapper->nextValidId(orderId);
                break;
            }

        case CONTRACT_DATA:
            {
                int version;
                DECODE_FIELD( version);

                int reqId = -1;
                if( version >= 3) {
                    DECODE_FIELD( reqId);
                }

                ContractDetails contract;
                DECODE_FIELD( contract.summary.symbol);
                DECODE_FIELD( contract.summary.secType);
                DECODE_FIELD( contract.summary.expiry);
                DECODE_FIELD( contract.summary.strike);
                DECODE_FIELD( contract.summary.right);
                DECODE_FIELD( contract.summary.exchange);
                DECODE_FIELD( contract.summary.currency);
                DECODE_FIELD( contract.summary.localSymbol);
                DECODE_FIELD( contract.marketName);
                DECODE_FIELD( contract.summary.tradingClass);
                DECODE_FIELD( contract.summary.conId);
                DECODE_FIELD( contract.minTick);
                DECODE_FIELD( contract.summary.multiplier);
                DECODE_FIELD( contract.orderTypes);
                DECODE_FIELD( contract.validExchanges);
                DECODE_FIELD( contract.priceMagnifier); // ver 2 field
                if( version >= 4) {
                    DECODE_FIELD( contract.underConId);
                }
                if( version >= 5) {
                    DECODE_FIELD( contract.longName);
                    DECODE_FIELD( contract.summary.primaryExchange);
                }
                if( version >= 6) {
                    DECODE_FIELD( contract.contractMonth);
                    DECODE_FIELD( contract.industry);
                    DECODE_FIELD( contract.category);
                    DECODE_FIELD( contract.subcategory);
                    DECODE_FIELD( contract.timeZoneId);
                    DECODE_FIELD( contract.tradingHours);
                    DECODE_FIELD( contract.liquidHours);
                }
                if( version >= 8) {
                    DECODE_FIELD( contract.evRule);
                    DECODE_FIELD( contract.evMultiplier);
                }
                if( version >= 7) {
                    int secIdListCount = 0;
                    DECODE_FIELD( secIdListCount);
                    if( secIdListCount > 0) {
                        TagValueListSPtr secIdList( new TagValueList);
                        secIdList->reserve( secIdListCount);
                        for( int i = 0; i < secIdListCount; ++i) {
                            TagValueSPtr tagValue( new TagValue());
                            DECODE_FIELD( tagValue->tag);
                            DECODE_FIELD( tagValue->value);
                            secIdList->push_back( tagValue);
                        }
                        contract.secIdList = secIdList;
                    }
                }

                m_pEWrapper->contractDetails( reqId, contract);
                break;
            }

        case BOND_CONTRACT_DATA:
            {
                int version;
                DECODE_FIELD( version);

                int reqId = -1;
                if( version >= 3) {
                    DECODE_FIELD( reqId);
                }

                ContractDetails contract;
                DECODE_FIELD( contract.summary.symbol);
                DECODE_FIELD( contract.summary.secType);
                DECODE_FIELD( contract.cusip);
                DECODE_FIELD( contract.coupon);
                DECODE_FIELD( contract.maturity);
                DECODE_FIELD( contract.issueDate);
                DECODE_FIELD( contract.ratings);
                DECODE_FIELD( contract.bondType);
                DECODE_FIELD( contract.couponType);
                DECODE_FIELD( contract.convertible);
                DECODE_FIELD( contract.callable);
                DECODE_FIELD( contract.putable);
                DECODE_FIELD( contract.descAppend);
                DECODE_FIELD( contract.summary.exchange);
                DECODE_FIELD( contract.summary.currency);
                DECODE_FIELD( contract.marketName);
                DECODE_FIELD( contract.summary.tradingClass);
                DECODE_FIELD( contract.summary.conId);
                DECODE_FIELD( contract.minTick);
                DECODE_FIELD( contract.orderTypes);
                DECODE_FIELD( contract.validExchanges);
                DECODE_FIELD( contract.nextOptionDate); // ver 2 field
                DECODE_FIELD( contract.nextOptionType); // ver 2 field
                DECODE_FIELD( contract.nextOptionPartial); // ver 2 field
                DECODE_FIELD( contract.notes); // ver 2 field
                if( version >= 4) {
                    DECODE_FIELD( contract.longName);
                }
                if( version >= 6) {
                    DECODE_FIELD( contract.evRule);
                    DECODE_FIELD( contract.evMultiplier);
                }
                if( version >= 5) {
                    int secIdListCount = 0;
                    DECODE_FIELD( secIdListCount);
                    if( secIdListCount > 0) {
                        TagValueListSPtr secIdList( new TagValueList);
                        secIdList->reserve( secIdListCount);
                        for( int i = 0; i < secIdListCount; ++i) {
                            TagValueSPtr tagValue( new TagValue());
                            DECODE_FIELD( tagValue->tag);
                            DECODE_FIELD( tagValue->value);
                            secIdList->push_back( tagValue);
                        }
                        contract.secIdList = secIdList;
                    }
                }

                m_pEWrapper->bondContractDetails( reqId, contract);
                break;
            }

        case EXECUTION_DATA:
            {
                int version;
                DECODE_FIELD( version);

                int reqId = -1;
                if( version >= 7) {
                    DECODE_FIELD(reqId);
                }

                int orderId;
                DECODE_FIELD( orderId);

                // decode contract fields
                Contract contract;
                DECODE_FIELD( contract.conId); // ver 5 field
                DECODE_FIELD( contract.symbol);
                DECODE_FIELD( contract.secType);
                DECODE_FIELD( contract.expiry);
                DECODE_FIELD( contract.strike);
                DECODE_FIELD( contract.right);
                if( version >= 9) {
                    DECODE_FIELD( contract.multiplier);
                }
                DECODE_FIELD( contract.exchange);
                DECODE_FIELD( contract.currency);
                DECODE_FIELD( contract.localSymbol);
                if (version >= 10) {
                    DECODE_FIELD( contract.tradingClass);
                }

                // decode execution fields
                Execution exec;
                exec.orderId = orderId;
                DECODE_FIELD( exec.execId);
                DECODE_FIELD( exec.time);
                DECODE_FIELD( exec.acctNumber);
                DECODE_FIELD( exec.exchange);
                DECODE_FIELD( exec.side);
                DECODE_FIELD( exec.shares);
                DECODE_FIELD( exec.price);
                DECODE_FIELD( exec.permId); // ver 2 field
                DECODE_FIELD( exec.clientId); // ver 3 field
                DECODE_FIELD( exec.liquidation); // ver 4 field

                if( version >= 6) {
                    DECODE_FIELD( exec.cumQty);
                    DECODE_FIELD( exec.avgPrice);
                }

                if( version >= 8) {
                    DECODE_FIELD( exec.orderRef);
                }

                if( version >= 9) {
                    DECODE_FIELD( exec.evRule);
                    DECODE_FIELD( exec.evMultiplier);
                }

                m_pEWrapper->execDetails( reqId, contract, exec);
                break;
            }

        case MARKET_DEPTH:
            {
                int version;
                int id;
                int position;
                int operation;
                int side;
                double price;
                int size;

                DECODE_FIELD( version);
                DECODE_FIELD( id);
                DECODE_FIELD( position);
                DECODE_FIELD( operation);
                DECODE_FIELD( side);
                DECODE_FIELD( price);
                DECODE_FIELD( size);

                m_pEWrapper->updateMktDepth( id, position, operation, side, price, size);
                break;
            }

        case MARKET_DEPTH_L2:
            {
                int version;
                int id;
                int position;
                std::string marketMaker;
                int operation;
                int side;
                double price;
                int size;

                DECODE_FIELD( version);
                DECODE_FIELD( id);
                DECODE_FIELD( position);
                DECODE_FIELD( marketMaker);
                DECODE_FIELD( operation);
                DECODE_FIELD( side);
                DECODE_FIELD( price);
                DECODE_FIELD( size);

                m_pEWrapper->updateMktDepthL2( id, position, marketMaker, operation, side,
                    price, size);

                break;
            }

        case NEWS_BULLETINS:
            {
                int version;
                int msgId;
                int msgType;
                std::string newsMessage;
                std::string originatingExch;

                DECODE_FIELD( version);
                DECODE_FIELD( msgId);
                DECODE_FIELD( msgType);
                DECODE_FIELD( newsMessage);
                DECODE_FIELD( originatingExch);

                m_pEWrapper->updateNewsBulletin( msgId, msgType, newsMessage, originatingExch);
                break;
            }

        case MANAGED_ACCTS:
            {
                int version;
                std::string accountsList;

                DECODE_FIELD( version);
                DECODE_FIELD( accountsList);

                m_pEWrapper->managedAccounts( accountsList);
                break;
            }

        case RECEIVE_FA:
            {
                int version;
                int faDataTypeInt;
                std::string cxml;

                DECODE_FIELD( version);
                DECODE_FIELD( faDataTypeInt);
                DECODE_FIELD( cxml);

                m_pEWrapper->receiveFA( (faDataType)faDataTypeInt, cxml);
                break;
            }

        case HISTORICAL_DATA:
            {
                int version;
                int reqId;
                std::string startDateStr;
                std::string endDateStr;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( startDateStr); // ver 2 field
                DECODE_FIELD( endDateStr); // ver 2 field

                int itemCount;
                DECODE_FIELD( itemCount);

                typedef std::vector<BarData> BarDataList;
                BarDataList bars;

                bars.reserve( itemCount);

                for( int ctr = 0; ctr < itemCount; ++ctr) {

                    BarData bar;
                    DECODE_FIELD( bar.date);
                    DECODE_FIELD( bar.open);
                    DECODE_FIELD( bar.high);
                    DECODE_FIELD( bar.low);
                    DECODE_FIELD( bar.close);
                    DECODE_FIELD( bar.volume);
                    DECODE_FIELD( bar.average);
                    DECODE_FIELD( bar.hasGaps);
                    DECODE_FIELD( bar.barCount); // ver 3 field

                    bars.push_back(bar);
                }

                assert( (int)bars.size() == itemCount);

                for( int ctr = 0; ctr < itemCount; ++ctr) {

                    const BarData& bar = bars[ctr];
                    m_pEWrapper->historicalData( reqId, bar.date, bar.open, bar.high, bar.low,
                        bar.close, bar.volume, bar.barCount, bar.average,
                        bar.hasGaps == "true");
                }

                // send end of dataset marker
                std::string finishedStr = std::string("finished-") + startDateStr + "-" + endDateStr;
                m_pEWrapper->historicalData( reqId, finishedStr, -1, -1, -1, -1, -1, -1, -1, 0);
                break;
            }

        case SCANNER_DATA:
            {
                int version;
                int tickerId;

                DECODE_FIELD( version);
                DECODE_FIELD( tickerId);

                int numberOfElements;
                DECODE_FIELD( numberOfElements);

                typedef std::vector<ScanData> ScanDataList;
                ScanDataList scannerDataList;

                scannerDataList.reserve( numberOfElements);

                for( int ctr=0; ctr < numberOfElements; ++ctr) {

                    ScanData data;

                    DECODE_FIELD( data.rank);
                    DECODE_FIELD( data.contract.summary.conId); // ver 3 field
                    DECODE_FIELD( data.contract.summary.symbol);
                    DECODE_FIELD( data.contract.summary.secType);
                    DECODE_FIELD( data.contract.summary.expiry);
                    DECODE_FIELD( data.contract.summary.strike);
                    DECODE_FIELD( data.contract.summary.right);
                    DECODE_FIELD( data.contract.summary.exchange);
                    DECODE_FIELD( data.contract.summary.currency);
                    DECODE_FIELD( data.contract.summary.localSymbol);
                    DECODE_FIELD( data.contract.marketName);
                    DECODE_FIELD( data.contract.summary.tradingClass);
                    DECODE_FIELD( data.distance);
                    DECODE_FIELD( data.benchmark);
                    DECODE_FIELD( data.projection);
                    DECODE_FIELD( data.legsStr);

                    scannerDataList.push_back( data);
                }

                assert( (int)scannerDataList.size() == numberOfElements);

                for( int ctr=0; ctr < numberOfElements; ++ctr) {

                    const ScanData& data = scannerDataList[ctr];
                    m_pEWrapper->scannerData( tickerId, data.rank, data.contract,
                        data.distance, data.benchmark, data.projection, data.legsStr);
                }

                m_pEWrapper->scannerDataEnd( tickerId);
                break;
            }

        case SCANNER_PARAMETERS:
            {
                int version;
                std::string xml;

                DECODE_FIELD( version);
                DECODE_FIELD( xml);

                m_pEWrapper->scannerParameters( xml);
                break;
            }

        case CURRENT_TIME:
            {
                int version;
                int time;

                DECODE_FIELD(version);
                DECODE_FIELD(time);

                m_pEWrapper->currentTime( time);
                break;
            }

        case REAL_TIME_BARS:
            {
                int version;
                int reqId;
                int time;
                double open;
                double high;
                double low;
                double close;
                int volume;
                double average;
                int count;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( time);
                DECODE_FIELD( open);
                DECODE_FIELD( high);
                DECODE_FIELD( low);
                DECODE_FIELD( close);
                DECODE_FIELD( volume);
                DECODE_FIELD( average);
                DECODE_FIELD( count);

                m_pEWrapper->realtimeBar( reqId, time, open, high, low, close,
                    volume, average, count);

                break;
            }

        case FUNDAMENTAL_DATA:
            {
                int version;
                int reqId;
                std::string data;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( data);

                m_pEWrapper->fundamentalData( reqId, data);
                break;
            }

        case CONTRACT_DATA_END:
            {
                int version;
                int reqId;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);

                m_pEWrapper->contractDetailsEnd( reqId);
                break;
            }

        case OPEN_ORDER_END:
            {
                int version;

                DECODE_FIELD( version);

                m_pEWrapper->openOrderEnd();
                break;
            }

        case ACCT_DOWNLOAD_END:
            {
                int version;
                std::string account;

                DECODE_FIELD( version);
                DECODE_FIELD( account);

                m_pEWrapper->accountDownloadEnd( account);
                break;
            }

        case EXECUTION_DATA_END:
            {
                int version;
                int reqId;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);

                m_pEWrapper->execDetailsEnd( reqId);
                break;
            }

        case DELTA_NEUTRAL_VALIDATION:
            {
                int version;
                int reqId;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);

                UnderComp underComp;

                DECODE_FIELD( underComp.conId);
                DECODE_FIELD( underComp.delta);
                DECODE_FIELD( underComp.price);

                m_pEWrapper->deltaNeutralValidation( reqId, underComp);
                break;
            }

        case TICK_SNAPSHOT_END:
            {
                int version;
                int reqId;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);

                m_pEWrapper->tickSnapshotEnd( reqId);
                break;
            }

        case MARKET_DATA_TYPE:
            {
                int version;
                int reqId;
                int marketDataType;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( marketDataType);

                m_pEWrapper->marketDataType( reqId, marketDataType);
                break;
            }

        case COMMISSION_REPORT:
            {
                int version;
                DECODE_FIELD( version);

                CommissionReport commissionReport;
                DECODE_FIELD( commissionReport.execId);
                DECODE_FIELD( commissionReport.commission);
                DECODE_FIELD( commissionReport.currency);
                DECODE_FIELD( commissionReport.realizedPNL);
                DECODE_FIELD( commissionReport.yield);
                DECODE_FIELD( commissionReport.yieldRedemptionDate);

                m_pEWrapper->commissionReport( commissionReport);
                break;
            }

        case POSITION_DATA:
            {
                int version;
                std::string account;
                int position;
                double avgCost = 0;

                DECODE_FIELD( version);
                DECODE_FIELD( account);

                // decode contract fields
                Contract contract;
                DECODE_FIELD( contract.conId);
                DECODE_FIELD( contract.symbol);
                DECODE_FIELD( contract.secType);
                DECODE_FIELD( contract.expiry);
                DECODE_FIELD( contract.strike);
                DECODE_FIELD( contract.right);
                DECODE_FIELD( contract.multiplier);
                DECODE_FIELD( contract.exchange);
                DECODE_FIELD( contract.currency);
                DECODE_FIELD( contract.localSymbol);
                if (version >= 2) {
                    DECODE_FIELD( contract.tradingClass);
                }

                DECODE_FIELD( position);
                if (version >= 3) {
                    DECODE_FIELD( avgCost);
                }

                m_pEWrapper->position( account, contract, position, avgCost);
                break;
            }

        case POSITION_END:
            {
                int version;

                DECODE_FIELD( version);

                m_pEWrapper->positionEnd();
                break;
            }

        case ACCOUNT_SUMMARY:
            {
                int version;
                int reqId;
                std::string account;
                std::string tag;
                std::string value;
                std::string curency;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( account);
                DECODE_FIELD( tag);
                DECODE_FIELD( value);
                DECODE_FIELD( curency);

                m_pEWrapper->accountSummary( reqId, account, tag, value, curency);
                break;
            }

        case ACCOUNT_SUMMARY_END:
            {
                int version;
                int reqId;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);

                m_pEWrapper->accountSummaryEnd( reqId);
                break;
            }

        case VERIFY_MESSAGE_API:
            {
                int version;
                std::string apiData;

                DECODE_FIELD( version);
                DECODE_FIELD( apiData);

                m_pEWrapper->verifyMessageAPI( apiData);
                break;
            }

        case VERIFY_COMPLETED:
            {
                int version;
                std::string isSuccessful;
                std::string errorText;

                DECODE_FIELD( version);
                DECODE_FIELD( isSuccessful);
                DECODE_FIELD( errorText);

                bool bRes = isSuccessful == "true";

                if (bRes) {
                    m_pEClient->startApi();
                }

                m_pEWrapper->verifyCompleted( bRes, errorText);
                break;
            }

        case DISPLAY_GROUP_LIST:
            {
                int version;
                int reqId;
                std::string groups;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( groups);

                m_pEWrapper->displayGroupList( reqId, groups);
                break;
            }

        case DISPLAY_GROUP_UPDATED:
            {
                int version;
                int reqId;
                std::string contractInfo;

                DECODE_FIELD( version);
                DECODE_FIELD( reqId);
                DECODE_FIELD( contractInfo);

                m_pEWrapper->displayGroupUpdated( reqId, contractInfo);
                break;
            }

        case VERIFY_AND_AUTH_MESSAGE_API:
            {
                int version;
                std::string apiData;
                std::string xyzChallenge;

                DECODE_FIELD( version);
                DECODE_FIELD( apiData);
                DECODE_FIELD( xyzChallenge);

                m_pEWrapper->verifyAndAuthMessageAPI( apiData, xyzChallenge);
                break;
            }

        case VERIFY_AND_AUTH_COMPLETED:
            {
                int version;
                std::string isSuccessful;
                std::string errorText;

                DECODE_FIELD( version);
                DECODE_FIELD( isSuccessful);
                DECODE_FIELD( errorText);

                bool bRes = isSuccessful == "true";

                if (bRes) {
                    m_pEClient->startApi();
                }

                m_pEWrapper->verifyAndAuthCompleted( bRes, errorText);
                break;
            }

        default:
            {
                m_pEWrapper->error( msgId, UNKNOWN_ID.code(), UNKNOWN_ID.msg());
                m_pEClient->eDisconnect();
                m_pEWrapper->connectionClosed();
                break;
            }
        }

        int processed = ptr - beginPtr;
        beginPtr = ptr;
        return processed;
    }
    catch( std::exception e) {
        m_pEWrapper->error( NO_VALID_ID, SOCKET_EXCEPTION.code(),
            SOCKET_EXCEPTION.msg() + errMsg(e));
    }
    return 0;
}


bool EDecoder::CheckOffset(const char* ptr, const char* endPtr)
{
    assert (ptr && ptr <= endPtr);
    return (ptr && ptr < endPtr);
}

const char* EDecoder::FindFieldEnd(const char* ptr, const char* endPtr)
{
    return (const char*)memchr(ptr, 0, endPtr - ptr);
}

bool EDecoder::DecodeField(bool& boolValue, const char*& ptr, const char* endPtr)
{
    int intValue;
    if( !DecodeField(intValue, ptr, endPtr))
        return false;
    boolValue = (intValue > 0);
    return true;
}

bool EDecoder::DecodeField(int& intValue, const char*& ptr, const char* endPtr)
{
    if( !CheckOffset(ptr, endPtr))
        return false;
    const char* fieldBeg = ptr;
    const char* fieldEnd = FindFieldEnd(fieldBeg, endPtr);
    if( !fieldEnd)
        return false;
    intValue = atoi(fieldBeg);
    ptr = ++fieldEnd;
    return true;
}

bool EDecoder::DecodeField(long& longValue, const char*& ptr, const char* endPtr)
{
    int intValue;
    if( !DecodeField(intValue, ptr, endPtr))
        return false;
    longValue = intValue;
    return true;
}

bool EDecoder::DecodeField(double& doubleValue, const char*& ptr, const char* endPtr)
{
    if( !CheckOffset(ptr, endPtr))
        return false;
    const char* fieldBeg = ptr;
    const char* fieldEnd = FindFieldEnd(fieldBeg, endPtr);
    if( !fieldEnd)
        return false;
    doubleValue = atof(fieldBeg);
    ptr = ++fieldEnd;
    return true;
}

bool EDecoder::DecodeField(std::string& stringValue,
                           const char*& ptr, const char* endPtr)
{
    if( !CheckOffset(ptr, endPtr))
        return false;
    const char* fieldBeg = ptr;
    const char* fieldEnd = FindFieldEnd(ptr, endPtr);
    if( !fieldEnd)
        return false;
    stringValue = fieldBeg; // better way?
    ptr = ++fieldEnd;
    return true;
}

bool EDecoder::DecodeFieldMax(int& intValue, const char*& ptr, const char* endPtr)
{
    std::string stringValue;
    if( !DecodeField(stringValue, ptr, endPtr))
        return false;
    intValue = stringValue.empty() ? UNSET_INTEGER : atoi(stringValue.c_str());
    return true;
}

bool EDecoder::DecodeFieldMax(long& longValue, const char*& ptr, const char* endPtr)
{
    int intValue;
    if( !DecodeFieldMax(intValue, ptr, endPtr))
        return false;
    longValue = intValue;
    return true;
}

bool EDecoder::DecodeFieldMax(double& doubleValue, const char*& ptr, const char* endPtr)
{
    std::string stringValue;
    if( !DecodeField(stringValue, ptr, endPtr))
        return false;
    doubleValue = stringValue.empty() ? UNSET_DOUBLE : atof(stringValue.c_str());
    return true;
}