using FootballSim.Models;
using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace FootballSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Match ActiveMatch { get; set; }
        public ObservableCollection<MatchLog> MatchLog = new ObservableCollection<MatchLog>();
        Tournoment tour = new Tournoment();

        public MainWindow()
        {
            InitializeComponent();
            MatchesDataGrid.DataContext = tour;
            Results.ItemsSource = tour.Teams;
        }

        private void StartMatchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MatchesDataGrid.SelectedItem is Match SelectedMatch)
            {
                ActiveMatch = SelectedMatch;
                MatchDataGrid.ItemsSource = ActiveMatch.Logs;
                MatchGrid.DataContext = ActiveMatch;
                HomeTeamDataGrid.ItemsSource = ActiveMatch.TeamHome.Players;
                GuestTeamDataGrid.ItemsSource = ActiveMatch.TeamGuest.Players;
                while (ActiveMatch.TimeLeft > 0)
                {
                    ActiveMatch.Cycle();
                    MatchGrid.DataContext = null;
                    MatchGrid.DataContext = ActiveMatch;
                    HomeTeamDataGrid.Items.Refresh();
                    GuestTeamDataGrid.Items.Refresh();
                    DoEvents();
                }
                ActiveMatch.Played = true;
                MatchesDataGrid.Items.Refresh();
                Results.Items.Refresh();
            }
        }

    


        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrames), frame);
            Dispatcher.PushFrame(frame);
        }
        public object ExitFrames(object f)
        {
            ((DispatcherFrame)f).Continue = false;

            return null;
        }
    }
}
