using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace نظام_الاجازات.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            Database1Entities DB = new Database1Entities();
            int userID = Int32.Parse(Session["UserID"].ToString());
            List<OrderVication> vications = DB.OrderVications.ToList();
           
            return PartialView(vications);
            
        }
        
        public ActionResult OrdersVications()
        {
            Database1Entities DB = new Database1Entities();
            int userID = Int32.Parse(Session["UserID"].ToString());
            List<OrderVication> vications = DB.OrderVications.Where(a =>  a.Status==0).ToList();

            return PartialView(vications);

        }
        [HttpPost]
        public ActionResult UpdateData(string ID, string comment, string status )
        {
            Database1Entities DB = new Database1Entities();
            int id = Int32.Parse(ID);
          // var update = DB.OrderVications.Where(a => a.ID == id).FirstOrDefault();

            OrderVication payment = new OrderVication();
            payment = DB.OrderVications.Find(id);
            payment.Status =Convert.ToInt16( status);
            payment.Comments = comment;
            DB.Entry(payment).State = EntityState.Modified;
            DB.SaveChanges();
            return Json(new { status = "Success", message = "Success" });

        }
    }
}