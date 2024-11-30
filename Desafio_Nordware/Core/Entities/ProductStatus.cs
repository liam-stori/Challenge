using App.Core.Enumerators;

namespace App.Core.Entities;

public class ProductStatus : EntityBase
{
    protected ProductStatus() { }

    public ProductStatus(ProductStatusEnum id) : this()
    {
        if (!Enum.IsDefined(typeof(ProductStatusEnum), id))
            throw new ArgumentOutOfRangeException(nameof(id), "The ID is not set to a product status.");

        Id = (short)id;
    }

    public ProductStatus(ProductStatusEnum id,
        string name) : this(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
    }

    public virtual string Name { get; protected set; } = default!;

    public virtual bool IsAvaliable()
    {
        return Id == (short)ProductStatusEnum.Avaliable;
    }

    public virtual bool IsTemporarilyUnavailable()
    {
        return Id == (short)ProductStatusEnum.TemporarilyUnavailable;
    }

    public virtual bool IsHighDemand()
    {
        return Id == (short)ProductStatusEnum.HighDemand;
    }
}
