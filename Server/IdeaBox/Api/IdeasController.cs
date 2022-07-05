using Connect.IdeaBox.IdeaBox.Common;
using Connect.IdeaBox.Models.Ideas;
using Connect.IdeaBox.Repositories;
using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Connect.IdeaBox.Api
{

  public partial class IdeasController : IdeaBoxApiController
  {
    [HttpGet]
    [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
    public HttpResponseMessage Get(int ideaId)
    {
      return Request.CreateResponse(HttpStatusCode.OK, IdeaRepository.Instance.GetIdea(ActiveModule.ModuleID, ideaId));
    }

    [HttpGet]
    [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.View)]
    public HttpResponseMessage List()
    {
      return Request.CreateResponse(HttpStatusCode.OK, IdeaRepository.Instance.GetIdeas(ActiveModule.ModuleID));
    }

    [HttpPost]
    [IdeaBoxAuthorize(SecurityLevel = SecurityAccessLevel.CanSubmit)]
    public HttpResponseMessage Update(IdeaBase idea)
    {
      var ideaId = idea.IdeaId;
      idea.ModuleId = ActiveModule.ModuleID;
      if (ideaId == -1)
      {
        ideaId = IdeaRepository.Instance.AddIdea(idea, UserInfo.UserID).IdeaId;
      }
      else
      {
        IdeaRepository.Instance.UpdateIdea(idea, UserInfo.UserID);
      }
      return Request.CreateResponse(HttpStatusCode.OK, IdeaRepository.Instance.GetIdea(ActiveModule.ModuleID, ideaId));
    }

    [HttpPost]
    [IdeaBoxAuthorize(SecurityLevel = SecurityAccessLevel.Admin)]
    public HttpResponseMessage Delete(int id)
    {
      IdeaRepository.Instance.DeleteIdea(ActiveModule.ModuleID, id);
      return Request.CreateResponse(HttpStatusCode.OK, true);
    }

  }
}

