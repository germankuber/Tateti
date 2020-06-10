using System;

namespace Tateti.Domain
{
    public class Game
    {

        private Board _board;
        private Players _players;

        public Game()
        {

        }

        public Game(Board object1, Players object2)
        {
            _board = object1;
            _players = object2;
        }



        internal void Start()
        {
            throw new NotImplementedException();
        }
    }
}