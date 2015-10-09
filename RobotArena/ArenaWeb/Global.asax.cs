using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ArenaWeb;

namespace ArenaWeb
{
    public class Global : HttpApplication
    {
        static RobotArena.ArenaList arenas = new RobotArena.ArenaList();
        static public RobotArena.ArenaList Arenas { get { return arenas; } }

        void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
        }
    }
}
