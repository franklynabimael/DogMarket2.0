namespace Dog_Market_2._0.ViewModels;

public class AddProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Code { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public string? ImgPath { get; set; }
}

