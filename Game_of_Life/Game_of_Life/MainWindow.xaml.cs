﻿using System;
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

        public MainWindow()
        {
            int gridColumns = 11;
            int gridRows = 11;

            Random random = new Random();

            // create an array for the coordinates of the cells
            Cell[][] cells = new Cell[gridRows][];

            // loads in XAML elements for usage
            InitializeComponent();

            // Set backgroundcolor
            grid.Background = new SolidColorBrush(Color.FromRgb(230, 200, 200));

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

                    // circle border color and thickness
                    circle.Stroke = Brushes.Black;
                    circle.StrokeThickness = 2;

                    // cell border color and thickness
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1);

                    // margin between circle and cell border
                    circle.Margin = new Thickness(8);

                    // hands over the circle object to the cell object
                    cells[x][y].Circle = circle;
                }
            }

            // sets the color of the circles depending
            // on their conditions
            for (int x = 0; x < gridRows; x++)
            {
                for(int y = 0; y < gridColumns; y++)
                {
                    Cell thisCell = cells[x][y];
                    Ellipse circle = thisCell.Circle;

                    if (thisCell.Condition)
                    {
                        circle.Fill = Brushes.Black;
                    }
                    else
                    {
                        circle.Fill = Brushes.White;
                    }
                }
            }
        }
    }
}
