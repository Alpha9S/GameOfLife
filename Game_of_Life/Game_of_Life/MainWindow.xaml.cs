using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game_of_Life
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int gridColumns = 9;
        int gridRows = 9;

        private Cell[][] cells = new Cell[9][];

        public MainWindow()
        {
            Grid grid = new Grid();
            InitializeComponent();



            for(int i = 0; i < gridColumns; i++)
            {
                cells[i] = new Cell[9];

                for (int x = 0; x < gridRows; x++)
                {
                    cells[i][x] = new Cell(x, i);
                }
            }

            gameboard.Background = new SolidColorBrush(Color.FromRgb(50, 100, 150));
        }
    }
}
