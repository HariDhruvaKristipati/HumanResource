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
    public class TrainingController : Controller
    {
        // GET: Training
        DALTraining daltrain = new DALTraining();
        [HttpGet]
        public ActionResult Show_Training()
        {
            List<Training> list = daltrain.Show_Training();
            List<Trainingclass> modellist = new List<Trainingclass>();
            foreach (var item in list)
            {
                Trainingclass c = new Trainingclass();
                c.ID = item.ID;
                c.TrainingExp = item.TrainingExp;
                c.TrainingName = item.TrainingName;
                c.TrainingPeriod = item.TrainingPeriod;
                c.TrainingStatus = item.TrainingStatus;
                c.PrevEmpExp = item.PrevEmpExp;



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
        public ActionResult Add_Training()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Training(Training form)
        {
            Bal.Training train = new Bal.Training();
            train.ID = form.ID;
            train.TrainingName = form.TrainingName;
            train.TrainingExp = form.TrainingExp;
            train.PrevEmpExp = form.PrevEmpExp;
            train.TrainingPeriod = form.TrainingPeriod;
            train.TrainingStatus = form.TrainingStatus;
            daltrain.Update_Training(train);
            TempData["message"] = "data is inserted";
            daltrain.Add_Training(train);
            TempData["Message"] = "Data id Inserted";
            return RedirectToAction("Show_Training");
        }



        public ActionResult Update_Training(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_Training(int id, Training form)
        {
            Bal.Training train = new Bal.Training();
            train.ID = form.ID;
            train.TrainingName = form.TrainingName;
            train.TrainingExp = form.TrainingExp;
            train.PrevEmpExp = form.PrevEmpExp;
            train.TrainingPeriod = form.TrainingPeriod;
            train.TrainingStatus = form.TrainingStatus;
            daltrain.Update_Training(train);
            TempData["message"] = "data is inserted";
            return RedirectToAction("Show_Training");
        }
        public ActionResult Delete_Training(int id)
        {
            daltrain.Delete_Training(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_Training");
        }

    }
}