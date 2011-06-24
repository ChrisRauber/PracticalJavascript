using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using PracticalJavascript.Web.UI.Models;

namespace PracticalJavascript.Web.UI.Areas.api.Controllers
{
    public class SalesPersonsController : Controller
    {
        private static Random _random = new Random();

        public ActionResult List()
        {
            return Json(GetSalesPeople().ToArray(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SalesPersonViewModel> GetSalesPeople()
        {
            var list = new List<SalesPersonViewModel>();
            IEnumerable<string> firstNames = LoadFirstNames();
            IEnumerable<string> lastNames = LoadLastNames();

            for ( int i=0; i < 250; i++ )
            {
                string firstName = firstNames.ElementAt(_random.Next(0, firstNames.Count() - 1));
                string lastName = lastNames.ElementAt(_random.Next(0, lastNames.Count() - 1));
                list.Add(CreateSalesPerson(firstName, lastName));
            }
            return list;
        }

        private SalesPersonViewModel CreateSalesPerson(string firstName, string lastName)
        {
            int id = _random.Next(100000, 999999);

            return new SalesPersonViewModel
                       {
                           SalesPersonId = id,
                           Name = String.Format("{0} {1}", firstName, lastName)
                       };
        }

        private IEnumerable<string> LoadFirstNames()
        {
            var firstNames = new List<string>();
            // Read the file and display it line by line.
            var file = String.Format("{0}{1}", HttpContext.Server.MapPath("~"), "App_Data/FirstNames.txt");
            using ( var sr = new StreamReader(file) )
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    firstNames.Add(line);
                }
            }
            return firstNames;
        }

        private IEnumerable<string> LoadLastNames()
        {
            var firstNames = new List<string>();
            // Read the file and display it line by line.
            using ( var sr = new StreamReader(HttpContext.Server.MapPath("~") + "App_Data/LastNames.txt") )
            {
                string line;
                while ( (line = sr.ReadLine()) != null )
                {
                    firstNames.Add(line);
                }
            }
            return firstNames;
        }

    }
}
