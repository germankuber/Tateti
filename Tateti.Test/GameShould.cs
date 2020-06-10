using Moq;
using Tateti.Domain;

namespace Tateti.Test
{
    public class GameShould
    {
        private Game _game;
        private readonly Mock<Players> _playersMock = new Mock<Players>();
        private readonly Mock<Board> _boardMock = new Mock<Board>();

        public GameShould()
        {
            _game = new Game(_boardMock.Object, _playersMock.Object);
        }

    }
}
