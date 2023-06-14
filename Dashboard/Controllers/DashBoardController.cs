using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class DashBoardController : Controller
    {
        RahulPracticeEntities db = new RahulPracticeEntities();
        // GET: DashBoard
        public ActionResult Dashboard()
        {
            return View();
        }
        
        public JsonResult getData() { 
            string student = "student";
            string faculty = "faculty";
            string admin = "admin";
            List<object> data = new List<object>();
            //List<string> username = db.users.Select(p=>p.Username).ToList();
            //data.Add(username);
            int studentCount = (from num in db.users
                         where num.Users == student
                                  select num).Count();
            data.Add(studentCount);
            int facultyCount = (from num in db.users
                                where num.Users == faculty
                                select num).Count();
            data.Add(facultyCount);
            int adminCount = (from num in db.users
                                where num.Users == admin
                              select num).Count();
            data.Add(adminCount);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}