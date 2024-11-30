using App.Core.Entities;
using App.Infrastructure.Persist.Mappings.Helpers;
using FluentNHibernate.Mapping;

namespace App.Infrastructure.Persist.Mappings;

public class ProductMap : ClassMap<Product>
{
    public ProductMap()
    {
        Id(x => x.Id).GeneratedBy
            .Sequence($"{TableNames.Product}_id_seq");

        Map(x => x.Name, ColumnNames.Name)
            .Length(75)
            .Not.Nullable();

        Map(x => x.Category, ColumnNames.Category)
            .Length(100)
            .Not.Nullable();

        Map(x => x.Description, ColumnNames.Description)
            .Length(250)
            .Not.Nullable();

        Map(x => x.Price, ColumnNames.Price)
            .Not.Nullable();

        Map(x => x.Quantity, ColumnNames.Quantity)
            .Not.Nullable();

        References(x => x.Status, ColumnNames.IdStatus)
            .ForeignKey($"P_FK_{ColumnNames.IdStatus}")
            .Not.Nullable()
            .Index($"idx_p_{ColumnNames.IdStatus}");

        Table(TableNames.Product);
    }
}
