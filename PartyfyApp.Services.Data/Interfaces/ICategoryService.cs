using PartyfyApp.Web.ViewModels.Category;

namespace PartyfyApp.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<EventSelectCategoryViewModel>> AllCategoriesAsync();

        Task<IEnumerable<string>> AllNamesAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
