using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class PriceController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: Price
        public ActionResult PieceWise()
        {
            
            return View(db.priceList_pw.ToList());
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(priceList_pw pw)
        {
            if (ModelState.IsValid)
            {
                db.priceList_pw.Add(pw);
                db.SaveChanges();
            }
            return RedirectToAction("PieceWise");
                
        }
        public ActionResult Edit(int id)
        {

            var data = db.priceList_pw.SingleOrDefault(model => model.PWid == id);
            db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(priceList_pw pw, int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.priceList_pw.SingleOrDefault(model => model.PWid == id);
                data.PWcode = pw.PWcode;
                data.PWclothtype = pw.PWclothtype;
                data.PWservice = pw.PWservice;
                data.PWprice = pw.PWprice;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PieceWise");
        }
        public ActionResult Delete(priceList_pw pw, int id)
        {
            var data = db.priceList_pw.SingleOrDefault(model => model.PWid == id);
            data.PWcode = pw.PWcode;
            data.PWclothtype = pw.PWclothtype;
            data.PWservice = pw.PWservice;
            data.PWprice = pw.PWprice;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("PieceWise");
        }
        public ActionResult WeightWise()
        {
            return View(db.priceList_ww.ToList());
        }
        public ActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create1(priceList_ww ww)
        {
            if (ModelState.IsValid)
            {
                db.priceList_ww.Add(ww);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult Edit1(int id)
        {
            var data = db.priceList_ww.SingleOrDefault(model => model.PWid == id);
            db.SaveChanges();
            return View(data);
        }
        
        [HttpPost]
        public ActionResult Edit1(priceList_ww ww, int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.priceList_ww.SingleOrDefault(model => model.PWid == id);
                data.PWcode = ww.PWcode;
                data.PWservice = ww.PWservice;
                data.PWboxweight = ww.PWboxweight;
                data.PWprice = ww.PWprice;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("WeightWise");
                
        }
        public ActionResult Delete1(priceList_ww ww, int id)
        {
            var data = db.priceList_ww.SingleOrDefault(model => model.PWid == id);
            data.PWcode = ww.PWcode;
            data.PWservice = ww.PWservice;
            data.PWboxweight = ww.PWboxweight;
            data.PWprice = ww.PWprice;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("WeightWise");
        }
        public ActionResult PackageWise()
        {
            return View(db.priceList_pkw.ToList());
        }
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create2(priceList_pkw pkw)
        {
            if (ModelState.IsValid)
            {
                db.priceList_pkw.Add(pkw);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult Edit2(int id)
        {
            var data = db.priceList_pkw.SingleOrDefault(model => model.PKWid == id);
            db.SaveChanges();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit2(priceList_pkw pkw, int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.priceList_pkw.SingleOrDefault(model => model.PKWid == id);
                data.PKWcode = pkw.PKWcode;
                data.PKWservice = pkw.PKWservice;
                data.PKWmonthpiece = pkw.PKWmonthpiece;
                data.PKWprice = pkw.PKWprice;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PackageWise");
        }
        public ActionResult Delete2(priceList_pkw pkw, int id)
        {
            var data = db.priceList_pkw.SingleOrDefault(model => model.PKWid == id);
            data.PKWcode = pkw.PKWcode;
            data.PKWservice = pkw.PKWservice;
            data.PKWmonthpiece = pkw.PKWmonthpiece;
            data.PKWprice = pkw.PKWprice;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("PackageWise");
        }

    }
}