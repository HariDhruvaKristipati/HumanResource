using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Bal;
using HumanResource.Models;

namespace HumanResource.Controllers
{
    public class PerformanceController : Controller
    {
        DALPerformance dalperform = new DALPerformance();
        [HttpGet]
        public ActionResult Show_Performance()
        {
            List<Performance> list = dalperform.Show_Performance();
            List<Performanceclass> modellist = new List<Performanceclass>();
            foreach (var item in list)
            {
              Performanceclass c = new Performanceclass();
                c.ID = item.ID;
                c.Division = item.Division;
                c.EmpName = item.EmpName;
                c.EvaluationDate = item.EvaluationDate;
                c.EvaluationPeriod = item.EvaluationPeriod;
                c.Evaluator = item.Evaluator;
                c.Vacation = item.Vacation;
                c.SickLeave = item.SickLeave;
                c.Holiday = item.Holiday;
                c.WorkGroup = item.WorkGroup;
               
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
        public ActionResult Add_Performance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Performance(Performance perform)
        {
            Bal.Performance c= new Bal.Performance();

            c.ID = perform.ID;
            c.Division = perform.Division;
            c.EmpName = perform.EmpName;
            c.EvaluationDate = perform.EvaluationDate;
            c.EvaluationPeriod = perform.EvaluationPeriod;
            c.Evaluator =perform.Evaluator;
            c.Vacation = perform.Vacation;
            c.SickLeave = perform.SickLeave;
            c.Holiday = perform.Holiday;
            c.WorkGroup=perform.WorkGroup;


            dalperform.Update_Performance(c);
            TempData["message"] = "data is inserted";
            dalperform.Add_Performance(c);
            TempData["Message"] = "Data id Inserted";
            return RedirectToAction("Show_Performance");
        }



        public ActionResult Update_Performance(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Performance(int id, Performance perform)
        {
            Bal.Performance c = new Bal.Performance();

            c.ID = perform.ID;
            c.Division = perform.Division;
            c.EmpName = perform.EmpName;
            c.EvaluationDate = perform.EvaluationDate;
            c.EvaluationPeriod = perform.EvaluationPeriod;
            c.Evaluator = perform.Evaluator;
            c.Vacation = perform.Vacation;
            c.SickLeave = perform.SickLeave;
            c.Holiday = perform.Holiday;
            c.WorkGroup = perform.WorkGroup;

            dalperform.Update_Performance(c);
            TempData["message"] = "data is inserted";
            return RedirectToAction("Show_Performance");
        }
        public ActionResult Delete_Performance(int id)
        {
            dalperform.Delete_Performance(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_Performance");
        }
    }
}