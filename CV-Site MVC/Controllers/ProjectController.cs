using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CV_Site_MVC.Controllers
{
    public class ProjectController : Controller
    {

        private SiteContext _dbContext;

        public ProjectController(SiteContext dbContext)
        {
                _dbContext = dbContext;
        }
        public IActionResult Project()
        {
            return View();
        }
    }
}
