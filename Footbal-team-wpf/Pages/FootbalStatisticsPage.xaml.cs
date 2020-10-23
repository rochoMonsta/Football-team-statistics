using Footbal_team_wpf.Models;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Footbal_team_wpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для FootbalStatisticsPage.xaml
    /// </summary>
    public partial class FootbalStatisticsPage : Page
    {
        static Exercise exercise = new Exercise();
        static JsonReader jsonReader = new JsonReader();
        public FootbalStatisticsPage()
        {
            InitializeComponent();
        }

        private void OpenJsonFile(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                path = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + @"\" + System.IO.Path.GetFileName(openFileDialog.FileName);
                GetStatistics(path);
            }   
        }
        private void GetStatistics(string path)
        {
            var season = jsonReader.ReadFromJsonFile(path);
            season.GetTeamsWhoPlayThisSeason();

            SeasonNameLabel.Content = season.name;

            var team1 = exercise.GetBestTeamByGoals(season);

            TeamNameLabel1.Content = team1.Name;
            GoalsScoreBySeason1.Content = team1.scoredGoals;
            MissedGoalsBySeason1.Content = team1.missedGoals;

            var team2 = exercise.GetBestTeamByMinMissedGoals(season);

            TeamNameLabel2.Content = team2.Name;
            GoalsScoreBySeason2.Content = team2.scoredGoals;
            MissedGoalsBySeason2.Content = team2.missedGoals;

            var team3 = exercise.GetBestTeamByMaxGoalsToMissedGoals(season);

            TeamNameLabel3.Content = team3.Name;
            GoalsScoreBySeason3.Content = team3.scoredGoals;
            MissedGoalsBySeason3.Content = team3.missedGoals;
        }

        private void OpenJsonFileMulti(object sender, RoutedEventArgs e)
        {
            var seasonsList = new List<Season>();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var file in openFileDialog.FileNames)
                    seasonsList.Add(jsonReader.ReadFromJsonFile(
                        System.IO.Path.GetDirectoryName(file) + @"\" + System.IO.Path.GetFileName(file)));

                var day = exercise.GetBestGameDayByCountOfScore(seasonsList);

                DayLabel.Content = day.GameDate;
                GoalsScoreByDay.Content = day.CountOfGoals;
            }
        }
    }
}
