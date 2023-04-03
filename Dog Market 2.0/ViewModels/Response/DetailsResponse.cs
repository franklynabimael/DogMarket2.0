using Dog_Market_2._0.Models;

namespace Dog_Market_2._0.ViewModels.Response;

public class DetailsResponse
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public Guid? PurchaseId { get; set; }
}
