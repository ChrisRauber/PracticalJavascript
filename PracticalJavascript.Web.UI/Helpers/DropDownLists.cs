using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalJavascript.Web.UI.Helpers
{
    public static class DropDownLists
    {
        public static IEnumerable<SelectListItem> OptionsForStates(this HtmlHelper html)
        {
            return new[]
                       {
                           new SelectListItem { Text = "-- Select --"},
                           new SelectListItem { Text = "Alaska", Value = "AK"},
                           new SelectListItem { Text = "Alabama", Value = "AL"},
                           new SelectListItem { Text = "Arkansas", Value = "AR"}
                       };
        }
    }
}