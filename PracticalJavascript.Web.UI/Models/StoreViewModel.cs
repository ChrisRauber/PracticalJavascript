using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PracticalJavascript.Web.UI.Models
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        
        [DisplayName("Name:")]
        public string Name { get; set; }
        
        [DisplayName("Address 1:")]
        public string AddressLine1 { get; set; }
        
        [DisplayName("Address 2:")]
        public string AddressLine2 { get; set; }
        
        [DisplayName("City:")]
        public string City { get; set; }

        [DisplayName("State:")]
        public string State { get; set; }

        [DisplayName("Zip Code:")]
        public string ZipCode { get; set; }

        [DisplayName("Sales Person ID:")]
        public int SalesPersonId { get; set; }

        [DisplayName("SalesPerson:")]
        public string SalesPerson { get; set; }

        [DisplayName("Store Type:")]
        public int StoreTypeId { get; set; }

        public string StoreType
        {
            get { 
                string storeType = "";
                switch ( StoreTypeId)
                {
                    case (int)Models.StoreType.Fuel:
                        storeType = "Fuel";
                        break;
                    case (int)Models.StoreType.Maintenance:
                        storeType = "Maintenance";
                        break;
                    case (int)Models.StoreType.FuelAndMaintenance:
                        storeType = "Fuel/Maintenance";
                        break;
                    default:
                        storeType = "Unknown";
                        break;
                }
                return storeType;
            }
        }
    }
}