using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
    public class CvViewModel
    {
        public CV Cv { get; set; }

        public string UserID { get; set; }

        public List <Work> Works { get; set; }
    }
}
