using System;
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
        
        // create an array for the coordinates of the cells
        private Cell[][] cells = new Cell[9][];

        public MainWindow()
        {
            InitializeComponent();

            // Fill in the coordinates of the cells into the array
            for (int x = 0; x < gridRows; x++)
            {
                cells[x] = new Cell[9];

                for (int y = 0; y < gridRows; y++)
                {
                    cells[x][y] = new Cell(x, y);
                }
            }

            // create a new grid
            Grid grid = new Grid();
            // zeige Trennlinien beim Grid
            grid.ShowGridLines = true;
            // Setze Hintergrundfarbe
            grid.Background = new SolidColorBrush(Color.FromRgb(50, 100, 150));

            // create columns for the grid
            for(int i = 0; i < gridColumns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // create rows for the grid
            for (int i = 0; i < gridRows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int x = 0; x < gridColumns; x++)
            {
                for (int y = 0; y < gridRows; y++)
                {
                    Console.WriteLine("X: " + cells[x][y].x + " Y: " + cells[x][y].y);
                }
            }

            
        }
    }
}
