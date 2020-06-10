namespace Tateti.Domain
{
    public class MarkPosition
    {
        public int X { get; }
        public int Y { get; }
        public MarkPosition(int x, int y)
        {
            if (x < 1 || x > 3) throw new InvalidMarkPositionException(nameof(x));
            if (y < 1 || y > 3) throw new InvalidMarkPositionException(nameof(y));
            X = x;
            Y = y;
        }


    }
}