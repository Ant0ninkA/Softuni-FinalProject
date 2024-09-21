namespace PartyfyApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PartyfyApp.Data.Models;

    public class PartyfyAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PartyfyAppDbContext(DbContextOptions<PartyfyAppDbContext> options)
            : base(options)
        {
        }
    }
}
