namespace PartyfyApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels;
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Upcoming() {
            return View(await _eventService.UpcomingThreeEventsAsync());
        }
    }
}
