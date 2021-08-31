
using HumanResource.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;



namespace HumanResource.Controllers
{
    public class EmpController : Controller
    {
        HRMSEntities1 obj = new HRMSEntities1();


        // GET: Emp
        public ActionResult ListEmp()
        {
           List<DETAIL> det= obj.DETAILS.ToList();
            List<EmpDetails> empdet = new List<EmpDetails>();
            foreach (var item in det)
            {
                EmpDetails d = new EmpDetails();
                d.Employee_id = item.Employee_id;
                d.Employee_Name = item.Employee_Name;
                d.Employee_status = item.Employee_status;
                d.Address = item.Employee_Name;
                d.Phone_number = item.phone_number;
                d.Supervisior_Name = item.Supervisor_Name;
                d.Department = item.Department;
                d.Age = item.Age;
                empdet.Add(d);


            }    
            return View(empdet);

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpDetails d)
        {
            DETAIL obj1 = new DETAIL();
            obj1.Employee_id = d.Employee_id;
            obj1.Employee_Name = d.Employee_Name;

            obj1.Address = d.Address;
            obj1.Age = d.Age;
            obj1.phone_number = d.Phone_number;
            obj1.Supervisor_Name = d.Supervisior_Name;
            obj1.Department = d.Department;
            obj1.Employee_status = d.Employee_status;
            obj.DETAILS.Add(obj1);
            obj.SaveChanges();
            return RedirectToAction("ListEmp");
            
        }

        public ActionResult Delete(int id)
        {
            var v = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            EmpDetails d = new EmpDetails();
            d.Employee_id = v.Employee_id;
            d.Employee_Name = v.Employee_Name;
            d.Employee_status = v.Employee_status;
            d.Supervisior_Name = v.Supervisor_Name;
            d.Department = v.Department;
            d.Age = v.Age;
            d.Address = v.Address;
            return View(d);
        }
        [HttpPost]
        public ActionResult Delete(int id, EmpDetails details)
        {
            DETAIL detail = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            obj.DETAILS.Remove(detail);
            obj.SaveChanges();
            return RedirectToAction("ListEmp");
        }
        public ActionResult Edit(int id)
        {
            var v = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            EmpDetails d = new EmpDetails();
            d.Employee_id = v.Employee_id;
            d.Employee_Name = v.Employee_Name;
            d.Employee_status = v.Employee_status;
            d.Supervisior_Name = v.Supervisor_Name;
            d.Department = v.Department;
            d.Age = v.Age;
            d.Address = v.Address;
            return View(d);
        }
        [HttpPost]
        public ActionResult Edit(int id, EmpDetails detail)
        {
            DETAIL d = new DETAIL();
            d.Employee_id = detail.Employee_id;

            var v = obj.DETAILS.Where(x => x.Employee_id == d.Employee_id).FirstOrDefault();
            v.Employee_Name = detail.Employee_Name;
            v.Department = detail.Department;
            v.Employee_status = detail.Employee_status;
            v.Address = detail.Address;
            v.Age = detail.Age;
            v.Supervisor_Name = detail.Supervisior_Name;


            obj.SaveChanges();
            return RedirectToAction("ListEmp");
        }

        public ActionResult Details(int id)
        {
            var v = obj.DETAILS.Where(x => x.Employee_id == id).FirstOrDefault();
            EmpDetails d = new EmpDetails();
            d.Employee_id = v.Employee_id;
            d.Employee_Name = v.Employee_Name;
            d.Department = v.Department;
            d.Employee_status = v.Employee_status;
            d.Address = v.Address;
            d.Age = v.Age;
            d.Supervisior_Name = v.Supervisor_Name;

            

            return View(d);

         
        }





    }
}