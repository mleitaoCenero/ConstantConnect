using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ConstantConnect.MVCClient.App_Start;
using System;

namespace ConstantConnect.MVCClient
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Orgin", "*");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}