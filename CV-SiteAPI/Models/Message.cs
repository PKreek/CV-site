using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CV_SiteAPI.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string SentTo { get; set; }
        public string SentFrom { get; set; }

        [ForeignKey(nameof(SentTo))]
        public virtual User Message_Reciever  { get; set; }

        [ForeignKey(nameof(SentFrom))]
        public virtual User Message_Sender { get; set; }
    }
}
