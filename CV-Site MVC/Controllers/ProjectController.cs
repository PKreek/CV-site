using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

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
            if (User.Identity.IsAuthenticated)
            {
                var id = currentUserId();
                var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
                ViewData["AntalMeddelande"] = antal;
            }

            return View(new Project());
        }

        [HttpPost]
        public IActionResult Project(Project projectObject)
        {
            if (ModelState.IsValid)
            {
                projectObject.UserId = currentUserId();
                _dbContext.Projects.Add(projectObject);
                _dbContext.SaveChanges();
                return RedirectToAction("Profil", "Home");
            }
            return View(projectObject);
        }

        public IActionResult ListOfProjects()
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = currentUserId();
                var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
                ViewData["AntalMeddelande"] = antal;
            }
            
            ProjectViewModel model = new ProjectViewModel();
            model.ProjectList = _dbContext.Projects.ToList();
            model.UserInProjects = _dbContext.Project_Users.ToList();
            model.cVLista = _dbContext.cVs.Where(x => x.PrivateCV == false).Select(x => x.UserID).ToList();
            model.UsersWithPrivateCV = _dbContext.Project_Users.Where(x => (model.cVLista.Contains(x.UserID))).ToList();
    
            return View(model);
        }

        [HttpPost]
        public IActionResult JoinProject(int projId)
        {
            Project_User project_User = new Project_User();
            project_User.project = _dbContext.Projects.Find(projId);
            project_User.ProjektID = projId;
            project_User.UserID = currentUserId();
            Console.WriteLine(project_User.UserID + project_User.ProjektID);

            _dbContext.Project_Users.Add(project_User);
            _dbContext.SaveChanges();
            return RedirectToAction("ListOfProjects", "Project");
        }

        [HttpPost]
        public IActionResult RemoveProject(int projId)
        {
            Project_User project_User = new Project_User();
            project_User.ProjektID = projId;
            project_User.UserID = currentUserId();
            _dbContext.Project_Users.Remove(project_User);
            _dbContext.SaveChanges();
            return RedirectToAction("ListOfProjects", "Project");
        }

        [HttpGet]
        public IActionResult UpdateProject(int projId)
        {
            Project project = _dbContext.Projects.Find(projId);

            return View(project);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                project.UserId = currentUserId();
                _dbContext.Projects.Update(project);
                _dbContext.SaveChanges();
                return RedirectToAction("Profil", "Home");
            }
            return View(project);
        }
        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
