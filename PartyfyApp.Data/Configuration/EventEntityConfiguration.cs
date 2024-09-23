namespace PartyfyApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PartyfyApp.Data.Models;
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasOne(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Hoster)
                .WithMany(c => c.MyEvents)
                .HasForeignKey(e => e.HosterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
