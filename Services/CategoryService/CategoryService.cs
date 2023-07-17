namespace IWantApp.Services;

using IWantApp.Data;
using IWantApp.Models.Products;
using IWantApp.ViewModel;

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
}
