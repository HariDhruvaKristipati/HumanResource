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
    public class ResignationController : Controller
    {
        DALResignation dalresign = new DALResignation();
        [HttpGet]
        public ActionResult Show_Resignation()
        {
            List<Resignation> list = dalresign.Show_Resignation();
            List<Resignationclass> modellist = new List<Resignationclass>();
            foreach (var item in list)
            {
                Resignationclass c = new Resignationclass();
                c.ID = item.ID;
                c.DeptName = item.DeptName;
                c.DeptPosition = item.DeptPosition;
                c.ContactNumber = item.ContactNumber;
                c.JoiningDate = item.JoiningDate;
                c.ResignationDate = item.ResignationDate;



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
        public ActionResult Add_Resignation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Resignation(Resignation item)
        {
            Bal.Resignation c = new Bal.Resignation();
            c.ID = item.ID;
            c.DeptName = item.DeptName;
            c.DeptPosition = item.DeptPosition;
            c.ContactNumber = item.ContactNumber;
            c.JoiningDate = item.JoiningDate;
            c.ResignationDate = item.ResignationDate;
            dalresign.Update_Resignation(c);
            TempData["message"] = "data is inserted";
            dalresign.Add_Resignation(c);
            TempData["Message"] = "Data is Inserted";
            return RedirectToAction("Show_Resignation");
        }



        public ActionResult Update_Resignation(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Resignation(int id, Resignation item)
        {
            Bal.Resignation c = new Bal.Resignation();
            c.ID = item.ID;
            c.DeptName = item.DeptName;
            c.DeptPosition = item.DeptPosition;
            c.ContactNumber = item.ContactNumber;
            c.JoiningDate = item.JoiningDate;
            c.ResignationDate = item.ResignationDate;
            dalresign.Update_Resignation(c);
            TempData["message"] = "data is inserted";
            return RedirectToAction("Show_Resignation");
        }
        public ActionResult Delete_Resignation(int id)
        {
            dalresign.Delete_Resignation(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_Resignation");
        }
    }
}

    
