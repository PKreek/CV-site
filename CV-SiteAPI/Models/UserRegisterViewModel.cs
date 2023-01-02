using System.ComponentModel.DataAnnotations;

namespace CV_SiteAPI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please insert a username")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please insert a password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
