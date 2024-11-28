namespace PartyfyApp.Web.ViewModels.Ticket
{
    public class UserTicketViewModel
    {
        public string EventTitle { get; set; } = null!;
        public DateTime EventDate { get; set; }

        public string TicketType { get; set; } = null!;

        public Guid TicketId { get; set; }
    }
}
