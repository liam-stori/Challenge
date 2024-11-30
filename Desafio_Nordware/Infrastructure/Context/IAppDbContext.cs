using App.Core.Interfaces;

namespace App.Infrastructure.Context;

public interface IAppDbContext
{
    IProductRepository Products { get; }
    ICustomerRepository Customers { get; }
    IReservationRepository Reservations { get; }
    IQueryable<T> Query<T>() where T : class;
}
