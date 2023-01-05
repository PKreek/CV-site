using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CV_Site_MVC.Controllers
{
    public class SearchController : Controller
    {
        private SiteContext _dbContext;

        public SearchController(SiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: SearchController
        public ActionResult Index(string search)
        {
                SearchViewModel model = new SearchViewModel();
                model.ListOfCv = _dbContext.cVs.Where(x => x.FirstName.StartsWith(search) || search == null).ToList();
                model.PrivateCvList = _dbContext.cVs.Where(x => x.PrivateCV == false).ToList();
                return View(model);
                //return View(_dbContext.cVs.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
            
        }

            // GET: SearchController/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
