using Microsoft.EntityFrameworkCore;
using PartyfyApp.Data;
using PartyfyApp.Data.Models;
using PartyfyApp.Services.Data.Interfaces;
using PartyfyApp.Web.ViewModels.Ticket;
using System.Linq;

namespace PartyfyApp.Services.Data
{
    public class TicketService : ITicketService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public TicketService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddTicketsAsync(TicketFormViewModel model)
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

        public async Task EditTicketsAsync(TicketFormViewModel model)
        {
            Ticket[] tickets = await _dbContext.Tickets
                .Where(t => t.EventId == model.EventId)
                .ToArrayAsync();

            Ticket? ticket;
            ticket = tickets
                .Where(t => t.TicketTypeId == 1)
                .FirstOrDefault();

            if (ticket != null)
            {
                ticket.Price = model.VipPrice;
                ticket.Quantity = model.VipQuantity;
            }
            else
            {
                await _dbContext.Tickets.AddAsync(new Ticket
                {
                    Id = Guid.NewGuid(),
                    TicketTypeId = 1,
                    Price = model.VipPrice,
                    Quantity = model.VipQuantity,
                    EventId = model.EventId,
                });
            }

            ticket = tickets
                .Where(t => t.TicketTypeId == 2)
                .FirstOrDefault();

            if (ticket != null)
            {
                ticket.Price = model.StandardPrice;
                ticket.Quantity = model.StandardQuantity;
            }
            else
            {
                await _dbContext.Tickets.AddAsync(new Ticket
                {
                    Id = Guid.NewGuid(),
                    TicketTypeId = 2,
                    Price = model.StandardPrice,
                    Quantity = model.StandardQuantity,
                    EventId = model.EventId,
                });
            }

            ticket = tickets.Where(t => t.TicketTypeId == 3)
                .FirstOrDefault();

            if (ticket != null)
            {
                ticket.Price = model.StandingPrice;
                ticket.Quantity = model.StandardQuantity;
            }
            else
            {
                await _dbContext.Tickets.AddAsync(new Ticket
                {
                    Id = Guid.NewGuid(),
                    TicketTypeId = 3,
                    Price = model.StandingPrice,
                    Quantity = model.StandingQuantity,
                    EventId = model.EventId,
                });
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TicketFormViewModel> GetTicketsForEdit(int eventId)
        {
            Ticket[] tickets = await _dbContext
                .Tickets
                .Where(t => t.EventId == eventId)
                .ToArrayAsync();

            TicketFormViewModel result = new TicketFormViewModel
            {
                VipPrice = tickets.Where(t => t.TicketTypeId == 1)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m,
                VipQuantity = tickets.Where(t => t.TicketTypeId == 1)
                             .Select(t => (int?)t.Quantity)
                             .FirstOrDefault() ?? 0,
                StandardPrice = tickets.Where(t => t.TicketTypeId == 2)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m,
                StandardQuantity = tickets.Where(t => t.TicketTypeId == 2)
                             .Select(t => (int?)t.Quantity)
                             .FirstOrDefault() ?? 0,
                StandingPrice = tickets.Where(t => t.TicketTypeId == 3)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m,
                StandingQuantity = tickets.Where(t => t.TicketTypeId == 3)
                             .Select(t => (int?)t.Quantity)
                             .FirstOrDefault() ?? 0
            };

            return result;
        }
    }
}
