using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiSweeper
{
    internal class Board
    {
        int height = 9;
        int width = 9;
        int mines = 10;
        //TODO: Custom sizes

        // Tile[,] board = new Tile[height,width];
        List<List<Tile>> board = new List<List<Tile>>(); 

        public Board() : this(9,9,10)
        {
            
        }

        public Board(int height, int width, int mines)
        {
            this.height = height;
            this.width = width;
            this.mines = mines;

            setUpBoard();
            setUpMines();
            setUpNumbers();

        }

        public void setUpBoard()
        {
            for (int i = 0; i < height; i++)
            {
                board.Add(new List<Tile>());
                for (int j = 0; j < width; j++)
                {
                    board[i].Add( new Tile());
                }
            }
        }

        void setUpMines()
        {

            Random random = new Random();

            int minesleft = mines;

            while (minesleft != 0)
            {
                int randHeight = random.Next(0, height);
                int randWidth = random.Next(0, width);

                if (board[randHeight][randWidth].isMine == false)
                {
                    minesleft--;
                    board[randHeight][randWidth].isMine = true;
                }
            }

        }

        void setUpNumbers()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(board[i][j].isMine == true)
                    {
                        for(int k = -1; k <= 1; k++)
                        {
                            for(int l = -1; l <= 1; l++)
                            {
                                try
                                {
                                    board[i + k][j + l].numMines++;
                                }
                                catch (Exception e)
                                {
                                    //out of bounds, we dont care
                                }
                            }
                        }
                    }
                }
            }
        }



        public string getBoardString()
        {
            string str = "";
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    str += (board[i][j].isMine ? "*" : board[i][ j].numMines);
                    str += " ";
                }
                str += "\n";
            }

            return str;
        }


    }
}
