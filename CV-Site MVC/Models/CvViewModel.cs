using Microsoft.AspNetCore.Mvc;

namespace CV_Site_MVC.Models
{
    public class CvViewModel
    {
        public CV Cv { get; set; }

        public string UserID { get; set; }
    }
}
