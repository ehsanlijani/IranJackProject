using IranJackProject.Domain.Models.Products;
using IranJackProject.Infrastructure.Persistence.Context;
using IranJackProject.Infrastructure.Persistence.Repositories.Contracts.Products;
using Microsoft.EntityFrameworkCore;

namespace IranJackProject.Infrastructure.Persistence.Repositories.Implementations.Products;

public class ProductRepository(IranJackDbContext iranJackDbContext) : IProductRepository
{
    public IQueryable<Product> GetAll()
     => iranJackDbContext.Products.AsNoTracking().AsQueryable();

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await iranJackDbContext.Products.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        => await iranJackDbContext.Products.AddAsync(product, cancellationToken);

    public void Update(Product product)
        => iranJackDbContext.Products.Update(product);

    public void Delete(Product product)
        => iranJackDbContext.Products.Remove(product);
}
