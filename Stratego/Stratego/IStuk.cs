namespace Stratego
{
    public interface IStuk
    {
        bool MagNaar(Richting richting);
        bool MagNaar(Richting richting, int afstand);
        bool GaNaar(Richting richting);
        bool GaNaar(Richting richting, int afstand);
        void ZetOpVeld(IVeld veld);
        UitkomstAanval ValtAan(IStuk anderStuk);
        string Naam { get; }
        int Waarde { get; }
        Rang Rang { get; }
        Kleur Kleur { get; }
    }
}