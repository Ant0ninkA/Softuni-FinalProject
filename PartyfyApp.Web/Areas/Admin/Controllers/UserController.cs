namespace PartyfyApp.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Web.ViewModels.Admin;
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AdminUserViewModel> users = await _userManager.Users
                .Select(u => new AdminUserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    Roles = string.Join(", ", _userManager.GetRolesAsync(u))
                })
                .ToArrayAsync();

            return View(users);
        }
    }
}
