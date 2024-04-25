using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_emp_240424.Models
{
    public class studentModelClass
    {
        public int id { get; set; }
        public int roll { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string gender { get; set; }
        public Nullable<int> deptId { get; set; }
        public string deptName { set; get; }
        public virtual tblDepartment tblDepartment { get; set; }
    }
}