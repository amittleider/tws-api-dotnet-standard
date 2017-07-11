using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBApi;
using TWSLib;
using System.Linq;
using System.Runtime.InteropServices;

namespace OrderConditionsParsingTestProject
{
    [TestClass]
    public class ControlEventsTest
    {
        [TestMethod]
        public void TestEWrapperToEventsConsistency()
        {
            var eWrapperMethods = typeof(EWrapper).GetMethods();
            var iTwsEventsMethods = typeof(ITwsEvents).GetMethods();
            var missingMethods = eWrapperMethods.Except(iTwsEventsMethods, new MethodComparer());

            Assert.AreEqual(missingMethods.Count(), 0, "Not all EWrapper methods are mapped to ITwsEvents");
        }

        [TestMethod]
        public void TestITwsEventsDispIdConsistency()
        {
            var type = typeof(ITwsEvents);
            var nUnique = type.GetMethods().Select(m => ((DispIdAttribute.GetCustomAttribute(m, typeof(DispIdAttribute)) as DispIdAttribute) ?? new DispIdAttribute(-1)).Value).Distinct().Count();

            Assert.AreEqual(type.GetMethods().Count(), nUnique, "Check ITwsEvents interface methods [DispId] attribute");
        }
    }
}
