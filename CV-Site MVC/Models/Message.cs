using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CV_Site_MVC.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string SentTo { get; set; }
        public string SentFrom { get; set; }

        public bool Read { get; set; }

        [ForeignKey(nameof(SentTo))]
        public virtual User Message_Reciever  { get; set; }

    }
}
