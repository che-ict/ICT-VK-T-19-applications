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
            if (GoedeLetters.Contains(letter.Value) || FouteLetters.Contains(letter.Value))
            {// letters mogen niet al eerder gebruikt zijn
                return false;
            }
            if (!Woord.Contains(letter.Value))
            {
                FouteLetters = FouteLetters + letter;
            }
            else
            {
                GoedeLetters = GoedeLetters + letter;
            }
            return true;
        }

        public string ShowWoord()
        {
            var result = "";
            foreach (var letter in Woord)
            {
                if (GoedeLetters.Any(gl => gl == letter))
                    result = result + letter;
                else
                    result = result + '*';
                    result = result + ' ';
            }

            return result;
        }

        public Status CurrentStatus()
        {
            if (AantalMissers < 0)
            {
                return Status.Invalid;
            }

            if (AantalMissers > MaxPogingen)
            {
                return Status.Verloren;
            }

            // meer linq: als voor alle letters (l) in woord geldt dat ze voorkomen in goedeLetters...
            // Ja, dan zijn alle letters en dus het hele woord geraden
            return Woord.All(l => GoedeLetters.Contains(l))
                ? Status.Gewonnen
                : Status.Onbeslist;
        }
    }

    public enum Status
    {
        Gewonnen,
        Verloren,
        Onbeslist,
        Invalid
    }
}