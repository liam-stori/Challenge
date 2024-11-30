using App.Core.Entities;
using App.Infrastructure.Persist.Mappings.Helpers;
using FluentNHibernate.Mapping;

namespace App.Infrastructure.Persist.Mappings;

public class ProductMapStatus : ClassMap<ProductStatus>
{
    public ProductMapStatus()
    {
        Id(x => x.Id).GeneratedBy
            .Sequence($"{TableNames.ProductStatus}_id_seq");

        Map(x => x.Name, ColumnNames.Name)
            .Length(50)
            .Not.Nullable();

        Table(TableNames.ProductStatus);
    }
}
