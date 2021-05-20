using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_of_Life
{
    class Game
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Random random = new Random();
        private int gridRows;
        private int gridColumns;
        private Cell[][] cells;
        private Grid grid;

        public Game(int gridRows, int gridColumns)
        {
            this.gridRows = gridRows;
            this.gridColumns = gridColumns;
        }

        public Grid Grid
        {
            get { return this.grid; }
            set { this.grid = value; }
        }
        public void Game_Tick(object sender, EventArgs e)
        {
            Random_Cell_Generation();
            Draw_Circles();
        }

        public void Game_Start()
        {
        }

        public void Game_Stop()
        {
        }
        public void Draw_Circles()
        {
            for(int x = 0; x < gridRows; x++)
            {
                for(int y = 0; y < this.gridColumns; y++)
                {
                    if (this.cells[x][y].Condition)
                    {
                        this.cells[x][y].Circle.Fill = Brushes.Black;
                    }
                    else
                    {
                        this.cells[x][y].Circle.Fill = Brushes.White;
                    }
                }
            }
        }
        public void Random_Cell_Generation()
        {
            for(int x = 0; x < this.gridRows; x++)
            {
                for(int y = 0; y < this.gridColumns; y++)
                {
                    if(random.Next(2) == 1)
                    {
                        this.cells[x][y].Condition = true;
                    }
                    else
                    {
                        this.cells[x][y].Condition = false;
                    }
                }
            }
        }

        /// <summary>
        /// Creates cell objects for every cell inside the grid
        /// </summary>
        /// <param name="grid">The grid object</param>
        /// <returns>Multidimensional array with cell objects inside</returns>
        public void Cell_Generation()
        {
            Cell[][] cells = new Cell[this.gridRows][];

            for (int x = 0; x < this.gridRows; x++)
            {
                cells[x] = new Cell[this.gridColumns];

                for (int y = 0; y < this.gridColumns; y++)
                {
                    cells[x][y] = new Cell(x, y, true);
                    Border border = new Border();
                    Ellipse circle = new Ellipse();

                    // add border and circle to the grid children
                    grid.Children.Add(border);
                    grid.Children.Add(circle);

                    // set x and y coordinates for the border
                    border.SetValue(Grid.RowProperty, x);
                    border.SetValue(Grid.ColumnProperty, y);
                    // cell border color and thickness
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1);

                    // set x and y coordinates for the circle
                    circle.SetValue(Grid.RowProperty, x);
                    circle.SetValue(Grid.ColumnProperty, y);
                    // margin between circle and cell border
                    circle.Margin = new Thickness(8);

                    // hands over the circle object to the cell object
                    cells[x][y].Circle = circle;
                }
            }

            this.cells = cells;
        }
    }
}
