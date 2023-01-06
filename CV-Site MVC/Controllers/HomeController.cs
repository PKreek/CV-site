using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CV_Site_MVC.Controllers
{
    public class HomeController : Controller
    {

        private SiteContext _dbContext;

        public HomeController(SiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = currentUserId();
                var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
                ViewData["AntalMeddelande"] = antal;
            }
            IndexViewModel model = new IndexViewModel();
            if (_dbContext.Projects.Count() > 0)
            {
                Project lastProject = _dbContext.Projects.OrderBy(x => x.Id).Last();
                model.lastProject = lastProject;
            }

            List<CV> cvList = _dbContext.cVs.ToList();
            List <Project_User> usersInProject = _dbContext.Project_Users.ToList();
            model.listOfCV = cvList;
            model.UserInProjects = usersInProject;
            model.cVLista = _dbContext.cVs.Where(x => x.PrivateCV == false).Select(x => x.UserID).ToList();
            model.PrivateCVUser = _dbContext.Users.Where(x => (model.cVLista.Contains(x.Id))).ToList();
            model.UsersWithPrivateCV = _dbContext.Project_Users.Where(x => (model.cVLista.Contains(x.UserID))).ToList();
            return View(model);
        }


        [Authorize]
        public IActionResult Profil()
        {
                var id = currentUserId();
                var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
                ViewData["AntalMeddelande"] = antal;
                var user = currentUserId();
                ProfileViewModel model = new ProfileViewModel();
                model.UserInProjects = _dbContext.Project_Users.ToList();
                model.ProjectList = _dbContext.Projects.Where(x => x.UserId.Equals(user)).ToList();
                model.ProjectsInvolved = _dbContext.Project_Users.Where(x => x.UserID.Equals(user)).ToList();
        
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
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RemoveProject(int projId)
        {
            Project_User project_User = new Project_User();
            project_User.ProjektID = projId;
            project_User.UserID = currentUserId();
            _dbContext.Project_Users.Remove(project_User);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
