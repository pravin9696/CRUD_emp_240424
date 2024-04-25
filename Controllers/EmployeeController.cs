using CRUD_emp_240424.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_emp_240424.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        

        //show all employees on index view
        public ActionResult Index()
        {
            DB240224Entities db1=new DB240224Entities();
            List<tblEmp> empList = db1.tblEmps.ToList();
            db1.Dispose();

            return View(empList);
        }
        public ActionResult Index1()
        {
            DB240224Entities db1 = new DB240224Entities();
            List<tblEmp> empList = db1.tblEmps.ToList();
            db1.Dispose();

            return View(empList);
        }

        public ActionResult edit(int id) {
            DB240224Entities db1 = new DB240224Entities();
            tblEmp e1=db1.tblEmps.Find(id);
            db1.Dispose();
            List<genderClass> gn = new List<genderClass>()
            {
                new genderClass(){id=1,gender="Male"},
                new genderClass(){id=2,gender="Female"},
                new genderClass(){id=3,gender="Trans"},
            };
            ViewBag.genders = gn;


            if (e1 == null)
            {
                //return View("Index");
                return RedirectToAction("Index");
            }
            else
            {
                return View(e1);
            }

        }
        [HttpPost]
        public ActionResult edit(tblEmp e1)
        {
            DB240224Entities db1 = new DB240224Entities();

            db1.tblEmps.AddOrUpdate(e1);

            int n=db1.SaveChanges();
            

            db1.Dispose();
            if (n>0)
            {
                return RedirectToAction("Index");
            }
              else
            {
                return View();
            }
        }
        public ActionResult delete(int id)
        {
            DB240224Entities db1 = new DB240224Entities();
            tblEmp e=db1.tblEmps.Find(id);
            db1.tblEmps.Remove(e);
            int n = db1.SaveChanges();
            db1.Dispose();
            if (n > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult delete1(int id)
        {
            DB240224Entities db1 = new DB240224Entities();
            tblEmp e1 = db1.tblEmps.Find(id);
            db1.Dispose();
            if (e1 == null)
            {
                //return View("Index");
                return RedirectToAction("Index");
            }
            else
            {
                return View(e1);
            }

        }
        public ActionResult details(int id)
        {
            DB240224Entities db1 = new DB240224Entities();
            tblEmp e1 = db1.tblEmps.Find(id);
            db1.Dispose();
            if (e1 == null)
            {
                //return View("Index");
                return RedirectToAction("Index");
            }
            else
            {
                return View(e1);
            }


        }
    }
}