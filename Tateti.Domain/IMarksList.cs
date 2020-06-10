namespace Tateti.Domain
{
    public interface IMarksList
    {
        MarkTypeEnum GetMarkPosition(MarkPosition markPosition);
        void SetMarkPosition(MarkPosition markPosition, MarkTypeEnum markType);
        bool HasWinner();
    }
}