using System.Runtime.Serialization;

namespace Footbal_team_wpf.Models
{
    [DataContract]
    sealed class Score
    {
        #region Fields
        [DataMember]
        public int[] ft { get; private set; }
        #endregion

        #region Constructors 
        public Score(int[] score) => this.ft = score;
        #endregion
    }
}
