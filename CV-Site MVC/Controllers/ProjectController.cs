using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult ListOfProjects()
        {
            List<Project> projectList = _dbContext.Projects.ToList();
            return View(projectList);
        }
    }
}
