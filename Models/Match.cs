using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class Match
    {

        public int TimeLeft { get; set; } = 90;


        public Team TeamHome { get; set; }
        public Team TeamGuest { get; set; }

        public bool HomeInPossession { get; set; }
        public bool Played { get; set; }

        public ObservableCollection<MatchLog> Logs { get; set; } //Matchlog will be displayed in mainwindow
        public MatchLog CurrentAction { get; set; }


        double dribbleStreak = 1;
        public Match(Team team1, Team team2)
        {
            TeamHome = team1;
            TeamGuest = team2;
            Logs = new ObservableCollection<MatchLog>();
        }
        void StartTheMatch()
        {
            TeamHome.Score =
            TeamHome.Recieved =
            TeamGuest.Score =
            TeamGuest.Recieved = 0;

            KickOfF(TeamHome);
            HomeInPossession = true;
        }
        public void Cycle()
        {

            if (TimeLeft == 90)
            {
                StartTheMatch();
            }

            var attacker = GetAttackingPlayer();
            var defender = GetDefendingPlayer();

            double shoot = attacker.Shoot() / defender.PositionLevel; 
            double defend = defender.Defend();
            double dribble = attacker.Dribble() / dribbleStreak;
            double pass = attacker.Pass();

            if (shoot >= defend)
            {
                //Score
                dribbleStreak = 1;

                CurrentAction = new MatchLog($"{attacker} scored!", TimeLeft, TeamHome.ReturnActivePlayer(), TeamGuest.ReturnActivePlayer(), HomeInPossession);
                Logs.Insert(0, CurrentAction);
                Score();
            }
            else if (dribble > defend && defender.PositionLevel != 1)
            {
                //Dribble
                dribbleStreak++; //This is to bring the chance of being a Maradona down. Player will have half chance to dribble next player and will be 8ced to pass or lose the ball.
                CurrentAction = new MatchLog($"{attacker} Dribbled {defender}!", TimeLeft, TeamHome.ReturnActivePlayer(), TeamGuest.ReturnActivePlayer(), HomeInPossession);
                Logs.Insert(0, CurrentAction);
                Dribble(defender);
            }
            else if (pass > defend && defender.PositionLevel != 1)
            {
                //Pass
                dribbleStreak = 1.5;
                string oldAttacker = attacker.ToString();
                Pass(attacker, defender);
                attacker = GetAttackingPlayer();
                CurrentAction = new MatchLog($"{oldAttacker} passed to {attacker}!", TimeLeft, TeamHome.ReturnActivePlayer(), TeamGuest.ReturnActivePlayer(), HomeInPossession);
                Logs.Insert(0, CurrentAction);
            }
            else
            {
                //Lose the ball
                dribbleStreak = 1;
                CurrentAction = new MatchLog($"{attacker} Lost the ball to {defender}!", TimeLeft, TeamHome.ReturnActivePlayer(), TeamGuest.ReturnActivePlayer(), HomeInPossession);
                Logs.Insert(0, CurrentAction);
                TurnPossession();
            }
            TimeLeft -= Randomizer.Rnd.Next(1,4);
            if (TimeLeft < 1 )
            {
                MatchEnd();
            }
            
        }

        void TurnPossession()
        {
            ReversePlayerMode(TeamHome);
            ReversePlayerMode(TeamGuest);
            HomeInPossession = !HomeInPossession;
        }
        void ReversePlayerMode(Team team)
        {
            var homeP = team.ReturnActivePlayer();
            if (homeP != null)
            {
                homeP.IsInPossesion = !homeP.IsInPossesion;
                homeP.IsDefending = !homeP.IsDefending;
            }

        }
        void Score()
        {
            if (TeamHome.ReturnAttackinglayer() != null)
            {
                TeamHome.Score++;
                TeamGuest.Recieved++;
                KickOfF(TeamGuest);
            }
            else
            {
                TeamGuest.Score++;
                TeamHome.Recieved++;
                KickOfF(TeamHome);
            }

        }
        void Dribble(Player defeated)
        {
            if (defeated.PositionLevel == 1)
            {
                Score();
                return;
            }
            ChangeDefender(1, defeated);
        }
        void ChangeDefender(int interval, Player defender)
        {
            defender.IsDefending = false;

            if (HomeInPossession)
            {
                TeamGuest.ReturnByPosition(defender.PositionLevel + interval).IsDefending = true;
            }
            else
            {
                TeamHome.ReturnByPosition(defender.PositionLevel + interval).IsDefending = true;
            }
        }
        void ChangeAttacker(int interval, Player attacker)
        {
            attacker.IsInPossesion = false;

            if (!HomeInPossession)
            {
                TeamGuest.ReturnByPosition(attacker.PositionLevel + interval, attacker.Name).IsInPossesion = true;
            }
            else
            {
                TeamHome.ReturnByPosition(attacker.PositionLevel + interval, attacker.Name).IsInPossesion = true;
            }
        }
        void Pass(Player attacker, Player defender)
        {
            ChangeDefender(-1, defender);
            ChangeAttacker(1, attacker);
        }
        void KickOfF(Team teamInPossession)
        {
            TeamHome.Clear();
            TeamGuest.Clear();
            teamInPossession.ReturnByPosition(6).IsInPossesion = true;
            if (teamInPossession == TeamHome)
            {
                TeamGuest.ReturnByPosition(6).IsDefending = true;
                HomeInPossession = true;
            }
            else
            {
                TeamHome.ReturnByPosition(6).IsDefending = true;
                HomeInPossession = false;
            }
            CurrentAction = new MatchLog("Kick off!", TimeLeft, TeamHome.ReturnActivePlayer(), TeamGuest.ReturnActivePlayer(), HomeInPossession);
            Logs.Insert(0, CurrentAction);
        }

        Player GetAttackingPlayer()
        {
            var p = TeamHome.ReturnActivePlayer();
            if (p != null && p.IsInPossesion)
            {
                return p;
            }
            return TeamGuest.ReturnActivePlayer();
        }
        Player GetDefendingPlayer()
        {
            var p = TeamHome.ReturnPlayerDefending();
            if (p != null && p.IsDefending)
            {
                return p;
            }
            return TeamGuest.ReturnPlayerDefending();
        }
        void MatchEnd()
        {
            TeamHome.Results.AddResult(TeamHome.Score, TeamHome.Recieved);
            TeamGuest.Results.AddResult(TeamGuest.Score, TeamGuest.Recieved);
        }
    }
}
