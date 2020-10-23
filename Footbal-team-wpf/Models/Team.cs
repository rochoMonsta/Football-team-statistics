using System;

namespace Footbal_team_wpf.Models
{
    sealed class Team
    {
        #region Fields
        public string Name { get; set; }
        public int scoredGoals { get; private set; } = 0;
        public int missedGoals { get; private set; } = 0;
        public int differenceBetweenGoals
        {
            get { return scoredGoals - missedGoals; }
        }
        #endregion

        #region Constructors 
        public Team(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException(nameof(Name));
            this.Name = Name;
        }
        public Team(string Name, int[] score) : this(Name)
        {
            if (score.Length != 2)
                throw new ArgumentException();

            if (score[0] < -1 || score[1] < -1)
                throw new ArgumentException();

            this.scoredGoals += score[0]; this.missedGoals += score[1];
        }
        #endregion

        #region Methods
        public void AddScoredGoals(int countOfGoals)
        {
            if (countOfGoals > -1)
                scoredGoals += countOfGoals;
        }
        public void AddMissedGoals(int countOfMissedGoals)
        {
            if (countOfMissedGoals > -1)
                missedGoals += countOfMissedGoals;
        }
        public override string ToString()
        {
            return $"Team name: {this.Name}\n\t" +
                   $"Scored goals: {this.scoredGoals}\n\t" +
                   $"Missed goals: {this.missedGoals}\n\t" +
                   $"Difference between goals: {this.differenceBetweenGoals}";
        }
        #endregion
    }
}
