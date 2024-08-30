using Common.Common.Repositories;
using ProductService.Api.Data;
using ProductService.Api.Models;

namespace ProductService.Api.Repositories
{
    public class ProductRepository : EfRepositoryBase<Product, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
    }
}
