using System;

namespace Stratego
{
    public class Stuk : IStuk
    {
        public IVeld Veld { get; set; }
        public string Naam => Rang.ToString();
        public int Waarde => (int) Rang;
        public Rang Rang { get; }
        public Kleur Kleur { get; }

        public static IStuk MaakStuk(Rang rang, Kleur kleur)
        {
            switch (rang)
            {
                case Rang.Vlag:
                case Rang.Bom:
                    return new StilstaandStuk(rang, kleur);
                case Rang.Spion:
                    return new Spion(rang, kleur);
                case Rang.Verkenner:
                    return new Verkenner(rang, kleur);
                case Rang.Mineur:
                    return new Mineur(rang, kleur);
                case Rang.Sergeant:
                case Rang.Luitenant:
                case Rang.Kapitein:
                case Rang.Majoor:
                case Rang.Colonel:
                case Rang.Generaal:
                case Rang.Maarschalk:
                    return new Stuk(rang, kleur);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Stuk(Rang rang, Kleur kleur)
        {
            Rang = rang;
            Kleur = kleur;
        }

        public virtual bool MagNaar(Richting richting)
        {
            return MagNaar(Veld, richting);
        }

        protected bool MagNaar(IVeld veld, Richting richting)
        {
            // veld moet bestaan en buurveld ook
            if (veld?.Buurveld(richting) == null)
                return false;
            // buurveld moet geen meer zijn
            if (veld.Buurveld(richting).IsEenMeer)
                return false;
            // buurveld moet geen stuk in eigen kleur bevatten
            if (veld.Buurveld(richting).Stuk?.Kleur == Kleur)
                return false;
            // dit soort stuk moet kunnen lopen
            return MagLopen;
        }


        public virtual bool MagNaar(Richting richting, int afstand)
        {
            return afstand == 1 && MagNaar(richting);
        }

        public virtual UitkomstAanval ValtAan(IStuk anderStuk)
        {
            if (anderStuk == null)
                return UitkomstAanval.Gewonnen;
            if (anderStuk.Rang == Rang.Bom)
                return MagBomOnschadelijkMaken ? UitkomstAanval.Gewonnen : UitkomstAanval.Verloren;
            if (Waarde > anderStuk.Waarde)
                return UitkomstAanval.Gewonnen;
            return Waarde == anderStuk.Waarde ? UitkomstAanval.GelijkSpel : UitkomstAanval.Verloren;
        }

        public virtual bool GaNaar(Richting richting)
        {
            if (!MagNaar(richting))
                return false;

            var buurVeld = Veld.Buurveld(richting);
            var anderStuk = buurVeld.Stuk;
            if (anderStuk != null)
            {
                var uitkomst = ValtAan(anderStuk);
                switch (uitkomst)
                {
                    case UitkomstAanval.Verloren:
                        // stuk van het bord halen
                        VerwijderVanBord();
                        break;
                    case UitkomstAanval.Gewonnen:
                        ((Stuk) anderStuk).VerwijderVanBord(); // iets fraaiers dan een cast verzinnen!
                        VerplaatsNaar(buurVeld);
                        break;
                    case UitkomstAanval.GelijkSpel:
                        VerwijderVanBord();
                        ((Stuk)anderStuk).VerwijderVanBord(); // iets fraaiers dan een cast verzinnen!
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                VerplaatsNaar(buurVeld);
            }
            return true;
        }

        public virtual bool GaNaar(Richting richting, int afstand)
        {
            return afstand == 1 && GaNaar(richting);
        }

        public void ZetOpVeld(IVeld veld)
        {
            Veld = veld;
            veld.Stuk = this;
        }

        private void VerwijderVanBord()
        {
            Veld.Stuk = null;
            Veld = null;
        }

        private void VerplaatsNaar(IVeld doelVeld)
        {
            Veld.Stuk = null;
            doelVeld.Stuk = this;
            Veld = doelVeld;
        }

        protected virtual bool MagLopen => true;
        protected virtual bool MagBomOnschadelijkMaken => false;
    }
}