using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.IdeaBox.Models.Votes;

namespace Connect.IdeaBox.Repositories
{
	public partial class VoteRepository : ServiceLocator<IVoteRepository, VoteRepository>, IVoteRepository
    {
    }
    public partial interface IVoteRepository
    {
    }
}

