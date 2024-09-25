namespace PartyfyApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class TicketTypeEntityConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder
                .HasData(this.GenerateTypes());
        }

        private TicketType[] GenerateTypes()
        {
            ICollection<TicketType> types = new HashSet<TicketType>();

            TicketType type;

            type = new TicketType()
            {
                Id = 1,
                Type = "VIP"
            };
            types.Add(type);

            type = new TicketType()
            {
                Id = 2,
                Type = "Standart"
            };
            types.Add(type);

            type = new TicketType()
            {
                Id = 3,
                Type = "Standing"
            };
            types.Add(type);

            return types.ToArray();

        }
    }
}
