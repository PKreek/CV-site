using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
    public class IndexViewModel
    {
        public Project lastProject { get; set; }

        public List<CV> listOfCV { get; set; }

        public List<Project_User> UserInProjects { get; set; }

        public List<Project_User> UsersWithPrivateCV { get; set; }

        public List<IdentityUser> PrivateCVUser { get; set; }


        //håller information om användarens ID med privata CV
        public List<string> cVLista { get; set; }



    }
}
