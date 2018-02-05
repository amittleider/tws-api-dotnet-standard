using IBApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TWSLib;

namespace OrderConditionsParsingTestProject
{
    class MethodComparer : IEqualityComparer<MethodInfo>
    {
        public bool Equals(MethodInfo x, MethodInfo y)
        {
            return IsException(y)
                || x + "" == MapSignature(y + "") 
                || x.Name == MapName(y.Name) 
                && x.ReturnParameter.ParameterType == y.ReturnParameter.ParameterType 
                && !x.GetParameters().Select(p => MapType(p.ParameterType)).SequenceEqual(y.GetParameters().Select(p => p.ParameterType));
        }

        private bool IsException(MethodInfo y)
        {
            return exceptionMethodNames.Contains(y.Name);
        }

        static string[] exceptionMethodNames = { "error", "historicalDataUpdate" };

        private static string MapName(string p)
        {
            string res;

            if (!eventsInterfaceMethodNameMap.TryGetValue(p, out res))
                return p;

            return res;
        }

        static Dictionary<string, string> signatureMap = new Dictionary<string, string>()
        {
            { "Void historicalData(Int32, IBApi.Bar)", 
              "Void historicalData(Int32, System.String, Double, Double, Double, Double, Int32, Int32, Double, Int32)" },
            { "Void historicalDataUpdate(Int32, IBApi.Bar)", 
              "Void historicalData(Int32, System.String, Double, Double, Double, Double, Int32, Int32, Double, Int32)" },
            { "Void updateNewsBulletin(Int32, Int32, System.String, System.String)", 
              "Void updateNewsBulletin(Int16, Int16, System.String, System.String)" },
            { "Void tickByTickAllLast(Int32, Int32, Int64, Double, Int32, IBApi.TickAttrib, System.String, System.String)",
              "Void tickByTickAllLast(Int32, Int32, System.String, Double, Int32, TWSLib.ITickAttrib, System.String, System.String)" },
            { "Void tickByTickBidAsk(Int32, Int64, Double, Double, Int32, Int32, IBApi.TickAttrib)",
              "Void tickByTickBidAsk(Int32, System.String, Double, Double, Int32, Int32, TWSLib.ITickAttrib)" },
            { "Void tickByTickMidPoint(Int32, Int64, Double)",
              "Void tickByTickMidPoint(Int32, System.String, Double)"}
        };

        private static string MapSignature(string signature)
        {
            string res;

            if (!signatureMap.TryGetValue(signature, out res))
                return signature;

            return res;
        }

        static Dictionary<Type, Type> eventsInterfaceArgumentTypesMap = new Dictionary<Type, Type>()
        {
           { typeof(NewsProvider[]), typeof(INewsProviderList) },
           { typeof(HistogramEntry[]), typeof(ComHistogramEntry[]) },
           { typeof(PriceIncrement[]), typeof(IPriceIncrementList) },
           { typeof(TickAttrib), typeof(bool) },
           { typeof(UnderComp), typeof(IUnderComp) },
           { typeof(ContractDetails), typeof(IContractDetails) },
           { typeof(Contract), typeof(IContract) },
           { typeof(Order), typeof(IOrder) },
           { typeof(OrderState), typeof(IOrderState) },
           { typeof(Execution), typeof(IExecution) },
           { typeof(CommissionReport), typeof(ICommissionReport) },
           { typeof(HashSet<string>), typeof(string[]) },
           { typeof(HashSet<double>), typeof(double[]) },
           { typeof(Dictionary<int, KeyValuePair<string, char>>), typeof(ArrayList[]) },
           { typeof(FamilyCode[]), typeof(IFamilyCodeList) },
           { typeof(ContractDescription[]), typeof(IContractDescriptionList) },
           { typeof(DepthMktDataDescription[]), typeof(IDepthMktDataDescriptionList) },
           { typeof(long), typeof(int) }
        };

        static Dictionary<string, string> eventsInterfaceMethodNameMap = new Dictionary<string, string>()
        {
            { "openOrder", "openOrderEx" },
            { "bondContractDetails", "bondContractDetailsEx" },
            { "contractDetails", "contractDetailsEx" },
            { "execDetails", "execDetailsEx" },
            { "scannerData", "scannerDataEx" }
        };

        private static Type MapType(Type type)
        {
            Type res;

            if (!eventsInterfaceArgumentTypesMap.TryGetValue(type, out res))
                return type;

            return res;
        }

        public int GetHashCode(MethodInfo obj)
        {
            return 0;
        }
    }
}
