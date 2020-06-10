namespace Tateti.Domain
{
    public interface IPlayer
    {
        MarkTypeEnum MarkType { get; }

        void AssignMark(MarkTypeEnum markType);
        void Play(IBoard board);
    }
}