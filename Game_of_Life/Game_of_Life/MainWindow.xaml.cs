using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

/// <summary>
/// Version 0.1
/// Author: Hikmet Özer
/// Author: Leon Hoppe
/// </summary>
namespace Game_of_Life
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private int gridColumns = 11;
        private int gridRows = 11;
        private Cell[][] cells;

        public MainWindow()
        {
            // create an array for the coordinates of the cells
            cells = new Cell[gridRows][];

            // loads in XAML elements for usage
            InitializeComponent();

            // Set backgroundcolor
            grid.Background = Brushes.White;

            // Add columns to the grid
            for(int i = 0; i < gridColumns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Add rows to the grid
            for (int i = 0; i < gridRows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            // iterates for every row in the grid
            for (int x = 0; x < gridRows; x++)
            {
                // create new row for the array
                cells[x] = new Cell[gridColumns];

                // iterates for every column in the grid
                for (int y = 0; y < gridColumns; y++)
                {
                    if(random.Next(2) == 1)
                    {
                        cells[x][y] = new Cell(x, y, true);
                    } else
                    {
                        cells[x][y] = new Cell(x, y, false);
                    }

                    Border border = new Border();
                    Ellipse circle = new Ellipse();

                    // add border and circle to the grid children
                    grid.Children.Add(border);
                    grid.Children.Add(circle);

                    // set x and y coordinates for the border
                    border.SetValue(Grid.RowProperty, x);
                    border.SetValue(Grid.ColumnProperty, y);

                    // set x and y coordinates for the circle
                    circle.SetValue(Grid.RowProperty, x);
                    circle.SetValue(Grid.ColumnProperty, y);

                    // cell border color and thickness
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1);

                    // margin between circle and cell border
                    circle.Margin = new Thickness(8);

                    // hands over the circle object to the cell object
                    cells[x][y].Circle = circle;

                    // fills the circles with color
                    if (cells[x][y].Condition)
                    {
                        circle.Fill = Brushes.Black;
                    }
                    else
                    {
                        circle.Fill = Brushes.White;
                    }

                    
                    
                } // end of for
            } // end of for

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        } // end of method

        private void Timer_Tick(object sender, EventArgs e)
        {
            // iterates for every row in the grid
            for (int x = 0; x < gridRows; x++)
            {
                // iterates for every column in the grid
                for (int y = 0; y < gridColumns; y++)
                {
                    if (random.Next(2) == 1)
                    {
                        cells[x][y].Condition = true;
                        cells[x][y].Circle.Fill = Brushes.Black;

                    }
                    else
                    {
                        cells[x][y].Condition = false;
                        cells[x][y].Circle.Fill = Brushes.White;
                    }
                } // end of for
            } // end of for
        } // end of method
    } // end of class
} // end of namespace
