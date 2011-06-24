using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalJavascript.Web.UI.Models;

namespace PracticalJavascript.Web.UI.Controllers
{
    public class StoresController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Edit", new StoreViewModel());
        }

    }
}
