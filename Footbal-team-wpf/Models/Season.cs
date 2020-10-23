using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Footbal_team_wpf.Models
{
    [DataContract]
    sealed class Season
    {
        #region Fields
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public List<Match> matches { get; private set; }

        public List<Team> teams { get; private set; }
        #endregion

        #region Constructors 
        public Season(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));

            this.name = Name;
            this.matches = new List<Match>();
            this.teams = new List<Team>();
        }
        #endregion

        #region Methods
        public void GetTeamsWhoPlayThisSeason()
        {
            teams = new List<Team>();

            foreach (var match in matches)
            {
                if (!teams.Any(t => t.Name == match.team1))
                    teams.Add(new Team(match.team1, match?.score?.ft));
                else
                {
                    int teamIndex = teams.IndexOf(teams.FirstOrDefault(t => t.Name == match.team1));

                    if (match.score != null)
                    {
                        teams[teamIndex].AddScoredGoals(match.score.ft[0]);
                        teams[teamIndex].AddMissedGoals(match.score.ft[1]);
                    }
                }

                if (!teams.Any(t => t.Name == match.team2))
                    teams.Add(new Team(match.team2));
                else
                {
                    int teamIndex = teams.IndexOf(teams.FirstOrDefault(t => t.Name == match.team2));

                    if (match.score != null)
                    {
                        teams[teamIndex].AddScoredGoals(match.score.ft[1]);
                        teams[teamIndex].AddMissedGoals(match.score.ft[0]);
                    }
                }
            }
        }
        #endregion
    }
}
