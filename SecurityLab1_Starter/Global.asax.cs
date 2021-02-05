using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication

    {
        protected void Application_Error()
        {
            HttpContext con = HttpContext.Current;
            var ex = Server.GetLastError();
            Console.WriteLine(ex);
            Exception exception = Server.GetLastError();
            Debug.WriteLine(exception);
            using (EventLog eventLog = new EventLog("Application")) 
            {
                eventLog.Source = "Application"; 
                eventLog.WriteEntry("Even error", EventLogEntryType.Information, 101, 1); 

            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Page :           " + con.Request.Url.ToString());
            sb.AppendLine("Error Message :  " + ex.Message);
            //sb.AppendLine("Inner Message :  " + ex.InnerException.ToString());

            // Here save text file containing this error details
            string fileName = Path.Combine(Server.MapPath("~/Error"), DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt");
            File.WriteAllText(fileName, sb.ToString());
        }

            protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
