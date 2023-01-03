using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
    public class IndexViewModel
    {
        public Project lastProject { get; set; }

        public List<CV> listOfCV { get; set; }

        public List<Project_User> UserInProjects { get; set; }

    }
}
