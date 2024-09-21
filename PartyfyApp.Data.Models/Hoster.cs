namespace PartyfyApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static PartyfyApp.Common.EntityValidationConstants.Hoster;
    public class Hoster
    {
        public Hoster()
        {
            Id = Guid.NewGuid();
            this.MyEvents = new HashSet<Event>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<Event> MyEvents { get; set; } = null!;

    }
}
