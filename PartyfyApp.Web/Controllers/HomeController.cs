namespace PartyfyApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;


    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels;

    using static PartyfyApp.Common.GeneralApplicationConstants;
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                //return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }

        public async Task<IActionResult> Upcoming() {
            return View(await _eventService.UpcomingThreeEventsAsync());
        }
    }
}
