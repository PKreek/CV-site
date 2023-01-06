using System.ComponentModel.DataAnnotations;

namespace CV_Site_MVC.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Måste fyllas i"), DataType(DataType.Password), Display(Name = "Current password")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "Måste fyllas i"), DataType(DataType.Password), Display(Name = "New password")]

        public string NewPassword { get; set; }


        [Required(ErrorMessage = "Måste fyllas i"), DataType(DataType.Password), Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "De nya lösenorden matchar inte")]
        public string ConfirmPassword { get; set; }
    }
}