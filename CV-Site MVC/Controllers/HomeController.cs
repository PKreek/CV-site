using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        [Authorize]
        public IActionResult Index()
        {
            List<Project> projectList = _dbContext.Projects.ToList();
            List<CV> cvList = _dbContext.cVs.ToList();
            IndexViewModel model = new IndexViewModel();
            model.listOfProjects = projectList;
            model.listOfCV = cvList;
            return View(model);
        }



        public IActionResult Profil()
        {
            return View();
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
