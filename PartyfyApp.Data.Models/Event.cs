namespace PartyfyApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.Event;
    public class Event
    {
        public Event()
        {
                this.Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        [Required]
        [StringLength(DJMaxLength)]
        public string DJ { get; set; } = null!;

        [Required]
        public DateTime EventDate { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required]
        public string PosterImagePath { get; set; } = null!;
        public bool Status  { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public Guid HosterId { get; set; }
        public virtual Hoster Hoster { get; set; } = null!;
        public Guid? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
