using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
	public class ProfileViewModel
	{
		public User User { get; set; }

        public List<Project> ProjectList { get; set; }

        public List<Project_User> UserInProjects { get; set; }

        public List<Project_User> ProjectsInvolved { get; set; }
    }
}
