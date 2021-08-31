using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bal;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class ResumeTrackingController : Controller
    {

        DALResumeTracking dalresume = new DALResumeTracking();
        [HttpGet]
        public ActionResult Show_ResumeTracking()
        {
            List<ResumeTracking> list = dalresume.Show_ResumeTracking();
            List<ResumeTrackingclass> modellist = new List<ResumeTrackingclass>();
            foreach (var item in list)
            {
                ResumeTrackingclass c = new ResumeTrackingclass();
                c.ID = item.ID;
                c.Curriculam = item.Curriculam;
                c.WorkExperience = item.WorkExperience;
                c.AreaOfSpecialization = item.AreaOfSpecialization;
                c.AreaOfInterest = item.AreaOfInterest;
                c.Contact = item.Contact;



                modellist.Add(c);
            }
            return View(modellist);
        }



        //[HttpPost]
        //public ActionResult Show_Training()
        //{
        //    return View();
        //}



        // GET: PayRoll
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_ResumeTracking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_ResumeTracking(ResumeTracking item)
        {
            Bal.ResumeTracking c = new Bal.ResumeTracking();
            c.ID = item.ID;
            c.Curriculam = item.Curriculam;
            c.WorkExperience = item.WorkExperience;
            c.AreaOfSpecialization = item.AreaOfSpecialization;
            c.AreaOfInterest = item.AreaOfInterest;
            c.Contact = item.Contact;
            dalresume.Update_ResumeTracking(c);
            TempData["message"] = "data is inserted";
            dalresume.Add_ResumeTracking(c);
            TempData["Message"] = "Data is Inserted";
            return RedirectToAction("Show_ResumeTracking");
        }



        public ActionResult Update_ResumeTracking(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_ResumeTracking(int id, ResumeTracking item)
        {
            Bal.ResumeTracking c = new Bal.ResumeTracking();
            c.ID = item.ID;
            c.Curriculam = item.Curriculam;
            c.AreaOfInterest = item.AreaOfInterest;
            c.AreaOfSpecialization = item.AreaOfSpecialization;
            c.Contact = item.Contact;
            c.WorkExperience = item.WorkExperience;
            dalresume.Update_ResumeTracking(c);
            TempData["message"] = "data is inserted";
            return RedirectToAction("Show_ResumeTracking");
        }
        public ActionResult Delete_ResumeTracking(int id)
        {
            dalresume.Delete_ResumeTracking(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_ResumeTracking");
        }
    }
}