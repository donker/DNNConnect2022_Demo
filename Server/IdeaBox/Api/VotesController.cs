using Connect.IdeaBox.IdeaBox.Common;
using Connect.IdeaBox.Models.Votes;
using Connect.IdeaBox.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Connect.IdeaBox.Api
{

  public partial class VotesController : IdeaBoxApiController
  {
    [HttpPost]
    [IdeaBoxAuthorize(SecurityAccessLevel.CanVote)]
    public HttpResponseMessage Vote(Vote vote)
    {
      vote.UserId = UserInfo.UserID;
      vote.VotedOn = System.DateTime.Now;
      var v = VoteRepository.Instance.GetVote(vote.IdeaId, vote.UserId);
      if (v == null)
      {
        VoteRepository.Instance.AddVote(vote);
      }
      else
      {
        VoteRepository.Instance.UpdateVote(vote);
      }
      return Request.CreateResponse(HttpStatusCode.OK, IdeaRepository.Instance.GetIdea(ActiveModule.ModuleID, vote.IdeaId));
    }
  }
}

