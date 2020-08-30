using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace نظام_الاجازات.Controllers
{
    public class OrderVicationController : Controller
    {
        // GET: OrderVication
        public ActionResult Index()
        {
            return PartialView();
        }
        // this function Write By Rawa alanzi & rtkanzi@moj.gov.sa
        [HttpPost]
        public ActionResult SaveData(string typevacation,string comment)
        {
            // this function Write By Rawa alanzi & rtkanzi@moj.gov.sa
            Database1Entities DB = new Database1Entities();
            OrderVication vication = new OrderVication();
            vication.UserID =Int32.Parse( Session["UserID"].ToString());
            vication.TypeVications = typevacation;
            vication.Status = 0;
            vication.Comments = comment;
            DB.OrderVications.Add(vication);
            int number = DB.SaveChanges();
            if (number > 0)
            {
                return Json(new { status = "Success", message = "Success" });
            }
            else
            {
                return Json(new { status = "error", message = "error" });
            }

            
        }
        // this function Write By Rawa alanzi & rtkanzi@moj.gov.sa
        public ActionResult VicationAccept()
        {
           // this function Write By Rawa alanzi & rtkanzi@moj.gov.sa
            Database1Entities DB = new Database1Entities();
            int userID= Int32.Parse(Session["UserID"].ToString());
            List<OrderVication> vications = DB.OrderVications.Where(a => a.UserID == userID && a.Status==1).ToList();
            return PartialView(vications);
        }
        
        public ActionResult VicationReject()
        {
            Database1Entities DB = new Database1Entities();
            int userID = Int32.Parse(Session["UserID"].ToString());
            List<OrderVication> vications = DB.OrderVications.Where(a => a.UserID == userID && a.Status == 2).ToList();
            return PartialView(vications);
        }
        
        public ActionResult Status()
        {
            Database1Entities DB = new Database1Entities();
            int userID = Int32.Parse(Session["UserID"].ToString());
            List<OrderVication> vications = DB.OrderVications.Where(a => a.UserID == userID && a.Status == 0).ToList();
            return PartialView(vications);
        }
    }
}