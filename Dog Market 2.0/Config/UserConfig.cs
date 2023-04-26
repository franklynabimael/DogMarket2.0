using Dog_Market_2._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dog_Market_2._0.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{

    private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
    private readonly UserManager<User> _userManager;
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.CartUser)
            .WithOne(x => x.UserCart)
            .HasForeignKey<Cart>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.PurchaseUser)
            .WithOne(x => x.UserPurchase)
            .HasForeignKey(x => x.UserId);

        var admin = new User
        {
            Id = adminId,
            Name = "Franklyn",
            UserName = "franklyn",
            NormalizedUserName = "FRANKLYN",
            Email = "user@example.com",
            NormalizedEmail = "USER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            LockoutEnabled = false,
            PhoneNumber = "8296872544",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            Address = "tuhna",
            Age = 22,
        };
        admin.PasswordHash = PassGenerate(admin);
        builder.HasData(admin);
    }

    public string PassGenerate(User user)
    {
        var passHash = new PasswordHasher<User>();
        return passHash.HashPassword(user, "Qwerty123");
    }
}
