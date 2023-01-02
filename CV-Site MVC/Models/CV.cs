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
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        public string? PhotoPath { get; set; }

        public bool PrivateCV { get; set; }

        public virtual ICollection<Work_CV> Work_CV { get; set; } = new List<Work_CV>();

        public CV (string userId)
        {
            UserID = userId;
        }

        public CV() { }
    }
}
