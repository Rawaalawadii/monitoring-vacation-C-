using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace نظام_الاجازات.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// SaveDetailedInfo write and  Commented By ( Rawa alanzi & rtkanzi@moj.gov.sa )
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="jopCode"></param>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveDetailedInfo(string name, string  department ,string  jopCode ,string  password ,string  username,string UserType )
        {
            // Commented By ( Rawa alanzi & rtkanzi@moj.gov.sa )
            Database1Entities DB = new Database1Entities();
            Employee emp = new Employee();
            emp.Name = name;
            emp.JopCode = jopCode;
            emp.Password = password;
            emp.Username = username;
            emp.UserType =Convert.ToInt32( UserType);
            emp.Department = department;
            DB.Employees.Add(emp);
            int number = DB.SaveChanges();
            if (number > 0)
            {
                return Json(new { status = "Success", message = "Success" });
            }
            else
            {
                return Json(new { status = "Error", message = "Error" });
            }
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            Database1Entities DB = new Database1Entities();
            Employee emp = new Employee();
            var login = DB.Employees.Where(a => a.Username == Username && a.Password == Password).FirstOrDefault();
            if (login != null)
            {
                Session["UserType"] = login.UserType;
                Session["UserID"] = login.ID;
                return Json(new { status = "Success", message = "Success" });
            }
            else
            {
                return Json(new { status = "Error", message = "Error" });
            }
        }
    }
}