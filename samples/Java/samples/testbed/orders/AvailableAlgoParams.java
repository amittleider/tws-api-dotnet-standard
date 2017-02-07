package samples.testbed.orders;

import java.util.ArrayList;

import com.ib.client.Order;
import com.ib.client.TagValue;

public class AvailableAlgoParams {
	
	//! [arrivalpx_params]
	public static void FillArrivalPriceParams(Order baseOrder, double maxPctVol, String riskAversion, String startTime, 
			String endTime, boolean forceCompletion, boolean allowPastTime, double monetaryValue) {
		
		baseOrder.algoStrategy("ArrivalPx");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("maxPctVol", String.valueOf(maxPctVol)));
		baseOrder.algoParams().add(new TagValue("riskAversion", riskAversion));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("allowPastEndTime", allowPastTime ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
                
	}
	//! [arrivalpx_params]
	
	//! [darkice_params]
	public static void FillDarkIceParams(Order baseOrder, int displaySize, String startTime, String endTime, 
			boolean allowPastEndTime, double monetaryValue) {
		
		baseOrder.algoStrategy("DarkIce");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("displaySize", String.valueOf(displaySize)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
		
	}
	//! [darkice_params]
	
	//! [pctvol_params]
	public static void FillPctVolParams(Order baseOrder, double pctVol, String startTime, String endTime, boolean noTakeLiq, double monetaryValue) {
		
		baseOrder.algoStrategy("PctVol");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("pctVol", String.valueOf(pctVol)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
	}
	//! [pctvol_params]
	
	//! [twap_params]
	public static void FillTwapParams(Order baseOrder, String strategyType, String startTime, String endTime, 
			boolean allowPastEndTime, double monetaryValue) {
		
		baseOrder.algoStrategy("Twap");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("strategyType", strategyType));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
		
	}
	//! [twap_params]
	
	//! [vwap_params]
	public static void FillVwapParams(Order baseOrder, double maxPctVol, String startTime, String endTime, 
			boolean allowPastEndTime, boolean noTakeLiq, boolean speedUp, double monetaryValue) {
		
		baseOrder.algoStrategy("Vwap");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("maxPctVol", String.valueOf(maxPctVol)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("allowPastEndTime", allowPastEndTime ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("speedUp", speedUp ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
		
	}
	//! [vwap_params]
	
	//! [ad_params]
	public static void FillAccumulateDistributeParams(Order baseOrder, int componentSize, int timeBetweenOrders, boolean randomizeTime20, boolean randomizeSize55,
            int giveUp, boolean catchUp, boolean waitForFill, String startTime, String endTime) {
		
		baseOrder.algoStrategy("AD");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("componentSize", String.valueOf(componentSize)));
		baseOrder.algoParams().add(new TagValue("timeBetweenOrders", String.valueOf(timeBetweenOrders)));
		baseOrder.algoParams().add(new TagValue("randomizeTime20", randomizeTime20 ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("randomizeSize55", randomizeSize55 ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("giveUp", String.valueOf(giveUp)));
		baseOrder.algoParams().add(new TagValue("catchUp", catchUp ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("waitForFill", waitForFill ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		
	}
	//! [ad_params]
	
	//! [balanceimpactrisk_params]
	public static void FillBalanceImpactRiskParams(Order baseOrder, double maxPctVol, String riskAversion, boolean forceCompletion) {
		
		baseOrder.algoStrategy("BalanceImpactRisk");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("maxPctVol", String.valueOf(maxPctVol)));
		baseOrder.algoParams().add(new TagValue("riskAversion", riskAversion));
		baseOrder.algoParams().add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
		
	}
	//! [balanceimpactrisk_params]
	
	//! [minimpact_params]
	public static void FillMinImpactParams(Order baseOrder, double maxPctVol) {
		
		baseOrder.algoStrategy("BalanceImpactRisk");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("maxPctVol", String.valueOf(maxPctVol)));
		
	}
	//! [minimpact_params]
	
	//! [adaptive_params]
	public static void FillAdaptiveParams(Order baseOrder, String priority) {

		baseOrder.algoStrategy("Adaptive");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("adaptivePriority", priority));

	}
	//! [adaptive_params]	
        
	//! [closepx_params]
	public static void FillClosePriceParams(Order baseOrder, double maxPctVol, String riskAversion, String startTime, 
			boolean forceCompletion, double monetaryValue){
            
		baseOrder.algoStrategy("ClosePx");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("maxPctVol", String.valueOf(maxPctVol)));
		baseOrder.algoParams().add(new TagValue("riskAversion", riskAversion));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("forceCompletion", forceCompletion ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
	}
	//! [closepx_params]
        
	//! [pctvolpx_params]
	public static void FillPriceVariantPctVolParams(Order baseOrder, double pctVol, double deltaPctVol, double minPctVol4Px, 
			double maxPctVol4Px, String startTime, String endTime, boolean noTakeLiq, double monetaryValue){
            
		baseOrder.algoStrategy("PctVolPx");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("pctVol", String.valueOf(pctVol)));
		baseOrder.algoParams().add(new TagValue("deltaPctVol", String.valueOf(deltaPctVol)));
		baseOrder.algoParams().add(new TagValue("minPctVol4Px", String.valueOf(minPctVol4Px)));
		baseOrder.algoParams().add(new TagValue("maxPctVol4Px", String.valueOf(maxPctVol4Px)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
	}
	//! [pctvolpx_params]
        
	//! [pctvolsz_params]
	public static void FillSizeVariantPctVolParams(Order baseOrder, double startPctVol, double endPctVol, 
			String startTime, String endTime, boolean noTakeLiq, double monetaryValue){
            
		baseOrder.algoStrategy("PctVolSz");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("startPctVol", String.valueOf(startPctVol)));
		baseOrder.algoParams().add(new TagValue("endPctVol", String.valueOf(endPctVol)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
	}
	//! [pctvolsz_params]
        
	//! [pctvoltm_params]
	public static void FillTimeVariantPctVolParams(Order baseOrder, double startPctVol, double endPctVol, 
			String startTime, String endTime, boolean noTakeLiq, double monetaryValue){
            
		baseOrder.algoStrategy("PctVolTm");
		baseOrder.algoParams(new ArrayList<>());
		baseOrder.algoParams().add(new TagValue("startPctVol", String.valueOf(startPctVol)));
		baseOrder.algoParams().add(new TagValue("endPctVol", String.valueOf(endPctVol)));
		baseOrder.algoParams().add(new TagValue("startTime", startTime));
		baseOrder.algoParams().add(new TagValue("endTime", endTime));
		baseOrder.algoParams().add(new TagValue("noTakeLiq", noTakeLiq ? "1" : "0"));
		baseOrder.algoParams().add(new TagValue("monetaryValue", String.valueOf(monetaryValue)));
	}
	//! [pctvoltm_params]
}
