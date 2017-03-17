using System.Collections.Generic;

namespace TwsRtdServer
{
    class TwsRtdServerErrors
    {

        // error codes
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

        // errors
        private static Dictionary<int, string> m_errors = new Dictionary<int, string> { 
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


        public static string GetErrorText(int code)
        {
            string errorText;
            return m_errors.TryGetValue(code, out errorText) ? errorText : null;
        }
    }
}
