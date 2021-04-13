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
            InitializeComponent();

            for(int i = 0; i < gridColumns; i++)
            {
                gameboard.ColumnDefinitions.Add(new ColumnDefinition());
                gameboard.RowDefinitions.Add(new RowDefinition());

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
