using FluentAssertions;

using Moq;
using Tateti.Domain;
using Xunit;

namespace Tateti.Test
{
    public class BoardShould
    {
        private readonly Board _board;
        private readonly Mock<IPlayer> _player1 = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _player2 = new Mock<IPlayer>();

        public BoardShould()
        {
            _board = new Board(new MarksList()); ;
            _player1.Setup(x => x.MarkType).Returns(MarkTypeEnum.Cross);
            _player2.Setup(x => x.MarkType).Returns(MarkTypeEnum.Circle);
        }

        [Fact]
        public void Start_With_Empty_Marks()
        {
            _board.IsEmpty().Should()
                            .BeTrue();
        }

        [Fact]
        public void Assign_Mark()
        {
            var position = new MarkPosition(1, 1);
            _board.AssignMark(_player1.Object, position);
            _board.GetMarkPosition(position).Should().Be(MarkTypeEnum.Cross);
        }

        [Fact]
        public void Not_Assign_Mark_In_Place_With_Other_Mark()
        {
            var position = new MarkPosition(1, 1);
            _board.AssignMark(_player1.Object, position);
            _board.AssignMark(_player2.Object, position);
            _board.GetMarkPosition(position).Should().Be(MarkTypeEnum.Cross);
        }
    }
}
