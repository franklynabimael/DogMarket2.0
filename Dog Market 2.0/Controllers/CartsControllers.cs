using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Net;
using System.Security.Claims;

namespace Dog_Market_2._0.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly DogMarketContext _context;
    public CartsController(DogMarketContext context)
    {
        _context = context;
    }

    [HttpGet("myCart")]
    [Authorize]
    public async Task<IActionResult> GetCart()
    {
        string? currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId == null)
            return StatusCode((int)HttpStatusCode.Unauthorized);
        var cart = await _context.Carts.Include(x => x.CartDetails).FirstOrDefaultAsync(x => x.UserId == currentUserId) ?? throw new ArgumentNullException(nameof(currentUserId), "No se encontro");
        CartResponse response = cart.Adapt<CartResponse>();
        return Ok(response);
    }

    [HttpGet("{productId}/{quantity:int}")]
    [Authorize]
    public async Task<IActionResult> CartProductAsync(Guid productId, int quantity)
    {
        string? currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId == null)
            return StatusCode((int)HttpStatusCode.Unauthorized);

        var cart = await _context.Carts.Include(x => x.CartDetails).FirstOrDefaultAsync(x => x.UserId == currentUserId) ?? throw new ArgumentNullException(nameof(currentUserId), "No se encontro");
        var product = await _context.Produts.FirstOrDefaultAsync(x => x.Id == productId) ?? throw new ArgumentNullException(nameof(productId), "No se encontro");

        if(cart.CartDetails == null)
            cart.CartDetails = new List<Detail>();
        var existingCart = cart.CartDetails.FirstOrDefault(x => x.ProductId == productId);
        if (existingCart == null)
        {
            if (quantity > product.Stock)
                throw new Exception($"You are exceding the stock");
            existingCart = new Detail
            {
                ProductId = productId,
                Quantity = quantity,
                Price = product.Price,
            };
            cart.CartDetails.Add(existingCart);
        }
        else
        {
            existingCart.Quantity += quantity;
            if (existingCart.Quantity > product.Stock)
                throw new Exception($"You are exceding the stock");
        } 
        

        _context.Carts.Update(cart);
        await _context.SaveChangesAsync();
        CartResponse cartResponse = cart.Adapt<CartResponse>();
        return Ok(cartResponse);
    }

    [HttpDelete("{detailId}")]
    [Authorize]
    public async Task<IActionResult> DeleteDetail(Guid detailId)
    {
        Detail detail = await _context.Details.FindAsync(detailId)?? throw new ArgumentNullException(nameof(detailId), "No Se encontro");
        _context.Details.Remove(detail);
        await _context.SaveChangesAsync();
        return Ok();
    }


}
    