using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public  class BookListing : Listing
    {
        public string CourseCode {  get; set; }
        public string Author {  get; set; }
        public string Edition {  get; set; }
        public string Condition {  get; set; }
        public override string GetCategoryDetails()
        {
            return $"Course: {CourseCode}, Author: {Author}, edition: {Edition}, Condition: {Condition}";
        }

   
    
    }
}
