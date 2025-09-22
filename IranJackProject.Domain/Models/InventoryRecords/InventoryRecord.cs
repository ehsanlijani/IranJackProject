using IranJackProject.Domain.Models.Common;
using IranJackProject.Domain.Models.Products;

namespace IranJackProject.Domain.Models.InventoryRecords;

public class InventoryRecord : BaseEntity
{
    #region Properties

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime ProductionDate { get; set; } = DateTime.Now;

    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(30);

    #endregion Properties

    #region Relations

    public Product Product { get; set; } 

    #endregion Relations
}
