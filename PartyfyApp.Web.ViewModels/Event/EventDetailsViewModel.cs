namespace PartyfyApp.Web.ViewModels.Event
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = null!;
        public string PosterImagePath { get; set; } = null!;

        public string HosterContact { get; set; } = null!;

        public bool IsLiked { get; set; }

        // Ticket details
        public decimal? VipTicketPrice { get; set; }
        public int? VipTicketQuantity { get; set; }
        public decimal? StandardTicketPrice { get; set; }
        public int? StandardTicketQuantity { get; set; }
        public decimal? StandingTicketPrice { get; set; }
        public int? StandingTicketQuantity { get; set; }

    }

}
