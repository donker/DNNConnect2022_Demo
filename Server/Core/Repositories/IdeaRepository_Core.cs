using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.IdeaBox.Models.Ideas;

namespace Connect.IdeaBox.Repositories
{

	public partial class IdeaRepository : ServiceLocator<IIdeaRepository, IdeaRepository>, IIdeaRepository
 {
        protected override Func<IIdeaRepository> GetFactory()
        {
            return () => new IdeaRepository();
        }
        public IEnumerable<Idea> GetIdeas(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Idea>();
                return rep.Get(moduleId);
            }
        }
        public Idea GetIdea(int moduleId, int ideaId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Idea>();
                return rep.GetById(ideaId, moduleId);
            }
        }
        public IdeaBase AddIdea(IdeaBase idea, int userId)
        {
            Requires.NotNull(idea);
            Requires.PropertyNotNegative(idea, "ModuleId");
            idea.CreatedByUserID = userId;
            idea.CreatedOnDate = DateTime.Now;
            idea.LastModifiedByUserID = userId;
            idea.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<IdeaBase>();
                rep.Insert(idea);
            }
            return idea;
        }
        public void DeleteIdea(IdeaBase idea)
        {
            Requires.NotNull(idea);
            Requires.PropertyNotNegative(idea, "IdeaId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<IdeaBase>();
                rep.Delete(idea);
            }
        }
        public void DeleteIdea(int moduleId, int ideaId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<IdeaBase>();
                rep.Delete("WHERE ModuleId = @0 AND IdeaId = @1", moduleId, ideaId);
            }
        }
        public void UpdateIdea(IdeaBase idea, int userId)
        {
            Requires.NotNull(idea);
            Requires.PropertyNotNegative(idea, "IdeaId");
            idea.LastModifiedByUserID = userId;
            idea.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<IdeaBase>();
                rep.Update(idea);
            }
        } 
    }
    public partial interface IIdeaRepository
    {
        IEnumerable<Idea> GetIdeas(int moduleId);
        Idea GetIdea(int moduleId, int ideaId);
        IdeaBase AddIdea(IdeaBase idea, int userId);
        void DeleteIdea(IdeaBase idea);
        void DeleteIdea(int moduleId, int ideaId);
        void UpdateIdea(IdeaBase idea, int userId);
    }
}

