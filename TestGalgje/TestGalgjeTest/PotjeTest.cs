using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestGalgje;

namespace GalgjeTest
{
    [TestClass]
    public class PotjeTest
    {
        [TestMethod]
        public void TestLastigWoord()
        {
            var galgje = new Potje("lastiglangWoord", 10);
            galgje.AddLetter('a');
            galgje.AddLetter('e');
            galgje.AddLetter('l');
            Assert.AreEqual("la****la*******", galgje.ShowWoord());
        }

        [TestMethod]
        public void TestLegeString()
        {
            var galgje = new Potje("", 10);
            galgje.AddLetter('a');
            galgje.AddLetter('e');
            galgje.AddLetter('l');
            Assert.AreEqual("", galgje.ShowWoord());
        }

        [TestMethod]
        public void TestGeenLetters()
        {
            var galgje = new Potje("lastiglangWoord", 10);
            Assert.AreEqual("***************", galgje.ShowWoord());
        }

        [TestMethod]
        public void TestDubbeleLetters()
        {
            var galgje= new Potje("x", 10);
            Assert.IsTrue(galgje.AddLetter('a'));
            Assert.IsFalse(galgje.AddLetter('a'));
        }

        [TestMethod]
        public void TestFouteInvoer()
        {
            var galgje = new Potje("", 10);
            Assert.IsFalse(galgje.AddLetter('3'));
            Assert.IsFalse(galgje.AddLetter('@'));
            Assert.IsFalse(galgje.AddLetter(null));
        }

        [TestMethod]
        public void TestGewonnen()
        {
            var galgje = new Potje("bal", 10);
            galgje.AddLetter('b');
            galgje.AddLetter('a');
            galgje.AddLetter('l');
            Assert.AreEqual(Status.Gewonnen, galgje.CurrentStatus());
        }

        [TestMethod]
        public void TestVerloren()
        {
            var galgje = new Potje("stoot", 2);
            galgje.AddLetter('b');
            galgje.AddLetter('a');
            galgje.AddLetter('l');
            Assert.AreEqual(Status.Verloren, galgje.CurrentStatus());
        }
    }
}
