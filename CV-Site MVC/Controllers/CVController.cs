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

            model.UserID = currentUserId();

            CV cv = _dbContext.cVs.Where(c => c.UserID == currentUserId()).FirstOrDefault<CV>();

            if (cv != null) model.Cv = cv;
            else model.Cv = new CV();

            return View(model);
        }

        public IActionResult NewCV(CV cv)
        {
            cv.UserID = currentUserId();
            _dbContext.cVs.Add(cv);
            _dbContext.SaveChanges();
            return RedirectToAction("CV", "CV");
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
