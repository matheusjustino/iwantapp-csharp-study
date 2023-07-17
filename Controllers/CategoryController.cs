namespace IWantApp;

using Microsoft.AspNetCore.Mvc;
using IWantApp.Models.Products;
using IWantApp.Services;
using IWantApp.ViewModel;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateCategory([FromBody] CreateCategoryViewModel categoryRequest)
    {
        Console.WriteLine("model valid: " + this.ModelState.IsValid);
        if (!this.ModelState.IsValid)
            return BadRequest();

        var categoryId = await this._categoryService.CreateCategory(categoryRequest);
        // if (categoryId is null)
        if (string.IsNullOrEmpty(categoryId))
        {
            return BadRequest("Couldn't create category");
        }

        return Ok(categoryId);
    }

    [HttpGet]
    public ActionResult<List<Category>> ListCategories()
    {
        return Ok(this._categoryService.ListCategories());
    }
}
