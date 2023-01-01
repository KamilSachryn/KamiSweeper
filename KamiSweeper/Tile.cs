using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiSweeper
{
    internal class Tile
    {
        //object to hold some information per tile
        public bool isMine = false;
        public int numMines = 0;
        public bool cleared = false;

    }
}
