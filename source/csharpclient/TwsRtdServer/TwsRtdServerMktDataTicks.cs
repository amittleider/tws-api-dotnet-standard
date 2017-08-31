using System;
using System.Collections.Generic;
using IBApi;

namespace TwsRtdServer
{
    public class TwsRtdServerMktDataTicks
    {
        // latest ticks (we should save ticks in case of non-streaming market data)
        private double m_lastPrice = 0.0;
        private double m_bidPrice = 0.0;
        private double m_askPrice = 0.0;
        private int m_lastSize = 0;
        private int m_bidSize = 0;
        private int m_askSize = 0;
        private double m_high = 0.0;
        private double m_low = 0.0;
        private int m_volume = 0;
        private double m_close = 0.0;
        private double m_open = 0.0;
        private string m_lastExch = "";
        private string m_bidExch = "";
        private string m_askExch = "";
        private string m_lastTime = "";
        private double m_halted = 0.0;

        // option ticks
        private TwsRtdServerData.OptionComputationData m_bidOptionComputation = new TwsRtdServerData.OptionComputationData();
        private TwsRtdServerData.OptionComputationData m_askOptionComputation = new TwsRtdServerData.OptionComputationData();
        private TwsRtdServerData.OptionComputationData m_lastOptionComputation = new TwsRtdServerData.OptionComputationData();
        private TwsRtdServerData.OptionComputationData m_modelOptionComputation = new TwsRtdServerData.OptionComputationData();

        // add generic ticks values
        private int m_genTickAuctionVolume = 0;
        private int m_genTickAuctionImbalance = 0;
        private double m_genTickAuctionPrice = 0.0;
        private int m_genTickRegulatoryImbalance = 0;
        private double m_genTickPlPrice = 0.0;
        private double m_genTickCreditmanMarkPrice = 0.0;
        private double m_genTickCreditmanSlowMarkPrice = 0.0;
        private int m_genTickCallOptionVolume = 0;
        private int m_genTickPutOptionVolume = 0;
        private int m_genTickCallOptionOpenInterest = 0;
        private int m_genTickPutOptionOpenInterest = 0;
        private double m_genTickOptionHistoricalVol = 0.0;
        private double m_genTickRTHistoricalVol = 0.0;
        private double m_genTickIndexFuturePremium = 0.0;
        private double m_genTickShortable = 0.0;
        private string m_genTickFundamentals = "";
        private double m_genTickTradeCount = 0.0;
        private double m_genTickTradeRate = 0.0;
        private double m_genTickVolumeRate = 0.0;
        private double m_genTickLastRTHTrade = 0.0;
        private string m_genTickIBDividends = "";
        private double m_genTickBondMultiplier = 0.0;
        private int m_genTickAverageVolume = 0;
        private double m_genTickWeek13Hi = 0.0;
        private double m_genTickWeek13Lo = 0.0;
        private double m_genTickWeek26Hi = 0.0;
        private double m_genTickWeek26Lo = 0.0;
        private double m_genTickWeek52Hi = 0.0;
        private double m_genTickWeek52Lo = 0.0;
        private int m_genTickShortTermVolume3Min = 0;
        private int m_genTickShortTermVolume5Min = 0;
        private int m_genTickShortTermVolume10Min = 0;
        private int m_futuresOpenInterest = 0;

        // delayed ticks
        private double m_delayed_lastPrice = 0.0;
        private double m_delayed_bidPrice = 0.0;
        private double m_delayed_askPrice = 0.0;
        private int m_delayed_lastSize = 0;
        private int m_delayed_bidSize = 0;
        private int m_delayed_askSize = 0;
        private double m_delayed_high = 0.0;
        private double m_delayed_low = 0.0;
        private int m_delayed_volume = 0;
        private double m_delayed_close = 0.0;
        private double m_delayed_open = 0.0;

        // constructor
        public TwsRtdServerMktDataTicks(){
        }

