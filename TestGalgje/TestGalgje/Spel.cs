using System;

namespace TestGalgje
{
    public class Spel
    {
        public Potje CreatePotje()
        {
            var index = new Random().Next(0, woorden.Length);
            return new Potje(woorden[index], Plaatjes.Length);
        }

        // alle teksten die je nodig hebt in een spel
        public string ValiedatieMelding = "Kies een letter die je nog niet eerder gekozen hebt dit potje";
        public string GewonnenMelding = "Yes!";
        public string VerlorenMelding = "Helaas...";
        public string NormaleHerstartButtonTekst = "Herstart";
        public string AfgelopenHerstartButtonTekst = "Nog een keer";

        // een setje leuke woorden
        private readonly string[] woorden =
        {
            "taxi", "quasi", "ei", "Quiz", "Lynx", "etui", "psyche", "dodo", "party", "Hyena", "picknick", "gymzaal",
            "oase", "fauna", "cycloon", "qua", "uier", "sfinx", "curry", "cacao", "galerij", "sambal", "bushalte",
            "jazzzanger", "winnaar"
        };

        // De ASCII-art nodig voor een spel
        public readonly string[] Plaatjes ={
@"       
       
       
       
       
       
  =========",
@"       
      |
      |
      |
      |
      |
  =========",
@"  +---+
      |
      |
      |
      |
      |
  =========",
@"  +---+
  |   |
      |
      |
      |
      |
  =========",
@"  +---+
  |   |
  O   |
      |
      |
      |
  =========",
@"  +---+
  |   |
  O   |
  |   |
      |
      |
  =========",
@"  +---+
  |   |
  O   |
 /|\  |
      |
      |
  =========",
@"  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
  =========",
@"  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
  ========="};
    }
}