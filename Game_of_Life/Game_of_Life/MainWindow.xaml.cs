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
        // amount of grid columns
        private int gridColumns = 11;
        // amount of grid rows
        private int gridRows = 11;

        public MainWindow()
        {
            // create an array for the coordinates of the cells
            Cell[][] cells = new Cell[gridRows][];

            // loads in XAML elements for usage
            InitializeComponent();

            // Setze Hintergrundfarbe
            test.Background = new SolidColorBrush(Color.FromRgb(50, 100, 150));

            // Add columns to the grid
            for(int i = 0; i < gridColumns; i++)
            {
                test.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Add rows for the grid
            for (int i = 0; i < gridRows; i++)
            {
                test.RowDefinitions.Add(new RowDefinition());
            }

            // Fill in the coordinates of the cells into the array 
            // and create a border around the cells
            for (int x = 0; x < gridRows; x++)
            {
                // create new row for the array
                cells[x] = new Cell[gridColumns];

                for (int y = 0; y < gridRows; y++)
                {
                    // creates a new cell object and saves it inside the array
                    cells[x][y] = new Cell(x, y);
                    // create a new border
                    Border border = new Border();
                    // add border to grid
                    test.Children.Add(border);
                    // border color
                    border.BorderBrush = Brushes.Black;
                    // border thickness
                    border.BorderThickness = new Thickness(1);
                    // set x coordinate for the border
                    border.SetValue(Grid.RowProperty, x);
                    // set y coordinate for the border
                    border.SetValue(Grid.ColumnProperty, y);
                }
            }

            // Console output for the coordinates of the cell objects
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
