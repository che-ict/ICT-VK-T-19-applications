namespace Stratego
{
    public interface IBord
    {
        IVeld VindVeld(int x, int y);
        IStuk ZetStukOpBord(Rang rang, Kleur kleur, int x, int y);
    }
}