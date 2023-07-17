namespace IWantApp;

using Microsoft.AspNetCore.Mvc;
using IWantApp.Models.Products;
using IWantApp.Services;
using IWantApp.ViewModel;

[Route("/api/categories")]
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
        {
            return BadRequest(new
            {
                message = "Invalid body",
            });
        }

        try
        {
            var categoryId = await this._categoryService.CreateCategory(categoryRequest);
            return Ok(new
            {
                categoryId,
            });
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new
            {
                message = "Couldn't create category",
            });
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<List<Category>> GetCategoryById([FromRoute] Guid id)
    {
        Console.WriteLine($"category id: {id}");

        var category = this._categoryService.GetCategoryById(id);
        if (category is null)
        {
            return NotFound(new
            {
                message = "Category not found",
            });
        }

        return Ok(category);
    }

    [HttpGet]
    public ActionResult<List<Category>> ListCategories()
    {
        return Ok(this._categoryService.ListCategories());
    }
}
