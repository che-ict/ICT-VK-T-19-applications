using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego;

namespace TestStratego
{
    [TestClass]
    public class StukTest
    {
        [TestMethod]
        public void TestValtAanGewonnen()
        {
            var(generaal, colonel) = MaakStukken(Rang.Generaal, Rang.Colonel);
            Assert.AreEqual(UitkomstAanval.Gewonnen, generaal.ValtAan(colonel));
            var (sergeant, spion) = MaakStukken(Rang.Sergeant, Rang.Spion);
            Assert.AreEqual(UitkomstAanval.Gewonnen, sergeant.ValtAan(spion));
            var (maarschalk, mineur) = MaakStukken(Rang.Maarschalk, Rang.Mineur);
            Assert.AreEqual(UitkomstAanval.Gewonnen, maarschalk.ValtAan(mineur));
            var (kapitein, vlag) = MaakStukken(Rang.Kapitein, Rang.Vlag);
            Assert.AreEqual(UitkomstAanval.Gewonnen, kapitein.ValtAan(vlag));

        }

        [TestMethod]
        public void TestValtAanVerloren()
        {
            var (majoor, colonel) = MaakStukken(Rang.Majoor, Rang.Colonel);
            Assert.AreEqual(UitkomstAanval.Verloren, majoor.ValtAan(colonel));
            var (verkenner, maarschalk) = MaakStukken(Rang.Verkenner, Rang.Maarschalk);
            Assert.AreEqual(UitkomstAanval.Verloren, verkenner.ValtAan(maarschalk));
            var (luitenant, bom) = MaakStukken(Rang.Luitenant, Rang.Bom);
            Assert.AreEqual(UitkomstAanval.Verloren, luitenant.ValtAan(bom));
        }

        [TestMethod]
        public void TestSpion()
        {
            var (spion, maarschalk) = MaakStukken(Rang.Spion, Rang.Maarschalk);
            var vlag = Stuk.MaakStuk(Rang.Vlag, Kleur.Rood);
            var verkenner = Stuk.MaakStuk(Rang.Verkenner, Kleur.Rood);
            var bom = Stuk.MaakStuk(Rang.Bom, Kleur.Rood);
            var generaal = Stuk.MaakStuk(Rang.Generaal, Kleur.Rood);
            Assert.AreEqual(UitkomstAanval.Gewonnen, spion.ValtAan(maarschalk));
            Assert.AreEqual(UitkomstAanval.Gewonnen, spion.ValtAan(vlag));
            Assert.AreEqual(UitkomstAanval.Verloren, spion.ValtAan(verkenner));
            Assert.AreEqual(UitkomstAanval.Verloren, spion.ValtAan(bom));
            Assert.AreEqual(UitkomstAanval.Verloren, spion.ValtAan(generaal));
        }

        [TestMethod]
        public void TestMineur()
        {
            var (mineur, bom) = MaakStukken(Rang.Mineur, Rang.Bom);
            var sergeant = Stuk.MaakStuk(Rang.Sergeant, Kleur.Rood);
            Assert.AreEqual(UitkomstAanval.Gewonnen, mineur.ValtAan(bom));
            Assert.AreEqual(UitkomstAanval.Verloren, mineur.ValtAan(sergeant));

        }

        [TestMethod]
        public void TestVerkenner()
        {
            var bord = new Bord();
            // rand to rand
            var verkenner = bord.ZetStukOpBord(Rang.Verkenner, Kleur.Blauw, 10, 10);
            Assert.IsTrue(verkenner.MagNaar(Richting.Zuid, 9));
            Assert.IsFalse(verkenner.MagNaar(Richting.Zuid, 10));

            // rand tot eerste verkenner
            var verkenner2 = bord.ZetStukOpBord(Rang.Verkenner, Kleur.Blauw, 1, 10);
            Assert.IsTrue(verkenner2.MagNaar(Richting.Zuid, 9));
            Assert.IsFalse(verkenner2.MagNaar(Richting.Oost, 9));
            Assert.IsTrue(verkenner2.MagNaar(Richting.Oost, 8));

            // rand tot meer
            var verkenner3 = bord.ZetStukOpBord(Rang.Verkenner, Kleur.Blauw, 4, 10);
            Assert.IsTrue(verkenner3.MagNaar(Richting.Zuid, 3));
            Assert.IsFalse(verkenner3.MagNaar(Richting.Zuid, 4));

            verkenner3.GaNaar(Richting.Zuid, 3);
            verkenner2.GaNaar(Richting.Oost, 8);
            verkenner.GaNaar(Richting.Zuid, 9);
            Assert.IsNotNull(bord.VindVeld(4,7)?.Stuk);
            Assert.IsNotNull(bord.VindVeld(9, 10)?.Stuk);
            Assert.IsNotNull(bord.VindVeld(10, 1)?.Stuk);

        }

        [TestMethod]
        public void TestBomEnVlag()
        {
            var bord = new Bord();
            var bom = bord.ZetStukOpBord(Rang.Bom, Kleur.Blauw, 2, 2);
            Assert.IsFalse(bom.MagNaar(Richting.Noord));
            var vlag = bord.ZetStukOpBord(Rang.Vlag, Kleur.Blauw, 8, 8);
            Assert.IsFalse(vlag.MagNaar(Richting.West));
        }

        private (IStuk stuk, IStuk anderStuk) MaakStukken(Rang rang1, Rang rang2)
        {
            return (Stuk.MaakStuk(rang1, Kleur.Blauw), Stuk.MaakStuk(rang2, Kleur.Rood));
        }
    }
}