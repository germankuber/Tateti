namespace Tateti.Domain
{
    public class PlayersFactory
    {
        private readonly Player _player1;
        public readonly Player _player2;

        public PlayersFactory(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }
        public Players Create(IDice dice)
        {
            var players = new Players(_player1, _player2);
            players.SetupPlayersPositions(dice);
            return players;
        }
    }
}
