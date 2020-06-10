using System.Collections.Generic;
using System.Linq;

namespace Tateti.Domain
{
    public class MarksList : IMarksList
    {
        private MarkTypeEnum[,] MarksPositions { get; } = new MarkTypeEnum[3, 3];
        private readonly List<((int, int), (int, int), (int, int))> _winnerPositions =
             new List<((int, int), (int, int), (int, int))>
         {
                ((1,1),(1,2),(1,3)),
                ((2,1),(2,2),(2,3)),
                ((3,1),(3,2),(3,3)),
                ((1,1),(2,1),(3,1)),
                ((1,2),(2,2),(3,2)),
                ((1,3),(2,3),(3,3)),
                ((1,1),(2,2),(3,3)),
                ((3,1),(2,2),(1,3)),
         };

        public MarkTypeEnum GetMarkPosition(MarkPosition markPosition) =>
          MarksPositions[markPosition.X - 1, markPosition.Y - 1];


        public bool HasWinner()
        {
            return _winnerPositions.Any(x => MarksPositions[x.Item1.Item1, x.Item1.Item2] == MarksPositions[x.Item2.Item1, x.Item2.Item2]
                                             &&
                                              MarksPositions[x.Item2.Item1, x.Item2.Item2] == MarksPositions[x.Item3.Item1, x.Item3.Item2]);
        }

        public void SetMarkPosition(MarkPosition markPosition, MarkTypeEnum markType)
        {
            MarksPositions[markPosition.X - 1, markPosition.Y - 1] = markType;
        }
    }
}