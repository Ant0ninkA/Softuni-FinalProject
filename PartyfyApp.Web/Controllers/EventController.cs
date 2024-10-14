namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class EventController : Controller
    {
        public EventController()
        {
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
