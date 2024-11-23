namespace PartyfyApp.Web.ViewModels.Event
{
    using System.ComponentModel.DataAnnotations;

   
    using PartyfyApp.Web.ViewModels.Ticket;

    public class EventAllViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string DJ { get; set; } = null!;

        [Display(Name = "")]
        public string PosterImagePath { get; set; } = null!;

        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Price for standard ticket")]
        public decimal PriceStandardTicket { get; set; }

        public TicketFormViewModel Tickets { get; set; } = null!;
    }
}
