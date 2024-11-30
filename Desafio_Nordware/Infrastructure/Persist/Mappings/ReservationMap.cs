using App.Core.Entities;
using App.Infrastructure.Persist.Mappings.Helpers;
using FluentNHibernate.Mapping;

namespace App.Infrastructure.Persist.Mappings;

public class ReservationMap : ClassMap<Reservation>
{
    public ReservationMap()
    {
        Id(x => x.Id).GeneratedBy
            .Sequence($"{TableNames.Reservation}_id_seq");

        Map(x => x.Quantity, ColumnNames.Quantity)
            .Not.Nullable();

        Map(x => x.ReservedAt, ColumnNames.ReservedAt)
            .Not.Nullable();

        Map(x => x.ExpiredAt, ColumnNames.ExpiredAt);

        Map(x => x.CanceledAt, ColumnNames.CanceledAt);

        References(x => x.Status, ColumnNames.IdStatus)
            .ForeignKey($"R_FK_{ColumnNames.IdStatus}")
            .Not.Nullable()
            .Index($"idx_r_{ColumnNames.IdStatus}");

        References(x => x.Customer, ColumnNames.IdCustomer)
            .ForeignKey($"R_FK_{ColumnNames.IdCustomer}")
            .Not.Nullable()
            .Index($"idx_r_{ColumnNames.IdCustomer}");

        References(x => x.Product, ColumnNames.IdProduct)
            .ForeignKey($"R_FK_{ColumnNames.IdProduct}")
            .Not.Nullable()
            .Index($"idx_r_{ColumnNames.IdProduct}");

        Table(TableNames.Reservation);
    }
}
