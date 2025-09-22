namespace IranJackProject.Application.Dtos.InventoryRecords;

public record InventoryRecordDto
(
    string ProductName,
    int Quantity,
    DateTime ProductionDate,
    DateTime ExpiryDate
);
