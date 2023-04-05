namespace Dog_Market_2._0.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set;}
    public string Code { get; set; }
    public ICollection<Detail>? ProductDetails { get; set; }
    public Category ProductCategory { get; set; }
    public int CategoryId { get; set; }
    public string? ImgPath { get; set; }
}
