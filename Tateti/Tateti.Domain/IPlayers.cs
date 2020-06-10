namespace Tateti.Domain
{
    public interface IPlayers
    {
        IPlayer FirstPlayer { get; }
        IPlayer SecondPlayer { get; }
        void Play(IBoard board);
    }
}