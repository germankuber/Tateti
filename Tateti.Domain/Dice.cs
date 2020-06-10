using System;

namespace Tateti.Domain
{
    public interface IDice
    {
        int Throw();
    }
    public class Dice : IDice
    {
        public int Throw() =>
            new Random().Next(1, 6);
    }
}