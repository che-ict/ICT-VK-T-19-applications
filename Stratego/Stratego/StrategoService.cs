using System;

namespace Stratego
{
    // Een frontendapplicatie (of het nou winforms is, een webapplicatie of bijv unity) 
    // zou alle spelershandelingen meoten kunnen uitvoeren met deze service
    // en alle gevolgen daarvan moeten kunnen terugzien in de bord-class
    public class StrategoService
    {
        public IBord Bord { get; }

        public StrategoService()
        {
            // hier bord maken en velden (laten) toekennen
            Bord = new Bord();
        }

        public bool ZetStukOpBord(Rang rang, Kleur kleur, int x, int y)
        {
            return Bord.ZetStukOpBord(rang, kleur, x, y) != null;
        }

        // geeft terug of de set uitgevoerd kan worden
        public bool Verplaats(int x, int y, Richting richting)
        {
            // Een speler moet in de spelfase (na het opzetten van het bord)
            // vrijwel alles met deze methode kunnen doen
            var stuk = Bord.VindVeld(x, y).Stuk;
            return stuk != null && stuk.GaNaar(richting);
        }
    }
}