using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Net;

namespace LMS.Controllers
{
    public class OrderListController : Controller
    {
        lmsEntities db = new lmsEntities();
        public void List_pw()
        {
            List<customer> cust = db.customers.ToList();
            ViewBag.custl = new SelectList(cust, "Cfn", "Cfn");
            List<priceList_pw> pw = db.priceList_pw.ToList();
            ViewBag.pwl = new SelectList(pw, "PWcode", "PWcode");
            ViewBag.pws = new SelectList(pw, "PWservice", "PWservice");
            List<delstatu> ds = db.delstatus.ToList();
            ViewBag.ds = new SelectList(ds, "DSstatus", "DSstatus");
            
        }
        public void List_ww()
        {
            List<customer> cust = db.customers.ToList();
            ViewBag.custl = new SelectList(cust, "Cfn", "Cfn");
            List<priceList_ww> pw = db.priceList_ww.ToList();
            ViewBag.pwl = new SelectList(pw, "PWcode", "PWcode");
            List<delstatu> ds = db.delstatus.ToList();
            ViewBag.ds = new SelectList(ds, "DSstatus", "DSstatus");
        }
        public void List_pkw()
        {
            List<customer> cust = db.customers.ToList();
            ViewBag.custl = new SelectList(cust, "Cfn", "Cfn");
            List<priceList_pkw> pw = db.priceList_pkw.ToList();
            ViewBag.pwl = new SelectList(pw, "PKWcode", "PKWcode");
            List<delstatu> ds = db.delstatus.ToList();
            ViewBag.ds = new SelectList(ds, "DSstatus", "DSstatus");
        }
        // GET: OrderList
        public ActionResult OrderList_pw()
        {

            return View(db.orderlist_pw.ToList());
        }
        public ActionResult Create_pw()
        {
            List_pw();
            return View();
        }
      
