using IranJackProject.Domain.Enums;
using IranJackProject.Domain.Models.InventoryRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranJackProject.Infrastructure.Persistence.Configurations.InventoryRecords;

public class InventoryRecordConfiguration : IEntityTypeConfiguration<InventoryRecord>
{
    public void Configure(EntityTypeBuilder<InventoryRecord> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.ToTable(x => x.HasCheckConstraint("CK_InventoryRecord_Quantity_NonNegative", "[Quantity] >= 0"));

        builder.HasOne(ir => ir.Product)
       .WithMany(p => p.InventoryRecords)
       .HasForeignKey(ir => ir.ProductId);
    }
}
