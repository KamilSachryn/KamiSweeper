using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiSweeper
{
    internal class Board
    {
        public int height = 9;
        public int width = 9;
        public int mines = 10;
        //TODO: Custom tile input from user

        //2d list of tiles
        //need a list due to board size being dynamic
        public List<List<Tile>> board = new List<List<Tile>>(); 

        //default size 9x9:10
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

        //Add tile objects to board
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
         //randomly place mines by modifying tileobjects
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

        //increment a number to every tile surrounding a mine 
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
                                
                                    if (isValid(i + k, j + l))
                                    {
                                        board[i + k][j + l].numMines++;
                                    }

                            }
                        }
                    }
                }
            }
        }


        //debug, show mines and numbers
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

        //if in board, out of range protection
        bool isValid(int h, int w)
        {
            return ((h >= 0) && (w >= 0) && (h < height) && (w < width));
        }


    }
}
