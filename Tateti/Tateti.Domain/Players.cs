namespace Tateti.Domain
{
    public class Players : IPlayers
    {
        public IPlayer FirstPlayer { get; private set; }

        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public IPlayer SecondPlayer { get; private set; }

        internal Players(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        internal void SetupPlayersPositions(IDice dice)
        {
            while (true)
            {
                var valuePlayer1 = dice.Throw();
                var valuePlayer2 = dice.Throw();
                if (valuePlayer1 > valuePlayer2)
                {
                    FirstPlayer = _player1;
                    SecondPlayer = _player2;
                    AssignMarks();
                    break;
                }
                else if (valuePlayer1 < valuePlayer2)
                {
                    FirstPlayer = _player2;
                    SecondPlayer = _player1;
                    AssignMarks();
                    break;
                }
            }
        }
        private bool _turnOfFirstPlayer = true;
        public void Play(IBoard board)
        {
            if (_turnOfFirstPlayer)
            {
                FirstPlayer.Play(board);
                _turnOfFirstPlayer = false;
            }
            else
            {
                SecondPlayer.Play(board);
                _turnOfFirstPlayer = true;
            }
        }
        private void AssignMarks()
        {
            FirstPlayer.AssignMark(MarkTypeEnum.Cross);
            SecondPlayer.AssignMark(MarkTypeEnum.Circle);
        }
    }
}