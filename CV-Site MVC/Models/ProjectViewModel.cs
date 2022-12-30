using System.Collections.Generic;
using System.Security.Policy;

namespace CV_Site_MVC.Models
{
	public class ProjectViewModel
	{
		public Project project { get; set; }	
		public string Projektledare { get; set; }
		public string UserID { get; set; }
		public List<Project> projektLista { get; set; }
	}
}
