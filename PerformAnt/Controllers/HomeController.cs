using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMarkupMin.Mvc.ActionFilters;

namespace PerformAnt.Controllers
{
    public class HomeController : Controller
    {
        [MinifyHtml]
        [CacheControl(MaxAge = 3600)]
        public ActionResult Index()
        {
            return View();
        }

        [MinifyHtml]
        [CacheControl(MaxAge = 86400)]
        public ActionResult About()
        {
            ViewBag.Message = "Web Performance";

            return View();
        }

        [MinifyHtml]
        [CacheControl(MaxAge = 86400)]
        public ActionResult Contact()
        {
            ViewBag.Message = "No way to contact. Hehe.";

            return View();
        }
    }
}