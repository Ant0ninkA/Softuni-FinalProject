namespace PartyfyApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data.Models;
    using System.Reflection;

    public class PartyfyAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PartyfyAppDbContext(DbContextOptions<PartyfyAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<TicketType> TicketTypes { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Hoster> Hosters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configurationAssembly = Assembly.GetAssembly(typeof(PartyfyAppDbContext)) ??Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configurationAssembly);

            base.OnModelCreating(builder);
        }

    }
}
