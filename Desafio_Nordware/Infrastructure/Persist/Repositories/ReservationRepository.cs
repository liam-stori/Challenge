using App.Core.Entities;
using App.Core.Interfaces;

namespace App.Infrastructure.Persist.Repositories;

public class ReservationRepository : Repository<Reservation>, IReservationRepository
{
    public ReservationRepository(ISession session)
        : base(session) { }
}
