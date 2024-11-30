namespace App.Core.Entities;

public class Customer : EntityBase
{
    private readonly IList<Reservation> _reservations = [];

    protected Customer() { }

    public Customer(string name, string email, 
        string document, string address) : this()
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException(nameof(email));

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentNullException(nameof(document));

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentNullException(nameof(address));

        Name = name;
        Email = email;
        Document = document;
        Address = address;
    }

    public virtual string Name { get; protected set; } = default!;
    public virtual string Email { get; protected set; } = default!;
    public virtual string Document { get; protected set; } = default!;
    public virtual string Address { get; protected set; } = default!;
    public virtual IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public virtual void AddReservation(Reservation reservation)
    {
        if (reservation == null) 
            throw new ArgumentNullException(nameof(reservation));

        _reservations.Add(reservation);
    }
}
