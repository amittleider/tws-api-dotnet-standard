//using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TwsRtdServer{

    public class TwsRtdServerData{

        // constants
        public const char CHAR_UNDERSCORE = '_';
        public const char CHAR_SPACE = ' ';
        public const char CHAR_SLASH = '/';
        public const char CHAR_AT = '@';
        public const char CHAR_DOT = '.';
        public const char CHAR_SEMICOLON = ';';
        public const char CHAR_HASH = '#';
        public const char CHAR_EQUAL = '=';

        //connection related
        // user input
        public const string HOST_STR = "host=";
        public const string PORT_STR = "port=";
        public const string CLIENT_ID_STR = "clientid=";
        public const string PAPER_STR = "paper";
        public const string GATEWAY_STR = "gw";
        public const string GATEWAY_PAPER_STR = "gwpaper";
        // defaults
        public const string DEFAULT_HOST = "127.0.0.1";
        public const string DEFAULT_PORT = "7496";
        public const int DEFAULT_CLIENT_ID = int.MaxValue - 1;
        public const string PAPER_PORT = "7497";
        public const string GATEWAY_PORT = "4001";
        public const string GATEWAY_PAPER_PORT = "4002";

        // topic related
        public const string QT = "qt=";

        // ticks
        public const string BIDSIZE = "BIDSIZE";
        public const string BID = "BID";
        public const string ASK = "ASK";
        public const string ASKSIZE = "ASKSIZE";
        public const string LAST = "LAST";
        public const string LASTSIZE = "LASTSIZE";
        public const string HIGH = "HIGH";
        public const string LOW = "LOW";
        public const string VOLUME = "VOLUME";
        public const string CLOSE = "CLOSE";

        public const string OPEN = "OPEN";
        public const string LASTEXCH = "LASTEXCH";
        public const string BIDEXCH = "BIDEXCH";
        public const string ASKEXCH = "ASKEXCH";
        public const string LASTTIME = "LASTTIME";
        public const string HALTED = "HALTED";

        // TODO: currently not supported in RTD server
        // BID_OPTION_COMPUTATION (IMPLIED_VOL, DELTA, OPT_PRICE, PV_DIVIDEND, GAMMA, VEGA, THETA, UNDER_PRICE)
        // ASK_OPTION_COMPUTATION (IMPLIED_VOL, DELTA, OPT_PRICE, PV_DIVIDEND, GAMMA, VEGA, THETA, UNDER_PRICE)
        // LAST_OPTION_COMPUTATION (IMPLIED_VOL, DELTA, OPT_PRICE, PV_DIVIDEND, GAMMA, VEGA, THETA, UNDER_PRICE)
        // MODEL_OPTION_COMPUTATION (IMPLIED_VOL, DELTA, OPT_PRICE, PV_DIVIDEND, GAMMA, VEGA, THETA, UNDER_PRICE)
        // BID_EFP_COMPUTATION, ASK_EFP_COMPUTATION, LAST_EFP_COMPUTATION, OPEN_EFP_COMPUTATION, CLOSE_EFP_COMPUTATION, HIGH_EFP_COMPUTATION, LOW_EFP_COMPUTATION,
        // YIELD_BID, YIELD_ASK, YIELD_LAST

        // TODO:
        // generic ticks

        // STK  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,456,460,595,619
        // OPT  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,456,460,595,619
        // FUT  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // FOP  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // WAR  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // CFD  100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // IND  100,101,104,106,162,165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // BAG  100,101,    106,    165,221,225,232,236,258,293,294,295,318,        460,    619
        // BOND 100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619
        // CASH 100,101,104,106,    165,221,225,232,236,258,293,294,295,318,411,    460,    619


        public const string GENERIC_TICKS_BASE = "100,101,106,165,221,225,232,236,258,293,294,295,318,460,619"; // BAG
        public const string GENERIC_TICKS_FUT = GENERIC_TICKS_BASE + ",104,411"; // FUT, FOP, WAR, CFD, BOND, CASH
        public const string GENERIC_TICKS_STK = GENERIC_TICKS_BASE + ",104,411,456,595"; // STK, OPT
        public const string GENERIC_TICKS_IND = GENERIC_TICKS_BASE + ",104,162,411"; // IND




        // AUCTION (225)
        public const string GEN_TICK_AUCTION_VOLUME = "AUCTIONVOLUME";
        public const string GEN_TICK_AUCTION_IMBALANCE = "AUCTIONIMBALANCE";
        public const string GEN_TICK_AUCTION_PRICE = "AUCTIONPRICE";
        public const string GEN_TICK_REGULATORY_IMBALANCE = "REGULATORYIMBALANCE";
        // PL_PRICE (232)
        public const string GEN_TICK_PL_PRICE = "PLPRICE";
        // CREDITMAN_MARK_PRICE (221)
        public const string GEN_TICK_CREDITMAN_MARK_PRICE = "CREDITMANMARKPRICE";
        // CREDITMAN_SLOW_MARK_PRICE (619)
        public const string GEN_TICK_CREDITMAN_SLOW_MARK_PRICE = "CREDITMANSLOWMARKPRICE";
        // OPTION_VOLUME (100)
        public const string GEN_TICK_CALL_OPTION_VOLUME = "CALLOPTIONVOLUME";
        public const string GEN_TICK_PUT_OPTION_VOLUME = "PUTOPTIONVOLUME";
        // OPTION_OPEN_INTEREST (101)
        public const string GEN_TICK_CALL_OPTION_OPEN_INTEREST = "CALLOPTIONOPENINTEREST";
        public const string GEN_TICK_PUT_OPTION_OPEN_INTEREST = "PUTOPTIONOPENINTEREST";
        // HIST_VOLAT (104)
        public const string GEN_TICK_OPTION_HISTORICAL_VOL = "OPTIONHISTORICALVOL";
        // REALTIME_HISTORICAL_VOLATILITY (411) - FUT only
        public const string GEN_TICK_RT_HISTORICAL_VOL = "RTHISTORICALVOL";
        // OPTION_IMPLIED_VOLATILITY (106)
        public const string GEN_TICK_OPTION_IMPLIED_VOL = "OPTIONIMPLIEDVOL";
        // INDEX_FUTURE_PREM (162) - IND only
        public const string GEN_TICK_INDEX_FUTURE_PREMIUM = "INDEXFUTUREPREMIUM";
        // SHORTABLE (236)
        public const string GEN_TICK_SHORTABLE = "SHORTABLE";
        // FUNDAMENTALS (258)
        public const string GEN_TICK_FUNDAMENTALS = "FUNDAMENTALS";
        // TRADE_COUNT (293)
        public const string GEN_TICK_TRADE_COUNT = "TRADECOUNT";
        // TRADE_RATE (294)
        public const string GEN_TICK_TRADE_RATE = "TRADERATE";
        // VOLUME_RATE (295)
        public const string GEN_TICK_VOLUME_RATE = "VOLUMERATE";
        // LAST_RTH_TRADE (318)
        public const string GEN_TICK_LAST_RTH_TRADE = "LASTRTHTRADE";
        // IB_DIVIDENDS (456)
        public const string GEN_TICK_IB_DIVIDENDS = "IBDIVIDENDS";
        // BOND_MULTIPLIER (460)
        public const string GEN_TICK_BOND_MULTIPLIER = "BONDMULTIPLIER";
        // MISCSTATS (165)
        public const string GEN_TICK_AVERAGE_VOLUME = "AVGVOLUME";
        public const string GEN_TICK_WEEK_13_HI = "WEEK13HI"; // 16
        public const string GEN_TICK_WEEK_13_LO = "WEEK13LO"; // 15
        public const string GEN_TICK_WEEK_26_HI = "WEEK26HI"; // 
        public const string GEN_TICK_WEEK_26_LO = "WEEK26LO";
        public const string GEN_TICK_WEEK_52_HI = "WEEK52HI";
        public const string GEN_TICK_WEEK_52_LO = "WEEK52LO";
        // SHORT_TERM_VOLUME (595)
        public const string GEN_TICK_SHORT_TERM_VOLUME_3_MIN = "SHORTTERMVOLUME3MIN";
        public const string GEN_TICK_SHORT_TERM_VOLUME_5_MIN = "SHORTTERMVOLUME5MIN";
        public const string GEN_TICK_SHORT_TERM_VOLUME_10_MIN = "SHORTTERMVOLUME10MIN";
        // DELAYED_TICKS
        public const string DELAYED_BID = "DELAYEDBID";
        public const string DELAYED_ASK = "DELAYEDASK";
        public const string DELAYED_LAST = "DELAYEDLAST";
        public const string DELAYED_BID_SIZE = "DELAYEDBIDSIZE";
        public const string DELAYED_ASK_SIZE = "DELAYEDASKSIZE";
        public const string DELAYED_LAST_SIZE = "DELAYEDLASTSIZE";
        public const string DELAYED_HIGH = "DELAYEDHIGH";
        public const string DELAYED_LOW = "DELAYEDLOW";
        public const string DELAYED_VOLUME = "DELAYEDVOLUME";
        public const string DELAYED_CLOSE = "DELAYEDCLOSE";
        public const string DELAYED_OPEN = "DELAYEDOPEN";


        // mktData request related
        public const string DEFAULT_SECTYPE = "STK";
        public const string DEFAULT_EXCHANGE = "SMART";
        public const string DEFAULT_CURRENCY = "USD";
        public const string DEFAULT_CASH_EXCHANGE = "IDEALPRO";
        public const string CASH_STR = "CASH";
        public const string CONID_STR = "conid=";
        public const string SYMBOL_STR = "sym=";
        public const string SECTYPE_STR = "sec=";
        public const string EXPIRATION_STR = "exp="; // lastTradeDateOrContractMonth
        public const string STRIKE_STR = "strike=";
        public const string RIGHT_STR = "right=";
        public const string MULTIPLIER_STR = "mult=";
        public const string EXCHANGE_STR = "exch=";
        public const string PRIMARYEXCH_STR = "prim=";
        public const string CURRENCY_STR = "cur=";
        public const string LOCALSYMBOL_STR = "loc=";
        public const string TRADINGCLASS_STR = "tc=";
        public const string COMBO_STR = "cmb=";
        public const string UNDERCOMP_STR = "und=";
        public const string OPTIONS_STR = "opt=";
        public const string GENTICKS_STR = "genticks=";
        public const string ACTION_BUY_1 = "BUY";
        public const string ACTION_BUY_2 = "B";
        public const string ACTION_SELL_1 = "SELL";
        public const string ACTION_SELL_2 = "S";
        public const string ACTION_SELL_SHORT_1 = "SSHORT";
        public const string ACTION_SELL_SHORT_2 = "SS";


        // vars
        private static string[] m_allowedTopics = new string[]{ 
            // market data ticks
            BIDSIZE, BID, ASK, ASKSIZE, LAST, LASTSIZE, HIGH,
            LOW, VOLUME, CLOSE, OPEN, LASTEXCH, BIDEXCH, ASKEXCH, 
            LASTTIME, HALTED,

            // generic ticks
            GEN_TICK_AUCTION_VOLUME, GEN_TICK_AUCTION_IMBALANCE, GEN_TICK_AUCTION_PRICE, GEN_TICK_REGULATORY_IMBALANCE, // AUCTION (225)
            GEN_TICK_PL_PRICE, // PL_PRICE (232)
            GEN_TICK_CREDITMAN_MARK_PRICE, // CREDITMAN_MARK_PRICE (221)
            GEN_TICK_CREDITMAN_SLOW_MARK_PRICE, // CREDITMAN_SLOW_MARK_PRICE (619)
            GEN_TICK_CALL_OPTION_VOLUME, GEN_TICK_PUT_OPTION_VOLUME, // OPTION_VOLUME (100)
            GEN_TICK_CALL_OPTION_OPEN_INTEREST, GEN_TICK_PUT_OPTION_OPEN_INTEREST, // OPTION_OPEN_INTEREST (101)
            GEN_TICK_OPTION_HISTORICAL_VOL, // HIST_VOLAT (104)
            GEN_TICK_RT_HISTORICAL_VOL, // REALTIME_HISTORICAL_VOLATILITY (411) - FUT only
            GEN_TICK_OPTION_IMPLIED_VOL, // OPTION_IMPLIED_VOLATILITY (106)
            GEN_TICK_INDEX_FUTURE_PREMIUM, // INDEX_FUTURE_PREM (162) - IND only
            GEN_TICK_SHORTABLE, // SHORTABLE (236)
            GEN_TICK_FUNDAMENTALS, // FUNDAMENTALS (258)
            GEN_TICK_TRADE_COUNT, // TRADE_COUNT (293)
            GEN_TICK_TRADE_RATE, // TRADE_RATE (294)
            GEN_TICK_VOLUME_RATE, // VOLUME_RATE (295)
            GEN_TICK_LAST_RTH_TRADE, // LAST_RTH_TRADE (318)
            GEN_TICK_IB_DIVIDENDS, // IB_DIVIDENDS (456)
            GEN_TICK_BOND_MULTIPLIER, // BOND_MULTIPLIER (460)
            GEN_TICK_AVERAGE_VOLUME, GEN_TICK_WEEK_13_HI, GEN_TICK_WEEK_13_LO, GEN_TICK_WEEK_26_HI, GEN_TICK_WEEK_26_LO, GEN_TICK_WEEK_52_HI, GEN_TICK_WEEK_52_LO, // MISCSTATS (165)
            GEN_TICK_SHORT_TERM_VOLUME_3_MIN, GEN_TICK_SHORT_TERM_VOLUME_5_MIN, GEN_TICK_SHORT_TERM_VOLUME_10_MIN, // SHORT_TERM_VOLUME (595)

            // delayed ticks
            DELAYED_BID, DELAYED_ASK, DELAYED_LAST, DELAYED_BID_SIZE, DELAYED_ASK_SIZE, DELAYED_LAST_SIZE, 
            DELAYED_HIGH, DELAYED_LOW, DELAYED_VOLUME, DELAYED_CLOSE, DELAYED_OPEN

        };

        private static Dictionary<int, string> m_tickToTopicMap = new Dictionary<int, string> { 
            { 0, BIDSIZE },
            { 1, BID },
            { 2, ASK },
            { 3, ASKSIZE },
            { 4, LAST },
            { 5, LASTSIZE },
            { 6, HIGH },
            { 7, LOW },
            { 8, VOLUME },
            { 9, CLOSE },
            { 14, OPEN },
            { 15, GEN_TICK_WEEK_13_LO },
            { 16, GEN_TICK_WEEK_13_HI },
            { 17, GEN_TICK_WEEK_26_LO },
            { 18, GEN_TICK_WEEK_26_HI },
            { 19, GEN_TICK_WEEK_52_LO },
            { 20, GEN_TICK_WEEK_52_HI },
            { 21, GEN_TICK_AVERAGE_VOLUME },
            { 23, GEN_TICK_OPTION_HISTORICAL_VOL },
            { 24, GEN_TICK_OPTION_IMPLIED_VOL },
            { 27, GEN_TICK_CALL_OPTION_OPEN_INTEREST },
            { 28, GEN_TICK_PUT_OPTION_OPEN_INTEREST },
            { 29, GEN_TICK_CALL_OPTION_VOLUME },
            { 30, GEN_TICK_PUT_OPTION_VOLUME },
            { 31, GEN_TICK_INDEX_FUTURE_PREMIUM },
            { 32, BIDEXCH },
            { 33, ASKEXCH },
            { 34, GEN_TICK_AUCTION_VOLUME },
            { 35, GEN_TICK_AUCTION_PRICE },
            { 36, GEN_TICK_AUCTION_IMBALANCE },
            { 37, GEN_TICK_PL_PRICE },
            { 45, LASTTIME },
            { 46, GEN_TICK_SHORTABLE },
            { 47, GEN_TICK_FUNDAMENTALS },
            { 49, HALTED },
            { 54, GEN_TICK_TRADE_COUNT },
            { 55, GEN_TICK_TRADE_RATE },
            { 56, GEN_TICK_VOLUME_RATE },
            { 57, GEN_TICK_LAST_RTH_TRADE },
            { 58, GEN_TICK_RT_HISTORICAL_VOL },
            { 59, GEN_TICK_IB_DIVIDENDS },
            { 60, GEN_TICK_BOND_MULTIPLIER },
            { 61, GEN_TICK_REGULATORY_IMBALANCE },
            { 63, GEN_TICK_SHORT_TERM_VOLUME_3_MIN },
            { 64, GEN_TICK_SHORT_TERM_VOLUME_5_MIN },
            { 65, GEN_TICK_SHORT_TERM_VOLUME_10_MIN },
            // delayed
            { 66, DELAYED_BID },
            { 67, DELAYED_ASK },
            { 68, DELAYED_LAST },
            { 69, DELAYED_BID_SIZE },
            { 70, DELAYED_ASK_SIZE },
            { 71, DELAYED_LAST_SIZE },
            { 72, DELAYED_HIGH },
            { 73, DELAYED_LOW },
            { 74, DELAYED_VOLUME },
            { 75, DELAYED_CLOSE },
            { 76, DELAYED_OPEN },
       
            { 78, GEN_TICK_CREDITMAN_MARK_PRICE },
            { 79, GEN_TICK_CREDITMAN_SLOW_MARK_PRICE },
            { 84, LASTEXCH }
        };


        // gets
        public static string[] AllowedTopics() { return m_allowedTopics; }


        public static string GetTopicStrByTickType(int tickType)
        {
            string res;
            return m_tickToTopicMap.TryGetValue(tickType, out res) ? res : null;
        }
    }
}
