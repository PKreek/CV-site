using System.Collections.Generic;

namespace CV_SiteAPI.Models
{
	public class ProfileViewModel
	{
		public User User { get; set; }

        public List<Project> ProjectList { get; set; }

        public List<Project_User> UserInProjects { get; set; }
    }
}
