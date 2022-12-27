using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiSweeper
{
    internal class Tile
    {
        public bool isMine = false;
        public int numMines = 0;
        public bool cleared = false;

        public Tile()
        {

        }
        public Tile(bool mine)
        {
            isMine = mine;
        }

        public Tile(int mines)
        {
            numMines = mines;
        }
        public Tile(bool mine, int mines)
        {
            isMine = mine;
            numMines = mines;
        }


    }
}
