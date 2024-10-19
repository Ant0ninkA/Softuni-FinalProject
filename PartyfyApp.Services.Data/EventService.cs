namespace PartyfyApp.Services.Data
{
    using System.Threading.Tasks;

    using PartyfyApp.Data;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Services.Data.Interfaces;
    using PartyfyApp.Web.ViewModels.Event;

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
            };

            await _dbContext.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}
