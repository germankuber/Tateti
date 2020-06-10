using FluentAssertions;
using Moq;
using Tateti.Domain;
using Xunit;

namespace Tateti.Test
{
    public class PlayersShould
    {
        private Player _player1 = new Player((board) => { });
        private Player _player2 = new Player((board) => { });
        private readonly Mock<IDice> _diceMock = new Mock<IDice>();

        [Fact]
        public void Accept_Two_Player()
        {
            _diceMock.SetupSequence(x => x.Throw())
                .Returns(2)
                .Returns(1);

            new PlayersFactory(_player1, _player2).Create(_diceMock.Object)
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void Player1_Be_First_Player_And_Player2_Be_Second_Player()
        {

            _diceMock.SetupSequence(x => x.Throw())
                .Returns(2)
                .Returns(1);

            var players = new PlayersFactory(_player1, _player2).Create(_diceMock.Object);

            players.FirstPlayer.Should()
                .Be(_player1);

            players.SecondPlayer.Should()
                .Be(_player2);
        }

        [Fact]
        public void First_Player_Have_Cross()
        {
            _diceMock.SetupSequence(x => x.Throw())
                .Returns(2)
                .Returns(1);

            var players = new PlayersFactory(_player1, _player2).Create(_diceMock.Object);

            players.FirstPlayer.MarkType.Should().Be(MarkTypeEnum.Cross);
        }

        [Fact]
        public void Second_Player_Have_Circle()
        {
            _diceMock.SetupSequence(x => x.Throw())
                .Returns(2)
                .Returns(1);

            var players = new PlayersFactory(_player1, _player2).Create(_diceMock.Object);

            players.SecondPlayer.MarkType.Should().Be(MarkTypeEnum.Circle);
        }

        [Fact]
        public void Player2_Be_First_Player_And_Player1_Be_Second_Player()
        {
            _diceMock.SetupSequence(x => x.Throw())
                .Returns(1)
                .Returns(2);

            var players = new PlayersFactory(_player1, _player2).Create(_diceMock.Object);

            players.FirstPlayer.Should()
                .Be(_player2);

            players.SecondPlayer.Should()
                .Be(_player1);
        }

        [Fact]
        public void Play_First_Player()
        {
            var execute = false;
            _player1 = new Player((board) => execute = true);
            var players = CreateToTest();
            players.Play(new Board());
            execute.Should().BeTrue();
        }

        [Fact]
        public void Play_Second_Player()
        {
            var execute = false;
            _player2 = new Player((board) => execute = true);
            var players = CreateToTest();
            players.Play(new Board());
            players.Play(new Board());
            execute.Should().BeTrue();
        }

        private IPlayers CreateToTest()
        {
            _diceMock.SetupSequence(x => x.Throw())
                  .Returns(2)
                  .Returns(1);
            return new PlayersFactory(_player1, _player2).Create(_diceMock.Object);
        }
    }
}
