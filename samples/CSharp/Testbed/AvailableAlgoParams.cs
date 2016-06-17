using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public class AvailableAlgoParams
    {
        //! [arrivalpx_params]
        public static void FillArrivalPriceParams(Order baseOrder, double maxPctVol, string riskAversion, string startTime, string endTime, 
            bool forceCompletion, bool allowPastTime)
        {            
            baseOrder.AlgoStrategy = "ArrivalPx";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("riskAversion", riskAversion));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastTime ? "1" : "0"));
        }
        //! [arrivalpx_params]

        //! [darkice_params]
        public static void FillDarkIceParams(Order baseOrder, int displaySize, string startTime, string endTime, bool allowPastEndTime)
        {
            baseOrder.AlgoStrategy = "DarkIce";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("displaySize", displaySize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
        }
        //! [darkice_params]

        //! [pctvol_params]
        public static void FillPctVolParams(Order baseOrder, double pctVol, string startTime, string endTime, bool noTakeLiq)
        {
            baseOrder.AlgoStrategy = "PctVol";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("pctVol", pctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
        }
        //! [pctvol_params]

        //! [twap_params]
        public static void FillTwapParams(Order baseOrder, string strategyType, string startTime, string endTime, bool allowPastEndTime)
        {
            baseOrder.AlgoStrategy = "Twap";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("strategyType", strategyType));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
        }
        //! [twap_params]

        //! [vwap_params]
        public static void FillVwapParams(Order baseOrder, double maxPctVol, string startTime, string endTime, bool allowPastEndTime, bool noTakeLiq)
        {
            baseOrder.AlgoStrategy = "Vwap";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
        }
        //! [vwap_params]

        //! [ad_params]
        public static void FillAccumulateDistributeParams(Order baseOrder, int componentSize, int timeBetweenOrders, bool randomizeTime20, bool randomizeSize55,
            int giveUp, bool catchUp, bool waitOrFill, string startTime, string endTime)
        {
            baseOrder.AlgoStrategy = "AD";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("componentSize", componentSize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("timeBetweenOrders", timeBetweenOrders.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("randomizeTime20", randomizeTime20 ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("randomizeSize55", randomizeSize55 ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("giveUp", giveUp.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("catchUp", catchUp ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("waitOrFill", waitOrFill ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
        }
        //! [ad_params]

        //! [balanceimpactrisk_params]
        public static void FillBalanceImpactRiskParams(Order baseOrder, double maxPctVol, string riskAversion, bool forceCompletion)
        {
            baseOrder.AlgoStrategy = "BalanceImpactRisk";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("riskAversion", riskAversion));
            baseOrder.AlgoParams.Add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
        }
        //! [balanceimpactrisk_params]

        //! [minimpact_params]
        public static void FillMinImpactParams(Order baseOrder, double maxPctVol)
        {
            baseOrder.AlgoStrategy = "MinImpact";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
        }
        //! [minimpact_params]

        //! [adaptive_params]
        public static void FillAdaptiveParams(Order baseOrder, string priority)
        {
            baseOrder.AlgoStrategy = "Adaptive";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("adaptivePriority", priority));
        }
        //! [adaptive_params]
    }
}
