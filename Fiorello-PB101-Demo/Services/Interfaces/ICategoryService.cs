
using Fiorello_PB101_Demo.Models;
using Fiorello_PB101_Demo.ViewModels.Categories;

namespace Fiorello_PB101_Demo.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync();
        Task<Category> GetByIdAsync(int id);
        Task<CategoryDetailVM> GetByIdWithProductsAsync(int id);
        Task<bool> ExistAsync(string name);
        Task CreateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<bool> ExistExceptByIdAsync(int id, string name);
        Task<IEnumerable<CategoryArchiveVM>> GetAllArchveAsync();

    }
}