        public void SetValue(string tickType, object value)
        {
            // save latest values
            switch (tickType)
            {
                case TwsRtdServerData.LAST:
                    m_lastPrice = (double)value;
                    break;
                case TwsRtdServerData.ASK:
                    m_askPrice = (double)value;
                    break;
                case TwsRtdServerData.BID:
                    m_bidPrice = (double)value;
                    break;
                case TwsRtdServerData.LASTSIZE:
                    m_lastSize = (int)value;
                    break;
                case TwsRtdServerData.ASKSIZE:
                    m_askSize = (int)value;
                    break;
                case TwsRtdServerData.BIDSIZE:
                    m_bidSize = (int)value;
                    break;
                case TwsRtdServerData.HIGH:
                    m_high = (double)value;
                    break;
                case TwsRtdServerData.LOW:
                    m_low = (double)value;
                    break;
                case TwsRtdServerData.OPEN:
                    m_open = (double)value;
                    break;
                case TwsRtdServerData.CLOSE:
                    m_close = (double)value;
                    break;
                case TwsRtdServerData.HALTED:
                    m_halted = (double)value;
                    break;
                case TwsRtdServerData.VOLUME:
                    m_volume = (int)value;
                    break;
                case TwsRtdServerData.BIDEXCH:
                    m_bidExch = (string)value;
                    break;
                case TwsRtdServerData.ASKEXCH:
                    m_askExch = (string)value;
                    break;
                case TwsRtdServerData.LASTEXCH:
                    m_lastExch = (string)value;
                    break;
                case TwsRtdServerData.LASTTIME:
                    m_lastTime = (string)value;
                    break;
                case TwsRtdServerData.BID_OPTION_COMPUTATION:
                    m_bidOptionComputation = (TwsRtdServerData.OptionComputationData)value;
                    break;
                case TwsRtdServerData.ASK_OPTION_COMPUTATION:
                    m_askOptionComputation = (TwsRtdServerData.OptionComputationData)value;
                    break;
                case TwsRtdServerData.LAST_OPTION_COMPUTATION:
                    m_lastOptionComputation = (TwsRtdServerData.OptionComputationData)value;
                    break;
                case TwsRtdServerData.MODEL_OPTION_COMPUTATION:
                    m_modelOptionComputation = (TwsRtdServerData.OptionComputationData)value;
                    break;
                // generic ticks
                case TwsRtdServerData.GEN_TICK_AUCTION_VOLUME:
                    m_genTickAuctionVolume = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_AUCTION_IMBALANCE:
                    m_genTickAuctionImbalance = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_AUCTION_PRICE:
                    m_genTickAuctionPrice = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_REGULATORY_IMBALANCE:
                    m_genTickRegulatoryImbalance = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_PL_PRICE:
                    m_genTickPlPrice = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_CREDITMAN_MARK_PRICE:
                    m_genTickCreditmanMarkPrice = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_CREDITMAN_SLOW_MARK_PRICE:
                    m_genTickCreditmanSlowMarkPrice = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_CALL_OPTION_VOLUME:
                    m_genTickCallOptionVolume = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_PUT_OPTION_VOLUME:
                    m_genTickPutOptionVolume = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_CALL_OPTION_OPEN_INTEREST:
                    m_genTickCallOptionOpenInterest = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_PUT_OPTION_OPEN_INTEREST:
                    m_genTickPutOptionOpenInterest = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_OPTION_HISTORICAL_VOL:
                    m_genTickOptionHistoricalVol = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_RT_HISTORICAL_VOL:
                    m_genTickRTHistoricalVol = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_INDEX_FUTURE_PREMIUM:
                    m_genTickIndexFuturePremium = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORTABLE:
                    m_genTickShortable = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_FUNDAMENTALS:
                    m_genTickFundamentals = (string)value;
                    break;
                case TwsRtdServerData.GEN_TICK_TRADE_COUNT:
                    m_genTickTradeCount = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_TRADE_RATE:
                    m_genTickTradeRate = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_VOLUME_RATE:
                    m_genTickVolumeRate = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_LAST_RTH_TRADE:
                    m_genTickLastRTHTrade = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_IB_DIVIDENDS:
                    m_genTickIBDividends = (string)value;
                    break;
                case TwsRtdServerData.GEN_TICK_BOND_MULTIPLIER:
                    m_genTickBondMultiplier = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_AVERAGE_VOLUME:
                    m_genTickAverageVolume = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_13_HI:
                    m_genTickWeek13Hi = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_13_LO:
                    m_genTickWeek13Lo = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_26_HI:
                    m_genTickWeek26Hi = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_26_LO:
                    m_genTickWeek26Lo = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_52_HI:
                    m_genTickWeek52Hi = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_52_LO:
                    m_genTickWeek52Lo = (double)value;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_3_MIN:
                    m_genTickShortTermVolume3Min = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_5_MIN:
                    m_genTickShortTermVolume5Min = (int)value;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_10_MIN:
                    m_genTickShortTermVolume10Min = (int)value;
                    break;
                case TwsRtdServerData.FUTURES_OPEN_INTEREST:
                    m_futuresOpenInterest = (int)value;
                    break;
                
                // delayed ticks
                case TwsRtdServerData.DELAYED_LAST:
                    m_delayed_lastPrice = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_BID:
                    m_delayed_bidPrice = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_ASK:
                    m_delayed_askPrice = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_LAST_SIZE:
                    m_delayed_lastSize = (int)value;
                    break;
                case TwsRtdServerData.DELAYED_BID_SIZE:
                    m_delayed_bidSize = (int)value;
                    break;
                case TwsRtdServerData.DELAYED_ASK_SIZE:
                    m_delayed_askSize = (int)value;
                    break;
                case TwsRtdServerData.DELAYED_HIGH:
                    m_delayed_high = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_LOW:
                    m_delayed_low = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_VOLUME:
                    m_delayed_volume = (int)value;
                    break;
                case TwsRtdServerData.DELAYED_CLOSE:
                    m_delayed_close = (double)value;
                    break;
                case TwsRtdServerData.DELAYED_OPEN:
                    m_delayed_open = (double)value;
                    break;
            }
        }

