namespace PartyfyApp.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PartyfyApp.Data;
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Event;
    using PartyfyApp.Web.ViewModels.Event.Enum;

    public class EventService : IEventService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public EventService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(string hosterId, EventFormViewModel model, string posterPath)
        {
            PartyfyApp.Data.Models.Event newEvent = new PartyfyApp.Data.Models.Event()
            {
                Title = model.Title,
                Description = model.Description,
                Location = model.Location,
                DJ = model.DJ,
                PosterImagePath = posterPath,
                EventDate = model.EventDate,
                CreatedOn = DateTime.UtcNow,
                CategoryId = model.CategoryId,
                HosterId = Guid.Parse(hosterId),
            };

            await _dbContext.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AllEventsFilteredAndPagedServiceModel> AllAsync(AllEventsQueryModel queryModel)
        {
            IQueryable<PartyfyApp.Data.Models.Event> eventsQuery = _dbContext
                .Events
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                eventsQuery = eventsQuery
                    .Where(e => e.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                eventsQuery = eventsQuery
                    .Where(e => EF.Functions.Like(e.Title, wildCard) ||
                                EF.Functions.Like(e.Location, wildCard) ||
                                EF.Functions.Like(e.DJ, wildCard) ||
                                EF.Functions.Like(e.DJ, wildCard));
            }

            eventsQuery = queryModel.EventSorting switch
            {
                EventSorting.Upcoming => eventsQuery
                    .OrderByDescending(e => e.EventDate),
                EventSorting.PriceAscending => eventsQuery
                    .OrderBy(e => e.Tickets.Where(t => t.TicketTypeId == 2)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m),
                EventSorting.PriceDescending => eventsQuery
                    .OrderByDescending(e => e.Tickets.Where(t => t.TicketTypeId == 2)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m)
            };

            IEnumerable<EventAllViewModel> allEvents = await eventsQuery
                //.Where(e => e.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.EventsPerPage)
                .Take(queryModel.EventsPerPage)
                .Select(e => new EventAllViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    Location = e.Location,
                    DJ = e.DJ,
                    PosterImagePath = e.PosterImagePath,
                    EventDate = e.EventDate,
                    PriceStandardTicket = e.Tickets.Where(t => t.TicketTypeId == 2)
                             .Select(t => (decimal?)t.Price)
                             .FirstOrDefault() ?? 0m
                })
                .ToArrayAsync();

            int totalEvents = eventsQuery.Count();

            return new AllEventsFilteredAndPagedServiceModel()
            {
                TotalEvents = totalEvents,
                Events = allEvents
            };
        }
    }
}
