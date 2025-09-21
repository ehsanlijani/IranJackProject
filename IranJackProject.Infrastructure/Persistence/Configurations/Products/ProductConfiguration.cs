using IranJackProject.Domain.Enums;
using IranJackProject.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranJackProject.Infrastructure.Persistence.Configurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Category)
            .HasDefaultValue(CategoryEnum.None);

        builder.HasMany(p => p.InventoryRecords)
            .WithOne(ir => ir.Product)
            .HasForeignKey(ir => ir.ProductId);
    }
}
