using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CV_Site_MVC.Controllers
{
    public class SearchController : Controller
    {
        private SiteContext _dbContext;

        public SearchController(SiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index(string search)
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = currentUserId();
                var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
                ViewData["AntalMeddelande"] = antal;
            }

            SearchViewModel model = new SearchViewModel();
            model.ListOfCv = _dbContext.cVs.Where(x => x.FirstName.StartsWith(search) || search == null).ToList();
            return View(model);   
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
