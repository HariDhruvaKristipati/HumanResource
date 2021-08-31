using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumanResource.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee_Details()
        {
            ViewBag.message = "employee.";
            Response.Redirect("Display.aspx");

            return View();
        }

       
        
    }
}