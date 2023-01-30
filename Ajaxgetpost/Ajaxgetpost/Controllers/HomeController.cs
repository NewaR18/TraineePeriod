using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajaxgetpost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult GetNames()
        {
            var names = new string[3]
            {
                "Sudip",
                "Shrestha",
                "Newar"
            };
            return new JsonResult(Ok(names));
        }
        [HttpPost]
        public JsonResult PostName(string s)
        {;
            return new JsonResult(Ok())
        }
    }
}