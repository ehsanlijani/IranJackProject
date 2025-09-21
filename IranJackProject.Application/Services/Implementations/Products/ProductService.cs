using IranJackProject.Application.Services.Interfaces.Products;
using IranJackProject.Domain.Models.Products;
using IranJackProject.Infrastructure.Persistence.UnitOfWork;

namespace IranJackProject.Application.Services.Implementations.Products;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await unitOfWork.Products.AddAsync(product, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        unitOfWork.Products.Delete(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Product> GetAll()
       => unitOfWork.Products.GetAll();

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
      => await unitOfWork.Products.GetByIdAsync(id, cancellationToken);

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        unitOfWork.Products.Update(product);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
