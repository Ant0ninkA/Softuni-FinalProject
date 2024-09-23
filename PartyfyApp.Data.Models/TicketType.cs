namespace PartyfyApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.TicketType;
    public class TicketType
    {
        public TicketType()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
