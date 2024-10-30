using PartyfyApp.Data;
using PartyfyApp.Data.Models;
using PartyfyApp.Services.Data.Interfaces;
using PartyfyApp.Web.ViewModels.Ticket;

namespace PartyfyApp.Services.Data
{
    public class TicketService : ITicketService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public TicketService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddTickets(TicketFormViewModel model)
        {
            Ticket ticket;
            ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 1,
                Price = model.VipPrice,
                Quantity = model.VipQuantity,
                EventId = model.EventId,
            };
            await _dbContext.Tickets
                .AddAsync(ticket);

            ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 2,
                Price = model.StandardPrice,
                Quantity = model.StandardQuantity,
                EventId = model.EventId,
            };
            await _dbContext.Tickets
                .AddAsync(ticket);

            ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 3,
                Price = model.StandingPrice,
                Quantity = model.StandingQuantity,
                EventId = model.EventId,
            };
            await _dbContext.Tickets
                .AddAsync(ticket);

            await _dbContext.SaveChangesAsync();
        }
    }
}
