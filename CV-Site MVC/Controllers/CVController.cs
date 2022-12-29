using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

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

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.UserID = currentUserID;

            CV cv = _dbContext.cVs.Where(c => c.UserID == currentUserID).FirstOrDefault<CV>();

            if (cv != null) model.Cv = cv;
            else model.Cv = new CV();

            return View(model);
        }
    }
}
