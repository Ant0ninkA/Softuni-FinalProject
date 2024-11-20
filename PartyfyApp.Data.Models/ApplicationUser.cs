namespace PartyfyApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

            this.LikedEvents = new HashSet<Event>();
            this.Tickets = new HashSet<Ticket>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Event> LikedEvents { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }



    }
}
