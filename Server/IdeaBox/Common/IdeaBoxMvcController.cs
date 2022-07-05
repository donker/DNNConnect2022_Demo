using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace Connect.IdeaBox.IdeaBox.Common
{
    public class IdeaBoxMvcController : DnnController
    {

        private ContextHelper _IdeaBoxModuleContext;
        public ContextHelper IdeaBoxModuleContext
        {
            get { return _IdeaBoxModuleContext ?? (_IdeaBoxModuleContext = new ContextHelper(this)); }
        }

    }
}