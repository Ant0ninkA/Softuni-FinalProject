namespace PartyfyApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.LikedEvents = new HashSet<Event>();
            this.BuyedTiskets = new HashSet<Ticket>();
        }

        public virtual ICollection<Event> LikedEvents { get; set; }
        public virtual ICollection<Ticket> BuyedTiskets { get; set; }



    }
}
