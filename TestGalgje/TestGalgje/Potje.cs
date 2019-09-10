using System.Linq;

namespace TestGalgje
{
    public class Potje
    {
        private string Woord { get; }
        public string GoedeLetters { get; private set; }
        public string FouteLetters { get; private set; }
        public int AantalMissers => FouteLetters.Length;
        private int MaxPogingen { get; }

        public Potje(string woord, int maxPogingen)
        {
            Woord = woord;
            GoedeLetters = "";
            FouteLetters = "";
            MaxPogingen = maxPogingen;
        }

        public bool AddLetter(char? letter)
        {
            if (HuidigeStatus() != Status.Onbeslist)
            {// geen letters toevoegen als het spel al afgelopen is
                return false;
            }
            if (!letter.HasValue)
            {// niks ingevuld => niks doen
                return false;
            }
            var lowerCaseLetter = letter.ToString().ToLowerInvariant().Single();
            if (GoedeLetters.Contains(lowerCaseLetter) || FouteLetters.Contains(lowerCaseLetter))
            {// letters mogen niet al eerder gebruikt zijn
                return false;
            }
            if (!Woord.Contains(lowerCaseLetter))
            {
                FouteLetters += lowerCaseLetter;
            }
            else
            {
                GoedeLetters += lowerCaseLetter;
            }
            return true;
        }

        public string ToonWoord()
        {
            // de kracht van C# en linq:
            // van woord naar char[] naar IEnumerable naar char[] naar string in 1 regel :-)
            return new string(Woord.Select(l => GoedeLetters.Contains(l) ? l : '*').ToArray());
        }

        public Status HuidigeStatus()
        {
            if (AantalMissers >= MaxPogingen)
            {
                return Status.Verloren;
            }

            // meer linq: als voor alle letters (l) in woord geldt dat ze voorkomen in goedeLetters...
            // Ja, dan zijn alle letters en is het hele woord dus geraden
            return Woord.All(l => GoedeLetters.Contains(l))
                ? Status.Gewonnen
                : Status.Onbeslist;
        }
    }

    public enum Status
    {
        Gewonnen,
        Verloren,
        Onbeslist
    }
}