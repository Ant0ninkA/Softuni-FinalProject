namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using PartyfyApp.Data.Models;
    using PartyfyApp.Web.ViewModels.User;
    using static PartyfyApp.Common.NotificationMessagesConstants;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await this._userManager.SetUserNameAsync(user, model.Email);
            await this._userManager.SetEmailAsync(user, model.Email);

            IdentityResult res = await this._userManager.CreateAsync(user, model.Password);

            if (!res.Succeeded)
            {
                foreach(var error in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await this._signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormViewModel model = new LoginFormViewModel()
            {
                ReturnUrl = returnUrl,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!res.Succeeded)
            {
                TempData[ErrorMessage] = "There was an error while logging you in. Please try later or contact administrator!";

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }

}
