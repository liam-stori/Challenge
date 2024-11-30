using App.Core.Enumerators;

namespace App.Core.Entities;

public class Reservation : EntityBase
{
    protected Reservation() { }

    public Reservation(Product product, Customer customer) : this()
    {
        Product = product;
        Customer = customer;
        Quantity = 1;
        ReservedAt = DateTime.Now;
        Status = new ReservationStatus(ReservationStatusEnum.Reserved);
    }

    public virtual Product Product { get; protected set; } = default!;
    public virtual Customer Customer { get; protected set; } = default!;
    public virtual int Quantity { get; protected set; } = default!;
    public virtual DateTime ReservedAt { get; protected set; } = default!;
    public virtual DateTime? ExpiredAt { get; protected set; } = default!;
    public virtual DateTime? CanceledAt { get; protected set; } = default!;
    public virtual ReservationStatus Status { get; protected set; } = default!;

    public virtual bool IsExpired()
    {
        return DateTime.Now > ReservedAt.AddDays(3);
    }

    public virtual bool IsReserved()
    {
        return Status.IsReserved();
    }

    public virtual void Expire()
    {
        Status = new ReservationStatus(ReservationStatusEnum.Expired);
        ExpiredAt = DateTime.Now;
    }

    public virtual void Cancel()
    {
        Status = new ReservationStatus(ReservationStatusEnum.Canceled);
        CanceledAt = DateTime.Now;
    }

    public virtual void AddQuantity()
    {
        Quantity += 1;
    }

    public virtual void RestartQuantity()
    {
        Quantity = 1;
    }
}
