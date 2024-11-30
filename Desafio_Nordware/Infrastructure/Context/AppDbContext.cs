using App.Core.Interfaces;
using App.Infrastructure.Persist.Repositories;

namespace App.Infrastructure.Context;

public class AppDbContext : IAppDbContext
{
    private readonly ISession _session;

    public AppDbContext(ISession session)
    {
        _session = session;
    }

    public IProductRepository Products => new ProductRepository(_session);
    public IReservationRepository Reservations => new ReservationRepository(_session);
    public ICustomerRepository Customers => new CustomerRepository(_session);

    public IQueryable<T> Query<T>() where T : class
    {
        return _session.Query<T>();
    }
}

