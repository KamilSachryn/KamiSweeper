using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KamiSweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;

        List<List<TileButton>> buttons = new List<List<TileButton>>();
        
        public MainWindow()
        {
            InitializeComponent();

            //default values
            int boardHeight = 20;
            int boardWidth = 20;
            int boardBombs = 40;
            //set up board size 
            board = new Board(boardHeight,boardWidth,boardBombs);


            //create dynamic buttons in h x w grid
            for(int i_Height = 0; i_Height < boardHeight; i_Height++)
            {
                buttons.Add(new List<TileButton>());
                for(int j_Width = 0; j_Width < boardWidth; j_Width++)
                {
                    TileButton temp = new TileButton(_grid, board, buttons, i_Height, j_Width);
                    buttons[i_Height].Add(temp);


                }
            }
        
        }



    }
}
