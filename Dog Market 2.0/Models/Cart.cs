using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dog_Market_2._0.Models;

public class Cart
{

    public Guid Id { get; set; }
    public User UserCart { get; set; }
    public string UserId { get; set; }
    public ICollection<Detail> CartDetails { get; set; }

}
