namespace IWantApp.Services;

using IWantApp.Models.Products;
using IWantApp.ViewModel;
using IWantApp.ViewModel.Category;

public interface ICategoryService
{
    Task<string> CreateCategory(CreateCategoryViewModel categoryRequest);

    List<Category> ListCategories();

    Category GetCategoryById(Guid id);

    Task<string> UpdateCategory(Guid categoryId, UpdateCategoryViewModel data);

    Task<string> DeleteCategory(Guid categoryId);
}
