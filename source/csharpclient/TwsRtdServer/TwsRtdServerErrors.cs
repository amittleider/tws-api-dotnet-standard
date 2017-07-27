using System.Collections.Generic;

namespace TwsRtdServer
{
    class TwsRtdServerErrors
    {

        // server errors
        public const int NO_ERROR = -1;
        public const int CANNOT_CONNECT_TO_TWS = 0;
        public const int REQUEST_MKT_DATA_ERROR = 1;
        public const int CANNOT_EXTRACT_CONNECTION_PARAMS = 2;
        public const int CANNOT_EXTRACT_CONTRACT = 3;
        public const int CANNOT_EXTRACT_OPTIONS = 4;
        public const int CANNOT_EXTRACT_GENERIC_TICKS = 5;
        public const int SOCKET_IS_NULL = 6;
        public const int CANNOT_EXTRACT_COMBO_LEGS = 7;
        public const int CANNOT_EXTRACT_UNDER_COMP = 8;

        // tws errors
        public const int ALREADY_CONNECTED = 501;
        public const int COULD_NOT_CONNECT = 502;
        public const int NOT_CONNECTED = 504;
        public const int CONNECTIVITY_BETWEEN_IB_AND_TWS_LOST = 1100;

        public const int SECURITY_DEFINITION = 200;
        public const int INVALID_COMBO_LEG = 313;
        public const int VALIDATE_REQ_ERROR = 321;
        public const int PROCESS_REQ_ERROR = 322;
        public const int MARKET_DATA_NOT_SUBSCRIBED = 354; // Not used since reqMarketDataType(4) is always called
        public const int DELTA_NEUTRAL_COMBO_ONLY = 429;
        public const int API_DATA_REQUIRES_SUBSCRIPTION = 10089; // Not used since reqMarketDataType(4) is always called
        public const int LEG_NOT_SUPPORTED = 10154;
        public const int REQUESTED_MARKET_DATA_NOT_SUBSCRIBED = 10167;

        // errors
        private static Dictionary<int, string> m_serverErrors = new Dictionary<int, string> { 
            { NO_ERROR, "No error." },
            { CANNOT_CONNECT_TO_TWS, "Cannot connect to TWS." },
            { REQUEST_MKT_DATA_ERROR, "Cannot request market data." },
            { CANNOT_EXTRACT_CONNECTION_PARAMS, "Cannot extract connection params." },
            { CANNOT_EXTRACT_CONTRACT, "Cannot extract contract." },
            { CANNOT_EXTRACT_OPTIONS, "Cannot extract options." },
            { CANNOT_EXTRACT_GENERIC_TICKS, "Cannot extract generic ticks." },
            { SOCKET_IS_NULL, "Socket is null." },
            { CANNOT_EXTRACT_COMBO_LEGS, "Cannot extract combo legs." },
            { CANNOT_EXTRACT_UNDER_COMP, "Cannot extract under comp." }
        };

        private static int[] m_twsServerErrors = new int[] {
            ALREADY_CONNECTED, COULD_NOT_CONNECT, NOT_CONNECTED, CONNECTIVITY_BETWEEN_IB_AND_TWS_LOST
        };

        private static int[] m_twsTickerErrors = new int[] {
            SECURITY_DEFINITION, INVALID_COMBO_LEG, VALIDATE_REQ_ERROR, PROCESS_REQ_ERROR, 
            DELTA_NEUTRAL_COMBO_ONLY, LEG_NOT_SUPPORTED, REQUESTED_MARKET_DATA_NOT_SUBSCRIBED
        };

        public static int[] TwsServerErrors() { return m_twsServerErrors; }

        public static int[] TwsTickerErrors() { return m_twsTickerErrors; }

        public static string GetErrorText(int code)
        {
            string errorText;
            return m_serverErrors.TryGetValue(code, out errorText) ? errorText : null;
        }
    }
}
