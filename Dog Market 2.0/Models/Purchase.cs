using System.ComponentModel.DataAnnotations.Schema;

namespace Dog_Market_2._0.Models;

public class Purchase
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public float Tax { get; set; }
    public int NumVoucher { get; set; }
    public User UserPurchase { get; set; }
    public string UserId { get; set; }
    public ICollection<Detail> PurchaseDetails { get; set; }


}
