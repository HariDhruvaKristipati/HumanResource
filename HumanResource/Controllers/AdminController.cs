using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bal;
using Dal;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
            
        }
        [HttpPost] 
        public ActionResult Login(Login AC)
        {
            Account_Bal ac = new Account_Bal();
            ac.id = AC.id;
            ac.password = AC.password;
            Dal.Account_Dal d = new Account_Dal();
            Boolean answer=d.Login (ac.id,ac.password);
            if (answer)
                {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }
    }
}