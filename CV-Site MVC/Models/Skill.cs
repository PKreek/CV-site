using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CV_Site_MVC.Models
{
	public class Skill
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange kompetens(tex C#)")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string Name { get; set; }

        public int CVId { get; set; }

        [ForeignKey(nameof(CVId))]
        public virtual CV Cv { get; set; }
    }
}
