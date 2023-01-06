using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class User:IdentityUser
        
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
