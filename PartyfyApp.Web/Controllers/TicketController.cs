namespace PartyfyApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.Infrastructure.Extensions;
    using PartyfyApp.Web.ViewModels.Ticket;

    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketFormViewModel model) {
            await _ticketService.AddTicketsAsync(model);

            return RedirectToAction("All", "Event");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TicketFormViewModel model)
        {
            await _ticketService.EditTicketsAsync(model);

            return RedirectToAction("All", "Event");
        }

        [HttpPost]
        public async Task<IActionResult> Buy(TicketBuyViewModel model)
        {
            if (model.QuantityToBuy > 0)
            {
                if(!(await _ticketService.EnoughTicketsAsync(model)))
                {
                    TempData["Error"] = "Not enough tickets available.";
                }
                else
                {
                    await _ticketService.BuyTicketsAsync(model, User.GetId());
                    TempData["Success"] = "Tickets purchased successfully!";
                }
            }
            else
            {
                TempData["Error"] = "Invalid ticket quantity.";
            }

            return RedirectToAction("All", "Event");
        }
    }
}
