using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBApi;
using TWSLib;
using System.Linq;
using System.Collections;

namespace OrderConditionsParsingTestProject
{
    [TestClass]
    public class OrderConditionsParsingTest
    {
        [TestMethod]
        public void ParseExecutionCondition()
        {
            ParseCondition<ExecutionCondition>("trade occurs for ANY symbol on ANY exchange for * security type");         
        }

        void ParseCondition<T>(string strCond) where T : OrderCondition
        {
            var cond = OrderCondition.Parse(strCond) as T;

            Assert.IsNotNull(cond);
            Assert.AreEqual(strCond, cond.ToString());
        }

        [TestMethod]
        public void ParseMarginCondition()
        {
            ParseCondition<MarginCondition>("the margin cushion percent is <= 5"); 
        }

        [TestMethod]
        public void ParseTimeCondition()
        {
            ParseCondition<TimeCondition>("time is <= 20151030 21:56:26 GMT+03:00");
        }

        [TestMethod]
        public void ParsePercentChangeCondition()
        {
            ParseCondition<PercentChangeCondition>("PercentCange of 43645865(ISLAND) is <= 0");
        }

        [TestMethod]
        public void ParseVolumeCondition()
        {
            ParseCondition<VolumeCondition>("Volume of 265598(SMART) is <= 8");
        }

        [TestMethod]
        public void ParsePriceCondition()
        {
            ParseCondition<PriceCondition>("last of bid/ask Price of 8314(SMART) is <= 0");
        }

        [TestMethod]
        public void ParseConditionList()
        {
            var conditions = (new Tws().ParseConditions("default Price of 8314(SMART) is <= 0 or the margin cushion percent is <= 5 or trade occurs for ANY symbol on ANY exchange for * security type or time is <= 20151030 21:56:26 GMT+03:00 or Volume of 265598(SMART) is <= 8 or PercentCange of 43645865(ISLAND) is <= 0") as ArrayList).OfType<OrderCondition>();

            var conds = new[] { 
                OperatorCondition.Parse("default Price of 8314(SMART) is <= 0 or"), 
                OperatorCondition.Parse("the margin cushion percent is <= 5 or"),
                OperatorCondition.Parse("trade occurs for ANY symbol on ANY exchange for * security type or"),
                OperatorCondition.Parse("time is <= 20151030 21:56:26 GMT+03:00 or"),
                OperatorCondition.Parse("Volume of 265598(SMART) is <= 8 or"),
                OperatorCondition.Parse("PercentCange of 43645865(ISLAND) is <= 0")
            };

            Assert.IsTrue(conds.Select(c => c.ToString()).SequenceEqual(conditions.Select(c => c.ToString())));
        }
    }
}
