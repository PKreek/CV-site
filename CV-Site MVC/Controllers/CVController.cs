using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace CV_Site_MVC.Controllers
{
    public class CVController : Controller
    {
        private SiteContext _dbContext;
        private IHostingEnvironment hostingEnvironment;

        public CVController(SiteContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult CV(string id)
        {
            CvViewModel model = new CvViewModel();

            //model.UserID = currentUserId();
            model.UserID = id;

            CV cv = _dbContext.cVs.Where(c => c.UserID.Equals(id)).FirstOrDefault<CV>();

            if (cv != null)
            { 
                model.Cv = cv;
            }
            else
            {
                model.Cv = new CV(id);
                _dbContext.cVs.Add(model.Cv);
                _dbContext.SaveChanges();
            }

            model.Skills = _dbContext.Skills.Where(s => s.CVId.Equals(model.Cv.ID)).ToList<Skill>();
            model.Educations = _dbContext.Educations.Where(s => s.CVId.Equals(model.Cv.ID)).ToList<Education>();
            model.Works = _dbContext.Works.Where(w => _dbContext.Work_CVs
                    .Where(c => c.CVID.Equals(model.Cv.ID))
                    .Select(i => i.WorkID).Contains(w.Id)).ToList();
            model.CvUser = _dbContext.Users.Where(u => u.Id.Equals(model.UserID)).First();

            if (User.Identity.IsAuthenticated)
                model.IsMyCv = id.Equals(currentUserId()) ? true : false;

            return View(model);
        }

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
            cv.PhotoPath = _dbContext.cVs.Where(x => x.UserID.Equals(currentUserId())).Select(y => y.PhotoPath).First();
            _dbContext.cVs.Update(cv);
            _dbContext.SaveChanges();

            return RedirectToAction("CV", new { id = currentUserId() });
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

            //_dbContext.cVs.Where(c => _dbContext.Work_CVs
            //    .Where(wc => wc.CVID.)

            return RedirectToAction("Work", new { id = cvIdCurrentUser() });
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

                return RedirectToAction("Work", new { id = cvIdCurrentUser() });
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

            return RedirectToAction("Work", new { id = cvIdCurrentUser() });
        }

        [HttpGet]
        public IActionResult Skill(int id)
        {
            List<Skill> skills = _dbContext.Skills.Where(w => w.CVId.Equals(id)).ToList<Skill>();

            return View(skills);
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            Skill skill = _dbContext.Skills.FirstOrDefault(w => w.Id.Equals(id));

            return View(skill);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skill.CVId = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
            _dbContext.Skills.Update(skill);
            _dbContext.SaveChanges();

            return RedirectToAction("Skill", new { id = cvIdCurrentUser() });
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.CVId = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
                _dbContext.Skills.Add(skill);
                _dbContext.SaveChanges();

                return RedirectToAction("Skill", new { id = cvIdCurrentUser() });
            }
            else
            {
                return View(skill);
            }
        }

        [HttpPost]
        public IActionResult DeleteSkill(Skill skill)
        {
            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();

            return RedirectToAction("Skill", new { id = cvIdCurrentUser() });
        }

        [HttpGet]
        public IActionResult Education(int id)
        {
            List<Education> educations = _dbContext.Educations.Where(w => w.CVId.Equals(id)).ToList<Education>();

            return View(educations);
        }

        [HttpGet]
        public IActionResult EditEducation(int id)
        {
            Education educations = _dbContext.Educations.FirstOrDefault(w => w.Id.Equals(id));

            return View(educations);
        }

        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
            education.CVId = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
            _dbContext.Educations.Update(education);
            _dbContext.SaveChanges();

            return RedirectToAction("education", new { id = cvIdCurrentUser() });
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                education.CVId = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
                _dbContext.Educations.Add(education);
                _dbContext.SaveChanges();

                return RedirectToAction("Education", new { id = cvIdCurrentUser() });
            }
            else
            {
                return View(education);
            }
        }

        [HttpPost]
        public IActionResult DeleteEducation(Education education)
        {
            _dbContext.Educations.Remove(education);
            _dbContext.SaveChanges();

            return RedirectToAction("Education", new { id = cvIdCurrentUser() });
        }

        [HttpGet]
        public IActionResult Image(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Image(CvViewModel model)
        {
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            CV cv = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId())).First();
            cv.PhotoPath = uniqueFileName;
            _dbContext.cVs.Update(cv);
            _dbContext.SaveChanges();

            return View();
        }

        public IActionResult Privat()
        {
            CV cv = _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId())).First();

            if (cv.PrivateCV)
            {
                cv.PrivateCV = false;
            } 
            else
            {
                cv.PrivateCV = true;
            }

            _dbContext.cVs.Update(cv);
            _dbContext.SaveChanges();

            return RedirectToAction("CV", new { id = currentUserId() });
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        private int cvIdCurrentUser()
        {
            return _dbContext.cVs.Where(c => c.UserID.Equals(currentUserId()))
                    .Select(i => i.ID).First();
        }
    }
}
