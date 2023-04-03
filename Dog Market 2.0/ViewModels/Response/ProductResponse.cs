using Dog_Market_2._0.Models;

namespace Dog_Market_2._0.ViewModels.Response;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
}
