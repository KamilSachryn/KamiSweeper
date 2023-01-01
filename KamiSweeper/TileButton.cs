using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KamiSweeper
{
    internal class TileButton
    {
        //default settings
        public Button btn;
        Grid grid;
        int height;
        int width;
        int sizeHeight = 30;
        int sizeWidth = 30;
        float offset = 30;
        Board board;
        Tile tile;
        List<List<TileButton>> buttons;


        //create button object
        public TileButton(Grid grid, Board board, List<List<TileButton>> buttons, int height, int width)
        {
            this.btn = new Button();
            this.board = board;
            this.grid = grid;
            this.height = height;
            this.width = width;
            tile = board.board[height][width];
            this.buttons = buttons;

            
            createDynamicButton();

        }

        //creates and implements clickable button
        void createDynamicButton()
        {
            btn.Name = "_DyanmicButton";
            btn.IsEnabled = true;
            btn.Width = sizeWidth;
            btn.Height = sizeHeight;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Margin = new Thickness(offset + sizeHeight * (height - 1), offset + sizeWidth * (width - 1), 0, 0);
            btn.PreviewMouseRightButtonUp += Btn_RightClick;
            btn.PreviewMouseLeftButtonUp += Btn_LeftClick;
            btn.Background = Brushes.Gray;
            grid.Children.Add(btn);

        }

        //on left click up trigger the tile
        //if its a mine, lose the game
        //if its a 0 explore tiles around it
        //if its a number reveal the number
        private void Btn_LeftClick(object sender, MouseButtonEventArgs e)
        {
            Button button = (Button)sender;
            if (tile.isMine)
            {
                button.Content = "b";
                buttons[height][width].btn.Background = Brushes.Red;
            }
            else
            {
                button.Content = tile.numMines;
            }

            if (tile.numMines == 0)
            {
                clearEmpty(height, width);
            }
            

        }

        //on right click set flag
        private void Btn_RightClick(object sender, MouseButtonEventArgs e)
        {
            if(buttons[height][width].btn.Background == Brushes.Blue)
            {
                buttons[height][width].btn.Background = Brushes.Gray;
            }
            else
            {
                buttons[height][width].btn.Background = Brushes.Blue;
            }
            

        }

        //checks and clears 0 tiles around a clicked 0 tile
        void clearEmpty(int height, int width)
        {
            
            for (int iHeight = -1; iHeight <= 1; iHeight++)
            {
                for (int jWidth = -1; jWidth <= 1; jWidth++)
                {
                    //if its on the board
                    if (isValid(height + iHeight, width + jWidth))
                    {
                        Tile tempTile = board.board[height + iHeight][width + jWidth];
                        //TODO: Fix this abomination.
                        //check only the 4 tiles in cardinal directions 
                        if (((iHeight == -1 && jWidth == 0) || (iHeight == 0 && jWidth == -1) || (iHeight == 0 && jWidth == 1) || (iHeight == 1 && jWidth == 0) || (iHeight == 0 && jWidth == 0)))// ((height + iHeight >= 0) && (width + jWidth >= 0) && (height + iHeight < board.height) && (width + jWidth < board.width)))
                        {

                            //if its a 0, and it has not been checked before
                            if (tempTile.numMines == 0 && board.board[height + iHeight][width + jWidth].cleared == false)
                            {
                                //set cleared
                                board.board[height + iHeight][width + jWidth].cleared = true;
                                //change to empty
                                buttons[height + iHeight][width + jWidth].btn.Content = "";
                                buttons[height + iHeight][width + jWidth].btn.Background = Brushes.Gray;
                                //recurse around this tile
                                clearEmpty(height + iHeight, width + jWidth);
                            }
                        }

                        //if its a numbered tile anywhere around current 0 tile
                        if(tempTile.numMines > 0)
                        {
                            //set to number
                            buttons[height + iHeight][width + jWidth].btn.Content = tempTile.numMines;
                        }


                    }

                }
            }

        }

        //check if chosen tile is in the board, out of range protection
        bool isValid(int h, int w)
        {
            return ((h >= 0) && (w >= 0) && (h < board.height) && (w < board.width));
        }
    }
}

/*



-1-1  -10  -11

0-1   00   01

1-1   10   11




*/