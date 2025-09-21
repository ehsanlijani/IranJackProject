using IranJackProject.Domain.Enums;
using IranJackProject.Domain.Models.Common;
using IranJackProject.Domain.Models.InventoryRecords;

namespace IranJackProject.Domain.Models.Products;

public class Product : BaseEntity
{
    #region Properties

    public string Name { get; set; }

    public CategoryEnum Category { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }

    #endregion Properties

    #region Relations

    public ICollection<InventoryRecord> InventoryRecords { get; set; } = new List<InventoryRecord>();

    #endregion Relations
}
