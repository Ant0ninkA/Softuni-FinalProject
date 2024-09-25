namespace PartyfyApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasOne(t => t.TicketType)
                .WithMany(tt => tt.Tickets)
                .HasForeignKey(t => t.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.Buyers)
                .WithMany(b => b.BuyedTickets)
                .UsingEntity(tb => tb.ToTable("TicketsBuyers"));

            builder
                .HasData(this.GenerateTickets());

        }

        private Ticket[] GenerateTickets()
        {
            ICollection<Ticket> tickets = new HashSet<Ticket>();

            Ticket ticket;

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 2,
                Price = 20.0m,
                Quantity = 400,
                EventId = 1
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 1,
                Price = 50.0m,
                Quantity = 30,
                EventId = 2
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 2,
                Price = 30.0m,
                Quantity = 100,
                EventId = 2
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 1,
                Price = 80.0m,
                Quantity = 45,
                EventId = 3
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 2,
                Price = 50.0m,
                Quantity = 200,
                EventId = 3
            };
            tickets.Add(ticket);

            ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                TicketTypeId = 3,
                Price = 20.0m,
                Quantity = 200,
                EventId = 3
            };
            tickets.Add(ticket);


            return tickets.ToArray();
        }
    }
}
