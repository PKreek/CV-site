using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class Project_User
    {
        public string UserID { get; set; }
        public int ProjektID { get; set; }

        [ForeignKey (nameof(UserID))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ProjektID))]
        public virtual Project project { get; set; }

    }
}
