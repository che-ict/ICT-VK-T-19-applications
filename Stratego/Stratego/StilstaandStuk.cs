namespace Stratego
{
    public class StilstaandStuk : Stuk
    {
        public StilstaandStuk(Rang rang, Kleur kleur) : base(rang, kleur)
        {
        }

        public override bool MagNaar(Richting richting) => false;
    }
}