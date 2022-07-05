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
    }
    public partial interface IIdeaRepository
    {
    }
}

