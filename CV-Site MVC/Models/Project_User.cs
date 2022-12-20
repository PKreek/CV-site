using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class Project_User
    {
        public int UserID { get; set; }
        public int ProjektID { get; set; }

        [ForeignKey (nameof(UserID))]
        public User User { get; set; }

        [ForeignKey(nameof(ProjektID))]
        public Project project { get; set; }

    }
}
