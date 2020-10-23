using System;
using System.Collections.Generic;
using System.Text;

namespace Footbal_team_wpf.Models
{
    sealed class GameDay
    {
        #region Fields
        public string GameDate { get; private set; }
        public int CountOfGoals { get; private set; } = 0;
        #endregion

        #region Constructors 
        public GameDay(string GameDate, int[] score)
        {
            if (string.IsNullOrWhiteSpace(GameDate))
                throw new ArgumentNullException();

            if (score.Length != 2)
                throw new ArgumentException();

            if (score[0] < -1 || score[1] < -1)
                throw new ArgumentException();

            this.GameDate = GameDate; this.CountOfGoals += score[0] + score[1];
        }
        #endregion

        #region Methods
        public void AddScore(int[] score)
        {
            if (score.Length != 2)
                throw new ArgumentException();

            if (score[0] < -1 || score[1] < -1)
                throw new ArgumentException();
            this.CountOfGoals += score[0] + score[1];
        }
        public override string ToString()
        {
            return $"Game date: {this.GameDate}\n" +
                   $"Count of goals: {this.CountOfGoals}";
        }
        #endregion
    }
}
