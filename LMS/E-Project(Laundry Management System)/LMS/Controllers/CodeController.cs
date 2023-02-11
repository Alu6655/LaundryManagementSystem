using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    
    public class CodeController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: Code
        public ActionResult BarcodeListt()
        {

            return View(db.barcodes.ToList());
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(barcode bb)
        {
            if (ModelState.IsValid)
            {
                string show = bb.Bcode.ToString();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Bitmap bitmap = new Bitmap(show.Length * 40, 80))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            Font ofont = new Font("IDAutomationHC39M", 16);
                            PointF point = new PointF(2f, 2f);
                            SolidBrush whitebrush = new SolidBrush(Color.White);
                            graphics.FillRectangle(whitebrush, 0, 0, bitmap.Width, bitmap.Height);
                            SolidBrush blackbrush = new SolidBrush(Color.DarkBlue);
                            graphics.DrawString("*" + show + "*", ofont, blackbrush, point);
                        }
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);
                        ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                db.barcodes.Add(bb);
                db.SaveChanges();
            }
            return  View();
        }
        public ActionResult Delete_barcode(barcode bb, int id)
        {
            var data = db.barcodes.SingleOrDefault(model => model.Bid == id);
            data.Bcode = bb.Bcode;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("BarcodeListt");
        }
    }
}