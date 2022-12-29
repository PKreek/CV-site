using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CV_Site_MVC.Controllers
{
    public class CVController : Controller
    {
        private SiteContext _dbContext;

        public CVController(SiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult CV()
        {
            CvViewModel model = new CvViewModel();
            model.Cv = _dbContext.cVs.Where(c => c.ID == 2).FirstOrDefault<CV>();
            return View(model);
        }
    }
}
