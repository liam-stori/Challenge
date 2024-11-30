using App.Core.Enumerators;

namespace App.Core.Entities;

public class ReservationStatus : EntityBase
{
    protected ReservationStatus() {  }

    public ReservationStatus(ReservationStatusEnum id) : this()
    {
        if (!Enum.IsDefined(typeof(ReservationStatusEnum), id))
            throw new ArgumentOutOfRangeException(nameof(id), "The ID is not set to a reservation status.");

        Id = (short)id;
    }

    public ReservationStatus(ReservationStatusEnum id, 
        string name) : this(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        
        Name = name;
    }

    public virtual string Name { get; protected set; } = default!;

    public virtual bool IsReserved()
    {
        return Id == (short)ReservationStatusEnum.Reserved;
    }

    public virtual bool IsExpired()
    {
        return Id == (short)ReservationStatusEnum.Expired;
    }

    public virtual bool IsCanceled()
    {
        return Id == (short)ReservationStatusEnum.Canceled;
    }
}
