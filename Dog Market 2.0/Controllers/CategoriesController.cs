using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels;
using Dog_Market_2._0.ViewModels.Response;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dog_Market_2._0.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly DogMarketContext _context;
    public CategoriesController(DogMarketContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        IEnumerable<Category> categories = await _context.Categories.ToListAsync();
        IEnumerable<CategoriesResponse> categoriesResponses = categories.Adapt<IEnumerable<CategoriesResponse>>();
        return Ok(categoriesResponses);
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategory(int categoryId)
    {
        Category category = await _context.Categories.Include(x => x.CategoryProducts).FirstOrDefaultAsync(x => x.Id == categoryId) ?? throw new ArgumentNullException(nameof(categoryId), "No se encontro");
        CategoryResponse response = category.Adapt<CategoryResponse>();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryDTO addCategoryDTO)
    {
        var category = addCategoryDTO.Adapt<Category>();
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        AddCategoryResponse categoryResponse = category.Adapt<AddCategoryResponse>();
        return Ok(categoryResponse);
    }
}
