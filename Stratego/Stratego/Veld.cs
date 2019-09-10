using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratego
{
    // Ik heb deze class alvast gedeeltelijk gebouwd omdat je velden moet kunnen vergelijken
    // en mogelijk uit dictionary's kunnen halen. Daar heb je goed werkende equals- en
    // GetHashCode-implementaties voor nodig. Bij deze.

    public class Veld : IVeld
    {
        public int X { get; }
        public int Y { get; }
        public IStuk Stuk { get; set; }
        public bool IsEenMeer { get; }
        private IVeld West { get; set; }
        private IVeld Oost { get; set; }
        private IVeld Noord { get; set; }
        private IVeld Zuid { get; set; }

        private static readonly (int, int)[] Meren = new[]
        {
            // linker meer
            (3, 5), (4, 5), (3, 6), (4, 6),
            // rechter meer
            (7, 5), (8,5), (7, 6), (8, 6)
        };

        public Veld(int x, int y)
        {
            X = x;
            Y = y;
            IsEenMeer = Meren.Contains((x, y));
        }

        public void SetBuren(IBord bord)
        {
            West = bord.VindVeld(X - 1, Y);
            Oost = bord.VindVeld(X + 1, Y);
            Zuid = bord.VindVeld(X, Y - 1);
            Noord = bord.VindVeld(X, Y + 1);
        }

        public IVeld Buurveld(Richting richting)
        {
            switch (richting)
            {
                case Richting.West:
                    return West;
                case Richting.Oost:
                    return Oost;
                case Richting.Noord:
                    return Noord;
                case Richting.Zuid:
                    return Zuid;
                default: // omdat je nooit weet of een of andere onverlaat richtingen toe gaat voegen!
                    throw new ArgumentOutOfRangeException(nameof(richting), richting, null);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Veld v)
            {
                return Equals(v);
            }
            return false;
        }

        public bool Equals(Veld other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return X * 113 + Y;
        }
    }
}