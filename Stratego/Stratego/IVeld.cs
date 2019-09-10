namespace Stratego
{
    public interface IVeld
    {
        int X { get; }
        int Y { get; }
        bool IsEenMeer { get; }
        IStuk Stuk { get; set; }
        void SetBuren(IBord bord);
        IVeld Buurveld(Richting richting);
    }
}