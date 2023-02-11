using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    
    public class HomeController : Controller
    {
        lmsEntities db = new lmsEntities();
        // GET: Home

        public ActionResult Index()
        {
            return View(db.customers.ToList());
        }
        public ActionResult Create()
        {
            
            return View();
        }
    }
}