using Tateti.Domain;

namespace Tateti.Test
{
    public class MatchGame
    {
        private readonly IBoard board;
        private readonly IPlayers players;
        public MatchGame(IBoard board, IPlayers players)
        {
            this.board = board;
            this.players = players;
        }

        public void Start()
        {
            while (!board.HasEnded())
                players.Play(board);
        }
    }
}