using Microsoft.AspNetCore.Mvc;

namespace CV_Site_MVC.Controllers
{
    public class CVController : Controller
    {
        public IActionResult CV()
        {
            return View();
        }
    }
}
