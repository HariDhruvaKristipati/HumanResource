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
    public class PayRollController : Controller
    {
        DALPayRoll dalpay = new DALPayRoll();
       
        [HttpGet]
        public ActionResult Show_PayRoll()
        {
            List<PayRoll> list = dalpay.Show_PayRoll();
            List<PayRollclass> modellist = new List<PayRollclass>();
            foreach (var item in list)
            {
                PayRollclass c = new PayRollclass();
                c.ID = item.ID;
                c.NetPay = item.NetPay;
                c.Allowances = item.Allowances;
                c.Deductions = item.Deductions;
                c.BasicPay = item.BasicPay;
                c.GrossPay = item.GrossPay;
                

                modellist.Add(c);
            }
            return View(modellist);
        }


        // GET: PayRoll
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_PayRoll()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_PayRoll(PayRoll item)
        {
            Bal.PayRoll c = new Bal.PayRoll();
            c.ID = item.ID;
            c.NetPay = item.NetPay;
            c.Allowances = item.Allowances;
            c.Deductions = item.Deductions;
            c.BasicPay = item.BasicPay;
            c.GrossPay = item.GrossPay;

            dalpay.Update_PayRoll(c);
            TempData["message"] = "data is inserted";
            dalpay.Add_PayRoll(c);
            TempData["Message"] = "Data id Inserted";
            return RedirectToAction("Show_PayRoll");
        }
       
           
        
        public ActionResult Update_PayRoll(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update_PayRoll(int id,PayRoll item)
        {
            Bal.PayRoll c = new Bal.PayRoll();
            c.ID = item.ID;
            c.NetPay = item.NetPay;
            c.Allowances = item.Allowances;
            c.Deductions = item.Deductions;
            c.BasicPay = item.BasicPay;
            c.GrossPay = item.GrossPay;
            dalpay.Update_PayRoll(c);
            TempData["message"] = "data is updated";
            return RedirectToAction("Show_PayRoll");
        }

        public ActionResult Delete_PayRoll(int id) {
            dalpay.Delete_PayRoll(id);
            TempData["message"] = "data deleted";
            return RedirectToAction("Show_PayRoll");
        }

       
       
    }
}