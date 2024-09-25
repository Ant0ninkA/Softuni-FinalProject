namespace PartyfyApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder
               //.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Techno"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Rap"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Pop-folk"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Winamp"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Latino"
            };
            categories.Add(category);

            return categories.ToArray();

        }
    }
}
