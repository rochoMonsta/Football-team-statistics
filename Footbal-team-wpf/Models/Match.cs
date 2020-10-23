using System;
using System.Runtime.Serialization;

namespace Footbal_team_wpf.Models
{
    [DataContract]
    sealed class Match
    {
        #region Fields
        [DataMember]
        public string round { get; private set; }
        [DataMember]
        public string date { get; private set; }
        [DataMember]
        public string team1 { get; private set; }
        [DataMember]
        public string team2 { get; private set; }
        [DataMember]
        public Score score { get; set; }
        #endregion

        #region Constructors 
        public Match() { }
        public Match(string team1, string team2, string date, string round, Score score)
        {
            if (string.IsNullOrWhiteSpace(team1) ||
                string.IsNullOrWhiteSpace(team2) ||
                string.IsNullOrWhiteSpace(round) ||
                string.IsNullOrWhiteSpace(date))
                throw new ArgumentNullException();

            if (score.ft.Length != 2)
                throw new ArgumentException(nameof(score));

            this.team1 = team1; this.team2 = team2; this.date = date; this.round = round; this.score = score;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Round: {this.round}\n\t" +
                   $"Game date: {this.date}\n\t" +
                   $"Team 1 name: {this.team1}\n\t" +
                   $"Team 2 name: {this.team2}\n\t" +
                   $"Score: [{score?.ft[0]} - {score?.ft[1]}]";
        }
        #endregion
    }
}
