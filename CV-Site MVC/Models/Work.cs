using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CV_Site_MVC.Models
{
    public class Work
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange företagsnamn")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ange roll")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Ange startdatum")]
        [DataType(DataType.Date , ErrorMessage = "Ange startdatum")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Work_CV> Work_CV { get; set; } = new List<Work_CV>();
    }
}
