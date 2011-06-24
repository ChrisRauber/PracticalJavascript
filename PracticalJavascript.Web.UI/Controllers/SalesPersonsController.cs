using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalJavascript.Web.UI.Controllers
{
    public class SalesPersonsController : Controller
    {
        //
        // GET: /SalesPersons/

        public ActionResult List()
        {
            return PartialView("_List");
        }

    }
}
