using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public class EquipmentListing: Listing
    {
        public string EquipmentType {  get; set; }
        public string Condition {  get; set; }
        public override string GetCategoryDetails()
        {
            return $"Equipment Type: {EquipmentType}, Condition: {Condition}";
        }
    }
}
