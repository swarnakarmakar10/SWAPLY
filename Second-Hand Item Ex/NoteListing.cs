using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public class NoteListing : Listing
    {
        public string CourseCode {  get; set; }
        public string Semester {  get; set; }
        public string Format {  get; set; }
        public override string GetCategoryDetails()
        {
            return $"Course Code: {CourseCode}, Semester: {Semester}, Format: {Format}";

        }
    }
}
