namespace Stratego
{
    public class Mineur : Stuk
    {
        public Mineur(Rang rang, Kleur kleur) : base(rang, kleur)
        {
        }

        protected override bool MagBomOnschadelijkMaken => true;
    }
}