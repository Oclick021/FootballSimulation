using FootballSim.Models;
using FootballSim.Utils;
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

namespace FootballSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Match ActiveMatch { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tournoment tour = new Tournoment();

            MatchesDataGrid.DataContext = tour;
        }

    
        private void StartMatchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MatchesDataGrid.SelectedItem is Match SelectedMatch)
            {
                ActiveMatch = SelectedMatch;
                ActiveMatch.StartMatch();
                while (ActiveMatch.MatchTime> 0)
                {
                    ActiveMatch.Cycle();
                }
            }
        }
    }
}
