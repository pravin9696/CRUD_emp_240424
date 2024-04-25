using CRUD_emp_240424.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_emp_240424.Controllers
{
    public class Temp2504Controller : Controller
    {
        // GET: Temp2504
        public ActionResult Index()
        {
            DB240224Entities dbo=new DB240224Entities();
            List<tblStudent> stlist = dbo.tblStudents.ToList();

            return View(stlist);
        }
        public ActionResult edit(int id)
        {
            DB240224Entities dbo = new DB240224Entities();
            tblStudent st = dbo.tblStudents.Find(id);

            List<tblDepartment> depts = dbo.tblDepartments.ToList();
            ViewBag.depts = depts;

            List<genderClass> gn = new List<genderClass>()
            {
                new genderClass(){id=1,gender="Male"},
                new genderClass(){id=2,gender="Female"},
                new genderClass(){id=3,gender="Trans"},
            };
            ViewBag.genders = gn;

            if (st!=null)
            {
                return View(st);
            }
            return View();
        }
        [HttpPost]
        public ActionResult edit(tblStudent st)
        {
            return View();
        }
     }
  }