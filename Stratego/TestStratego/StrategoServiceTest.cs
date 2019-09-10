using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego;

namespace TestStratego
{
    [TestClass]
    public class StrategoServiceTest
    {
        [TestMethod]
        public void SimpeleVerplaatsTest()
        {
            var service = new StrategoService();
            var bord = service.Bord;
            bord.ZetStukOpBord(Rang.Majoor, Kleur.Rood, 1, 1);

            var stuk = bord.VindVeld(1, 1).Stuk;
            var result = service.Verplaats(1, 1, Richting.West);
            var zelfdeStuk = bord.VindVeld(1, 1).Stuk;
            // mag niet over rand
            Assert.IsFalse(result);
            Assert.AreEqual(stuk.Naam, zelfdeStuk.Naam);

            result = service.Verplaats(1, 1, Richting.Oost);
            zelfdeStuk = bord.VindVeld(2, 1).Stuk;
            // mag wel naar rechtsboven
            Assert.IsTrue(result);
            Assert.AreEqual(stuk.Naam, zelfdeStuk.Naam);
        }
    }
}