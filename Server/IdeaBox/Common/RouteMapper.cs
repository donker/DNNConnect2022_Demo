using DotNetNuke.Web.Api;

namespace Connect.IdeaBox.IdeaBox.Common
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Connect/IdeaBox", "IdeaBoxMap1", "{controller}/{action}", null, null, new[] { "Connect.IdeaBox.Api" });
            mapRouteManager.MapHttpRoute("Connect/IdeaBox", "IdeaBoxMap2", "{controller}/{action}/{id}", null, new { id = "-?\\d+" }, new[] { "Connect.IdeaBox.Api" });
        }
    }
}