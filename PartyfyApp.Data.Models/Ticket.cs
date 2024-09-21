namespace PartyfyApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Ticket
    {
        public Ticket()
        {
            Id = Guid.NewGuid();
            this.Buyers = new HashSet<ApplicationUser>();
        }

        [Key]
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public virtual TicketType TicketType { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Buyers { get; set; }
    }
}
