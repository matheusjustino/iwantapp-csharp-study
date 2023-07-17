namespace IWantApp.Services;

using IWantApp.Models.Products;
using IWantApp.ViewModel;

public interface ICategoryService
{
    Task<string> CreateCategory(CreateCategoryViewModel categoryRequest);

    List<Category> ListCategories();

    Category GetCategoryById(Guid id);
}
