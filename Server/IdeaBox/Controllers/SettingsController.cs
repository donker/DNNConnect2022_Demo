using Connect.IdeaBox.IdeaBox.Common;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using System.Web.Mvc;

namespace Connect.IdeaBox.IdeaBox.Controllers
{
  [DnnModuleAuthorize(AccessLevel = DotNetNuke.Security.SecurityAccessLevel.Edit)]
  [DnnHandleError]
  public class SettingsController : IdeaBoxMvcController
  {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult Settings()
    {
      return View(IdeaBoxModuleContext.Settings);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="supportsTokens"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateInput(false)]
    [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
    public ActionResult Settings(ModuleSettings settings)
    {
      settings.SaveSettings(ModuleContext.Configuration);
      return RedirectToDefaultRoute();
    }
  }
}