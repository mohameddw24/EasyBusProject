using EasyBus.Models;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


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
                var existingUser = await UserManager.FindByNameAsync(newUserVM.UserName);
                if (existingUser != null)
                {
                    ModelState.AddModelError("UserName", "Username is already exists");
                    return View(newUserVM);
                }

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

        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = Url.Action("GoogleLoginRedirect") }
                );
            
        }

        public async Task<IActionResult> GoogleLoginRedirect()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            var userEmail = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var userName = authenticateResult.Principal.FindFirst(ClaimTypes.Name)?.Value;

            var existingUser = await UserManager.FindByEmailAsync(userEmail);

            if (existingUser == null)
            {
                var newUser = new User
                {
                    UserName = userName,
                    Email = userEmail,
                    ClientName = userName,
                };

                var createResult = await UserManager.CreateAsync(newUser);

                await UserManager.AddToRoleAsync(newUser, (UserManager.Users.Count() > 0) ? "User" : "Admin");


                if (!createResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, authenticateResult.Principal);

            return RedirectToAction("Index", "Home");

        }

    }
}
