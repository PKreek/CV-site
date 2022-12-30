using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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
           
            return View(new Project());
        }

        [HttpPost]
        public IActionResult Project(Project projectObject)
        {
            projectObject.UserId = currentUserId();
            _dbContext.Projects.Add(projectObject);
            _dbContext.SaveChanges();
            return RedirectToAction("Profil","Home");
        }

        public IActionResult ListOfProjects()
        {
            ProjectViewModel model = new ProjectViewModel();
            model.ProjectList = _dbContext.Projects.ToList();
    
            return View(model);
        }

        [HttpPost]
        public IActionResult JoinProject(User joinedUser, Project joinedProject)
        {
           
            return RedirectToAction("ListOfProjects", "Project");
        }
        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
