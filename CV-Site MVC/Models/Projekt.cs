using Microsoft.VisualBasic;

namespace CV_Site_MVC.Models
{
    public class Projekt
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateAndTime StartDate { get; set; }
    }
}
