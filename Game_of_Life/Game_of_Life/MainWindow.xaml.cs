using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;

/// <summary>
/// Version 0.3
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
        private static int gridColumns = 11;
        private static int gridRows = 11;
        private DispatcherTimer timer = new DispatcherTimer();
        private Game game = new Game(gridRows, gridColumns);

        public MainWindow()
        {

            // loads in XAML elements for usage
            InitializeComponent();

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

            game.Grid = grid;
            game.CellGeneration();
            game.RandomCellGeneration();
            AddEvents();
        } // end of method

        private void AddEvents()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += new EventHandler(game.GameTick);
            timer.Start();

            Button button = start_button;
            button.Click += new RoutedEventHandler(GameStartAndStop);
        }

        private void GameStartAndStop(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }
       
    } // end of class
} // end of namespace
