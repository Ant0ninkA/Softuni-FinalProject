namespace PartyfyApp.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PartyfyApp.Data;
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Event;
    using PartyfyApp.Web.ViewModels.Event.Enum;
    using PartyfyApp.Data.Models;

    public class EventService : IEventService
    {
        private readonly PartyfyAppDbContext _dbContext;

        public EventService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(string hosterId, EventFormViewModel model, string posterPath)
        {
            Event newEvent = new Event()
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
                Status = true
            };

            await _dbContext.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AllEventsFilteredAndPagedServiceModel> AllAsync(AllEventsQueryModel queryModel)
        {
            IQueryable<Event> eventsQuery = _dbContext
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
                .Where(e => e.Status)
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

        public async Task<bool> ExistsByIdAsync(int eventId)
        {
            return await _dbContext.Events.AnyAsync(e => e.Id == eventId);
        }

        public async Task LikeAsync(string userId, int eventId)
        {
            var user = await _dbContext.Users
                .Include(u => u.LikedEvents)
                .FirstAsync(u => u.Id.ToString() == userId);

            var likedEvent = await _dbContext.Events.FindAsync(eventId);

            if (!user.LikedEvents.Contains(likedEvent))
            {
                user.LikedEvents.Add(likedEvent);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task UnlikeAsync(string userId, int eventId)
        {
            var user = await _dbContext.Users
                .Include(u => u.LikedEvents)
                .FirstAsync(u => u.Id.ToString() == userId);

            var likedEvent = await _dbContext.Events.FindAsync(eventId);

            if (user.LikedEvents.Contains(likedEvent))
            {
                user.LikedEvents.Remove(likedEvent);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<EventAllViewModel>> AllLiked(string userId)
        {
            var user = await _dbContext.Users
                .Include(u =>u.LikedEvents)
                .FirstAsync(u => u.Id.ToString() == userId);

            IEnumerable<EventAllViewModel> likedEvents = user
                .LikedEvents
                .Select(le => new EventAllViewModel
                {
                    Id = le.Id,
                    Title = le.Title,
                    Location = le.Location,
                    DJ = le.DJ,
                    EventDate = le.EventDate,
                    PosterImagePath = le.PosterImagePath
                })
                .ToArray();

            return likedEvents;
        }

        public async Task<int> GetTicketsCount(int eventId)
        {
            Event currEvent = await _dbContext.Events
                .Include(e => e.Tickets)
                .Where(e => e.Id == eventId)
                .FirstAsync();

            return currEvent.Tickets.Count();

        }

        public async Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId)
        {
            Event currEvent = await _dbContext.Events
                .Include(e => e.Tickets)
                .Include(e => e.Hoster)
                .Where(e => e.Id == eventId)
                .FirstAsync();

            var vipTicket = currEvent.Tickets.FirstOrDefault(t => t.TicketTypeId == 1);
            var standardTicket = currEvent.Tickets.FirstOrDefault(t => t.TicketTypeId == 2);
            var standingTicket = currEvent.Tickets.FirstOrDefault(t => t.TicketTypeId == 3);

            EventDetailsViewModel model = new EventDetailsViewModel
            {
                Id = currEvent.Id,
                Title = currEvent.Title,
                Description = currEvent.Description,
                EventDate = currEvent.EventDate,
                Location = currEvent.Location,
                PosterImagePath = currEvent.PosterImagePath,
                HosterContact = currEvent.Hoster.PhoneNumber,
                VipTicketPrice = vipTicket?.Price ?? 0,
                StandardTicketPrice = standardTicket?.Price ?? 0,
                StandingTicketPrice = standingTicket?.Price ?? 0,
                VipTicketQuantity = vipTicket?.Quantity ?? 0,
                StandardTicketQuantity = standardTicket?.Quantity ?? 0,
                StandingTicketQuantity = standingTicket?.Quantity ?? 0

            };

            return model;
        }

        public async Task<EventFormViewModel> GetEventForEditByIdAsync(int eventId)
        {
            Event currEvent = await _dbContext
                .Events
                .Include(e => e.Category)
                .Where(e => e.Status)
                .FirstAsync(e => e.Id == eventId);

            return new EventFormViewModel
            {
                Title = currEvent.Title,
                Description = currEvent.Description,
                Location = currEvent.Location,
                DJ = currEvent.DJ,
                EventDate = currEvent.EventDate,
                CategoryId = currEvent.CategoryId,
            };
        }

        public async Task EditEventAsync(int eventId,string posterPath, EventFormViewModel model)
        {
            Event currEvent = await _dbContext
                .Events
                .Where(e => e.Status)
                .FirstAsync(e => e.Id == eventId);

            currEvent.Title = model.Title;
            currEvent.Description = model.Description;
            currEvent.Location = model.Location;
            currEvent.DJ = model.DJ;
            currEvent.EventDate = model.EventDate;
            currEvent.CategoryId = model.CategoryId;

            if(posterPath != "")
            {
                currEvent.PosterImagePath = posterPath;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<EventPreDeleteViewModel> GetEventForDeleteByIdAsync(int eventId)
        {
            Event currEvent = await _dbContext
              .Events
              .Where(e => e.Status)
              .FirstAsync(e => e.Id == eventId);

            return new EventPreDeleteViewModel
            {
                Title = currEvent.Title,
                EventDate = currEvent.EventDate,
                PosterImg = currEvent.PosterImagePath,
            };
        }

        public async Task DeleteEventAsync(int eventId)
        {
            Event eventToDelete = await _dbContext
                .Events
                .Where(e => e.Status)
                .FirstAsync(e => e.Id == eventId);

            eventToDelete.Status = false;

            await _dbContext.SaveChangesAsync();
        }
    }
}
