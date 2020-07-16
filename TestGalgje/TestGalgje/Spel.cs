using System;
using System.Collections.Generic;

namespace TestGalgje
{
    public class Spel
    {
        public Potje CreatePotje()
        {
            var index = new Random().Next(0, Woorden.Length);
            return new Potje(Woorden[index], Pics.Keys.Count);
        }

        // alle teksten die je nodig hebt in een spel
        public string ValiedatieMelding = "Kies een leter die je nog niet eerder gekozen hebt dit potje";
        public string GewonnenMelding = "Yes!";
        public string VerlorenMelding = "Helaas...";
        public string NormaleHerstartButtonTekst = "Hertart";
        public string AfgelopenHerstartButtonTekst = "Nog een keer";

        // een setje leuke woorden
        public string[] Woorden =
        {
            "taxi", "quasi", "ei", "quiz", "lynx", "etui", "psyche", "dodo", "party", "hyena", "picknick", "gymzaal",
            "oase", "fauna", "cycloon", "qua", "uier", "sfinx", "curry", "cacao", "galerij", "sambal", "bushalte",
            "jazzzanger", "winnaar"
        };

        // De ASCII-art nodig voor een spel
        public readonly Dictionary<string, object> Pics = new Dictionary<string, object>{{"voetstuk",
@"       
       
       
       
       
       
  ========="},
{"paal", @"       
      |
      |
      |
      |
      |
  ========="},
{"toplat", @"  +---+
      |
      |
      |
      |
      |
  ========="},
{"touw", @"  +---+
  |   |
      |
      |
      |
      |
  ========="},
{"hoofd", @"  +---+
  |   |
  O   |
      |
      |
      |
  ========="},
{"romp", @"  +---+
  |   |
  O   |
  |   |
      |
      |
  ========="},
{"linkerarm", @"  +---+
  |   |
  O   |
 /|   |
      |
      |
  ========="},
{"rechterarm", @"  +---+
  |   |
  O   |
 /|\  |
      |
      |
  ========="},
{"linkerbeen",@"  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
  ========="},
{"rechterbeen",@"  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
  ========="}};
    }
}