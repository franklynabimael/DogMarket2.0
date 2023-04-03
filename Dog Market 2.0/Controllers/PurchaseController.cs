using Dog_Market_2._0.Models;
using Dog_Market_2._0.ViewModels.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using System.Threading;

namespace Dog_Market_2._0.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly DogMarketContext _context;
    public PurchaseController(DogMarketContext context)
    {
        _context = context;
    }

    [HttpPost("carts/{cartId}/Purchase")]
    [Authorize]
    public async Task<IActionResult> PurchaseAsync(Guid cartId)
    {
        string? currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId == null)
            return StatusCode((int)HttpStatusCode.Unauthorized);

        var details = _context.Details.Include(x => x.ProductDetail).Where(x => x.CartId == cartId).ToList() ?? throw new ArgumentNullException(nameof(cartId), "No hay productos en el carrito");
        var purchase = new Purchase()
        {
            Date = DateTime.UtcNow,
            NumVoucher = 0,
            UserId = currentUserId,
            Tax = 0,
            PurchaseDetails = details
        };
        foreach (Detail detail in purchase.PurchaseDetails)
        {
            if (detail.ProductDetail.Stock < detail.Quantity)
                throw new Exception("Products stock exceded");
            detail.ProductDetail.Stock -= detail.Quantity;
            detail.PurchaseId = purchase.Id;
            detail.CartId = null;
        }
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
        PurchaseResponse purchaseResponse = purchase.Adapt<PurchaseResponse>();
        return Ok(purchaseResponse);
    }
}
