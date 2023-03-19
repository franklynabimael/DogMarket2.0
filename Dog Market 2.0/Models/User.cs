using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dog_Market_2._0.Models;
public class User: IdentityUser
{
    [MinLength(3) , MaxLength(50), Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int Age { get; set; }
    public Cart CartUser { get; set; }
    public ICollection<Purchase> PurchaseUser { get; set; }

}

