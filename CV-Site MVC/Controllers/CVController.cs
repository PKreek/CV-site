using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult CV()
        {
            CvViewModel model = new CvViewModel();

            model.UserID = currentUserId();

            CV cv = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId())).FirstOrDefault<CV>();

            if (cv != null)
            { 
                model.Cv = cv;
                model.Works = _dbContext.Works.ToList<Work>();

                model.Works = _dbContext.Works.Where(w => w.Work_CV.Equals(model.Cv.Work_CV)).ToList<Work>();
            }
            else
            {
                model.Cv = new CV(currentUserId());
                _dbContext.cVs.Add(model.Cv);
                _dbContext.SaveChanges();
            }

            return View(model);
        }

        //public IActionResult NewCV(CV cv)
        //{
        //    cv.UserID = currentUserId();
        //    _dbContext.cVs.Add(cv);
        //    _dbContext.SaveChanges();

        //    return RedirectToAction("CV");
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CV cv = _dbContext.cVs.FirstOrDefault(c => c.ID.Equals(id));

            return View(cv);
        }

        [HttpPost]
        public IActionResult Edit(CV cv)
        {
            cv.UserID = currentUserId();
            _dbContext.cVs.Update(cv);
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
