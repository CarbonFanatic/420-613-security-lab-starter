using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    public class InventoryController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            //Log the error!!
            Debug.WriteLine(filterContext.Exception);
            //Redirect or return a view, but not both.  
            filterContext.Result = RedirectToAction("ServerError", "Error");
           
        }
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GenError()
        {
            throw new Exception("test");
        }
    
}
}