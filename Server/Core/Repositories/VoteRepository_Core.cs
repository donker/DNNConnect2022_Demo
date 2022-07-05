using System;
using System.Collections.Generic;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.IdeaBox.Models.Votes;

namespace Connect.IdeaBox.Repositories
{

	public partial class VoteRepository : ServiceLocator<IVoteRepository, VoteRepository>, IVoteRepository
 {
        protected override Func<IVoteRepository> GetFactory()
        {
            return () => new VoteRepository();
        }
        public IEnumerable<Vote> GetVotesByIdea(int ideaId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Vote>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE IdeaId=@0",
                    ideaId);
            }
        }
        public IEnumerable<Vote> GetVotesByUser(int userId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Vote>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE UserId=@0",
                    userId);
            }
        }
        public Vote GetVote(int ideaId, int userId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Vote>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE IdeaId=@0 AND UserId=@1",
                    ideaId,userId);
            }
        }
        public void AddVote(Vote vote)
        {
            Requires.NotNull(vote);
            Requires.NotNull(vote.IdeaId);
            Requires.NotNull(vote.UserId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "IF NOT EXISTS (SELECT * FROM {databaseOwner}{objectQualifier}IdeaBox_Votes " +
                    "WHERE IdeaId=@0 AND UserId=@1) " +
                    "INSERT INTO {databaseOwner}{objectQualifier}IdeaBox_Votes (IdeaId, UserId, Karma, VotedOn) " +
                    "SELECT @0, @1, @2, @3", vote.IdeaId, vote.UserId, vote.Karma, vote.VotedOn);
            }
        }
        public void DeleteVote(Vote vote)
        {
            DeleteVote(vote.IdeaId, vote.UserId);
        }
        public void DeleteVote(int ideaId, int userId)
        {
             Requires.NotNull(ideaId);
             Requires.NotNull(userId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE IdeaId=@0 AND UserId=@1",
                    ideaId,userId);
            }
        }
        public void DeleteVotesByIdea(int ideaId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE IdeaId=@0",
                    ideaId);
            }
        }
        public void DeleteVotesByUser(int userId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}IdeaBox_Votes WHERE UserId=@0",
                    userId);
            }
        }
        public void UpdateVote(Vote vote)
        {
            Requires.NotNull(vote);
            Requires.NotNull(vote.IdeaId);
            Requires.NotNull(vote.UserId);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Vote>();
                rep.Update("SET Karma=@0, VotedOn=@1 WHERE IdeaId=@2 AND UserId=@3",
                          vote.Karma,vote.VotedOn, vote.IdeaId,vote.UserId);
            }
        } 
 }

    public partial interface IVoteRepository
    {
        IEnumerable<Vote> GetVotesByIdea(int ideaId);
        IEnumerable<Vote> GetVotesByUser(int userId);
        Vote GetVote(int ideaId, int userId);
        void AddVote(Vote vote);
        void DeleteVote(Vote vote);
        void DeleteVote(int ideaId, int userId);
        void DeleteVotesByIdea(int ideaId);
        void DeleteVotesByUser(int userId);
        void UpdateVote(Vote vote);
    }
}

