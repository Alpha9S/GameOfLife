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
        public MainWindow()
        {
            InitializeComponent();

            gameboard.ColumnDefinitions.Add(new ColumnDefinition());
            gameboard.ColumnDefinitions.Add(new ColumnDefinition());
            gameboard.ColumnDefinitions.Add(new ColumnDefinition());
            gameboard.RowDefinitions.Add(new RowDefinition());
            gameboard.RowDefinitions.Add(new RowDefinition());
            gameboard.RowDefinitions.Add(new RowDefinition());

            gameboard.Background = new SolidColorBrush(Color.FromRgb(0, 200, 0));
        }
    }
}
