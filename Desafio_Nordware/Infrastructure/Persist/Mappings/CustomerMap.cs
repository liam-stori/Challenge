using App.Core.Entities;
using App.Infrastructure.Persist.Mappings.Helpers;
using FluentNHibernate.Mapping;

namespace App.Infrastructure.Persist.Mappings;

public class CustomerMap : ClassMap<Customer>
{
    public CustomerMap()
    {
        Id(x => x.Id).GeneratedBy
            .Sequence($"{TableNames.Customer}_id_seq");

        Map(x => x.Name, ColumnNames.Name)
            .Length(150)
            .Not.Nullable();

        Map(x => x.Email, ColumnNames.Email)
            .Length(100)
            .Not.Nullable();

        Map(x => x.Document, ColumnNames.Document)
            .Length(25)
            .Not.Nullable();

        Map(x => x.Address, ColumnNames.Address)
            .Length(250)
            .Not.Nullable();

        HasMany(x => x.Reservations)
            .Access.CamelCaseField(Prefix.Underscore)
            .KeyColumn(ColumnNames.IdCustomer)
            .ForeignKeyConstraintName($"CR_FK_{ColumnNames.IdCustomer}")
            .Inverse()
            .Cascade.AllDeleteOrphan();

        Table(TableNames.Customer);
    }
}
