using Dog_Market_2._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dog_Market_2._0.Config;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    private const int CategoryId = 1;
    private const int CategoryId2 = 2;
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasData(new Category()
        {
            Id = CategoryId,
            Name = "Juguetes",
            Description = "Son Juguetes",
        });
        builder.HasData(new Category()
        {
            Id = CategoryId2,
            Name = "Comida",
            Description = "Lo que comen los perros",
        });
    }
}
