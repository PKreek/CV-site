using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CV_Site_MVC.Models
{
    public class CV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Ange en giltig email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Ange ett giltigt telefonnummer")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Ange förnamn")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ange efternamn")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
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
