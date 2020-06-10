namespace Tateti.Domain
{
    public interface IBoard
    {
        MarkTypeEnum GetMarkPosition(MarkPosition markPosition);
        bool IsEmpty();
        bool HasEnded();
        int MarkCount { get; }
    }
}