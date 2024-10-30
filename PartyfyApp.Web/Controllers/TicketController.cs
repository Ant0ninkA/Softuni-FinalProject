namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Ticket;

    public class TicketController : Controller
    {
        private readonly ITicketService _ticketservice;

        public TicketController(ITicketService ticketservice)
        {
            _ticketservice = ticketservice;
        }

        public async Task<IActionResult> Add(TicketFormViewModel model) {
            await _ticketservice.AddTickets(model);

            return RedirectToAction("All", "Event");
        }
    }
}
