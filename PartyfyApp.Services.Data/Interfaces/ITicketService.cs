using PartyfyApp.Web.ViewModels.Ticket;

namespace PartyfyApp.Services.Data.Interfaces
{
    public interface ITicketService
    {
        Task AddTicketsAsync(TicketFormViewModel model);

        Task EditTicketsAsync(TicketFormViewModel model);

        Task<TicketFormViewModel> GetTicketsForEdit(int eventId);
    }
}
