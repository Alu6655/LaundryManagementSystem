using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Net;

namespace LMS.Controllers
{
    public class CustomerController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: Customer
        public ActionResult Customer()
        {
            
            return View(db.customers.ToList());
        }
        [HttpPost]
        public ActionResult Customer(string name)
        {
            var data = db.customers.ToList();
             if(name!=null)
            {
                data = db.customers.Where(model => model.Ccontact.Contains(name)).ToList();
            }
             
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(customer cust)
        {
           
            if (ModelState.IsValid)
            {
                db.customers.Add(cust);
                db.SaveChanges();
                WebClient client = new WebClient();
                string message;
                message = "Thanking Your For Registration On LM(Laundry Management) Your Responsibility Is Our Pride";
                string baseURL = "https://platform.clickatell.com/messages/http/send?apiKey=zcMDpK05ToO220Ay-dIyXQ==&to=923090832359&content=" + message.ToString() + "'&text=" + message + ".";
                client.OpenRead(baseURL);


                return RedirectToAction("Customer");
            }
            else
            {
                return View("Create");
            }
                
        }
        
        public ActionResult Edit(int id)
        {
           var data= db.customers.SingleOrDefault(model => model.Cid == id);
            db.SaveChanges();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(customer cust,int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.customers.SingleOrDefault(model => model.Cid == id);
                data.Cfn = cust.Cfn;
                data.Cemail = cust.Cemail;
                data.Ccontact = cust.Ccontact;
                data.Caddress = cust.Caddress;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Customer");
        }
        public ActionResult Delete(customer cust,int id)
        {
            var data = db.customers.SingleOrDefault(model => model.Cid == id);
            data.Cfn = cust.Cfn;
            data.Cemail = cust.Cemail;
            data.Ccontact = cust.Ccontact;
            data.Caddress = cust.Caddress;
            db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
}