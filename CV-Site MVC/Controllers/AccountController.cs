using CV_Site_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CV_Site_MVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> logInManager;
        private SiteContext _dbContext;

        public AccountController(UserManager<User> _userManager, SignInManager<User> _logInManager, SiteContext dbContext)
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
                    await logInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
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
        public IActionResult Edit( int id )
        {
            //User user = (User)_dbContext.Users.Find(id);
            //User user = (User)_dbContext.Users.FirstOrDefault(u => u.Id.Equals(id));

            return View();
        }
    }

   
}
