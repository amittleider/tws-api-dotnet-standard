/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class MinServerVer
    {
        
        public const int MIN_VERSION = 38;

        //shouldn't these all be deprecated?
        public const int HISTORICAL_DATA = 24;
        public const int CURRENT_TIME = 33;
        public const int REAL_TIME_BARS = 34;
        public const int SCALE_ORDERS = 35;
        public const int SNAPSHOT_MKT_DATA = 35;
        public const int SSHORT_COMBO_LEGS = 35;
        public const int WHAT_IF_ORDERS = 36;
        public const int CONTRACT_CONID = 37;

        public const int PTA_ORDERS = 39;
        public const int FUNDAMENTAL_DATA = 40;
        public const int UNDER_COMP = 40;
        public const int CONTRACT_DATA_CHAIN = 40;
        public const int SCALE_ORDERS2 = 40;
        public const int ALGO_ORDERS = 41;
        public const int EXECUTION_DATA_CHAIN = 42;
        public const int NOT_HELD = 44;
        public const int SEC_ID_TYPE = 45;
        public const int PLACE_ORDER_CONID = 46;
        public const int REQ_MKT_DATA_CONID = 47;
        public const int REQ_CALC_IMPLIED_VOLAT = 49;
        public const int REQ_CALC_OPTION_PRICE = 50;
        public const int CANCEL_CALC_IMPLIED_VOLAT = 50;
        public const int CANCEL_CALC_OPTION_PRICE = 50;
        public const int SSHORTX_OLD = 51;
        public const int SSHORTX = 52;
        public const int REQ_GLOBAL_CANCEL = 53;
        public const int HEDGE_ORDERS = 54;
        public const int REQ_MARKET_DATA_TYPE = 55;
        public const int OPT_OUT_SMART_ROUTING = 56;
        public const int SMART_COMBO_ROUTING_PARAMS = 57;
        public const int DELTA_NEUTRAL_CONID = 58;
        public const int SCALE_ORDERS3 = 60;
        public const int ORDER_COMBO_LEGS_PRICE = 61;
        public const int TRAILING_PERCENT = 62;
        public const int DELTA_NEUTRAL_OPEN_CLOSE = 66;
        public const int ACCT_SUMMARY = 67;
        public const int TRADING_CLASS = 68;
        public const int SCALE_TABLE = 69;
        public const int LINKING = 70;
        public const int ALGO_ID = 71;
        public const int OPTIONAL_CAPABILITIES = 72;
        public const int ORDER_SOLICITED = 73;
        public const int LINKING_AUTH = 74;
        public const int PRIMARYEXCH = 75;
        public const int RANDOMIZE_SIZE_AND_PRICE = 76;
        public const int FRACTIONAL_POSITIONS = 101;
        public const int PEGGED_TO_BENCHMARK = 102;
        public const int MODELS_SUPPORT = 103;
        public const int SEC_DEF_OPT_PARAMS_REQ = 104;
        public const int EXT_OPERATOR = 105;
        public const int SOFT_DOLLAR_TIER = 106;
        public const int REQ_FAMILY_CODES = 107;
        public const int REQ_MATCHING_SYMBOLS = 108;
        public const int PAST_LIMIT = 109;
        public const int MD_SIZE_MULTIPLIER = 110;
        public const int CASH_QTY = 111;
        public const int REQ_MKT_DEPTH_EXCHANGES = 112;
        public const int TICK_NEWS = 113;
        public const int SMART_COMPONENTS = 114;
        public const int REQ_NEWS_PROVIDERS = 115;
        public const int REQ_NEWS_ARTICLE = 116;
        public const int REQ_HISTORICAL_NEWS = 117;
        public const int REQ_HEAD_TIMESTAMP = 118;
        public const int REQ_HISTOGRAM_DATA = 119;
        public const int SERVICE_DATA_TYPE = 120;
        public const int AGG_GROUP = 121;
    }
}