        public Object GetValue(string topicStr)
        {
            Object value = null;
            switch (topicStr)
            {
                case TwsRtdServerData.LAST:
                    value = m_lastPrice;
                    break;
                case TwsRtdServerData.BID:
                    value = m_bidPrice;
                    break;
                case TwsRtdServerData.ASK:
                    value = m_askPrice;
                    break;
                case TwsRtdServerData.LASTSIZE:
                    value = m_lastSize;
                    break;
                case TwsRtdServerData.ASKSIZE:
                    value = m_askSize;
                    break;
                case TwsRtdServerData.BIDSIZE:
                    value = m_bidSize;
                    break;
                case TwsRtdServerData.HIGH:
                    value = m_high;
                    break;
                case TwsRtdServerData.LOW:
                    value = m_low;
                    break;
                case TwsRtdServerData.OPEN:
                    value = m_open;
                    break;
                case TwsRtdServerData.CLOSE:
                    value = m_close;
                    break;
                case TwsRtdServerData.HALTED:
                    value = m_halted;
                    break;
                case TwsRtdServerData.VOLUME:
                    value = m_volume;
                    break;
                case TwsRtdServerData.BIDEXCH:
                    value = m_bidExch;
                    break;
                case TwsRtdServerData.ASKEXCH:
                    value = m_askExch;
                    break;
                case TwsRtdServerData.LASTEXCH:
                    value = m_lastExch;
                    break;
                case TwsRtdServerData.LASTTIME:
                    value = m_lastTime;
                    break;
                case TwsRtdServerData.BID_IMPLIED_VOL:
                    value = m_bidOptionComputation.getImpliedVolatility();
                    break;
                case TwsRtdServerData.BID_DELTA:
                    value = m_bidOptionComputation.getDelta();
                    break;
                case TwsRtdServerData.BID_OPT_PRICE:
                    value = m_bidOptionComputation.getOptPrice();
                    break;
                case TwsRtdServerData.BID_PV_DIVIDEND:
                    value = m_bidOptionComputation.getPvDividend();
                    break;
                case TwsRtdServerData.BID_GAMMA:
                    value = m_bidOptionComputation.getGamma();
                    break;
                case TwsRtdServerData.BID_VEGA:
                    value = m_bidOptionComputation.getVega();
                    break;
                case TwsRtdServerData.BID_THETA:
                    value = m_bidOptionComputation.getTheta();
                    break;
                case TwsRtdServerData.BID_UND_PRICE:
                    value = m_bidOptionComputation.getUndPrice();
                    break;
                case TwsRtdServerData.ASK_IMPLIED_VOL:
                    value = m_askOptionComputation.getImpliedVolatility();
                    break;
                case TwsRtdServerData.ASK_DELTA:
                    value = m_askOptionComputation.getDelta();
                    break;
                case TwsRtdServerData.ASK_OPT_PRICE:
                    value = m_askOptionComputation.getOptPrice();
                    break;
                case TwsRtdServerData.ASK_PV_DIVIDEND:
                    value = m_askOptionComputation.getPvDividend();
                    break;
                case TwsRtdServerData.ASK_GAMMA:
                    value = m_askOptionComputation.getGamma();
                    break;
                case TwsRtdServerData.ASK_VEGA:
                    value = m_askOptionComputation.getVega();
                    break;
                case TwsRtdServerData.ASK_THETA:
                    value = m_askOptionComputation.getTheta();
                    break;
                case TwsRtdServerData.ASK_UND_PRICE:
                    value = m_askOptionComputation.getUndPrice();
                    break;
                case TwsRtdServerData.LAST_IMPLIED_VOL:
                    value = m_lastOptionComputation.getImpliedVolatility();
                    break;
                case TwsRtdServerData.LAST_DELTA:
                    value = m_lastOptionComputation.getDelta();
                    break;
                case TwsRtdServerData.LAST_OPT_PRICE:
                    value = m_lastOptionComputation.getOptPrice();
                    break;
                case TwsRtdServerData.LAST_PV_DIVIDEND:
                    value = m_lastOptionComputation.getPvDividend();
                    break;
                case TwsRtdServerData.LAST_GAMMA:
                    value = m_lastOptionComputation.getGamma();
                    break;
                case TwsRtdServerData.LAST_VEGA:
                    value = m_lastOptionComputation.getVega();
                    break;
                case TwsRtdServerData.LAST_THETA:
                    value = m_lastOptionComputation.getTheta();
                    break;
                case TwsRtdServerData.LAST_UND_PRICE:
                    value = m_lastOptionComputation.getUndPrice();
                    break;
                case TwsRtdServerData.MODEL_IMPLIED_VOL:
                    value = m_modelOptionComputation.getImpliedVolatility();
                    break;
                case TwsRtdServerData.MODEL_DELTA:
                    value = m_modelOptionComputation.getDelta();
                    break;
                case TwsRtdServerData.MODEL_OPT_PRICE:
                    value = m_modelOptionComputation.getOptPrice();
                    break;
                case TwsRtdServerData.MODEL_PV_DIVIDEND:
                    value = m_modelOptionComputation.getPvDividend();
                    break;
                case TwsRtdServerData.MODEL_GAMMA:
                    value = m_modelOptionComputation.getGamma();
                    break;
                case TwsRtdServerData.MODEL_VEGA:
                    value = m_modelOptionComputation.getVega();
                    break;
                case TwsRtdServerData.MODEL_THETA:
                    value = m_modelOptionComputation.getTheta();
                    break;
                case TwsRtdServerData.MODEL_UND_PRICE:
                    value = m_modelOptionComputation.getUndPrice();
                    break;
                    
                // generic ticks
                case TwsRtdServerData.GEN_TICK_AUCTION_VOLUME:
                    value = m_genTickAuctionVolume;
                    break;
                case TwsRtdServerData.GEN_TICK_AUCTION_IMBALANCE:
                    value = m_genTickAuctionImbalance;
                    break;
                case TwsRtdServerData.GEN_TICK_AUCTION_PRICE:
                    value = m_genTickAuctionPrice;
                    break;
                case TwsRtdServerData.GEN_TICK_REGULATORY_IMBALANCE:
                    value = m_genTickRegulatoryImbalance;
                    break;
                case TwsRtdServerData.GEN_TICK_PL_PRICE:
                    value = m_genTickPlPrice;
                    break;
                case TwsRtdServerData.GEN_TICK_CREDITMAN_MARK_PRICE:
                    value = m_genTickCreditmanMarkPrice;
                    break;
                case TwsRtdServerData.GEN_TICK_CREDITMAN_SLOW_MARK_PRICE:
                    value = m_genTickCreditmanSlowMarkPrice;
                    break;
                case TwsRtdServerData.GEN_TICK_CALL_OPTION_VOLUME:
                    value = m_genTickCallOptionVolume;
                    break;
                case TwsRtdServerData.GEN_TICK_PUT_OPTION_VOLUME:
                    value = m_genTickPutOptionVolume;
                    break;
                case TwsRtdServerData.GEN_TICK_CALL_OPTION_OPEN_INTEREST:
                    value = m_genTickCallOptionOpenInterest;
                    break;
                case TwsRtdServerData.GEN_TICK_PUT_OPTION_OPEN_INTEREST:
                    value = m_genTickPutOptionOpenInterest;
                    break;
                case TwsRtdServerData.GEN_TICK_OPTION_HISTORICAL_VOL:
                    value = m_genTickOptionHistoricalVol;
                    break;
                case TwsRtdServerData.GEN_TICK_RT_HISTORICAL_VOL:
                    value = m_genTickRTHistoricalVol;
                    break;
                case TwsRtdServerData.GEN_TICK_INDEX_FUTURE_PREMIUM:
                    value = m_genTickIndexFuturePremium;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORTABLE:
                    value = m_genTickShortable;
                    break;
                case TwsRtdServerData.GEN_TICK_FUNDAMENTALS:
                    value = m_genTickFundamentals;
                    break;
                case TwsRtdServerData.GEN_TICK_TRADE_COUNT:
                    value = m_genTickTradeCount;
                    break;
                case TwsRtdServerData.GEN_TICK_TRADE_RATE:
                    value = m_genTickTradeRate;
                    break;
                case TwsRtdServerData.GEN_TICK_VOLUME_RATE:
                    value = m_genTickVolumeRate;
                    break;
                case TwsRtdServerData.GEN_TICK_LAST_RTH_TRADE:
                    value = m_genTickLastRTHTrade;
                    break;
                case TwsRtdServerData.GEN_TICK_IB_DIVIDENDS:
                    value = m_genTickIBDividends;
                    break;
                case TwsRtdServerData.GEN_TICK_BOND_MULTIPLIER:
                    value = m_genTickBondMultiplier;
                    break;
                case TwsRtdServerData.GEN_TICK_AVERAGE_VOLUME:
                    value = m_genTickAverageVolume;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_13_HI:
                    value = m_genTickWeek13Hi;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_13_LO:
                    value = m_genTickWeek13Lo;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_26_HI:
                    value = m_genTickWeek26Hi;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_26_LO:
                    value = m_genTickWeek26Lo;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_52_HI:
                    value = m_genTickWeek52Hi;
                    break;
                case TwsRtdServerData.GEN_TICK_WEEK_52_LO:
                    value = m_genTickWeek52Lo;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_3_MIN:
                    value = m_genTickShortTermVolume3Min;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_5_MIN:
                    value = m_genTickShortTermVolume5Min;
                    break;
                case TwsRtdServerData.GEN_TICK_SHORT_TERM_VOLUME_10_MIN:
                    value = m_genTickShortTermVolume10Min;
                    break;
                case TwsRtdServerData.FUTURES_OPEN_INTEREST:
                    value = m_futuresOpenInterest;
                    break;

                // delayed ticks
                case TwsRtdServerData.DELAYED_LAST:
                    value = m_delayed_lastPrice;
                    break;
                case TwsRtdServerData.DELAYED_BID:
                    value = m_delayed_bidPrice;
                    break;
                case TwsRtdServerData.DELAYED_ASK:
                    value = m_delayed_askPrice;
                    break;
                case TwsRtdServerData.DELAYED_LAST_SIZE:
                    value = m_delayed_lastSize;
                    break;
                case TwsRtdServerData.DELAYED_BID_SIZE:
                    value = m_delayed_bidSize;
                    break;
                case TwsRtdServerData.DELAYED_ASK_SIZE:
                    value = m_delayed_askSize;
                    break;
                case TwsRtdServerData.DELAYED_HIGH:
                    value = m_delayed_high;
                    break;
                case TwsRtdServerData.DELAYED_LOW:
                    value = m_delayed_low;
                    break;
                case TwsRtdServerData.DELAYED_VOLUME:
                    value = m_delayed_volume;
                    break;
                case TwsRtdServerData.DELAYED_CLOSE:
                    value = m_delayed_close;
                    break;
                case TwsRtdServerData.DELAYED_OPEN:
                    value = m_delayed_open;
                    break;
            }
            return value;
        }



    }
}
