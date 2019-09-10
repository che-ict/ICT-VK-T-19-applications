using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego;

namespace TestStratego
{
    [TestClass]
    public class EchteStrategoServiceTest
    {
        private StrategoService service;

        [TestInitialize]
        public void Setup()
        {
            service = new StrategoService();
        }

        [TestMethod]
        public void SimpeleVerplaatsTest()
        {
            var bord = service.Bord;
            var stuk = bord.ZetStukOpBord(Rang.Maarschalk, Kleur.Rood, 1, 1);

            var result = service.Verplaats(1, 1, Richting.West);
            var zelfdeStuk = bord.VindVeld(1, 1).Stuk;
            // mag niet over rand
            Assert.IsFalse(result);
            Assert.AreEqual(stuk.Naam, zelfdeStuk.Naam);

            result = service.Verplaats(1, 1, Richting.Oost);
            zelfdeStuk = bord.VindVeld(2, 1).Stuk;
            var geenStuk = bord.VindVeld(1, 1).Stuk;
            // mag wel naar rechts
            Assert.IsTrue(result);
            Assert.AreEqual(stuk.Naam, zelfdeStuk.Naam);
            // oorspronkelijke positie is leeg
            Assert.IsNull(geenStuk);
            
            var stuk2 = bord.ZetStukOpBord(Rang.Generaal, Kleur.Rood, 1, 1);
            // botsing met eigen Maarschalk, dus geen verplaatsing
            result = service.Verplaats(1, 1, Richting.Oost);
            zelfdeStuk = bord.VindVeld(1, 1).Stuk;
            Assert.IsFalse(result);
            Assert.AreEqual(stuk2.Naam, zelfdeStuk.Naam);
        }

        [TestMethod]
        public void MeervoudigeVerplaatsTest()
        {
            var bord = service.Bord;
            var stuk = bord.ZetStukOpBord(Rang.Maarschalk, Kleur.Rood, 1, 1);

            // mag niet door meer
            service.Verplaats(1, 1, Richting.Oost);
            service.Verplaats(2, 1, Richting.Noord);
            service.Verplaats(2, 2, Richting.Noord);
            service.Verplaats(2, 3, Richting.Noord);
            service.Verplaats(2, 4, Richting.Oost);
            var result = service.Verplaats(3, 4, Richting.Noord);
            Assert.IsFalse(result);
            var zelfdeStuk = bord.VindVeld(3, 4).Stuk;
            Assert.AreEqual(stuk.Naam, zelfdeStuk.Naam);
        }

        [TestMethod]
        public void SlaanTest()
        {
            var bord = service.Bord;
            bord.ZetStukOpBord(Rang.Maarschalk, Kleur.Rood, 5, 5);
            var spion =bord.ZetStukOpBord(Rang.Spion, Kleur.Blauw, 5, 4);
            service.Verplaats(5, 4, Richting.Noord);
            var zelfdeSpion = bord.VindVeld(5, 5).Stuk;
            Assert.AreEqual(spion.Naam, zelfdeSpion.Naam);
        }

        [TestMethod]
        public void BomSlaanTest()
        {
            var bord = service.Bord;
            bord.ZetStukOpBord(Rang.Bom, Kleur.Rood, 5, 5);
            var mineur = bord.ZetStukOpBord(Rang.Mineur, Kleur.Blauw, 5, 4);
            service.Verplaats(5, 4, Richting.Noord);
            var zelfdemineur = bord.VindVeld(5, 5).Stuk;
            Assert.AreEqual(mineur.Naam, zelfdemineur.Naam);
        }

        [TestMethod]
        public void BomSlaanTest2()
        {
            var bord = service.Bord;
            var bom = bord.ZetStukOpBord(Rang.Bom, Kleur.Rood, 5, 5);
            bord.ZetStukOpBord(Rang.Majoor, Kleur.Blauw, 5, 4);
            service.Verplaats(5, 4, Richting.Noord);
            var zelfdebom = bord.VindVeld(5, 5).Stuk;
            Assert.AreEqual(bom.Naam, zelfdebom.Naam);
        }
    }
}