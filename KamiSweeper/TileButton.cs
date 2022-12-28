using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KamiSweeper
{
    internal class TileButton
    {

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

        public TileButton(Grid grid,Board board, List<List<TileButton>> buttons, int height, int width)
        {
            this.btn = new Button();
            this.board = board;
            this.grid = grid;
            this.height = height;
            this.width = width;
            tile = board.board[height][width];
            this.buttons = buttons;


            MoveButton();

        }


        void MoveButton()
        {
            btn.Content = tile.isMine ?  "?b" : "?" + tile.numMines ;
            btn.Name = "_DyanmicButton";
            btn.IsEnabled = true;
            btn.Width = sizeWidth;
            btn.Height = sizeHeight;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.Margin = new Thickness(offset + sizeHeight * (height - 1), offset + sizeWidth * (width - 1), 0, 0);
            btn.Click += Btn_Click;

            grid.Children.Add(btn);
            
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (tile.isMine)
            {
                button.Content = "b";
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

        void clearEmpty(int height, int width)
        {
            try
            {
                for (int iHeight = -1; iHeight <= 1; iHeight++)
                {
                    for (int jWidth = -1; jWidth <= 1; jWidth++)
                    {
                        //TODO: Fix this abomination.
                        if (((iHeight == -1 && jWidth == 0) || (iHeight == 0 && jWidth == -1) || (iHeight == 0 && jWidth == 1) || (iHeight == 1 && jWidth == 0) || (iHeight == 0 && jWidth == 0)) &&
                            ((height + iHeight >= 0) && (width + jWidth >= 0) && (height + iHeight < board.height) && (width + jWidth < board.width)))
                        {

                            Tile tempTile = board.board[height + iHeight][width + jWidth];
                            if (tempTile.numMines == 0 && board.board[height + iHeight][width + jWidth].cleared == false)
                            {
                                board.board[height + iHeight][width + jWidth].cleared = true;
                                buttons[height + iHeight][width + jWidth].btn.Content = "";
                                clearEmpty(height + iHeight, width + jWidth);
                            }
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //out of bounds
            }
        }
    }
}

/*



-1-1  -10  -11

0-1   00   01

1-1   10   11




*/