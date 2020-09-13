using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace X06Reservation
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Temporary;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("History", "AboutUs/History", "~/History.aspx");
            routes.MapPageRoute("Directions", "AboutUs/Directions", "~/Directions.aspx");
        }
    }

    public class MyUrlResolver : WebFormsFriendlyUrlResolver
    {
        protected override bool TrySetMobileMasterPage(HttpContextBase ctx,
            System.Web.UI.Page page, string mobileSuffix)
        {
            return false;
        }

        public override string ConvertToFriendlyUrl(string path)
        {
            if (path.Contains("History") || path.Contains("Directions"))
                return "~/AboutUs" + path.Replace(".aspx", "");
            return base.ConvertToFriendlyUrl(path);
        }
    }

}
