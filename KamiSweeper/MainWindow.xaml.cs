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

            int h = 20;
            int w = 20;
            int b = 40;

            int buttonWidth = 30;




            board = new Board(h,w,b);

            for(int iHeight = 0; iHeight < h; iHeight++)
            {
                buttons.Add(new List<TileButton>());
                for(int jWidth = 0; jWidth < w; jWidth++)
                {
                    TileButton temp = new TileButton(_grid, board, buttons, iHeight, jWidth);
                    temp.btn.Click += Btn_Click;
                    buttons[iHeight].Add(temp);


                }
            }
            
            
            
            
            
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
