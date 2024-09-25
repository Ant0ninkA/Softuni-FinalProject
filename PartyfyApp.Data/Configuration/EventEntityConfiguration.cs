namespace PartyfyApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
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

        private Event[] GenerateEvents()
        {
            ICollection<Event> events = new HashSet<Event>();

            Event currEvent;
            currEvent = new Event()
            {
                Id = 1,
                Title = "EXE season 7 OPENING",
                Description = "This season is centred around what we want to see more, it's all about the deep connection with the subconscious and the city that made us, the true urban jungle that we all want to be part of each and every week!",
                Location = "EXE club, Sofia",
                DJ = "COZTOF",
                EventDate = new DateTime(2024, 10, 3),
                CreatedOn = DateTime.UtcNow,
                PosterImagePath = "~/images/EXE CLUB.png",
                CategoryId = 4,
                HosterId = Guid.Parse("F875A472-77C7-4908-AEEF-6D2B031282E1")
            };
            events.Add(currEvent);

            currEvent = new Event()
            {
                Id = 2,
                Title = "Ladies night",
                Description = "Feel the heat with the best Latin music, from sensual salsa to reggaeton beats that will keep you dancing all night long. Whether you're a seasoned dancer or just looking to have a great time, our DJ will spin the hottest tracks to make sure the energy never stops!",
                Location = "Hacienda canteen, Sofia",
                DJ = "Pandora MC Bram",
                EventDate = new DateTime(2024, 12, 14),
                CreatedOn = DateTime.UtcNow,
                PosterImagePath = "~/images/Ladies Night.png",
                CategoryId = 5,
                HosterId = Guid.Parse("F875A472-77C7-4908-AEEF-6D2B031282E1")
            };
            events.Add(currEvent);

            currEvent = new Event()
            {
                Id = 3,
                Title = "Les Machines with Commissar Lag",
                Description = "Our world-class DJ lineup will take you on an intense sonic journey with hard-hitting bass, hypnotic melodies, and deep, driving rhythms that will make you lose yourself on the dance floor. This is where the music speaks, and the crowd moves as one.",
                Location = "Yalta club, Sofia",
                DJ = "Dimitar Georgiev - Groky",
                EventDate = new DateTime(2025, 1, 25),
                CreatedOn = DateTime.UtcNow,
                PosterImagePath = "~/images/Techno Rave.png",
                CategoryId = 1,
                HosterId = Guid.Parse("F875A472-77C7-4908-AEEF-6D2B031282E1")
            };
            events.Add(currEvent);

            return events.ToArray();
        }
    }
}
