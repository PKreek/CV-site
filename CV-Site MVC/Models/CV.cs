using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CV_Site_MVC.Models
{
    public class CV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Utbildning { get; set; }
        //public string IdentityID { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        //[ForeignKey(nameof(IdentityID))]
        //public virtual User Owner { get; set; }
        public virtual IEnumerable<Work_CV> Work_CV { get; set; } = new List<Work_CV>();

        public CV (string userId)
        {
            UserID = userId;
        }

        public CV() { }
    }
}
