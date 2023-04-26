using Dog_Market_2._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dog_Market_2._0.Config;

public class CartConfig : IEntityTypeConfiguration<Cart>
{
    private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
    private const string cartId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.CartDetails)
            .WithOne(x => x.CartDetail)
            .HasForeignKey(x => x.CartId);

        builder.HasData(new Cart()
        {
            Id = Guid.Parse(cartId),
            UserId = adminId,
        } );
    }
}


