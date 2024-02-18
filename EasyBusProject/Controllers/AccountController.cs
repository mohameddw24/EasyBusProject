using EasyBus.Models;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EasyBusProject.Controllers
{
    public class AccountController: Controller
    {
        public UserManager<User> UserManager { get; set; }
        public SignInManager<User> SignInManager { get; set; }

        public AccountController(UserManager<User> userManager , SignInManager<User> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM newUserVM)
        {
            if (ModelState.IsValid)
            {

                User newUser = new User();
                newUser.PasswordHash = newUserVM.Password;
                newUser.ClientName = newUserVM.ClientName;
                newUser.UserName = newUserVM.UserName;
                //newUser.UserName = newUserVM.ClientName + new Random().Next(1000,10000).ToString();

                var userCount = UserManager.Users.Count();

                IdentityResult result = await UserManager.CreateAsync(newUser, newUserVM.Password);                               

                await UserManager.AddToRoleAsync(newUser, (userCount > 0)? "User" : "Admin");

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Element", errorItem.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userAttemptToLoginVM)
        {
            if (ModelState.IsValid)
            {
                User savedUser = await UserManager.FindByNameAsync(userAttemptToLoginVM.UserName);

                if (savedUser != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(savedUser, userAttemptToLoginVM.Password);

                    if (found == true)
                    {
                        await SignInManager.SignInAsync(savedUser, userAttemptToLoginVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Wrong UserName Or Password");
            return View(userAttemptToLoginVM);
        }

        public IActionResult SignOut()
        {

            SignInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }

    }
}
