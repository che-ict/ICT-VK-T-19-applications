using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego;

namespace TestStratego
{
    [TestClass]
    public class BordTest
    {
        private IBord Bord { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Bord = new Bord();
        }

        [TestMethod]
        public void TestVeldenVinden()
        {
            Assert.AreEqual(new Veld(3, 4), Bord.VindVeld(3,4));
        }

        [TestMethod]
        public void TestRanden()
        {
            Assert.IsNull(Bord.VindVeld(1, 4).Buurveld(Richting.West));
            Assert.IsNull(Bord.VindVeld(10, 8).Buurveld(Richting.Oost));
            Assert.IsNull(Bord.VindVeld(2, 1).Buurveld(Richting.Zuid));
            Assert.IsNull(Bord.VindVeld(10, 10).Buurveld(Richting.Noord));
        }

        [TestMethod]
        public void TestMeren()
        {
            Assert.IsFalse(Bord.VindVeld(2, 6).IsEenMeer);
            Assert.IsFalse(Bord.VindVeld(7, 5).Buurveld(Richting.West).IsEenMeer);
            Assert.IsTrue(Bord.VindVeld(3, 5).IsEenMeer);
            Assert.IsTrue(Bord.VindVeld(8, 6).Buurveld(Richting.Zuid).IsEenMeer);
        }

        [TestMethod]
        public void TestDoorlopend()
        {
            var veld = Bord.VindVeld(4, 1);
            while (veld.Buurveld(Richting.Noord) != null)
            {
                veld = veld.Buurveld(Richting.Noord);
            }
            while (veld.Buurveld(Richting.Oost) != null)
            {
                veld = veld.Buurveld(Richting.Oost);
            }
            Assert.AreEqual(10, veld.X);
            Assert.AreEqual(10, veld.Y);
        }
    }
}