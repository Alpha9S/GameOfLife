using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            test.Background = new SolidColorBrush(Color.FromRgb(230, 200, 200));

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

            // iterates for every row in the grid
            for (int x = 0; x < gridRows; x++)
            {
                // create new row for the array
                cells[x] = new Cell[gridColumns];

                // iterates for every column in the grid
                for (int y = 0; y < gridRows; y++)
                {
                    // creates a new cell object and saves it inside the cell array
                    cells[x][y] = new Cell(x, y, false);
                    // create a new border
                    Border border = new Border();
                    // create new circle
                    Ellipse circle = new Ellipse();
                    // sets the color of the circle border and the filling
                    circle.Stroke = Brushes.Black;
                    circle.Fill = Brushes.White;
                    // sets the thickness of the circle border
                    circle.StrokeThickness = 2;
                    // sets the margin between circle and border
                    circle.Margin = new Thickness(8);
                    // add border and circle to the grid children
                    test.Children.Add(border);
                    test.Children.Add(circle);
                    // border color
                    border.BorderBrush = Brushes.Black;
                    // border thickness
                    border.BorderThickness = new Thickness(1);
                    // set x and y coordinates for the border
                    border.SetValue(Grid.RowProperty, x);
                    border.SetValue(Grid.ColumnProperty, y);
                    // set x and y coordinates for the circle
                    circle.SetValue(Grid.RowProperty, x);
                    circle.SetValue(Grid.ColumnProperty, y);
                }
            }

            // Console output for the coordinates of the cell objects
            for (int x = 0; x < gridColumns; x++)
            {
                for (int y = 0; y < gridRows; y++)
                {
                    Console.WriteLine("X: " + cells[x][y].getX + " Y: " + cells[x][y].getY);
                }
            }
        }
    }
}
