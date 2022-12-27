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

        List<List<Button>> buttons = new List<List<Button>>();
        
        public MainWindow()
        {
            InitializeComponent();
            int h = 20;
            int w = 20;
            int b = 20;
            board = new Board(h,w,b);

            for(int i = 0; i < h; i++)
            {
                buttons.Add(new List<Button>());
                for(int j = 0; j < w; j++)
                {
                    Button tempButton = new Button();
                    tempButton.Name =  "_" + i + "_" + j + "_" ;
                    buttons[i].Add(tempButton);
                }
            }
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
