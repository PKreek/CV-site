using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateAndTime StartDate { get; set; }
    }
}
