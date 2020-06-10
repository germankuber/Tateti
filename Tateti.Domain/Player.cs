using System;

namespace Tateti.Domain
{
    public class Player : IPlayer
    {
        public MarkTypeEnum MarkType { get; private set; }
        private readonly Action<IBoard> _playCallback;
        public Player(Action<IBoard> playCallback)
        {
            _playCallback = playCallback;
        }
        public void AssignMark(MarkTypeEnum markType)
        {
            MarkType = markType;
        }
        public void Play(IBoard board) =>
            _playCallback(board);
    }
}