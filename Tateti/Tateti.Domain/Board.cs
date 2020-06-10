namespace Tateti.Domain
{
    public class Board : IBoard
    {
        private readonly IMarksList marksList;

        public int MarkCount { get; private set; } = 0;

        public Board()
        {
        }
        public Board(IMarksList marksList)
        {
            this.marksList = marksList;
        }
        public bool IsEmpty()
        {
            for (int x = 1; x < 4; x++)
                for (int y = 1; y < 4; y++)
                    if (marksList.GetMarkPosition(new MarkPosition(x, y)) != MarkTypeEnum.Empty)
                        return false;

            return true;
        }

        public bool HasEnded()
        {
            if (MarkCount == 9)
                return true;

            if (marksList.HasWinner())
            {
                //Notifico al player
                return true;
            }
            return false;
        }

        public bool AssignMark(IPlayer player, MarkPosition markPosition)
        {
            if (marksList.GetMarkPosition(markPosition) == MarkTypeEnum.Empty)
            {
                marksList.SetMarkPosition(markPosition, player.MarkType);
                ++MarkCount;
                return true;
            }
            return false;
        }
        public MarkTypeEnum GetMarkPosition(MarkPosition markPosition) =>
           marksList.GetMarkPosition(markPosition);
    }
}