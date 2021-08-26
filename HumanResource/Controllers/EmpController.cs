using HumanResource.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HumanResource.Controllers
{
    public class EmpController : Controller
    {
        HRMSEntities1 obj = new HRMSEntities1();


        // GET: Emp
        public ActionResult Emp()
        {
            return View();
        }
        
        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(DETAIL d)
        {
            DETAIL obj1 = new DETAIL();
            obj1.Employee_id = d.Employee_id;
            obj1.Employee_Name = d.Employee_Name;
          
            obj1.Address = d.Address;
            obj1.Age = d.Age;
            obj1.phone_number = d.phone_number;
            obj1.Supervisor_Name = d.Supervisor_Name;
            obj1.Department = d.Department;
            obj1.Employee_status = d.Employee_status;
            obj.DETAILS.Add(obj1);
            obj.SaveChanges();
            return View("Emp");

            
        }
        public ActionResult Showemplist()
        {
            var a =obj.DETAILS.ToList();
            return View(a);
        }

        public ActionResult Details(int id)
        {
           
            var v=obj.DETAILS.Where(x=>x.Employee_id == id).FirstOrDefault();
            return View(v);
        }

        public ActionResult Edit(int id)
        {
            var v = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            return View(v);
        }
        [HttpPost]
        public ActionResult Edit(int id, DETAIL detail )
        {
            obj.Entry(detail).State = EntityState.Modified;
            obj.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var v = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            return View(v);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DETAIL detail=obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            obj.DETAILS.Remove(detail);
            obj.SaveChanges();
            return View();
        }
    }
}