namespace PartyfyApp.Services.Data.Interfaces
{
    using PartfyApp.Services.Data.Models.Event;
    using PartyfyApp.Data.Models;
    using PartyfyApp.Web.ViewModels.Event;
    public interface IEventService
    {
        Task AddAsync(string userId, EventFormViewModel model, string posterPath);

        Task<AllEventsFilteredAndPagedServiceModel> AllAsync(AllEventsQueryModel queryModel);

        Task<IEnumerable<EventAllViewModel>> AllLiked(string userId);

        Task LikeAsync(string userId, int eventId);

        Task UnlikeAsync(string userId, int eventId);

        Task<bool> ExistsByIdAsync(int eventId);

        Task<int> GetTicketsCount(int eventId);

        Task<EventDetailsViewModel> GetEventDetailsAsync(int eventId);

        Task<EventFormViewModel> GetEventForEditByIdAsync(int eventId);

        Task EditEventAsync(int eventId, string posterPath, EventFormViewModel model);

        Task<EventPreDeleteViewModel> GetEventForDeleteByIdAsync(int eventId);

        Task DeleteEventAsync(int eventId);
    }
}
