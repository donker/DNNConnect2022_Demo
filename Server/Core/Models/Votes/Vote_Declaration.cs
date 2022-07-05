using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.IdeaBox.Data;

namespace Connect.IdeaBox.Models.Votes
{
    [TableName("IdeaBox_Votes")]
    [DataContract]
    public partial class Vote     {

        #region .ctor
        public Vote()
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public int IdeaId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public short Karma { get; set; }
        [DataMember]
        public DateTime VotedOn { get; set; }
        #endregion

        #region Methods
        public void ReadVote(Vote vote)
        {
            if (vote.IdeaId > -1)
                IdeaId = vote.IdeaId;

            if (vote.UserId > -1)
                UserId = vote.UserId;

            if (vote.Karma > -1)
                Karma = vote.Karma;

            VotedOn = vote.VotedOn;

        }
        #endregion

    }
}



