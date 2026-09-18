using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public enum ListingStatus
    {
        Available,
        Reserved,
        Sold

    }
    public abstract class Listing
    {
        public string ItemName {  get; set; }
        public string Description {  get; set; }
        public User Owner {  get; set; }
        public DateTime DatePosted {  get; set; }
        public ListingStatus Status {  get; set; }
        public byte[] ImageData { get; set; }



        public abstract string GetCategoryDetails();
        public override string ToString()
        {
            return $"{ItemName} [{Status}] - {GetCategoryDetails()}";
        }
    }
   
}
