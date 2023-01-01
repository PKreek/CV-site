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
                model.Works = _dbContext.Works.Where(w => _dbContext.Work_CVs
                    .Where(c => c.CVID.Equals(cv.ID))
                    .Select(i => i.WorkID).Contains(w.Id)).ToList();
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

            return RedirectToAction("CV");
        }

        [HttpGet]
        public IActionResult Work(int id)
        {
            List<Work> works = _dbContext.Works.Where(w => _dbContext.Work_CVs
                    .Where(c => c.CVID.Equals(id))
                    .Select(i => i.WorkID).Contains(w.Id)).ToList();

            return View(works);
        }

        [HttpGet]
        public IActionResult EditWork(int id)
        {
            Work work = _dbContext.Works.FirstOrDefault(w => w.Id.Equals(id));

            return View(work);
        }

        [HttpPost]
        public IActionResult EditWork(Work work)
        {
            _dbContext.Works.Update(work);
            _dbContext.SaveChanges();

            return RedirectToAction("Work");
        }

        [HttpGet]
        public IActionResult AddWork()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWork(Work work)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Works.Add(work);
                _dbContext.SaveChanges();

                Work_CV work_cv = new Work_CV();
                work_cv.WorkID = work.Id;
                work_cv.CVID = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
                _dbContext.Work_CVs.Add(work_cv);

                _dbContext.SaveChanges();

                return RedirectToAction("Work");
            }
            else
            {
                return View(work);
            }
            
        }

        [HttpPost]
        public IActionResult DeleteWork(Work work)
        {
            _dbContext.Work_CVs.Remove(_dbContext.Work_CVs.Where(c => c.WorkID.Equals(work.Id)).First());
            _dbContext.Works.Remove(work);
            _dbContext.SaveChanges();

            return RedirectToAction("Work");
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
