using Dog_Market_2._0.Models;

namespace Dog_Market_2._0.ViewModels.Response;

public class PurchaseResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public float Tax { get; set; }
    public int NumVoucher { get; set; }
    public string UserId { get; set; }
    public ICollection<DetailsResponse> PurchaseDetails { get; set; }
}
