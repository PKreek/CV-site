using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
    public class ProjectViewModel
    {
        public List<Project> ProjectList { get; set; }

        public Project Project { get; set; }

        public List<Project_User> UserInProjects { get; set; }

        public List<Project_User> UsersWithPrivateCV { get; set; }

        public User User { get; set; }

        //håller information om användarens ID med privata CV
        public List<string> cVLista{ get; set; }   

    }
}
