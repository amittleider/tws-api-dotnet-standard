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
            ExecutionCondition cond = ParseCondition<ExecutionCondition>("trade occurs for ANY symbol on ANY exchange for * security type");
            var examp = OrderCondition.Create(OrderConditionType.Execution) as ExecutionCondition;

            examp.Exchange = "ANY";
            examp.Symbol = "ANY";
            examp.SecType = "*";

            Assert.IsNotNull(cond);
            Assert.AreEqual(cond.Exchange, "any", true);
            Assert.IsFalse(cond.IsConjunctionConnection);
            Assert.AreEqual(cond.SecType, "*");
            Assert.AreEqual(cond.Symbol, "any", true);
            Assert.AreEqual(cond, examp);
        }

        T ParseCondition<T>(string strCond) where T : OrderCondition
        {
            var cond = OrderCondition.Parse(strCond) as T;

            Assert.IsNotNull(cond);
            Assert.AreEqual(strCond, cond.ToString());

            return cond;
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
            var conditions = (new Tws().ParseConditions("default Price of 8314(SMART) is <= 0 and the margin cushion percent is <= 5 or trade occurs for ANY symbol on ANY exchange for * security type and time is <= 20151030 21:56:26 GMT+03:00 or Volume of 265598(SMART) is <= 8 and PercentCange of 43645865(ISLAND) is <= 0") as ArrayList).OfType<OrderCondition>();

            var conds = new[] { 
                OperatorCondition.Parse("default Price of 8314(SMART) is <= 0 and"), 
                OperatorCondition.Parse("the margin cushion percent is <= 5 or"),
                OperatorCondition.Parse("trade occurs for ANY symbol on ANY exchange for * security type and"),
                OperatorCondition.Parse("time is <= 20151030 21:56:26 GMT+03:00 or"),
                OperatorCondition.Parse("Volume of 265598(SMART) is <= 8 and"),
                OperatorCondition.Parse("PercentCange of 43645865(ISLAND) is <= 0")
            };

            Assert.IsTrue(conds.SequenceEqual(conditions));
        }
    }
}
