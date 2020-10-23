using Footbal_team_wpf.Models;
using System.Collections.Generic;
using System.Linq;

namespace Footbal_team_wpf
{
    sealed class Exercise
    {
        public Team GetBestTeamByGoals(Season season)
        {
            return season.teams.FirstOrDefault(t => t.scoredGoals == season.teams.Max(s => s.scoredGoals));
        }
        public Team GetBestTeamByMinMissedGoals(Season season)
        {
            return season.teams.FirstOrDefault(t => t.missedGoals == season.teams.Min(s => s.missedGoals));
        }
        public Team GetBestTeamByMaxGoalsToMissedGoals(Season season)
        {
            int maxDefference = season.teams.Max(s => s.differenceBetweenGoals);

            var teams = season.teams.Where(t => t.differenceBetweenGoals == maxDefference);

            return teams.FirstOrDefault(t => t.scoredGoals == teams.Max(t => t.scoredGoals));
        }
        public GameDay GetBestGameDayByCountOfScore(List<Season> seasons)
        {
            var dateList = new List<GameDay>();

            foreach (var season in seasons)
            {
                foreach (var gameDate in season.matches)
                {
                    if (!dateList.Any(d => d.GameDate == gameDate.date))
                    {
                        if (gameDate.score == null)
                            gameDate.score = new Score(new int[] { 0, 0 });
                        dateList.Add(new GameDay(gameDate.date, gameDate.score.ft));
                    }
                    else
                    {
                        if (gameDate.score != null)
                            dateList[dateList.IndexOf(dateList.FirstOrDefault(d => d.GameDate == gameDate.date))].AddScore(gameDate.score.ft);
                    }
                }
            }
            return dateList.FirstOrDefault(d => d.CountOfGoals == dateList.Max(d => d.CountOfGoals));
        }
    }
}
