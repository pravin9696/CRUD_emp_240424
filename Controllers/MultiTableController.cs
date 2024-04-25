using CRUD_emp_240424.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_emp_240424.Controllers
{
    public class MultiTableController : Controller
    {
        // GET: MultiTable
        public ActionResult Index()
        {
            DB240224Entities dbo = new DB240224Entities();

            List<tblStudent> studList = dbo.tblStudents.ToList();
            List<studentModelClass> studMClass = studList.Select(x => new studentModelClass
            {
                id = x.id,
                deptId = x.deptId,
                DOB = x.DOB,
                gender = x.gender,
                name = x.name,
                roll = x.roll,
                deptName = x.tblDepartment.Dept
            }).ToList();
            return View(studMClass);
        }
        public ActionResult Edit(int id)
        {
            DB240224Entities dbo = new DB240224Entities();
            var stud = dbo.tblStudents.Find(id);
            studentModelClass smc = new studentModelClass();
            smc.id = stud.id;
            List<tblDepartment> deptList = dbo.tblDepartments.ToList();
            ViewBag.depts = deptList;

            if (stud != null)
            {
                smc.id = stud.id;
                smc.roll = stud.roll;
                smc.name = stud.name;
                smc.DOB = stud.DOB;
                smc.gender = stud.gender;
                smc.deptId = stud.deptId;
                return View(smc);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Edit(studentModelClass smc)
        {
            DB240224Entities dbo = new DB240224Entities();

            tblStudent st = dbo.tblStudents.Find(smc.id);
            if (st != null)
            {
                st.roll = smc.roll;
                st.name = smc.name;
                st.DOB = smc.DOB;
                st.gender = smc.gender;
                st.deptId = smc.deptId;
                dbo.tblStudents.AddOrUpdate(st);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }

}