using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace castle_mvc4.Controllers
{
    public class HomeController : Controller
    {

        private readonly IContactManager _contactManager;


        public HomeController(IContactManager contactManager)
        {
            _contactManager = contactManager;

        }

        public ActionResult Index()
        {


            ViewBag.Message = _contactManager.GetMessage();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
