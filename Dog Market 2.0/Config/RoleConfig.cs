using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dog_Market_2._0.Config;

/// <summary>
/// Configures the schema needed for ASP.NET Identity.
/// </summary>
public sealed class RoleConfig : IEntityTypeConfiguration<IdentityRole>
{

    private const string adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
    private const string userId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = adminId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = userId,
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}