        public JsonResult CalculatePrice(string selectedcode, int countOrWeight)
        {
            priceList_pw pw = db.priceList_pw.FirstOrDefault(a => a.PWcode == selectedcode);
            decimal price = countOrWeight * pw.PWprice;

            return Json(price, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Service(string code)
        {
            priceList_pw pw = db.priceList_pw.FirstOrDefault(a => a.PWcode == code);
            string service = pw.PWservice;

            return Json(service, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Advance(string code, decimal  count, int qty)
        {
            priceList_pw pw = db.priceList_pw.FirstOrDefault(a => a.PWcode == code);
            decimal advance = (qty * pw.PWprice) - count;


            return Json(advance, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create_pw(orderlist_pw opw)
        {
            if (ModelState.IsValid)
            {
                List_pw();
                db.orderlist_pw.Add(opw);
                db.SaveChanges();

                WebClient client = new WebClient();
                string message;
                message = "Thanking Your For Your PieceWise Order  Regard: LM(Laundry Management) Your Responsibility Is Our Pride";
                string baseURL = "https://platform.clickatell.com/messages/http/send?apiKey=zcMDpK05ToO220Ay-dIyXQ==&to=923090832359&content=" + message.ToString() + "'&text=" + message + ".";
                client.OpenRead(baseURL);

            }

            return View();
        }
        public ActionResult Edit_pw(int id)
        {
            List_pw();
            var data = db.orderlist_pw.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit_pw(orderlist_pw pw, int id)
        {
            if (ModelState.IsValid)
            {
                List_pw();
                var data = db.orderlist_pw.SingleOrDefault(model => model.OPWid == id);
                data.OPWcust = pw.OPWcust;
                data.OPWcode = pw.OPWcode;
                data.OPWservice = pw.OPWservice;
                data.OPWqty = pw.OPWqty;
                data.OPWdate = pw.OPWdate;
                data.OPWdel = pw.OPWdel;
                data.OPWdue = pw.OPWdue;
                data.OPWstat = pw.OPWstat;
                data.OPWprice = pw.OPWprice;
                data.OPWadvance = pw.OPWadvance;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("OrderList_pw");
        }

        public ActionResult Delete_pw(orderlist_pw pw, int id)
        {
            List_pw();
            var data = db.orderlist_pw.SingleOrDefault(model => model.OPWid == id);
            data.OPWcust = pw.OPWcust;
            data.OPWcode = pw.OPWcode;
            data.OPWservice = pw.OPWservice;
            data.OPWqty = pw.OPWqty;
            data.OPWdate = pw.OPWdate;
            data.OPWdel = pw.OPWdel;
            data.OPWdue = pw.OPWdue;
            data.OPWstat = pw.OPWstat;
            data.OPWprice = pw.OPWprice;
            data.OPWadvance = pw.OPWadvance;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("OrderList_pw");
        }
        public ActionResult Invoice_pw(int id)
        {
            List_pw();
            var data = db.orderlist_pw.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }

        public ActionResult OrderList_ww()
        {

            return View(db.orderlist_ww.ToList());
        }
        public JsonResult CalculatePrice_ww(string code)
        {
            priceList_ww ww = db.priceList_ww.FirstOrDefault(a => a.PWcode == code);
            decimal price =  ww.PWprice;

            return Json(price, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Advance_ww(string code, decimal count)
        {
            priceList_ww ww = db.priceList_ww.FirstOrDefault(a => a.PWcode == code);
            decimal advance =  ww.PWprice - count;


            return Json(advance, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Service_ww(string code)
        {
            priceList_ww ww = db.priceList_ww.FirstOrDefault(a => a.PWcode == code);
            string service = ww.PWservice;

            return Json(service, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Weight_ww(string code)
        {
            priceList_ww ww = db.priceList_ww.FirstOrDefault(a => a.PWcode == code);
            int weight = ww.PWboxweight;

            return Json(weight, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create_ww()
        {

            List_ww();

            return View();
        }
        [HttpPost]
        public ActionResult Create_ww(orderlist_ww oww)
        {

            if (ModelState.IsValid)
            {
                List_ww();
                db.orderlist_ww.Add(oww);
                db.SaveChanges();
                WebClient client = new WebClient();
                string message;
                message = "Thanking Your For Your PieceWise Order  Regard: LM(Laundry Management) Your Responsibility Is Our Pride";
                string baseURL = "https://platform.clickatell.com/messages/http/send?apiKey=zcMDpK05ToO220Ay-dIyXQ==&to=923090832359&content=" + message.ToString() + "'&text=" + message + ".";
                client.OpenRead(baseURL);

            }
            return View();
        }
        public ActionResult Edit_ww(int id)
        {
            List_ww();
            var data = db.orderlist_ww.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit_ww(orderlist_ww ww, int id)
        {
            if (ModelState.IsValid)
            {
                List_ww();
                var data = db.orderlist_ww.SingleOrDefault(model => model.OPWid == id);
                data.OPWcust = ww.OPWcust;
                data.OPWcode = ww.OPWcode;
                data.OPWservice = ww.OPWservice;
                data.OPWbw = ww.OPWbw;
                data.OPWdate = ww.OPWdate;
                data.OPWdel = ww.OPWdel;
                data.OPWdue = ww.OPWdue;
                data.OPWstat = ww.OPWstat;
                data.OPWprice = ww.OPWprice;
                data.OPWadvance = ww.OPWadvance;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("OrderList_ww");
        }
        public ActionResult Delete_ww(orderlist_ww ww, int id)
        {
            List_ww();
            var data = db.orderlist_ww.SingleOrDefault(model => model.OPWid == id);
            data.OPWcust = ww.OPWcust;
            data.OPWcode = ww.OPWcode;
            data.OPWservice = ww.OPWservice;
            data.OPWbw = ww.OPWbw;
            data.OPWdate = ww.OPWdate;
            data.OPWdel = ww.OPWdel;
            data.OPWdue = ww.OPWdue;
            data.OPWstat = ww.OPWstat;
            data.OPWprice = ww.OPWprice;
            data.OPWadvance = ww.OPWadvance;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("OrderList_ww");
        }
        public ActionResult Invoice_ww(int id)
        {
            
            List_ww();
            var data = db.orderlist_ww.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }
        public ActionResult OrderList_pkw()
        {

            return View(db.orderlist_pkw.ToList());
        }
        public JsonResult CalculatePrice_pkw(string code)
        {
            priceList_pkw pkw = db.priceList_pkw.FirstOrDefault(a => a.PKWcode == code);
            decimal price = pkw.PKWprice;

            return Json(price, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Advance_pkw(string code, decimal count)
        {
            priceList_pkw pkw = db.priceList_pkw.FirstOrDefault(a => a.PKWcode == code);
            decimal advance = pkw.PKWprice - count;


            return Json(advance, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Service_pkw(string code)
        {
            priceList_pkw pkw = db.priceList_pkw.FirstOrDefault(a => a.PKWcode == code);
            string service = pkw.PKWservice;

            return Json(service, JsonRequestBehavior.AllowGet);
        }
        public JsonResult fixed_pkw(string code)
        {
            priceList_pkw pkw = db.priceList_pkw.FirstOrDefault(a => a.PKWcode == code);
            int fp = pkw.PKWmonthpiece;

            return Json(fp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create_pkw()
        {
            List_pkw();

            return View();
        }
        [HttpPost]
        public ActionResult Create_pkw(orderlist_pkw opk)
        {
            if (ModelState.IsValid)
            {
                List_pkw();
                db.orderlist_pkw.Add(opk);
                db.SaveChanges();
                WebClient client = new WebClient();
                string message;
                message = "Thanking Your For Your PackageWise Order  Regard: LM(Laundry Management) Your Responsibility Is Our Pride";
                string baseURL = "https://platform.clickatell.com/messages/http/send?apiKey=zcMDpK05ToO220Ay-dIyXQ==&to=923090832359&content=" + message.ToString() + "'&text=" + message + ".";
                client.OpenRead(baseURL);
                
                

            }
            return View();

        }
        public ActionResult Edit_pkw(int id)
        {
            List_pkw();
            var data = db.orderlist_pkw.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit_pkw(orderlist_pkw opk, int id)
        {
            if (ModelState.IsValid)
            {
                List_pkw();
                var data = db.orderlist_pkw.SingleOrDefault(model => model.OPWid == id);
                data.OPWcust = opk.OPWcust;
                data.OPWcode = opk.OPWcode;
                data.OPWservice = opk.OPWservice;
                data.OPWfp = opk.OPWfp;
                data.OPWdate = opk.OPWdate;
                data.OPWdel = opk.OPWdel;
                data.OPWdue = opk.OPWdue;
                data.OPWstat = opk.OPWstat;
                data.OPWprice = opk.OPWprice;
                data.OPWadvance = opk.OPWadvance;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("OrderList_pkw");
        }
        public ActionResult Delete_pkw(orderlist_pkw opk, int id)
        {
            List_pkw();
            var data = db.orderlist_pkw.SingleOrDefault(model => model.OPWid == id);
            data.OPWcust = opk.OPWcust;
            data.OPWcode = opk.OPWcode;
            data.OPWservice = opk.OPWservice;
            data.OPWfp = opk.OPWfp;
            data.OPWdate = opk.OPWdate;
            data.OPWdel = opk.OPWdel;
            data.OPWdue = opk.OPWdue;
            data.OPWstat = opk.OPWstat;
            data.OPWprice = opk.OPWprice;
            data.OPWadvance = opk.OPWadvance;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("OrderList_pkw");
        }
        public ActionResult Invoice_pkw(int id)
        {
            List_pkw();
            var data = db.orderlist_pkw.SingleOrDefault(model => model.OPWid == id);
            db.SaveChanges();
            return View(data);
        }
    }
}