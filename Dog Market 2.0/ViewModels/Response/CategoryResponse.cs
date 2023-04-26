using Dog_Market_2._0.Models;

namespace Dog_Market_2._0.ViewModels.Response;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProductsResponses>? CategoryProducts { get; set; }
}
