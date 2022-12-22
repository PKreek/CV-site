using System.ComponentModel.DataAnnotations;

namespace CV_Site_MVC.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage ="Please insert a username")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please insert a password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }  
        public bool RememberMe { get; set; }
    }
}
