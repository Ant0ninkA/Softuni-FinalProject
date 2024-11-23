namespace PartyfyApp.Web.ViewModels.Category
{
    using PartyfyApp.Data.Models;
    using PartyfyApp.Services.Mapping;
    public class EventSelectCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
