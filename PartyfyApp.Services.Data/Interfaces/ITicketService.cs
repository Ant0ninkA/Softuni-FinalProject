using PartyfyApp.Web.ViewModels.Ticket;

namespace PartyfyApp.Services.Data.Interfaces
{
    public interface ITicketService
    {
        Task AddTicketsAsync(TicketFormViewModel model);

        Task EditTicketsAsync(TicketFormViewModel model);

        Task<TicketFormViewModel> GetTicketsForEditAsync(int eventId);

        Task<TicketBuyViewModel> GetTicketsToBuyAsync(int eventId);

        Task BuyTicketsAsync(TicketBuyViewModel model, string userId);

        Task<bool> EnoughTicketsAsync(TicketBuyViewModel model);

        Task<IEnumerable<UserTicketViewModel>> GetTicketsByUserAsync(string userId);
    }
}
