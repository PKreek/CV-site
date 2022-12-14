using System;

namespace CV_Site_MVC.Models
{
    public class ErrorViewModel
    {
         public string RequestId { get; set; }

         public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
