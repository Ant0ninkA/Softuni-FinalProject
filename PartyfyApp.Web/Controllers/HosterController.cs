namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PartyfyApp.Web.Infrastructure.Extensions;
    using PartyfyApp.Web.ViewModels.Hoster;
    using PartyfyApp.Services.Data.Interfaces;
    using static PartyfyApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class HosterController : Controller
    {
        private readonly IHosterService _hosterService;

        public HosterController(IHosterService hosterService)
        {
            _hosterService = hosterService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.GetId();

            bool hosterExist = await _hosterService.HosterExistsByIdAsync(userId);

            if (hosterExist)
            {
                TempData[ErrorMessage] = "You are already a hoster!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeHosterFormModel model)
        {
            string? userId = User.GetId();
            bool isAlreadyHoster = await _hosterService.HosterExistsByIdAsync(userId);
            if (isAlreadyHoster)
            {
                TempData[ErrorMessage] = "You are already a hoster!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken =
                await _hosterService.HosterExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Hoster with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                await _hosterService.AddAsync(userId, model);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] =
                    "Unexpected error occurred while registering you as a hoster! Please try again later or contact administrator.";

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("All", "Event");
        }
    }
}
