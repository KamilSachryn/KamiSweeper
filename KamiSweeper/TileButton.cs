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

        public TileButton(Grid grid, Board board, List<List<TileButton>> buttons, int height, int width)
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
            //btn.Content = tile.isMine ?  "?b" : "?" + tile.numMines ;
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
            

            //e.Handled = true;
        }

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
            void revealSurrounding(int height, int width)
        {
            for (int iHeight = -1; iHeight <= 1; iHeight++)
            {
                for (int jWidth = -1; jWidth <= 1; jWidth++)
                {
                    if (isValid(height + iHeight, width + jWidth))
                    {

                        

                    }
                }
            }
        }

        void clearEmpty(int height, int width)
        {

            for (int iHeight = -1; iHeight <= 1; iHeight++)
            {
                for (int jWidth = -1; jWidth <= 1; jWidth++)
                {
                    if (isValid(height + iHeight, width + jWidth))
                    {
                        Tile tempTile = board.board[height + iHeight][width + jWidth];
                        //TODO: Fix this abomination.
                        if (((iHeight == -1 && jWidth == 0) || (iHeight == 0 && jWidth == -1) || (iHeight == 0 && jWidth == 1) || (iHeight == 1 && jWidth == 0) || (iHeight == 0 && jWidth == 0)))// ((height + iHeight >= 0) && (width + jWidth >= 0) && (height + iHeight < board.height) && (width + jWidth < board.width)))
                        {

                            
                            if (tempTile.numMines == 0 && board.board[height + iHeight][width + jWidth].cleared == false)
                            {
                                board.board[height + iHeight][width + jWidth].cleared = true;
                                buttons[height + iHeight][width + jWidth].btn.Content = "";
                                buttons[height + iHeight][width + jWidth].btn.Background = Brushes.Gray;
                                clearEmpty(height + iHeight, width + jWidth);
                            }
                        }

                        if(tempTile.numMines > 0)
                        {
                            buttons[height + iHeight][width + jWidth].btn.Content = tempTile.numMines;
                        }


                    }

                }
            }

        }

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