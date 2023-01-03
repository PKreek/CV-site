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




        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        
        public IActionResult Index()
        {
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
            return View(model);
        }


        [Authorize]
        public IActionResult Profil()
        {      
                var user = currentUserId();
                ProfileViewModel model = new ProfileViewModel();
                model.UserInProjects = _dbContext.Project_Users.ToList();
                model.ProjectList = _dbContext.Projects.Where(x => x.UserId.Equals(user)).ToList();

                return View(model);  
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
