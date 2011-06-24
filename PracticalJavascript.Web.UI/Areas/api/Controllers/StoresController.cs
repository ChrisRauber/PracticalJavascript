using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalJavascript.Web.UI.Models;

namespace PracticalJavascript.Web.UI.Areas.api.Controllers
{
    public class StoresController : Controller
    {
        private static Random _random = new Random();

        public ActionResult List()
        {
            return Json(GetStores().ToArray(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<StoreViewModel> GetStores()
        {
            var list = new List<StoreViewModel>();
            IEnumerable<string> storeNames = LoadStoreNames();
            IEnumerable<string> streetNames = LoadStreetNames();
            IEnumerable<string> firstNames = LoadFirstNames();
            IEnumerable<string> lastNames = LoadLastNames();

            for ( int i=0; i < 25; i++ )
            {
                string storeName = storeNames.ElementAt(_random.Next(0, storeNames.Count() - 1));
                string streetName = streetNames.ElementAt(_random.Next(0, streetNames.Count() - 1));
                string firstName = firstNames.ElementAt(_random.Next(0, firstNames.Count() - 1));
                string lastName = lastNames.ElementAt(_random.Next(0, lastNames.Count() - 1));
                var store =
                    new StoreViewModel
                    {
                        StoreId = _random.Next(100000, 999999),
                        Name = storeName,
                        AddressLine1 = String.Format("{0} {1}", _random.Next(100, 10000), streetName),
                        City = "Atlanta",
                        State = "GA",
                        ZipCode = _random.Next(30000, 31000).ToString(),
                        SalesPerson = String.Format("{0} {1}", firstName, lastName),
                        StoreTypeId = _random.Next(1, 4)
                    };
                list.Add(store);
            }

            return list;
        }

        private IEnumerable<string> LoadStoreNames()
        {
            return LoadFromFile("StoreNames.txt");
        }

        private IEnumerable<string> LoadStreetNames()
        {
            return LoadFromFile("StreetNames.txt");
        }

        private IEnumerable<string> LoadFirstNames()
        {
            var firstNames = new List<string>();
            // Read the file and display it line by line.
            var file = String.Format("{0}{1}", HttpContext.Server.MapPath("~"), "App_Data/FirstNames.txt");
            using ( var sr = new StreamReader(file) )
            {
                string line;
                while ( (line = sr.ReadLine()) != null )
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

        private IEnumerable<string> LoadFromFile(string fileName)
        {
            var names = new List<string>();
            // Read the file and display it line by line.
            var file = String.Format("{0}App_Data/{1}", HttpContext.Server.MapPath("~"), fileName);
            using ( var sr = new StreamReader(file) )
            {
                string line;
                while ( (line = sr.ReadLine()) != null )
                {
                    names.Add(line);
                }
            }
            return names;
        }
    }
}
