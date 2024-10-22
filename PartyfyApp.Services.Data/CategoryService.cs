using Microsoft.EntityFrameworkCore;
using PartyfyApp.Data;
using PartyfyApp.Services.Data.Interfaces;
using PartyfyApp.Web.ViewModels.Category;

namespace PartyfyApp.Services.Data
{
    public class CategoryService : ICategoryService
    {
        public readonly PartyfyAppDbContext _dbContext;

        public CategoryService(PartyfyAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<EventSelectCategoryViewModel>> AllCategoriesAsync()
        {
            IEnumerable<EventSelectCategoryViewModel> categories =
                await _dbContext.Categories
                .Select(c => new EventSelectCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return categories;
        }

        public async Task<IEnumerable<string>> AllNamesAsync()
        {
            IEnumerable<string> categories =
                await _dbContext.Categories
                .Select (c => c.Name)
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _dbContext.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
