using IranJackProject.Domain.Enums;

namespace IranJackProject.Application.Dtos.Products;

public record ProductDto
(
  string Name,
  CategoryEnum Category,
  decimal Price,
  bool IsActive
);
