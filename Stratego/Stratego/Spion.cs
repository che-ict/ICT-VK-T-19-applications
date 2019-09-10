namespace Stratego
{
    public class Spion : Stuk
    {
        public Spion(Rang rang, Kleur kleur) : base(rang, kleur)
        {
        }

        public override UitkomstAanval ValtAan(IStuk anderStuk)
        {
            if (anderStuk == null || anderStuk.Rang == Rang.Vlag || anderStuk.Rang == Rang.Maarschalk)
                return UitkomstAanval.Gewonnen;
            return anderStuk.Rang == Rang.Spion ? UitkomstAanval.GelijkSpel : UitkomstAanval.Verloren;
        }
    }
}