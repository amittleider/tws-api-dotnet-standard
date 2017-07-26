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
            bool forceCompletion, bool allowPastTime, double monetaryValue)
        {            
            baseOrder.AlgoStrategy = "ArrivalPx";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("riskAversion", riskAversion));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastTime ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [arrivalpx_params]

        //! [darkice_params]
        public static void FillDarkIceParams(Order baseOrder, int displaySize, string startTime, string endTime, 
            bool allowPastEndTime, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "DarkIce";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("displaySize", displaySize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [darkice_params]

        //! [pctvol_params]
        public static void FillPctVolParams(Order baseOrder, double pctVol, string startTime, string endTime, bool noTakeLiq, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "PctVol";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("pctVol", pctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [pctvol_params]

        //! [twap_params]
        public static void FillTwapParams(Order baseOrder, string strategyType, string startTime, string endTime, bool allowPastEndTime, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "Twap";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("strategyType", strategyType));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [twap_params]

        //! [vwap_params]
        public static void FillVwapParams(Order baseOrder, double maxPctVol, string startTime, string endTime, 
            bool allowPastEndTime, bool noTakeLiq, bool speedUp, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "Vwap";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("speedUp", speedUp ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [vwap_params]

        //! [ad_params]
        public static void FillAccumulateDistributeParams(Order baseOrder, int componentSize, int timeBetweenOrders, bool randomizeTime20, bool randomizeSize55,
            int giveUp, bool catchUp, bool waitForFill, string startTime, string endTime)
        {
            baseOrder.AlgoStrategy = "AD";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("componentSize", componentSize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("timeBetweenOrders", timeBetweenOrders.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("randomizeTime20", randomizeTime20 ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("randomizeSize55", randomizeSize55 ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("giveUp", giveUp.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("catchUp", catchUp ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("waitForFill", waitForFill ? "1" : "0"));
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

        //! [closepx_params]
        public static void FillClosePriceParams(Order baseOrder, double maxPctVol, string riskAversion, string startTime, 
            bool forceCompletion, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "ClosePx";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol", maxPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("riskAversion", riskAversion));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [closepx_params]

        //! [pctvolpx_params]
        public static void FillPriceVariantPctVolParams(Order baseOrder, double pctVol, double deltaPctVol, double minPctVol4Px, 
            double maxPctVol4Px, String startTime, String endTime, bool noTakeLiq, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "PctVolPx";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("pctVol", pctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("deltaPctVol", deltaPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("minPctVol4Px", minPctVol4Px.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("maxPctVol4Px", maxPctVol4Px.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [pctvolpx_params]

        //! [pctvolsz_params]
        public static void FillSizeVariantPctVolParams(Order baseOrder, double startPctVol, double endPctVol, 
            String startTime, String endTime, bool noTakeLiq, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "PctVolSz";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("startPctVol", startPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("endPctVol", endPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [pctvolsz_params]

        //! [pctvoltm_params]
        public static void FillTimeVariantPctVolParams(Order baseOrder, double startPctVol, double endPctVol,
            String startTime, String endTime, bool noTakeLiq, double monetaryValue)
        {
            baseOrder.AlgoStrategy = "PctVolTm";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("startPctVol", startPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("endPctVol", endPctVol.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("monetaryValue", monetaryValue.ToString()));
        }
        //! [pctvoltm_params]
        
        //! [jefferies_vwap_params]
        public static void FillJefferiesVWAPParams(Order baseOrder, string startTime, string endTime, double relativeLimit,
        double maxVolumeRate, string excludeAuctions, double triggerPrice, double wowPrice, int minFillSize, double wowOrderPct,
            string wowMode, bool isBuyBack, string wowReference)
        {
            baseOrder.AlgoStrategy = "VWAP";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("relativeLimit", relativeLimit.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("maxVolumeRate", maxVolumeRate.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("excludeAuctions", excludeAuctions));
            baseOrder.AlgoParams.Add(new TagValue("triggerPrice", triggerPrice.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("wowPrice", wowPrice.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("minFillSize", minFillSize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("wowOrderPct", wowOrderPct.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("wowMode", wowMode));
            baseOrder.AlgoParams.Add(new TagValue("IsBuyBack", isBuyBack ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("wowReference", wowReference));
        }
        //! [jefferies_vwap_params]

        //! [csfb_inline_params]
        public static void FillCSFBInlineParams(Order baseOrder, string startTime, string endTime, string execStyle, int minPercent,
        int maxPercent, int displaySize, string auction, bool blockFinder, double blockPrice, int minBlockSize, int maxBlockSize, double iWouldPrice)
        {

            // must be direct-routed to "CSFBALGO"

            baseOrder.AlgoStrategy = "INLINE";
            baseOrder.AlgoParams = new List<TagValue>();
            baseOrder.AlgoParams.Add(new TagValue("startTime", startTime));
            baseOrder.AlgoParams.Add(new TagValue("endTime", endTime));
            baseOrder.AlgoParams.Add(new TagValue("execStyle", execStyle));
            baseOrder.AlgoParams.Add(new TagValue("minPercent", minPercent.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("maxPercent", maxPercent.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("displaySize", displaySize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("auction", auction));
            baseOrder.AlgoParams.Add(new TagValue("blockFinder", blockFinder ? "1" : "0"));
            baseOrder.AlgoParams.Add(new TagValue("blockPrice", blockPrice.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("minBlockSize", minBlockSize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("maxBlockSize", maxBlockSize.ToString()));
            baseOrder.AlgoParams.Add(new TagValue("iWouldPrice", iWouldPrice.ToString()));
        }
        //! [csfb_inline_params] 
    }
}
