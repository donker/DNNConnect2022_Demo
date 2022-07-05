using DotNetNuke.Instrumentation;
using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;

namespace Connect.IdeaBox.IdeaBox.Common
{
    public class IdeaBoxApiController : DnnApiController
    {
        public static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(DnnApiController));
        
        private ContextHelper _IdeaBoxModuleContext;
        public ContextHelper IdeaBoxModuleContext
        {
            get { return _IdeaBoxModuleContext ?? (_IdeaBoxModuleContext = new ContextHelper(this)); }
        }

        public HttpResponseMessage ServiceError(string message) {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, message);
        }

        public HttpResponseMessage AccessViolation(string message)
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized, message);
        }

    }
}