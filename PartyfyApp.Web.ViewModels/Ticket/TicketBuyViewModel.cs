namespace PartyfyApp.Web.ViewModels.Ticket
{
    public class TicketBuyViewModel
    {
        public int EventId { get; set; }
        public List<TicketOptionViewModel> Tickets { get; set; } = null!;
        public int SelectedTicketTypeId { get; set; }
        public int QuantityToBuy { get; set; }
    }
}
