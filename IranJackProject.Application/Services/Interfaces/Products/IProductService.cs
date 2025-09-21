using IranJackProject.Domain.Models.Products;
using System.Threading.Tasks;

namespace IranJackProject.Application.Services.Interfaces.Products;

public interface IProductService
{
    IQueryable<Product> GetAll();

    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(Product product, CancellationToken cancellationToken);

    Task UpdateAsync(Product product, CancellationToken cancellationToken);

    Task DeleteAsync(Product product, CancellationToken cancellationToken);
}
