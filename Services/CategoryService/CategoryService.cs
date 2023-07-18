namespace IWantApp.Services;

using IWantApp.Data;
using IWantApp.Models.Products;
using IWantApp.ViewModel;
using IWantApp.ViewModel.Category;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;

    private readonly ApplicationDbContext _context;

    public CategoryService(ILogger<CategoryService> logger, ApplicationDbContext context)
    {
        this._logger = logger;
        this._context = context;
    }

    public async Task<string> CreateCategory(CreateCategoryViewModel categoryRequest)
    {
        this._logger.Log(LogLevel.Information, "Create category");

        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "Test",
            EditedBy = "Test",
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now,
        };

        await this._context.Categories.AddAsync(category);
        await this._context.SaveChangesAsync();
        // this._context.Dispose();
        return category.Id.ToString();
    }

    public List<Category> ListCategories()
    {
        return this._context.Categories.ToList();
    }

    public Category? GetCategoryById(Guid id)
    {
        return this._context.Categories.Where(c => c.Id == id).FirstOrDefault();
    }

    public async Task<string> UpdateCategory(Guid categoryId, UpdateCategoryViewModel data)
    {
        this._logger.Log(LogLevel.Information, $"Update Category - categoryId: {categoryId} - data: {data}");

        var category = await this._context.Categories.FindAsync(categoryId);
        if (category is null)
        {
            throw new BadHttpRequestException("Category not found");
        }

        if (category.Name == data.Name)
        {
            return category.Id.ToString();
        }

        category.Name = data.Name;
        category.UpdatedOn = DateTime.Now;

        await this._context.SaveChangesAsync();

        return category.Id.ToString();
    }

    public async Task<string> DeleteCategory(Guid categoryId)
    {
        this._logger.Log(LogLevel.Information, $"Delete Category - categoryId: {categoryId}");

        var category = this._context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        if (category is null)
        {
            throw new BadHttpRequestException("Category not found");
        }

        this._context.Categories.Remove(category);
        await this._context.SaveChangesAsync();

        return categoryId.ToString();
    }
}
