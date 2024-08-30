using Common.Common.Repositories;
using ProductService.Api.Models;

namespace ProductService.Api.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
