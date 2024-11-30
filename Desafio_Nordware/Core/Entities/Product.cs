using App.Core.Enumerators;

namespace App.Core.Entities;

public class Product : EntityBase
{
    protected Product() { }

    public Product(string name, string category, string description,
        decimal price, int quantity, ProductStatus status) : this()
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentNullException(nameof(category));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException(nameof(description));

        Name = name;
        Category = category;
        Description = description;
        Price = price;
        Quantity = quantity;
        Status = status;
    }

    public virtual string Name { get; protected set; } = default!;
    public virtual string Category { get; protected set; } = default!;
    public virtual string Description { get; protected set; } = default!;
    public virtual decimal Price { get; protected set; } = default!;
    public virtual int Quantity { get; protected set; } = default!;
    public virtual ProductStatus Status { get; protected set; } = default!;

    public virtual bool IsAvaliable()
    {
        return Status.IsAvaliable();
    }

    public virtual bool IsTemporarilyUnavailable()
    {
        return Status.IsTemporarilyUnavailable();
    }

    public virtual bool CanBeReserved()
    {
        return Status.IsAvaliable()
            || Status.IsTemporarilyUnavailable()
            || (Status.IsHighDemand() && Quantity > 0);
    }

    public virtual void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public virtual void RemoveQuantity(int quantity)
    {
        Quantity -= quantity;
    }

    public virtual void DefineTemporarilyUnavailable()
    {
        Status = new ProductStatus(ProductStatusEnum.TemporarilyUnavailable);
    }
}
