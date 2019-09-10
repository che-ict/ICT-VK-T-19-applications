namespace Stratego
{
    public class Verkenner : Stuk
    {
        public Verkenner(Rang rang, Kleur kleur) : base(rang, kleur)
        {
        }

        public override bool MagNaar(Richting richting, int afstand)
        {
            var veld = Veld;
            for (var i = 1; i <= afstand; i++)
            {
                if (MagNaar(veld, richting))
                {
                    veld = veld.Buurveld(richting);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public override bool GaNaar(Richting richting, int afstand)
        {
            if(!MagNaar(richting, afstand))
                return false;

            var veld = Veld;
            for (var i = 1; i <= afstand; i++)
            {
                if (GaNaar(richting)) continue;
                Veld = veld;
                veld.Stuk = this;
                return false;
            }
            return true;
        }
    }
}