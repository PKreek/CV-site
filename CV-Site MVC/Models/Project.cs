using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange projektnamn")]
        [StringLength(100, ErrorMessage = "Projektnamn får vara max 100 tecken")]
        public string ProjectName { get; set; }
        [StringLength(200, ErrorMessage = "Beskrivning får vara max 200 tecken")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ange startdatum")]
        [DataType(DataType.Date, ErrorMessage = "Ange startdatum")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public virtual IEnumerable<Project_User> Users { get; set; } = new List<Project_User>();

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }

}
