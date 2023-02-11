using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class ReportsController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: Report
        public ActionResult Report_cust()
        {

            return View(db.customers.ToList());

        }
        [HttpPost]
        public ActionResult Report_cust(string name)
        {
            var data = db.customers.ToList();
            if (name != null)
            {
                data = db.customers.Where(model => model.Ccontact.Contains(name)).ToList();
            }

            return View(data);
        }

        public ActionResult Due_Payment()
        {
            return View(db.orderlist_pw.ToList());
        }
        public ActionResult Duepayment_ww()
        {
            return View(db.orderlist_ww.ToList());
        }
        public ActionResult Duepayment_pkw()
        {
            return View(db.orderlist_pkw.ToList());
        }
    }
}