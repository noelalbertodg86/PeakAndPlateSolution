using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeakAndPlatePredictor.Business;
using System;

namespace PeakAndPlateTestUnit
{
    /// <summary>
    /// Test class to certify functionalities of PeakAndPlate Solution
    /// </summary>
    /// <returns></returns>
    [TestClass]
    public class PeakAndPlateTest
    {
        [TestMethod]
        public void IsAllowToRoad()
        {
            LastNumberRule lastNumberRule = new LastNumberRule();
            DateTime targetDate = new DateTime(2019, 06, 27);
            TimeSpan targetTime = new TimeSpan(9, 30, 0);
            Assert.IsTrue(lastNumberRule.IsAllow("PDG3892", targetDate, targetTime));
        }
    }
}
