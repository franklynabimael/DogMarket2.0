using Dog_Market_2._0.JwtFeatures;
using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels;
using Dog_Market_2._0.ViewModels.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dog_Market_2._0.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DogMarketContext _context;
    public ProductsController(DogMarketContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        IEnumerable<Product> products = await _context.Produts.ToListAsync();
        IEnumerable<ProductsResponses> productsResponses = products.Adapt<IEnumerable<ProductsResponses>>();
        return Ok(productsResponses);
    }

    [HttpGet("{productId}")]
    public async Task <IActionResult> GetProduct(Guid productId)
    {
        Product product = await _context.Produts.FirstOrDefaultAsync(x => x.Id == productId)??throw new ArgumentNullException(nameof(productId), "No se encontro");
        ProductResponse response = product.Adapt<ProductResponse>();
        return Ok(response);
    }

    [HttpPost("add")]
    
    public async Task<IActionResult> AddProducts(AddProductDTO addProductDTO)
    {
        var product = addProductDTO.Adapt<Product>();
        _context.Produts.Add(product);
        await _context.SaveChangesAsync();
        AddProductResponse productResponse = product.Adapt<AddProductResponse>();
        return Ok(productResponse);
    }

    [HttpDelete("{productId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        Product product = await _context.Produts.FindAsync(productId)?? throw new ArgumentNullException(nameof(productId), "No se encontro");
        _context.Produts.Remove(product);
        await _context.SaveChangesAsync();
        return Ok();
    }

}



