using App.Core.Entities;
using App.Core.Interfaces;

namespace App.Infrastructure.Persist.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ISession session)
        : base(session) { }
}
