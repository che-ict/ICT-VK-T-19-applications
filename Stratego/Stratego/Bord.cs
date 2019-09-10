using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stratego
{
    public class Bord : IBord
    {
        private Dictionary<(int, int), IVeld> velden;

        private readonly Dictionary<Rang, int> maxAantalPerRang = new Dictionary<Rang, int>
        {
            {Rang.Vlag, 1},
            {Rang.Bom, 6 },
            {Rang.Spion, 1 },
            {Rang.Verkenner, 8 },
            {Rang.Mineur, 5 },
            {Rang.Sergeant, 4 },
            {Rang.Luitenant, 4 },
            {Rang.Kapitein, 4 },
            {Rang.Majoor, 3 },
            {Rang.Colonel, 2 },
            {Rang.Generaal, 1 },
            {Rang.Maarschalk, 1 }
        };

        public Bord()
        {
            velden = new Dictionary<(int, int), IVeld>();
            MaakVelden();
        }

        private void MaakVelden()
        {
            var xs = Enumerable.Range(1, 10).ToArray();
            var ys = Enumerable.Range(1, 10).ToArray();
            // eerst 100 velden aanmaken
            velden = xs.SelectMany(x => ys.Select(y => (IVeld) new Veld(x, y)))
                .ToDictionary(v => (v.X, v.Y), v => v);

            // dan elk veld z'n buurvelden laten opzoeken
            foreach (var veld in velden.Values)
            {
                veld.SetBuren(this);
            }
        }

        public IVeld VindVeld(int x, int y)
        {
            var gelukt = velden.TryGetValue((x, y), out var veld);
            return gelukt ? veld : null;
        }

        public IStuk ZetStukOpBord(Rang rang, Kleur kleur, int x, int y)
        {
            if (!MagStukNogOpBord(rang, kleur))
            {
                return null;
            }
            var veld = VindVeld(x, y);
            if (veld.Stuk != null || veld.IsEenMeer)
            {
                return null;
            }
            var stuk = Stuk.MaakStuk(rang, kleur);

            stuk.ZetOpVeld(veld);
            return stuk;
        }

        private bool MagStukNogOpBord(Rang rang, Kleur kleur)
        {
            return TelStukkenVanRangEnKleur(rang, kleur) < maxAantalPerRang[rang];
        }

        private IEnumerable<IStuk> AlleStukken()
        {
            return velden.Values
                .Select(v => v.Stuk)
                .Where(s => s != null);
        }

        private int TelStukkenVanRangEnKleur(Rang? rang, Kleur? kleur)
        {
            var set = AlleStukken();
            if (kleur != null)
            {
                set = set.Where(s => s.Kleur == kleur);
            }
            if (rang != null)
            {
                set = set.Where(s => s.Rang == rang);
            }

            return set.Count();
        }
    }
}