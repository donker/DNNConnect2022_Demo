using System.Web.Mvc;
using Connect.IdeaBox.IdeaBox.Common;

namespace Connect.IdeaBox.IdeaBox.Controllers
{
    public class HomeController : IdeaBoxMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(IdeaBoxModuleContext.Settings.View);
        }
    }
}
