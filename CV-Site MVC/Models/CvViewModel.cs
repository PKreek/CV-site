using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
    public class CvViewModel
    {
        public CV Cv { get; set; }

        public string UserID { get; set; }

        public IdentityUser CvUser { get; set; }

        public List<Work> Works { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Education> Educations { get; set; }

        public IFormFile Photo { get; set; }

        public bool IsMyCv { get; set; }
    }
}
