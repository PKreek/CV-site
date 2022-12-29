using Microsoft.AspNetCore.Mvc;

namespace CV_Site_MVC.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
