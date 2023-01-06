using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_Site_MVC.Models
{
    public class User:IdentityUser
        
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public virtual CV Cv { get; set; }


      

        [InverseProperty("Message_Sender")]
        public virtual IEnumerable<Message> Sender { get; set; }

        [InverseProperty("Message_Reciever")]
        public virtual IEnumerable<Message> Reciever { get; set; }
        //Password?

    }
}
