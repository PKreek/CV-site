using System.ComponentModel.DataAnnotations;

namespace CV_Site_MVC.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Ange ett användarnamn")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ange ett lösenord")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$",
         ErrorMessage = "Lösenordet måste innehålla minst 8 tecken varav minst en stor bokstav, en siffra och ett specialtecken")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Upprepa lösenordet")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ange ditt förnamn")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ange ditt efternamn")]
        [StringLength(100, ErrorMessage = "Max 100 tecken")]
        public string LastName { get; set; }
    }
}
