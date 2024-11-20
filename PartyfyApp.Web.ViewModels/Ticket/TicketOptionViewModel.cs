namespace PartyfyApp.Web.ViewModels.Ticket
{
    public class TicketOptionViewModel
    {
        public int TicketTypeId { get; set; }
        public string TicketType { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
