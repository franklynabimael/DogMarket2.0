using Dog_Market_2._0.Models;

namespace Dog_Market_2._0.ViewModels.Response;

public class CartResponse
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public IEnumerable<DetailsResponse>? CartDetails { get; set; }
}
