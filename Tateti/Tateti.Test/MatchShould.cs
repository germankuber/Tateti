using Moq;
using Tateti.Domain;
using Xunit;

namespace Tateti.Test
{
    public class MatchShould
    {
        private readonly MatchGame _match;
        private readonly Mock<IBoard> _boardMock = new Mock<IBoard>();
        private readonly Mock<IPlayers> _playersMock = new Mock<IPlayers>();
        public MatchShould()
        {
            _match = new MatchGame(_boardMock.Object, _playersMock.Object);
        }

        [Fact]
        public void Start()
        {
            _playersMock.Setup(x => x.Play(It.IsAny<IBoard>()));

            _boardMock.SetupSequence(x => x.HasEnded())
                .Returns(false)
                .Returns(true);

            _match.Start();

            _playersMock.Verify(x => x.Play(It.IsAny<IBoard>()), Times.AtLeast(1));
        }
    }
}
