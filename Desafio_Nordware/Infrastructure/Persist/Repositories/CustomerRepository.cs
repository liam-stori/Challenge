using App.Core.Entities;
using App.Core.Interfaces;

namespace App.Infrastructure.Persist.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ISession session)
        : base(session) { }
}
