using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CV_Site_MVC.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> logInManager;
        private SiteContext _dbContext;

        public AccountController(UserManager<User> _userManager,
          SignInManager<User> _logInManager, SiteContext dbContext)
        {
            this.userManager = _userManager;
            this.logInManager = _logInManager;
            _dbContext = dbContext;

        }

        [HttpGet]
        public IActionResult LogIn()
        {
            LogInViewModel logInViewModel = new LogInViewModel();
            return View(logInViewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
        {
            if(ModelState.IsValid)
            {
                User user = new User();
                user.UserName = userRegister.UserName;

                var result = await userManager.CreateAsync(user, userRegister.PassWord);
                if(result.Succeeded)
                {
                    CV cv = new CV(user.Id);
                    cv.FirstName = userRegister.FirstName;
                    cv.LastName = userRegister.LastName;
                    _dbContext.cVs.Add(cv);
                    _dbContext.SaveChanges();
                    await logInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Profil", "Home");
                }
            }
            return View(userRegister);
        }

        [HttpPost]
        public async Task<IActionResult>LogIn(LogInViewModel loginView)
        {
            if(ModelState.IsValid)
            {
                var result = await logInManager.PasswordSignInAsync(loginView.UserName, loginView.PassWord, 
                    isPersistent: loginView.RememberMe, lockoutOnFailure: false);


                    if(result.Succeeded)
                {
                    return RedirectToAction("Profil", "Home");
                }
            }
            return View(loginView);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await logInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            User model = new User();

            model.Id = currentUserId();
            model.UserName = currentUserName();

            //User user = (User)_dbContext.Users.Where(c => c.Id.Equals(currentUserId()));

            //if (user != null)
            //{
            //    model.user = user;
            //    //model.Works = _dbContext.Works.Where(w => _dbContext.Work_CVs
            //    //    .Where(c => c.CVID.Equals(cv.ID))
            //    //    .Select(i => i.WorkID).Contains(w.Id)).ToList();
            //}
            //else
            //{
            //    //model.user = new User(currentUserId());
            //    //_dbContext.Users.Add(model.user);
            //    //_dbContext.SaveChanges();
            //}

            return View(model);
        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        private string currentUserName()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.Name).Value;
        }

        //[HttpGet]
        //public IActionResult Edit( int id )
        //{
        //    //var claim = (ClaimsIdentity)User.Identity;
        //    //User user = (User)_dbContext.Users.Find(id);
        //    //User user = (User)_dbContext.Users.FirstOrDefault(u => u.Id.Equals(id));

        //    return View();
        //}

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            var id = currentUserId();
            var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
            ViewData["AntalMeddelande"] = antal;
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {



            if (ModelState.IsValid)
            {

                var result = await ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View(model);
                }


                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = currentUserId();
            var user = await userManager.FindByIdAsync(userId);
            return await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }


    }


}
