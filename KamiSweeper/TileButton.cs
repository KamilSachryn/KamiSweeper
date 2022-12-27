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
        int x;
        int y;
        int sizeHeight = 30;
        int sizeWidth = 30;
        float offset = 30;
        Board board;
        Tile tile;
        List<List<TileButton>> buttons;

        public TileButton(Grid grid,Board board, List<List<TileButton>> buttons, int x, int y)
        {
            this.btn = new Button();
            this.board = board;
            this.grid = grid;
            this.x = x;
            this.y = y;
            tile = board.board[x][y];
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
            btn.Margin = new Thickness(offset + sizeHeight * (x - 1), offset + sizeWidth * (y - 1), 0, 0);
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

            clearEmpty(x, y);
            
        }

        void clearEmpty(int x, int y)
        {
            try
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        Tile tempTile = board.board[x + i][y + j];
                        if (tempTile.numMines == 0 && board.board[x + i][y + j].cleared == false)
                        {
                            board.board[x + i][y + j].cleared = true;
                            buttons[x + i][y + j].btn.Content = "";
                            clearEmpty(x + i, y + j);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //out of bounds
            }
        }
    }
}
