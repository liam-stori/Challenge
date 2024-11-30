using App.Core.Entities;
using App.Infrastructure.Persist.Mappings.Helpers;
using FluentNHibernate.Mapping;

namespace App.Infrastructure.Persist.Mappings;

public class ReservationStatusMap : ClassMap<ReservationStatus>
{
    public ReservationStatusMap()
    {
        Id(x => x.Id).GeneratedBy
            .Sequence($"{TableNames.ReservationStatus}_id_seq");

        Map(x => x.Name, ColumnNames.Name)
            .Length(50)
            .Not.Nullable();

        Table(TableNames.ReservationStatus);
    }
}
