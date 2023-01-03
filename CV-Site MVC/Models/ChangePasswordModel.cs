using System.ComponentModel.DataAnnotations;

namespace CV_Site_MVC.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Current password")]
        public string CurrentPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "New password")]

        public string NewPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Confirm new password does not match")]
        public string ConfirmPassword { get; set; }
    }
}