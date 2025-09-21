using IranJackProject.Domain.Models.Products;
using System.Linq.Expressions;

namespace IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;

public interface IProductRepository
{
    IQueryable<Product> GetAll();

    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(Product product, CancellationToken cancellationToken = default);

    void Update(Product product);

    void Delete(Product product);
}