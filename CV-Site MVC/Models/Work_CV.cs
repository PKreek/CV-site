using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.PortableExecutable;

namespace CV_Site_MVC.Models
{
    public class Work_CV
    {
        public int WorkID { get;set;}
        public int CVID { get; set; }

        [ForeignKey (nameof(WorkID))]
        public Work Work { get; set; }

        [ForeignKey(nameof (CVID))]
        public CV Cv { get; set; }
    }
}
