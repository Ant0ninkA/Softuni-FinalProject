namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using PartyfyApp.Web.Infrastructure.Extensions;
    using PartyfyApp.Web.ViewModels.Ticket;
    using PartyfyApp.Services.Data.Interfaces;
    using static PartyfyApp.Common.NotificationMessagesConstants;
    

    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyTickets()
        {
            var model = await _ticketService.GetTicketsByUserAsync(User.GetId());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add", new { model.EventId });
            }

            try
            {
                await _ticketService.AddTicketsAsync(model);
                TempData[SuccessMessage] = "Tickets added successfully!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your tickets. Please try later or contact administrator!");
                return RedirectToAction("Add", new { model.EventId });
            }

            return RedirectToAction("All", "Event");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TicketFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { model.EventId });
            }

            try
            {
                await _ticketService.EditTicketsAsync(model);
                TempData[SuccessMessage] = "Tickets updated successfully!";
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while editing your tickets. Please try later or contact administrator!");
                return RedirectToAction("Edit", new { model.EventId });
            }

            return RedirectToAction("All", "Event");

        }
    }
}
