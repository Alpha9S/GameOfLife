using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_of_Life
{
    class Game
    {
        private Random random = new Random();
        private int gridRows;
        private int gridColumns;
        private Cell[][] cells;
        private Grid grid;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="gridRows">amount of rows of the grid</param>
        /// <param name="gridColumns">amount of columns of the grid</param>
        public Game(int gridRows, int gridColumns)
        {
            this.gridRows = gridRows;
            this.gridColumns = gridColumns;
        }

        /// <summary>
        /// getter and setter for the grid variable
        /// </summary>
        public Grid Grid
        {
            get { return this.grid; }
            set { this.grid = value; }
        }

        /// <summary>
        /// Manages the methods used every game tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GameTick(object sender, EventArgs e)
        {
            CellCalculation();
            DrawCircles();
        }

        /// <summary>
        /// uses colors to show living cells and hide dead cells
        /// </summary>
        public void DrawCircles()
        {
            for(int x = 0; x < gridRows; x++)
            {
                for(int y = 0; y < this.gridColumns; y++)
                {
                    if (this.cells[x][y].IsAlive)
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

        /// <summary>
        /// generates random living cells inside the grid
        /// </summary>
        public void RandomCellGeneration()
        {
            for(int x = 0; x < this.gridRows; x++)
            {
                for(int y = 0; y < this.gridColumns; y++)
                {
                    if(random.Next(2) == 1)
                    {
                        this.cells[x][y].IsAlive = true;
                    }
                    else
                    {
                        this.cells[x][y].IsAlive = false;
                    }
                }
            }

            for(int x = 0; x < gridRows; x++)
            {
                for(int y = 0; y < gridColumns; y++)
                {
                    Console.WriteLine(this.cells[x][y].IsAlive);
                }
            }
        }


        /// <summary>
        /// Creates cell objects for every cell inside the grid
        /// </summary>
        /// <param name="grid">The grid object</param>
        /// <returns>Multidimensional array with cell objects inside</returns>
        public void CellGeneration()
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

        /// <summary>
        /// calculates the new generation of cells
        /// with the principle of game of life
        /// </summary>
        private void CellCalculation()
        {
            // new variable for storage of the new cells
            Cell[][] newCells = this.cells.Clone() as Cell[][];
            // stores if decrement/increment for x is possible
            bool xDecrementPossible, xIncrementPossible;
            // stores if decrement/increment for y is possible
            bool yDecrementPossible, yIncrementPossible;

            // loops through rows of the grid
            for (int x = 0; x < gridRows; x++)
            {
                //loops through all columns of the grid
                for(int y = 0; y < gridColumns; y++)
                {
                    int livingAdjacentCells = 0;

                    // checks if a decrement for x is possible
                    if ((x - 1) >= 0)
                    {
                        xDecrementPossible = true;
                    }
                    else
                    {
                        xDecrementPossible = false;
                    }

                    // checks if an increment for x is possible
                    if((x + 1) <= (gridRows - 1))
                    {
                        xIncrementPossible = true;
                    }
                    else
                    {
                        xIncrementPossible = false;
                    }

                    //checks if a decrement for y is possible
                    if((y - 1) >= 0)
                    {
                        yDecrementPossible = true;
                    }
                    else
                    {
                        yDecrementPossible = false;
                    }

                    //checks if an increment for y is possible
                    if((y + 1) <= (gridColumns - 1))
                    {
                        yIncrementPossible = true;
                    } 
                    else
                    {
                        yIncrementPossible = false;
                    }

                    // checks the living state of all adjacent cells
                    if (xDecrementPossible && yDecrementPossible)
                    {
                        if (this.cells[x - 1][y - 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if (yDecrementPossible)
                    {
                        if (this.cells[x][y - 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if(xIncrementPossible && yDecrementPossible)
                    {
                        if (this.cells[x + 1][y - 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if (xDecrementPossible)
                    {
                        if (this.cells[x - 1][y].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if (xIncrementPossible)
                    {
                        if (this.cells[x + 1][y].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if(xDecrementPossible && yIncrementPossible)
                    {
                        if (this.cells[x - 1][y + 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if (yIncrementPossible)
                    {
                        if (this.cells[x][y + 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    if(xIncrementPossible && yIncrementPossible)
                    {
                        if (this.cells[x + 1][y + 1].IsAlive)
                        {
                            livingAdjacentCells++;
                        }
                    }

                    // checks if the current cell is alive
                    if (this.cells[x][y].IsAlive)
                    {
                        // checks if the living adjacent cells are not 2 or 3
                        if((livingAdjacentCells != 2) && (livingAdjacentCells != 3))
                        {
                            // kills the current cell
                            newCells[x][y].IsAlive = false;
                        }
                    }
                    else
                    {
                        // checks if the living adjacent cells are 3
                        if(livingAdjacentCells == 3)
                        {
                            // revives the current cell
                            newCells[x][y].IsAlive = true;
                        }
                    }
                }
            }

            // replaces the old cell states with the new ones
            this.cells = newCells;
        }
    }
}
