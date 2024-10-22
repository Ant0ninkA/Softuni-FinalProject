namespace PartyfyApp.Services.Data.Interfaces
{
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Web.ViewModels.Event;
    public interface IEventService
    {
        Task AddAsync(string userId, EventFormViewModel model, string posterPath);

        Task<AllEventsFilteredAndPagedServiceModel> AllAsync(AllEventsQueryModel queryModel);
    }
}
