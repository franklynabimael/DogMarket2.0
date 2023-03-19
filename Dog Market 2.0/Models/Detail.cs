using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dog_Market_2._0.Models;

public class Detail
{
    public Guid IdDetailPurchase { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Cart CartDetail { get; set; }
    public Guid CartId { get; set; }

    public Product ProductDetail { get; set; }
    public Guid ProductId { get; set; }
    public Purchase PurchaseDetail { get; set; }
    public Guid PurchaseId { get; set; }

}
