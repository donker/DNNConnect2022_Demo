using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using DotNetNuke.Instrumentation;
using DotNetNuke.Web.Api;

namespace Connect.IdeaBox.IdeaBox.Common
{
  public enum SecurityAccessLevel
  {
    Anonymous = 0,
    Authenticated = 1,
    View = 2,
    Edit = 3,
    Admin = 4,
    Host = 5,
    CanSubmit = 6,
    CanVote = 7
  }

  public class IdeaBoxAuthorizeAttribute : AuthorizeAttributeBase, IOverrideDefaultAuthLevel
  {
    private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(IdeaBoxAuthorizeAttribute));
    public SecurityAccessLevel SecurityLevel { get; set; }
    public UserInfo User { get; set; }

    public IdeaBoxAuthorizeAttribute()
    {
      SecurityLevel = SecurityAccessLevel.Admin;
    }

    public IdeaBoxAuthorizeAttribute(SecurityAccessLevel accessLevel)
    {
      SecurityLevel = accessLevel;
    }

    public override bool IsAuthorized(AuthFilterContext context)
    {
      Logger.Trace("IsAuthorized");
      if (SecurityLevel == SecurityAccessLevel.Anonymous)
      {
        Logger.Trace("Anonymous");
        return true;
      }
      User = HttpContextSource.Current.Request.IsAuthenticated ? UserController.Instance.GetCurrentUserInfo() : new UserInfo();
      Logger.Trace("UserId " + User.UserID.ToString());
      ContextSecurity security = ContextSecurity.GetSecurity(context.ActionContext.Request.FindModuleInfo());
      Logger.Trace(security.ToString());
      switch (SecurityLevel)
      {
        case SecurityAccessLevel.Authenticated:
          return User.UserID != -1;
        case SecurityAccessLevel.Host:
          return User.IsSuperUser;
        case SecurityAccessLevel.Admin:
          return security.IsAdmin;
        case SecurityAccessLevel.Edit:
          return security.CanEdit;
        case SecurityAccessLevel.View:
          return security.CanView;
        case SecurityAccessLevel.CanSubmit:
          return security.CanSubmit;
        case SecurityAccessLevel.CanVote:
          return security.CanVote;
      }
      return false;
    }
  }
}
