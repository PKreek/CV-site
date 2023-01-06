namespace CV_Site_MVC.Models
{
    public class MessageViewModel
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Text { get; set; }
        public string Date  { get; set; }
        public bool Read { get; set; }
    }
}
