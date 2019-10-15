using ExploringMars.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExploringMars.Tests
{
    [TestClass]
    public class ProbeTests
    {
        [TestMethod]
        public void ShouldProcessCorrectly_BasicScenario()
        {
            var plane = new Plane
            {
                Max = new Point(5, 5)
            };
            var probe = new Probe(plane, 1, 2, Domain.Enums.CardinalDirection.N);
            var result = probe.Process(new char[9] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' });
            Assert.IsTrue(result && probe.GetPosition() == "1 3 N");
        }

        [TestMethod]
        public void ShouldProcessCorrectly_BasicScenario2()
        {
            var plane = new Plane
            {
                Max = new Point(5, 5)
            };
            var probe = new Probe(plane, 3, 3, Domain.Enums.CardinalDirection.E);
            var result = probe.Process(new char[10] { 'M','M','R','M','M','R','M','R','R','M' });
            Assert.IsTrue(result && probe.GetPosition() == "5 1 E");
        }

        [TestMethod]
        public void ShouldThrowErrorWhenAchievingEndOfPlane()
        {
            var plane = new Plane
            {
                Max = new Point(5, 5)
            };
            var probe = new Probe(plane, 3, 3, Domain.Enums.CardinalDirection.E);
            try
            {
                var result = probe.Process(new char[10] { 'M', 'M', 'M', 'M', 'M', 'M', 'M', 'M', 'M', 'M' });
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(ex.Message, "Probe is out of plane boundary!");
            }          
        }
    }
}
