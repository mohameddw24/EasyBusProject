using Azure.Identity;
using EasyBus.Models;
using EasyBusProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyBusProject.Controllers
{
    public class UserController : Controller
    {

        public UserManager<User> UserManager { get; set; }
        public RoleManager<IdentityRole<int>> RoleManager { get; set; }

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserRoleVM> users = UserManager.GetUsersInRoleAsync("User").Result.Select(User =>
                new UserRoleVM
                {
                    Id = User.Id,
                    UserName = User.UserName,
                    IsAdmin = false
                }
            ); ;
            var allUsers = UserManager.Users;

            return View(users);
        }



        [HttpPost]  
        public async Task<IActionResult> Index(UserRoleDictVM userRoleDictVM) 
        {
            if(userRoleDictVM.UserIdList !=  null)
            {
                foreach (var userId in userRoleDictVM.UserIdList)
                {
                    var user = await UserManager.FindByIdAsync(userId.ToString());

                    if (user != null)
                    {
                        await UserManager.RemoveFromRoleAsync(user, "User");
                        await UserManager.AddToRoleAsync(user, "Admin");
                        await UserManager.UpdateAsync(user);
                    }

                }
            }

            return RedirectToAction(nameof(Index));
        }



    }
}
