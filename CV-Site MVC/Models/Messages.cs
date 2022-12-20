using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CV_Site_MVC.Models
{
    public class Messages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int SentTo { get; set; }
        public int SentFrom { get; set; }

        [ForeignKey(nameof(SentTo))]
        public virtual User Message_Reciver  { get; set; }

        [ForeignKey(nameof(SentFrom))]
        public virtual User Message_Sender { get; set; }
    }
}
