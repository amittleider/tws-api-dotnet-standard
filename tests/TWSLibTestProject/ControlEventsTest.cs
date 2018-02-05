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

            Assert.AreEqual(0, missingMethods.Count(), "Not all EWrapper methods are mapped to ITwsEvents: " + string.Join(", ", missingMethods.Select(m => m.Name).ToArray()));
        }

        [TestMethod]
        public void TestITwsEventsDispIdConsistency()
        {
            var type = typeof(ITwsEvents);
            var nUnique = type.GetMethods().Select(m => ((DispIdAttribute.GetCustomAttribute(m, typeof(DispIdAttribute)) as DispIdAttribute) ?? new DispIdAttribute(-1)).Value).Distinct().Count();

            Assert.AreEqual(type.GetMethods().Count(), nUnique, "Check ITwsEvents interface methods [DispId] attribute");
        }

        [TestMethod]
        public void TestITwsToDelegatesConsistency()
        {
            var methods = typeof(ITwsEvents).GetMethods();
            var missingDelegates = methods.Where(m =>
                AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "TWSLib").GetType("TWSLib.Tws+" + m.Name + "Delegate", false, true) == null);

            Assert.AreEqual(0, missingDelegates.Count(), "Following ITWSEvents methods does not have corresponding delegates: " + string.Join(", ", missingDelegates.Select(md => md.Name).ToArray()));

            var delegates = methods.ToDictionary(m => AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "TWSLib").GetType("TWSLib.Tws+" + m.Name + "Delegate", false, true));
            var notMatchedDelegates = delegates.Where(d => !d.Key.GetMethod("Invoke").GetParameters().Select(p => p.ParameterType).SequenceEqual(d.Value.GetParameters().Select(p => p.ParameterType)));

            Assert.AreEqual(0, notMatchedDelegates.Count(), "Following  ITWSEvents methods does not match signature with their delegates: " + string.Join(", ", notMatchedDelegates.Select(d => d.Value.Name).ToArray()));
        }
    }
}
