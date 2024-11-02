using PartyfyApp.Web.ViewModels.Ticket;

namespace PartyfyApp.Services.Data.Interfaces
{
    public interface ITicketService
    {
        Task AddTickets(TicketFormViewModel model);
        
        Task<TicketFormViewModel> GetTicketsForEdit(int eventId);
    }
}
